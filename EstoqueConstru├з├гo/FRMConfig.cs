using MySql.Data.MySqlClient;
using MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Estoque_Material_Construção
{
    public partial class FRMConfig : Form
    {
        public FRMConfig()
        {
            InitializeComponent();
        }

        public FRMConfig(MySqlCommand cmd)
        {
            this.cmd = cmd;
        }

        ConexaoBD conexao = new ConexaoBD();
        private MySqlCommand cmd;

        private void BTNGerar_Click(object sender, EventArgs e)
        {
            BackupBanco();
            ZiparCopias();
        }

        public void ZiparCopias()
        {
            string arquivoA = "Config_Marca.xml";
            string arquivoB = "Config_Categoria.xml";
            string sourcePath = Directory.GetCurrentDirectory();
            string targetPath = Directory.GetCurrentDirectory() + "\\Backup";

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            string sourceFile = System.IO.Path.Combine(sourcePath, arquivoA);
            string destFile = System.IO.Path.Combine(targetPath, arquivoA);
            string sourceFile2 = System.IO.Path.Combine(sourcePath, arquivoB);
            string destFile2 = System.IO.Path.Combine(targetPath, arquivoB);

            System.IO.File.Copy(sourceFile, destFile, true);
            System.IO.File.Copy(sourceFile2, destFile2, true);

            string startPath = Directory.GetCurrentDirectory() + "//Backup";
            FBDBackup.ShowDialog();
            string zipPath = FBDBackup.SelectedPath + "//BackupSistema.zip";
            if(System.IO.File.Exists(FBDBackup.SelectedPath + "//BackupSistema.zip") == true)
            {
                System.IO.File.Delete(FBDBackup.SelectedPath + "//BackupSistema.zip");
            }
            ZipFile.CreateFromDirectory(startPath, zipPath);
            MessageBox.Show("Operação completada com sucesso.");
        }

        public void BackupBanco()
        {
            string constring = "server=localhost;user=root;pwd=samsung123;database=construcao;";
            string file = Directory.GetCurrentDirectory()  + "//Backup/ConstrucaoBackup.sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
        }

        public void RestaurarBanco()
        {
            FBDBackup.ShowDialog();
            string zipPath = FBDBackup.SelectedPath + "//BackupSistema.zip";
            string extractPath = Directory.GetCurrentDirectory();
            ZipFile.ExtractToDirectory(zipPath, extractPath);
            string constring = "server=localhost;user=root;pwd=samsung123;database=construcao;";
            string file = FBDBackup.SelectedPath  + "//ConstrucaoBackup.sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(file);
                        conn.Close();
                    }
                }
            }
            try
            {
                System.IO.File.Delete(Directory.GetCurrentDirectory()  + "//ConstrucaoBackup.sql");
                MessageBox.Show("Operação completada com sucesso.");
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Aruivo em uso no momento.", e.ToString());
                return;
            }
        }

        private void ExportToFile(string file)
        {
            throw new NotImplementedException();
        }

        private void BTNImportar_Click(object sender, EventArgs e)
        {
            RestaurarBanco();
        }

        private void BTNVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

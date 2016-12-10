using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque_Material_Construção
{
    public partial class FRMAvisoProdutos : Form
    {
        ConexaoBD banco = new ConexaoBD();
        FRMFuncionario funcionario = new FRMFuncionario();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlCommand comandoQuery = new MySqlCommand();
        private MySqlCommand comandoVerificacao = new MySqlCommand();
        private MySqlDataReader leitor;
        private int controle;
        ToolTip MytoolTip = new ToolTip();

        public int Controle
        {
            get
            {
                return controle;
            }

            set
            {
                controle = value;
            }
        }

        public FRMAvisoProdutos()
        {
            InitializeComponent();
            DGVFaltas.Columns.Add("Codigo", "Código");
            DGVFaltas.Columns.Add("Nome", "Nome");
            DGVFaltas.Columns.Add("Fornecedor", "Fornecedor");
            DGVFaltas.Columns.Add("Categoria", "Categoria");
            DGVFaltas.Columns.Add("Quantidade", "Atual");
            DGVFaltas.Columns.Add("Minimo", "Mínimo");
            Controle = produtos_Falta(banco.AbrirConexao());
        }

        private void FRMPesquisaResultado_Load(object sender, EventArgs e)
        {
            
        }

        public int produtos_Falta(MySqlConnection Conn)
        {
            Conn.Open();
            int i = 0;
            int j = 0;
            int v = 0;
            comando.Connection = Conn;
            comandoQuery.Connection = Conn;
            comandoVerificacao.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT COUNT(*) FROM produtos";
                    comando.Prepare();
                    comandoQuery.Parameters.Clear();
                    comandoQuery.CommandText = "SELECT * FROM produtos WHERE estoque_atual < estoque_minimo ORDER BY nome DESC";
                    comandoQuery.Prepare();
                    j = int.Parse(comando.ExecuteScalar().ToString());
                    comandoVerificacao.Parameters.Clear();
                    comandoVerificacao.CommandText = "SELECT COUNT(*) FROM produtos WHERE estoque_atual < estoque_minimo";
                    comandoVerificacao.Prepare();
                    v = int.Parse(comandoVerificacao.ExecuteScalar().ToString());
                    leitor = comandoQuery.ExecuteReader();
                    for (i = 0; i < j; i++)
                    {
                        while (leitor.Read())
                        {
                            this.DGVFaltas.Rows.Insert(i, leitor.GetString("codigo"), leitor.GetString("nome"), leitor.GetString("fornecedor"), leitor.GetString("categoria"), leitor.GetString("estoque_atual"), leitor.GetString("estoque_minimo"));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " " + ex.Message);
                }
                finally
                {
                    if (leitor != null)
                    {
                        leitor.Close();
                    }
                    if (Conn != null)
                    {
                        Conn.Close();
                    }
                }
            }
            if (v > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void BTNSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNSair_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNSair, "Ir para tela principal do sistema.");
        }
    }
}

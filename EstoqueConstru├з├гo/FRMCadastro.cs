using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Windows.Forms;

namespace Estoque_Material_Construção
{
    public partial class FRMCadastro : Form
    {
        string valor_Formulario;
        ToolTip MytoolTip = new ToolTip();
        public FRMCadastro(string Valor_Form)
        {
            InitializeComponent();
            label1.Text = Valor_Form;
            this.Text = Valor_Form;
            valor_Formulario = Valor_Form;
        }

        private void BTNSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNInserir_Click(object sender, EventArgs e)
        {
                if (valor_Formulario == "Categoria")
            {
                if (File.Exists("Config_Categoria.xml") == true)
                {
                    XmlTextReader leitor_categoria = new XmlTextReader("Config_Categoria.xml");
                    XmlDocument categoria = new XmlDocument();
                    categoria.Load(leitor_categoria);
                    leitor_categoria.Close();
                    XmlElement nome = categoria.CreateElement("Nome");
                    nome.InnerText = TXTCatMar.Text;
                    categoria.DocumentElement.AppendChild(nome);
                    categoria.Save("Config_Categoria.xml");
                }
                else
                {
                    using (XmlWriter criar_Xml = XmlWriter.Create("Config_Categoria.xml"))
                    {
                        criar_Xml.WriteStartDocument();
                        criar_Xml.WriteStartElement("Categorias");
                        criar_Xml.WriteElementString("Nome", TXTCatMar.Text);
                        criar_Xml.WriteEndElement();
                        criar_Xml.WriteEndDocument();
                    }
                }
            }
                if(valor_Formulario == "Marca")
            {
                if (File.Exists("Config_Marca.xml") == true)
                {
                    XmlTextReader leitor_categoria = new XmlTextReader("Config_Marca.xml");
                    XmlDocument categoria = new XmlDocument();
                    categoria.Load(leitor_categoria);
                    leitor_categoria.Close();
                    XmlElement nome = categoria.CreateElement("Valor");
                    nome.InnerText = TXTCatMar.Text;
                    categoria.DocumentElement.AppendChild(nome);
                    categoria.Save("Config_Marca.xml");
                }
                else
                {
                    using (XmlWriter criar_Xml = XmlWriter.Create("Config_Marca.xml"))
                    {
                        criar_Xml.WriteStartDocument();
                        criar_Xml.WriteStartElement("Marcas");
                        criar_Xml.WriteElementString("Valor", TXTCatMar.Text);
                        criar_Xml.WriteEndElement();
                        criar_Xml.WriteEndDocument();
                    }
                }
            }
            limpar();
        }

        private void BTNInserir_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNInserir, "Inserir Nova " + valor_Formulario);
        }

        private void BTNSair_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNSair, "Sair");
        }
        public void limpar()
        {
            TXTCatMar.Text = null;
        }
    }
}

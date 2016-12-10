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
    public partial class FRMOrcamento : Form
    {
        public FRMOrcamento(string nome)
        {
            InitializeComponent();
            TXTVendedor.Text = nome;
        }
        DateTime Data = DateTime.Now;
        ToolTip MytoolTip = new ToolTip();
        double total_Grid;
        string codigo_produto, nome, marca, valor, quantidade;
        ConexaoBD BDClass = new ConexaoBD();
        Variaveis variaveis = new Variaveis();
        protected string permissao = "";
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;

        private void BTNImprimir_Click(object sender, EventArgs e)
        {
            if(RDBPrazo.Checked == false && RDBVista.Checked == false)
            {
                LBLTipoVenda.Visible = true;
            }
            else
            {
                LBLTipoVenda.Visible = false;
                PSDOrcamento.AllowOrientation = true;
                PSDOrcamento.AllowPaper = true;
                PSDOrcamento.AllowPrinter = true;
                PSDOrcamento.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                if (PSDOrcamento.ShowDialog().Equals(DialogResult.OK))
                {
                    PPDOrcamento.ShowDialog();
                }
            }
        }

        private void BTNAdicionar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(codigo_produto);
            DataGridViewRow linhaP = (DataGridViewRow)DGVProdutos.Rows[0].Clone();
            linhaP.Cells[0].Value = codigo_produto;
            linhaP.Cells[1].Value = nome;
            linhaP.Cells[2].Value = TXTQuantidade.Text;
            linhaP.Cells[3].Value = valor;
            linhaP.Cells[4].Value = marca;
            DGVProdutos.Rows.Add(linhaP);
            TXTNome_Produto.Text = "";
            TXTProduto.Text = "";
            TXTQuantidade.Text = "";
        }

        private void FRMOrcamento_Load(object sender, EventArgs e)
        {
            TXTData.Text = Data.ToString("dd/MM/yy");
        }

        private void RDBVista_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void RDBPrazo_CheckedChanged(object sender, EventArgs e)
        {
            TXTNumero_Parcelas.Enabled = true;
        }

        private void TXTValorItems_Leave(object sender, EventArgs e)
        {
            if(TXTValorItems.Text == "")
            {
                LBLValorItems.Visible = true;
                TXTValorItems.Focus();
            }
            else
            {
                LBLValorItems.Visible = false;
            }
        }

        private void BTNLimpar_Click(object sender, EventArgs e)
        {
            TXTNome_Produto.Text = null;
            TXTDesconto.Text = null;
            TXTCliente.Text = null;
            TXTNumero_Parcelas.Text = null;
            TXTProduto.Text = null;
            TXTQuantidade.Text = null;
            TXTTotal.Text = null;
            TXTValorItems.Text = null;
            TXTValor_Parcela.Text = null;
            DGVProdutos.Rows.Clear();
            RDBPrazo.Checked = false;
            RDBVista.Checked = false;
        }

        private void TXTValorItems_Enter(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < (DGVProdutos.RowCount - 1); i++)
            {
                total_Grid = (double.Parse(DGVProdutos.Rows[i].Cells[3].Value.ToString()) * double.Parse(DGVProdutos.Rows[i].Cells[2].Value.ToString())) + total_Grid;
                //quantidade_Grid = 1;//double.Parse(DGVProdutos.Rows[i].Cells[2].Value.ToString());
            }
            TXTValorItems.Text = string.Format("{0:C}", Convert.ToDouble(total_Grid));
        }

        private void TXTDesconto_Leave(object sender, EventArgs e)
        {
            if(TXTDesconto.Text == "")
            {
                LBLDesconto.Visible = true;
                TXTDesconto.Focus();
            }
            else
            {
                LBLDesconto.Visible = false;
            }
            double valor_total = Convert.ToDouble((total_Grid) - ((total_Grid) * double.Parse(TXTDesconto.Text) / 100));
            TXTTotal.Text = string.Format("{0:C}", valor_total);
        }

        private void TXTNumero_Parcelas_Leave(object sender, EventArgs e)
        {
            if(TXTNumero_Parcelas.Text == "")
            {
                LBLNumeroParcelas.Visible = true;
                TXTNumero_Parcelas.Focus();
            }
            else
            {
                LBLNumeroParcelas.Visible = false;
            }
            TXTValor_Parcela.Text  = string.Format("{0:C}", (double.Parse(TXTTotal.Text.Replace("R", "").Replace("$","")) / double.Parse(TXTNumero_Parcelas.Text)));
        }

        private void TXTCliente_Leave(object sender, EventArgs e)
        {
            if(TXTCliente.Text == "")
            {
                LBLCliente.Visible = true;
                TXTCliente.Focus();
            }
            else
            {
                LBLCliente.Visible = false;
            }
        }

        private void TXTQuantidade_Leave(object sender, EventArgs e)
        {
            if(TXTQuantidade.Text == "")
            {
                LBLQuantidade.Visible = true;
                TXTQuantidade.Focus();
            }
            else
            {
                LBLQuantidade.Visible = false;
            }
        }

        private void TXTProduto_Leave(object sender, EventArgs e)
        {
            if(TXTProduto.Text == "")
            {
                LBLProduto.Visible = true;
                TXTProduto.Focus();
            }
            else
            {
                LBLProduto.Visible = false;
            }
        }

        private void BTNImprimir_Leave(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNImprimir, "Imprimir orçamento");
        }

        private void BTNLimpar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNLimpar, "Limpar campos");
        }

        private void BTNVoltar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNVoltar, "Voltar para tela principal");
        }

        private void BTNPesquisar_Click(object sender, EventArgs e)
        {
            PesquisarProdutos_Nome(BDClass.AbrirConexao(), TXTProduto.Text);
            TXTQuantidade.Text = quantidade;
        }

        private void BTNVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PDOrcamento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.PageBounds {0, 10, 10, 10 };
            /*
             try
            {
                PDOrcamento.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
                PDOrcamento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PDOrcamento_PrintPage);
                PDOrcamento.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro ocorreu ao ao imprimir.", ex.ToString());
            }
             */

            string[,] myList = new string[DGVProdutos.ColumnCount, DGVProdutos.RowCount];
            string testando = null;
            Image Logo = Image.FromFile("C:/Users/Gian Luca/OneDrive/Documentos/Visual Studio 2015/Projects/EstoqueConstrução/EstoqueConstrução/Resources/LOGO.png");
            Font fonteA = new Font("Arial", 25, FontStyle.Regular, GraphicsUnit.Pixel);
            Font fonteB = new Font("Times New Roman", 25, FontStyle.Regular, GraphicsUnit.Pixel);
            Font fonteC = new Font("Arial", 15, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush caneta = new SolidBrush(Color.Black);
            Pen pincel = new Pen(Color.Black);
            float x = 10.0F;
            float y = 10.0F;
            float width = 400.0F;
            float height = 1000.0F;
            //RectangleF foreground = new RectangleF(x, y, width, height);
            e.Graphics.DrawRectangle(pincel, x, y, width, height);
            e.Graphics.DrawString("Data: ", fonteA, caneta, 10, 10);
            e.Graphics.DrawString(TXTData.Text, fonteB, caneta, 70, 10);
            e.Graphics.DrawString("Validade: ", fonteA, caneta, 195, 10);
            e.Graphics.DrawString((Data.AddDays(3).ToString("dd/MM/yy")), fonteB, caneta, 305, 10);
            e.Graphics.DrawLine(pincel, 10, 40, 410, 40);//Horizontal
            e.Graphics.DrawString("Cliente: ", fonteA, caneta, 10, 50);
            e.Graphics.DrawString(TXTCliente.Text, fonteB, caneta, 100, 50);
            e.Graphics.DrawLine(pincel, 10, 80, 410, 80);//Horizontal
            e.Graphics.DrawString("Vendedor: ", fonteA, caneta, 10, 90);
            e.Graphics.DrawString(TXTVendedor.Text, fonteB, caneta, 130, 90);
            e.Graphics.DrawLine(pincel, 10, 120, 410, 120);//Horizontal
            e.Graphics.DrawString("Produto", fonteA, caneta, 10, 130);
            e.Graphics.DrawLine(pincel, 140, 120, 140, 600);//Vertical
            e.Graphics.DrawString("Quant.", fonteA, caneta, 140, 130);
            e.Graphics.DrawLine(pincel, 230, 120, 230, 600);//Vertical
            e.Graphics.DrawString("Marca", fonteA, caneta, 230, 130);
            e.Graphics.DrawLine(pincel, 320, 120, 320, 565);//Vertical
            e.Graphics.DrawString("R$", fonteA, caneta, 320, 130);
            e.Graphics.DrawLine(pincel, 10, 160, 410, 160);//Horizontal
            //draw do datagrid aqui
            float heightProd = 160;
            for (int i = 0; i < DGVProdutos.RowCount - 1; i++) //percorre as linhas 
            {
                for (int a = 0; a < DGVProdutos.ColumnCount; a++) // percorre as colunas
                {
                    if (DGVProdutos[a, i].Value != null)
                    {
                        myList[a, i] = DGVProdutos[a, i].Value.ToString();
                        testando = myList[a, i] + "#" + testando;
                    }
                }
                if (myList[0, i].Count() == 2)
                {
                    e.Graphics.DrawString(myList[1, i], fonteC, caneta, 10, heightProd);
                    e.Graphics.DrawString(myList[2, i], fonteC, caneta, 145, heightProd);
                    e.Graphics.DrawString(myList[3, i], fonteC, caneta, 235, heightProd);
                    e.Graphics.DrawString(myList[4, i], fonteC, caneta, 325, heightProd);
                    valor = valor + myList[3, i];
                    MessageBox.Show(valor);
                    e.Graphics.DrawString(valor, fonteC, caneta, 325, 570);
                }
                else
                {
                    e.Graphics.DrawString(myList[1, i], fonteC, caneta, 10, heightProd);
                    e.Graphics.DrawString(myList[2, i], fonteC, caneta, 145, heightProd);
                    e.Graphics.DrawString(myList[3, i], fonteC, caneta, 235, heightProd);
                    e.Graphics.DrawString(myList[4, i], fonteC, caneta, 325, heightProd);
                }
                heightProd = heightProd + 15;
            }
            //
            e.Graphics.DrawLine(pincel, 10, 565, 410, 565);//Horizontal
            e.Graphics.DrawString("Total = ", fonteA, caneta, 230, 570);
            e.Graphics.DrawLine(pincel, 10, 600, 410, 600);//Horizontal
            //Draw do total aqui
            e.Graphics.DrawString("Tipo de venda: ", fonteA, caneta, 10, 610);
            if(RDBPrazo.Checked == true)
            {
                e.Graphics.DrawString("À Prazo", fonteB, caneta, 190, 610);
            }
            else
            {
                if(RDBVista.Checked == true)
                {
                    e.Graphics.DrawString("À Vista", fonteB, caneta, 190, 610);
                }
            }
            e.Graphics.DrawString("Valor dos Items: ", fonteA, caneta, 10, 650);
            e.Graphics.DrawString(TXTValorItems.Text, fonteB, caneta, 200, 650);
            e.Graphics.DrawString("Desconto: ", fonteA, caneta, 10, 690);
            e.Graphics.DrawString(TXTDesconto.Text, fonteB, caneta, 200, 690);
            e.Graphics.DrawString("Valor total: ", fonteA, caneta, 10, 730);
            e.Graphics.DrawString(TXTTotal.Text, fonteB, caneta, 200, 730);
            e.Graphics.DrawLine(pincel, 10, 760, 410, 760);//Horizontal
            e.Graphics.DrawImage(Logo, 10, 750, width, 200);
            e.Graphics.DrawLine(pincel, 100, 980, 300, 980);//Horizontal
            e.Graphics.DrawString("Assinatura do Vendedor", fonteC, caneta, 120, 985);
        }

        public void PesquisarProdutos_Nome(MySqlConnection Conn, string codigo)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT * FROM produtos WHERE nome = @codigo";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        if (leitor.GetString("estoque_atual") != "0")
                        {
                            TXTNome_Produto.Text = leitor.GetString("nome");
                            codigo_produto = leitor.GetString("codigo");
                            nome = leitor.GetString("nome");
                            quantidade = leitor.GetString("estoque_atual");
                            valor = leitor.GetString("preco_final");
                            marca = leitor.GetString("marca");
                        }
                        else
                        {
                            MessageBox.Show("Produto fora de estoque.");
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
        }
    }
}

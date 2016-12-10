using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque_Material_Construção
{
    public partial class FRMVendas : Form
    {
        public FRMVendas(string nome)
        {
            InitializeComponent();
            TXTVendedor.Text = nome;
            TControl.TabPages.Remove(TPTrocas);
            TControl.TabPages.Remove(TPDevolucao);
        }
        ToolTip MytoolTip = new ToolTip();
        int codigo_venda = 0;
        double total_Grid = 0;
        double desconto_Grid = 0;
        double quantidade_Grid = 0;
        double resultado_local = 0;
        string codigo_produto, nome, marca, valor, quantidade;
        ConexaoBD BDClass = new ConexaoBD();
        Variaveis variaveis = new Variaveis();
        protected string permissao = "";
        private MySqlCommand comando = new MySqlCommand();
        private MySqlCommand comandoP = new MySqlCommand();
        private MySqlCommand comandoAuxiliar = new MySqlCommand();
        private MySqlCommand comandoAuxiliarDev = new MySqlCommand();
        private MySqlDataReader leitor;
        protected bool tipo_Codigo = false;
        double valor_pago = 0;

        private void FRMVendas_Load(object sender, EventArgs e)
        {
            //TControl.TabPages.Remove(TPTrocas);
            //MessageBox.Show("a");
            //TControl.TabPages.Add(TPTrocas);
            DGVProdutos_Troca.ReadOnly = false;
            DateTime Data = DateTime.Now;
            TXTData.Text = Data.ToString("dd/MM/yyyy");
            TXTData_Devolucao.Text = Data.ToString("dd/MM/yyyy");
            TXTData_Troca.Text = Data.ToString("dd/MM/yyyy");
            //select goes here
            if(PesquisarCodigo(BDClass.AbrirConexao()) == null)
            {
                codigo_venda = codigo_venda + 1;
            }
            else
            {
                codigo_venda = codigo_venda + int.Parse(PesquisarCodigo(BDClass.AbrirConexao()));
            }
            TXTCodigo_Venda.Text = codigo_venda.ToString();
        }

        private void BTNVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void BTNPesquisar_Produto_Click(object sender, EventArgs e)
        {
            PesquisarProdutos_Nome(BDClass.AbrirConexao(), TXTProduto.Text);
            TXTQuantidade.Text = quantidade;
        }

        private void RDBPrazo_CheckedChanged(object sender, EventArgs e)
        {
            TXTNumero_Parcelas.Enabled = true;
            TXTValor_Pago.Enabled = false;
            TXTTroco.Enabled = false;
            int i;
            for (i = 0; i < (DGVProdutos.RowCount - 1); i ++)
            {
                total_Grid = (double.Parse(DGVProdutos.Rows[i].Cells[3].Value.ToString()) * double.Parse(DGVProdutos.Rows[i].Cells[2].Value.ToString())) + total_Grid;
                desconto_Grid = double.Parse(DGVProdutos.Rows[i].Cells[4].Value.ToString()) + desconto_Grid;
                quantidade_Grid = 1;
            }
            TXTValor_Items.Text = string.Format("{0:C}", Convert.ToDouble(total_Grid));
            TXTValor_Desconto.Text = string.Format("{0:P}", desconto_Grid/100);
            TXTValor_Total.Text = string.Format("{0:C}", Convert.ToDouble((total_Grid * quantidade_Grid) - ((total_Grid * quantidade_Grid) * desconto_Grid / 100)));
        }

        private void RDBVista_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < (DGVProdutos.RowCount - 1); i++)
            {
                total_Grid = (double.Parse(DGVProdutos.Rows[i].Cells[3].Value.ToString()) * double.Parse(DGVProdutos.Rows[i].Cells[2].Value.ToString())) + total_Grid;
                desconto_Grid = double.Parse(DGVProdutos.Rows[i].Cells[4].Value.ToString()) + desconto_Grid;
                quantidade_Grid = 1;
            }
            TXTValor_Items.Text = string.Format("{0:C}", Convert.ToDouble(total_Grid * quantidade_Grid));
            TXTValor_Desconto.Text = string.Format("{0:P}", Convert.ToDouble(desconto_Grid)/100);
            TXTValor_Total.Text = string.Format("{0:C}", Convert.ToDouble((total_Grid * quantidade_Grid) - ((total_Grid * quantidade_Grid) * desconto_Grid / 100)));
        }

        private void TXTValor_Pago_Leave(object sender, EventArgs e)
        {
            if(TXTValor_Pago.Text == "")
            {
                LBLValorPago.Visible = true;
                TXTValor_Pago.Focus();
            }
            else
            {
                LBLValorPago.Visible = false;
                valor_pago = double.Parse(TXTValor_Pago.Text);
                resultado_local = valor_pago - Convert.ToDouble((total_Grid * quantidade_Grid) - ((total_Grid * quantidade_Grid) * desconto_Grid / 100));
                TXTTroco.Text = string.Format("{0:C}", Convert.ToDouble(resultado_local));
            }
            
        }

        private void TXTValor_Desconto_Leave(object sender, EventArgs e)
        {
            //resultado_local = double.Parse(TXTValor_Items.Text) - double.Parse(TXTValor_Desconto.Text);
            //TXTValor_Total.Text = string.Format("{0:C}", Convert.ToDouble(resultado_local));
        }

        private void BTNSalvar_Click(object sender, EventArgs e)
        {
            variaveis.Codigo_Venda1 = TXTCodigo_Venda.Text;
            variaveis.Data_Venda1 = TXTData.Text;
            variaveis.Cliente_Venda1 = TXTCliente.Text;
            variaveis.CPF_Venda1 = MTXCpf.Text.Replace(",", "").Replace("-", "");
            variaveis.Vendedor_Venda1 = TXTVendedor.Text;
            if(RDBVista.Checked == true)
            {
                variaveis.Tipo_Venda1 = RDBVista.Text;
                variaveis.Valor_Parcela1 = "";
                variaveis.Numero_Parcela1 = "";
            }
            else
            {
                variaveis.Tipo_Venda1 = RDBPrazo.Text;
                variaveis.Valor_Parcela1 = TXTValor_Parcela.Text.Replace("R$","").Replace(",","").Trim();
                variaveis.Numero_Parcela1 = TXTNumero_Parcelas.Text;
            }
            variaveis.Valor_Itens1 = TXTValor_Items.Text.Replace("R$", "").Replace(",", "").Trim();
            variaveis.Desconto1 = TXTDesconto.Text.Replace("%", "").Replace(",", "").Trim();
            variaveis.Valor_Total1 = TXTValor_Total.Text.Replace("R$", "").Replace(",", "").Trim();
            variaveis.Valor_Pago1 = TXTValor_Pago.Text.Replace("R$", "").Replace(",", "").Trim();
            variaveis.Troco1 = TXTTroco.Text.Replace("R$", "").Replace(",", "").Trim();
            //InserirProdutos(BDClass.AbrirConexao(), variaveis.Codigo_Venda1, variaveis.Data_Venda1, variaveis.Cliente_Venda1, variaveis.CPF_Venda1, variaveis.Vendedor_Venda1, variaveis.Tipo_Venda1, variaveis.Valor_Parcela1, variaveis.Numero_Parcela1, variaveis.Valor_Itens1, variaveis.Desconto1, variaveis.Valor_Total1, variaveis.Valor_Pago1, variaveis.Troco1);
            if (PSDVendas.ShowDialog().Equals(DialogResult.OK))
            {
                PPDVendas.ShowDialog();
            }
        }

        public void limpar()
        {
            valor_pago = 0;
            total_Grid = 0;
            desconto_Grid = 0;
            quantidade_Grid = 0;
            resultado_local = 0;
            TXTCliente.Text = "";
            TXTData_Troca.Text = "";
            TXTCodigo_Venda.Text = "";
            TXTCod_Devolucao.Text = "";
            TXTCod_Troca.Text = "";
            TXTData.Text = "";
            TXTData_Devolucao.Text = "";
            TXTDesconto.Text = "";
            TXTNome_Produto.Text = "";
            TXTNumero_Parcelas.Text = "";
            TXTProduto.Text = "";
            TXTProduto_Devolucao.Text = "";
            TXTProduto_Troca.Text = "";
            TXTQuantidade.Text = "";
            TXTTroco.Text = "";
            TXTValor_Desconto.Text = null;
            TXTValor_Items.Text = null;
            TXTValor_Pago.Text = "";
            TXTValor_Parcela.Text = "";
            TXTValor_Total.Text = null;
            TXTVendedor.Text = "";
            MTXCpf.Text = "";
            DGVDevolucao_Produtos.Rows.Clear();
            DGVProdutos.Rows.Clear();
            DGVProdutos_Troca.Rows.Clear();
            RDBPrazo.Checked = false;
            RDBVista.Checked = false;
            codigo_venda = 0;
            if (PesquisarCodigo(BDClass.AbrirConexao()) == null)
            {
                codigo_venda = codigo_venda + 1;
            }
            else
            {
                codigo_venda = codigo_venda + int.Parse(PesquisarCodigo(BDClass.AbrirConexao()));
            }
            TXTCodigo_Venda.Text = codigo_venda.ToString();
        }

        private void TXTNumero_Parcelas_Leave(object sender, EventArgs e)
        {
            if(TXTNumero_Parcelas.Text == "")
            {
                LBLParcelas.Visible = true;
                TXTNumero_Parcelas.Focus();
            }
            else
            {
                LBLParcelas.Visible = false;
                double valor_total = Convert.ToDouble((total_Grid * quantidade_Grid) - ((total_Grid * quantidade_Grid) * desconto_Grid / 100));
                TXTValor_Parcela.Text = string.Format("{0:C}", (valor_total/ double.Parse(TXTNumero_Parcelas.Text)));
            }
        }

        private void BTNPesquisar_Click(object sender, EventArgs e)
        {
            string codigo = Microsoft.VisualBasic.Interaction.InputBox("Insira o código da Venda:", "Pesquisa", "");
                pesquisarVenda(BDClass.AbrirConexao(), codigo);
                TControl.TabPages.Add(TPTrocas);
                TControl.TabPages.Add(TPDevolucao);
                TXTNumero_Parcelas.Text = variaveis.Numero_Parcela1;
                TXTValor_Parcela.Text = string.Format("{0:C}", variaveis.Valor_Parcela1);
                TXTValor_Pago.Text = string.Format("{0:C}", variaveis.Valor_Pago1);
                TXTTroco.Text = string.Format("{0:C}", variaveis.Troco1);
                TXTValor_Items.Text = string.Format("{0:C}", variaveis.Valor_Itens1);
                TXTValor_Desconto.Text = string.Format("{0:C}", variaveis.Desconto1);
                TXTValor_Total.Text = string.Format("{0:C}", variaveis.Valor_Total1);
                TXTVendedor.Text = variaveis.Vendedor_Venda1;
                TXTCliente.Text = variaveis.Cliente_Venda1;
                MTXCpf.Text = variaveis.CPF_Venda1;
                TXTData.Text = variaveis.Data_Venda1;
                TXTCodigo_Venda.Text = variaveis.Codigo_Venda1;
                if (variaveis.Tipo_Venda1 == "À Prazo")
                {
                    RDBPrazo.Checked = true;
                }
                else
                {
                    RDBVista.Checked = true;
                }
                TXTCod_Devolucao.Text = variaveis.Codigo_Venda1;
                TXTCod_Troca.Text = variaveis.Codigo_Venda1;
        }

        public string PesquisarCodigo(MySqlConnection Conn)
        {
            string codigo_interno = null;
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT codigo FROM vendas";
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        codigo_interno = leitor.GetString("codigo");
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
            return codigo_interno;
        }

        private void BTNAdicionarProduto_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(codigo_produto);
            DataGridViewRow linhaP = linhaP = (DataGridViewRow)DGVProdutos.Rows[0].Clone();
            linhaP.Cells[0].Value = codigo_produto;
            linhaP.Cells[1].Value = nome;
            linhaP.Cells[2].Value = TXTQuantidade.Text;
            linhaP.Cells[3].Value = valor;
            linhaP.Cells[4].Value = TXTDesconto.Text;
            linhaP.Cells[5].Value = marca;
            DGVProdutos.Rows.Add(linhaP);
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
                        if(leitor.GetString("estoque_atual") != "0")
                        {
                            TXTNome_Produto.Text = leitor.GetString("nome");
                            codigo_produto = leitor.GetString("codigo");
                            nome = leitor.GetString("nome");
                            quantidade  = leitor.GetString("estoque_atual");
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
            tipo_Codigo = true;
        }

        public void InserirProdutos(MySqlConnection Conn, string codigo, string data, string cliente, string cpf, string vendedor, string tipo_venda, string valor_parcela, string numero_parcela, string valor_itens, string desconto, string valor_total, string valor_pago, string troco)
        {
            string[,] myList = new string[DGVProdutos.ColumnCount, DGVProdutos.RowCount];
            Conn.Open();
            comando.Connection = Conn;
            comandoAuxiliar.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "INSERT INTO vendas(Codigo, Data, Cliente, CPF, Vendedor, Tipo_Venda, Valor_Parcela, Numero_Parcela, Valor_Itens, Desconto, Valor_Total, Valor_Pago, Troco, dados_produtos) VALUES(@Codigo, @Data, @Cliente, @CPF, @Vendedor, @Tipo_Venda, @Valor_Parcela, @Numero_Parcela, @Valor_Itens, @Desconto, @Valor_Total, @Valor_Pago, @Troco, @dados_produtos)";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@Codigo", codigo);
                    comando.Parameters.AddWithValue("@Data", data);
                    comando.Parameters.AddWithValue("@Cliente", cliente);
                    comando.Parameters.AddWithValue("@CPF", cpf);
                    comando.Parameters.AddWithValue("@Vendedor", vendedor);
                    comando.Parameters.AddWithValue("@Tipo_Venda", tipo_venda);
                    comando.Parameters.AddWithValue("@Valor_Parcela", valor_parcela);
                    comando.Parameters.AddWithValue("@Numero_Parcela", numero_parcela);
                    comando.Parameters.AddWithValue("@Valor_Itens", valor_itens);
                    comando.Parameters.AddWithValue("@Desconto", desconto);
                    comando.Parameters.AddWithValue("@Valor_Total", valor_total);
                    comando.Parameters.AddWithValue("@Valor_Pago", valor_pago);
                    comando.Parameters.AddWithValue("@Troco", troco);
                    //string[] array = new string[];
                    string testando = null;
                    for (int i = 0; i < DGVProdutos.RowCount - 1; i++) //percorre as linhas 
                    {
                        for (int x = 0; x < DGVProdutos.ColumnCount; x++) // percorre as colunas
                        {
                            if (DGVProdutos[x, i].Value != null)
                            {
                                myList[x, i] = DGVProdutos[x, i].Value.ToString();
                                testando = myList[x, i] + "#" + testando;
                                //.Split('#');
                                //MessageBox.Show(array);
                                //comando.Parameters.AddWithValue("@dados_produtos", array.ToString());
                            }
                        }
                        if (myList[0, i].Count() == 2)
                        {
                            comandoAuxiliar.Parameters.Clear();
                            comandoAuxiliar.CommandText = "UPDATE PRODUTOS set Estoque_Atual = (SELECT estoque_atual WHERE codigo = @codigo) - @estoque_atual WHERE codigo = @codigo";
                            comandoAuxiliar.Prepare();
                            comandoAuxiliar.Parameters.AddWithValue("@Codigo", myList[0, i - 1]);
                            //MessageBox.Show(quantidade[1]);
                            comandoAuxiliar.Parameters.AddWithValue("@estoque_atual", int.Parse(DGVProdutos[2, i].Value.ToString()));
                            comandoAuxiliar.ExecuteNonQuery();
                        }
                        else
                        {
                            comandoAuxiliar.Parameters.Clear();
                            comandoAuxiliar.CommandText = "UPDATE PRODUTOS set Estoque_Atual = (SELECT estoque_atual WHERE codigo = @codigo) - @estoque_atual WHERE codigo = @codigo";
                            comandoAuxiliar.Prepare();
                            comandoAuxiliar.Parameters.AddWithValue("@Codigo", myList[0, i]);
                            //MessageBox.Show(quantidade[1]);
                            comandoAuxiliar.Parameters.AddWithValue("@estoque_atual", int.Parse(DGVProdutos[2, i].Value.ToString()));
                            comandoAuxiliar.ExecuteNonQuery();
                        }
                    }
                    var array = testando;
                    comando.Parameters.AddWithValue("@dados_produtos", array);
                    comando.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " " + ex.Message);
                }
                finally
                {
                    if (Conn != null)
                    {
                        Conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Nope");
            }
        }
        public void inserirTrocas(MySqlConnection Conn, string codigo, string data)
        {
            string[,] myList = new string[DGVProdutos_Troca.ColumnCount, DGVProdutos_Troca.RowCount];
            Conn.Open();
            comando.Connection = Conn;
            comandoAuxiliar.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "INSERT INTO trocas(Codigo, Data, dados_produtos, codigo_venda) VALUES(@Codigo, @Data, @dados_produtos, @codigo_venda)";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@Codigo", codigo);
                    comando.Parameters.AddWithValue("@Codigo_venda", codigo);
                    comando.Parameters.AddWithValue("@Data", data);
                    //string[] array = new string[];
                    string testando = null;
                    for (int i = 0; i < DGVProdutos_Troca.RowCount - 1; i++) //percorre as linhas 
                    {
                        for (int x = 0; x < DGVProdutos_Troca.ColumnCount; x++) // percorre as colunas
                        {
                            if (DGVProdutos_Troca[x, i].Value != null)
                            {
                                myList[x, i] = DGVProdutos_Troca[x, i].Value.ToString();
                                testando = myList[x, i] + "#" + testando;
                                //.Split('#');
                                //MessageBox.Show(array);
                                //comando.Parameters.AddWithValue("@dados_produtos", array.ToString());
                            }
                        }
                        if (myList[0, i].Count() == 2)
                        {
                            comandoAuxiliar.Parameters.Clear();
                            comandoAuxiliar.CommandText = "UPDATE PRODUTOS set Estoque_Atual = (SELECT estoque_atual WHERE codigo = @codigo) - @estoque_atual WHERE codigo = @codigo";
                            comandoAuxiliar.Prepare();
                            comandoAuxiliar.Parameters.AddWithValue("@Codigo", myList[0, i - 1]);
                            //MessageBox.Show(quantidade[1]);
                            comandoAuxiliar.Parameters.AddWithValue("@estoque_atual", int.Parse(DGVProdutos_Troca[2, i].Value.ToString()));
                            comandoAuxiliar.ExecuteNonQuery();
                        }
                        else
                        {
                            comandoAuxiliar.Parameters.Clear();
                            comandoAuxiliar.CommandText = "UPDATE PRODUTOS set Estoque_Atual = (SELECT estoque_atual WHERE codigo = @codigo) - @estoque_atual WHERE codigo = @codigo";
                            comandoAuxiliar.Prepare();
                            comandoAuxiliar.Parameters.AddWithValue("@Codigo", myList[0, i]);
                            //MessageBox.Show(quantidade[1]);
                            comandoAuxiliar.Parameters.AddWithValue("@estoque_atual", int.Parse(DGVProdutos_Troca[2, i].Value.ToString()));
                            comandoAuxiliar.ExecuteNonQuery();
                        }
                    }
                    var array = testando;
                    comando.Parameters.AddWithValue("@dados_produtos", array);
                    comando.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " " + ex.Message);
                }
                finally
                {
                    if (Conn != null)
                    {
                        Conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Nope");
            }
        }

        private void BTNTroca_Click(object sender, EventArgs e)
        {
            variaveis.Data_Troca1 = TXTData_Troca.Text;
            variaveis.Codigo_Troca1 = TXTCod_Troca.Text;
            inserirTrocas(BDClass.AbrirConexao(), variaveis.Codigo_Troca1, variaveis.Data_Troca1);
            limpar();
        }

        private void BTNPesquisar_Troca_Click(object sender, EventArgs e)
        {
            string codigo = TXTProduto_Troca.Text;
            pesquisar(BDClass.AbrirConexao(), codigo);
            TXTProduto_Troca.Text = null;
            TXTQuantidade_Trocas.Text = null;
        }

        private void BTNDevolucao_Click(object sender, EventArgs e)
        {
            variaveis.Data_Devolucoes1 = TXTData_Devolucao.Text;
            variaveis.Codigo_Devolucoes1 = TXTCod_Devolucao.Text;
            inserirDevoluções(BDClass.AbrirConexao(), variaveis.Codigo_Devolucoes1, variaveis.Data_Devolucoes1);
        }

        private void TXTQuantidade_TextChanged(object sender, EventArgs e)
        {
            if(int.Parse(TXTQuantidade.Text) > int.Parse(quantidade))
            {
                MessageBox.Show("A quantidade de produtos não pode ser maior que o estoque atual!");
                TXTQuantidade.Text = quantidade;
            }
        }

        private void MTXCpf_Leave(object sender, EventArgs e)
        {
            if (MTXCpf.Text == "")
            {
                BTNSalvar.Enabled = false;
                MTXCpf.Focus();
            }
            else
            {
                BTNSalvar.Enabled = true;
                if (ValidaCPF(MTXCpf.Text) == false)
                {
                    MessageBox.Show("CPF inválido.", "Verificador de CPF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MTXCpf.Text = "";
                    LBLCpf.Visible = true;
                    MTXCpf.Focus();
                }
                else
                {
                    LBLCpf.Visible = false;
                }
            }
        }

        public void inserirDevoluções(MySqlConnection Conn, string codigo, string data)
        {
            string[,] myLis = new string[DGVDevolucao_Produtos.ColumnCount, DGVDevolucao_Produtos.RowCount];
            Conn.Open();
            comando.Connection = Conn;
            comandoAuxiliar.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "INSERT INTO devolucoes(codigo, data, dados_produtos, codigo_venda) VALUES(@Codigo, @Data, @dados_produtos, @codigo_venda)";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@Codigo", codigo);
                    comando.Parameters.AddWithValue("@codigo_venda", codigo);
                    comando.Parameters.AddWithValue("@Data", data);
                    //string[] array = new string[];
                    string testando = null;
                    for (int i = 0; i < DGVDevolucao_Produtos.RowCount - 1; i++) //percorre as linhas 
                    {
                        for (int x = 0; x < DGVDevolucao_Produtos.ColumnCount; x++) // percorre as colunas
                        {
                            if (DGVDevolucao_Produtos[x, i].Value != null)
                            {
                                myLis[x, i] = DGVDevolucao_Produtos[x, i].Value.ToString();
                                testando = myLis[x, i] + "#" + testando;
                                //.Split('#');
                                //MessageBox.Show(array);
                                //comando.Parameters.AddWithValue("@dados_produtos", array.ToString());
                            }
                        }
                        if (myLis[0, i].Count() == 2)
                        {
                            comandoAuxiliarDev.Parameters.Clear();
                            comandoAuxiliarDev.CommandText = "UPDATE PRODUTOS set Estoque_Atual = (SELECT estoque_atual WHERE codigo = @codigo) + @estoque_atual WHERE codigo = @codigo";
                            comandoAuxiliarDev.Prepare();
                            comandoAuxiliarDev.Parameters.AddWithValue("@Codigo", myLis[0, i - 1]);
                            //MessageBox.Show(quantidade[1]);
                            comandoAuxiliarDev.Parameters.AddWithValue("@estoque_atual", (DGVDevolucao_Produtos[2, i].Value.ToString()));
                            comandoAuxiliarDev.ExecuteNonQuery();
                        }
                        else
                        {
                            comandoAuxiliarDev.Parameters.Clear();
                            comandoAuxiliarDev.CommandText = "UPDATE PRODUTOS set Estoque_Atual = (SELECT estoque_atual WHERE codigo = @codigo) + @estoque_atual WHERE codigo = @codigo";
                            comandoAuxiliarDev.Prepare();
                            comandoAuxiliarDev.Parameters.AddWithValue("@Codigo", myLis[0, i]);
                            //MessageBox.Show(quantidade[1]);
                            comandoAuxiliarDev.Parameters.AddWithValue("@estoque_atual", (DGVDevolucao_Produtos[2, i].Value.ToString()));
                            comandoAuxiliarDev.ExecuteNonQuery();
                        }
                    }
                    var array = testando;
                    comando.Parameters.AddWithValue("@dados_produtos", array);
                    comando.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " " + ex.Message);
                }
                finally
                {
                    if (Conn != null)
                    {
                        Conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Nope");
            }
            limpar();
        }
        public void pesquisarVenda(MySqlConnection Conn, string codigo)
        {
            string data_valores = "";
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT * FROM vendas WHERE codigo = @codigo";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        variaveis.Codigo_Venda1 = leitor.GetString("codigo");
                        variaveis.Data_Venda1 = leitor.GetString("data");
                        variaveis.Cliente_Venda1 = leitor.GetString("cliente");
                        variaveis.CPF_Venda1 = leitor.GetString("cpf");
                        variaveis.Vendedor_Venda1 = leitor.GetString("vendedor");
                        data_valores = leitor.GetString("dados_produtos");
                        variaveis.Tipo_Venda1 = leitor.GetString("tipo_venda");
                        variaveis.Numero_Parcela1 = leitor.GetString("numero_parcela");
                        variaveis.Valor_Parcela1 = leitor.GetString("valor_parcela");
                        variaveis.Valor_Itens1 = leitor.GetString("valor_itens");
                        variaveis.Desconto1 = leitor.GetString("desconto");
                        variaveis.Valor_Total1 = leitor.GetString("valor_total");
                        variaveis.Valor_Pago1 = leitor.GetString("valor_pago");
                        variaveis.Troco1 = leitor.GetString("troco");
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
                int controle_dados;
                string[] datagrid = data_valores.Split('#');
                int invert_dados = 0;
                DataGridViewRow linha = new DataGridViewRow();
                int contador_linhas = 2;
                while(contador_linhas < datagrid.Count())
                {
                    if( contador_linhas != 0)
                    {
                        invert_dados = (datagrid.Count() - contador_linhas);
                        contador_linhas = contador_linhas + 5;
                    }
                    contador_linhas = contador_linhas + 1;
                    linha = (DataGridViewRow)DGVProdutos.Rows[0].Clone();
                    for (controle_dados = 0; controle_dados < 6; controle_dados++)
                    {
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        invert_dados = invert_dados - 1;
                    }
                    DGVProdutos.Rows.Add(linha);
                }
                //MessageBox.Show(datagrid[0]);
            }
        }

        private void BTNPesquisar_Devolucao_Click(object sender, EventArgs e)
        {
            string codigo = TXTProduto_Devolucao.Text;
            pesquisar(BDClass.AbrirConexao(), codigo);
            TXTQuantidade_Devolucao.Text = null;
            TXTProduto_Devolucao.Text = null;
        }

        private void BTNAdicionarProduto_Leave(object sender, EventArgs e)
        {
            TXTQuantidade.Text = "0";
            TXTNome_Produto.Text = "";
            TXTDesconto.Text = "";
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

        private void TXTProduto_Devolucao_Leave(object sender, EventArgs e)
        {
            if(TXTProduto_Devolucao.Text == "")
            {
                LBLProdutoDevolucao.Visible = true;
                TXTProduto_Devolucao.Focus();
            }
            else
            {
                LBLProdutoDevolucao.Visible = false;
            }
        }

        private void TXTQuantidade_Devolucao_Leave(object sender, EventArgs e)
        {
            if(TXTQuantidade_Devolucao.Text == "")
            {
                LBLQuantidadeDev.Visible = true;
                TXTQuantidade_Devolucao.Focus();
            }
            else
            {
                LBLQuantidadeDev.Visible = false;
            }
        }

        private void TXTProduto_Troca_Leave(object sender, EventArgs e)
        {
            if (TXTProduto_Troca.Text == "")
            {
                LBLProdutoTroca.Visible = true;
                TXTProduto_Troca.Focus();
            }
            else
            {
                LBLProdutoTroca.Visible = false;
            }
        }

        private void TXTQuantidade_Trocas_Leave(object sender, EventArgs e)
        {
            if (TXTQuantidade_Trocas.Text == "")
            {
                LBLQuantidadeTroca.Visible = true;
                TXTQuantidade_Trocas.Focus();
            }
            else
            {
                LBLQuantidadeTroca.Visible = false;
            }
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
        }

        private void TXTQuantidade_Leave(object sender, EventArgs e)
        {
            if (TXTQuantidade.Text == "")
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
            if (TXTProduto.Text == "")
            {
                LBLProduto.Visible = true;
                TXTProduto.Focus();
            }
            else
            {
                LBLProduto.Visible = false;
            }
        }

        private void BTNPesquisar_Produto_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNPesquisar_Produto, "Pesquisar produtos");
        }

        private void BTNAdicionarProduto_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNAdicionarProduto, "Adicionar produtos a lista");
        }

        private void BTNTroca_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNTroca, "Realizar troca");
        }

        private void BTNDevolucao_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNDevolucao, "Realizar devolução");
        }

        private void BTNSalvar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNSalvar, "Salvar venda");
        }

        private void BTNPesquisar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNPesquisar, "Pesquisar venda");
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

        private void PDVendas_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
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
            e.Graphics.DrawLine(pincel, 10, 40, 410, 40);//Horizontal
            e.Graphics.DrawString("Cliente: ", fonteA, caneta, 10, 40);
            e.Graphics.DrawString(TXTCliente.Text, fonteB, caneta, 100, 40);
            e.Graphics.DrawString("CPF: ", fonteA, caneta, 10, 80);
            e.Graphics.DrawString(MTXCpf.Text, fonteB, caneta, 100, 80);
            e.Graphics.DrawLine(pincel, 10, 110, 410, 110);//Horizontal
            e.Graphics.DrawString("Vendedor: ", fonteA, caneta, 10, 110);
            e.Graphics.DrawString(TXTVendedor.Text, fonteB, caneta, 130, 110);
            e.Graphics.DrawLine(pincel, 10, 140, 410, 140);//Horizontal
            e.Graphics.DrawString("Produto", fonteA, caneta, 10, 150);
            e.Graphics.DrawLine(pincel, 140, 140, 140, 600);//Vertical
            e.Graphics.DrawString("Quant.", fonteA, caneta, 140, 150);
            e.Graphics.DrawLine(pincel, 230, 140, 230, 600);//Vertical
            e.Graphics.DrawString("Marca", fonteA, caneta, 230, 150);
            e.Graphics.DrawLine(pincel, 320, 140, 320, 565);//Vertical
            e.Graphics.DrawString("R$", fonteA, caneta, 320, 150);
            e.Graphics.DrawLine(pincel, 10, 180, 410, 180);//Horizontal
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
            e.Graphics.DrawString(TXTValor_Items.Text, fonteA, caneta, 280, 570);
            e.Graphics.DrawLine(pincel, 10, 600, 410, 600);//Horizontal
            //Draw do total aqui
            e.Graphics.DrawString("Venda: ", fonteA, caneta, 10, 610);
            if (RDBPrazo.Checked == true)
            {
                e.Graphics.DrawString("À Prazo", fonteB, caneta, 100, 610);
                e.Graphics.DrawString(TXTNumero_Parcelas.Text + "x de R$ " + TXTValor_Parcela.Text, fonteB, caneta, 200, 610);
            }
            else
            {
                if (RDBVista.Checked == true)
                {
                    e.Graphics.DrawString("À Vista", fonteB, caneta, 190, 610);
                }
            }
            e.Graphics.DrawString("Valor total: ", fonteA, caneta, 10, 650);
            e.Graphics.DrawString(TXTValor_Total.Text, fonteB, caneta, 200, 650);
            e.Graphics.DrawString("Desconto: ", fonteA, caneta, 10, 690);
            e.Graphics.DrawString(TXTDesconto.Text, fonteB, caneta, 200, 690);
            e.Graphics.DrawString("Valor Pago: ", fonteA, caneta, 10, 730);
            e.Graphics.DrawString(TXTValor_Pago.Text, fonteB, caneta, 200, 730);
            e.Graphics.DrawString("Troco: ", fonteA, caneta, 10, 770);
            e.Graphics.DrawString(TXTTroco.Text, fonteB, caneta, 200, 770);
            e.Graphics.DrawLine(pincel, 10, 800, 410, 800);//Horizontal
            e.Graphics.DrawImage(Logo, 10, 800, width, 200);
        }

        //fazer pesquisar vendas e devolução além de inserir dos mesmos
        public void pesquisarDevolucao(MySqlConnection Conn, string codigo)
        {
            string data_valores = "";
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT * FROM devolucoes WHERE codigo = @codigo";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        variaveis.Codigo_Venda1 = leitor.GetString("codigo");
                        variaveis.Data_Venda1 = leitor.GetString("data");
                        variaveis.Cliente_Venda1 = leitor.GetString("cliente");
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
                int controle_dados;
                string[] datagrid = data_valores.Split('#');
                int invert_dados = 0;
                DataGridViewRow linha = new DataGridViewRow();
                int contador_linhas = 2;
                while (contador_linhas < datagrid.Count())
                {
                    if (contador_linhas != 0)
                    {
                        invert_dados = (datagrid.Count() - contador_linhas);
                        contador_linhas = contador_linhas + 5;
                    }
                    contador_linhas = contador_linhas + 1;
                    linha = (DataGridViewRow)DGVProdutos.Rows[0].Clone();
                    for (controle_dados = 0; controle_dados < 6; controle_dados++)
                    {
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        invert_dados = invert_dados - 1;
                    }
                    DGVProdutos.Rows.Add(linha);
                }
            }
        }
        public void pesquisarTroca(MySqlConnection Conn, string codigo)
        {
            string data_valores = "";
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT * FROM trocas WHERE codigo = @codigo";
                    comando.Prepare();/*
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.AddWithValue("@codigo_venda",);
                    comando.Parameters.AddWithValue("@data",);
                    comando.Parameters.AddWithValue("@dados_produtos",);*/
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        variaveis.Codigo_Venda1 = leitor.GetString("codigo");
                        variaveis.Data_Venda1 = leitor.GetString("data");
                        variaveis.Cliente_Venda1 = leitor.GetString("cliente");
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
                int controle_dados;
                string[] datagrid = data_valores.Split('#');
                int invert_dados = 0;
                DataGridViewRow linha = new DataGridViewRow();
                int contador_linhas = 2;
                while (contador_linhas < datagrid.Count())
                {
                    if (contador_linhas != 0)
                    {
                        invert_dados = (datagrid.Count() - contador_linhas);
                        contador_linhas = contador_linhas + 5;
                    }
                    contador_linhas = contador_linhas + 1;
                    linha = (DataGridViewRow)DGVProdutos.Rows[0].Clone();
                    for (controle_dados = 0; controle_dados < 6; controle_dados++)
                    {
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        linha.Cells[controle_dados].Value = datagrid[invert_dados];
                        invert_dados = invert_dados - 1;
                    }
                    DGVProdutos.Rows.Add(linha);
                }
            }
        }
        public void pesquisar(MySqlConnection Conn, string codigo)
        {
            string codigo_interno = null, nome = null, valor = null, marca_interno = null;
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comandoP.Parameters.Clear();
                    comandoP.CommandText = "SELECT * FROM produtos WHERE nome = @codigo";
                    comandoP.Prepare();
                    comandoP.Parameters.AddWithValue("@codigo", codigo);
                    leitor = comandoP.ExecuteReader();
                    while (leitor.Read())
                    {
                        if (leitor.GetString("estoque_atual") != "0")
                        {
                            nome = leitor.GetString("nome");
                            codigo_interno = leitor.GetString("codigo");
                            quantidade = leitor.GetString("estoque_atual");
                            valor = leitor.GetString("preco_final");
                            marca_interno = leitor.GetString("marca");
                        }
                        else
                        {
                            MessageBox.Show("Produto fora de estoque.");
                        }
                    }
                    DataGridViewRow linhainterna, linhainterna2;
                    if (TPTrocas.Focus() == true)
                    {
                        linhainterna = (DataGridViewRow)DGVProdutos_Troca.Rows[0].Clone();
                        linhainterna.Cells[0].Value = codigo_interno;
                        linhainterna.Cells[1].Value = nome;
                        linhainterna.Cells[2].Value = TXTQuantidade_Trocas.Text;
                        linhainterna.Cells[3].Value = valor;
                        linhainterna.Cells[4].Value = marca_interno;
                        DGVProdutos_Troca.Rows.Add(linhainterna);
                    }
                    else
                    {
                        linhainterna2 = (DataGridViewRow)DGVDevolucao_Produtos.Rows[0].Clone();
                        linhainterna2.Cells[0].Value = codigo_interno;
                        linhainterna2.Cells[1].Value = nome;
                        linhainterna2.Cells[2].Value = TXTQuantidade_Devolucao.Text;
                        linhainterna2.Cells[3].Value = valor;
                        linhainterna2.Cells[4].Value = marca_interno;
                        DGVDevolucao_Produtos.Rows.Add(linhainterna2);
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
        public static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");
            if (valor.Length != 11)
                return false;
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;
            if (igual || valor == "12345678909")
                return false;
            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];
            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }
    }
}

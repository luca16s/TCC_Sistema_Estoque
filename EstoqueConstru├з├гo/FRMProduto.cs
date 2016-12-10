using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Estoque_Material_Construção
{
    public partial class FRMProduto : Form
    {
        ConexaoBD BDClass = new ConexaoBD();
        Variaveis variaveis = new Variaveis();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        protected Boolean tipo_Codigo = false;
        ToolTip MytoolTip = new ToolTip();
        double resultado;

        public FRMProduto()
        {
            InitializeComponent();
            //MTBICMS.Text = string.Format("{0:C}", Convert.ToDouble(1200.58));
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        string end_Image;

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void BTNImage_Click(object sender, EventArgs e)
        {
            if(OFDImagem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                end_Image = OFDImagem.FileName;
                TXTImageEnd.Text = end_Image;
                PTBImage.ImageLocation = end_Image;
                //MessageBox.Show(end_Image);
            }
        }

        private void BTNVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void BTNFornecedor_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            FRMFornecedores fornecedor = new FRMFornecedores();
            fornecedor.ShowDialog();
        }

        private void BTNCategoria_Click(object sender, EventArgs e)
        {
            FRMCadastro cadastro = new FRMCadastro("Categoria");
            cadastro.ShowDialog();
        }

        private void BTNMarca_Click(object sender, EventArgs e)
        {
            FRMCadastro cadastro = new FRMCadastro("Marca");
            cadastro.ShowDialog();
        }

        private void CBXCategoria_DropDown(object sender, EventArgs e)
        {
        }

        private void CBXMarca_DropDown(object sender, EventArgs e)
        {
                string[] valores;
                if (File.Exists("Config_Marca.xml") == true)
                {
                    using (XmlReader leitor_Xml = XmlReader.Create("Config_Marca.xml"))
                    {
                        while (leitor_Xml.Read())
                        {
                            if (leitor_Xml.IsStartElement())
                            {
                                switch (leitor_Xml.Name)
                                {
                                    case "Marcas":
                                        break;
                                    case "Valor":
                                        string atributo_no = leitor_Xml["name"];
                                        if (atributo_no != null)
                                        {
                                            MessageBox.Show(atributo_no);
                                        }
                                        if (leitor_Xml.Read())
                                        {
                                            valores = new string[] { leitor_Xml.Value.Trim() };
                                        }
                                        break;
                                }
                            }
                        }
                    }
            }
        }
        int codigo;
        private void FRMProduto_Load(object sender, EventArgs e)
        {
            if (PesquisarCodigo(BDClass.AbrirConexao()) == null)
            {
                codigo = codigo + 1;
            }
            else
            {
                codigo = codigo + int.Parse(PesquisarCodigo(BDClass.AbrirConexao())) + 1;
            }
            TXTCodigo.Text = codigo.ToString();
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
                    comando.CommandText = "SELECT codigo FROM produtos";
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

        private void BTNSalvar_Click(object sender, EventArgs e)
        {
            if (tipo_Codigo == false)
            {
                variaveis.Acrescimos_Produto = TXTAcrescimos.Text;
                variaveis.Balcao = TXTBalcao.Text;
                variaveis.Codigo_Produto = TXTCodigo.Text;
                variaveis.Corredor = TXTCorredor.Text;
                variaveis.Desconto_Produto = TXTDesconto.Text;
                variaveis.Descricao_Produto = TXTDescricao.Text;
                variaveis.Despesas_Produto = TXTDespesas.Text;
                variaveis.Estoque_Atual = TXTE_Atual.Text;
                variaveis.Estoque_Maximo = TXTE_Maximo.Text;
                variaveis.Estoque_Minimo = TXTE_Minimo.Text;
                variaveis.Estoque_Recomendado = TXTE_Recomendado.Text;
                variaveis.Foto_Produto = TXTImageEnd.Text;
                variaveis.Frete_Produto = MTBFrete.Text;
                variaveis.Icms_Produto = MTBICMS.Text;
                variaveis.Lucro_Produto = TXTLucro.Text;
                variaveis.Medida = TXTMedida.Text;
                variaveis.Nome_Produto = TXTNome.Text;
                variaveis.Prateleira = TXTPrateleira.Text;
                variaveis.Preco_Custo_Produto = MTBP_Custo.Text;
                variaveis.Preco_Final = TXTPreco_Final.Text;
                variaveis.Preco_Minimo = TXTPreco_Minimo.Text;
                variaveis.Unidade_Medida = CBXMedida.Text;
                InserirProdutos(BDClass.AbrirConexao(), variaveis.Codigo_Produto, variaveis.Nome_Produto, variaveis.Descricao_Produto, variaveis.Categoria_Produto, variaveis.Marca_Produto, variaveis.Foto_Produto, variaveis.Fornecedor_Produto, variaveis.Preco_Custo_Produto, variaveis.Frete_Produto, variaveis.Icms_Produto, variaveis.Despesas_Produto, variaveis.Lucro_Produto, variaveis.Desconto_Produto, variaveis.Preco_Minimo, variaveis.Acrescimos_Produto, variaveis.Preco_Final, variaveis.Estoque_Minimo, variaveis.Estoque_Recomendado, variaveis.Estoque_Atual, variaveis.Estoque_Maximo, variaveis.Unidade_Medida, variaveis.Medida, variaveis.Prateleira, variaveis.Corredor, variaveis.Balcao);
                limpar();
            }
            else
                if (tipo_Codigo == true)
            {
                EditarProdutos(BDClass.AbrirConexao(), variaveis.Codigo_Produto, variaveis.Nome_Produto, variaveis.Descricao_Produto, variaveis.Categoria_Produto, variaveis.Marca_Produto, variaveis.Foto_Produto, variaveis.Fornecedor_Produto, variaveis.Preco_Custo_Produto, variaveis.Frete_Produto, variaveis.Icms_Produto, variaveis.Despesas_Produto, variaveis.Lucro_Produto, variaveis.Desconto_Produto, variaveis.Preco_Minimo, variaveis.Acrescimos_Produto, variaveis.Preco_Final, variaveis.Estoque_Minimo, variaveis.Estoque_Recomendado, variaveis.Estoque_Atual, variaveis.Estoque_Maximo, variaveis.Unidade_Medida, variaveis.Medida, variaveis.Prateleira, variaveis.Corredor, variaveis.Balcao);
                limpar();
            }
            tipo_Codigo = false;
        }

        private void BTNExcluir_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Tem certeza que deseja excluir este produto?", "Exclusão de produto.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (escolha == DialogResult.Yes)
            {
                ExcluirProdutos(BDClass.AbrirConexao(), TXTCodigo.Text);
                limpar();
            }
        }

        public void limpar()
        {
            TXTAcrescimos.Text = "";
            TXTBalcao.Text = "";
            TXTCodigo.Text = "";
            TXTCorredor.Text = "";
            TXTDesconto.Text = "";
            TXTDescricao.Text = "";
            TXTDespesas.Text = "";
            TXTE_Atual.Text = "";
            TXTE_Maximo.Text = "";
            TXTE_Minimo.Text = "";
            TXTE_Recomendado.Text = "";
            TXTImageEnd.Text = "";
            TXTLucro.Text = "";
            TXTMedida.Text = "";
            TXTNome.Text = "";
            TXTPrateleira.Text = "";
            TXTPreco_Final.Text = "";
            TXTPreco_Minimo.Text = "";
            MTBFrete.Text = "";
            MTBICMS.Text = "";
            MTBP_Custo.Text = "";
            PTBImage.Image = null;
            CKBMedida.Checked = false;
        }

        private void CBXFornecedor_DropDown(object sender, EventArgs e)
        {
            PesquisarFornecedor(BDClass.AbrirConexao());
        }

        public void InserirProdutos(MySqlConnection Conn, string codigo, string nome, string descrição, string categoria, string marca, string foto, string fornecedor, string preco_custo, string frete, string icms, string despesas, string lucro, string desconto, string preco_minimo, string acrescimos, string preco_final, string estoque_minimo, string estoque_recomendado, string estoque_atual, string estoque_maximo, string unidade_medida, string medida, string prateleira, string corredor, string balcao)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "Insert into produtos values (@codigo, @nome, @descricao, @categoria, @marca, @foto, @fornecedor, @preco_custo, @frete, @icms, @despesas, @lucro, @desconto, @preco_minimo, @acrescimos, @preco_final, @estoque_minimo, @estoque_recomendado, @estoque_atual, @estoque_maximo, @unidade_medida, @medida, @prateleira, @corredor, @balcao)";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@descricao", descrição);
                    comando.Parameters.AddWithValue("@categoria", categoria);
                    comando.Parameters.AddWithValue("@marca", marca);
                    comando.Parameters.AddWithValue("@foto", foto);
                    comando.Parameters.AddWithValue("@fornecedor", fornecedor);
                    comando.Parameters.AddWithValue("@preco_custo", preco_custo.Replace("R$", "").Trim());
                    comando.Parameters.AddWithValue("@frete", frete.Replace("R$", "").Trim());
                    comando.Parameters.AddWithValue("@icms", icms.Replace("R$", "").Trim());
                    comando.Parameters.AddWithValue("@despesas", despesas.Replace("R$", "").Trim());
                    comando.Parameters.AddWithValue("@lucro", lucro.Replace("R$", "").Trim());
                    comando.Parameters.AddWithValue("@desconto", desconto.Replace("R$", "").Trim());//.Replace("R", "").Replace("$", "").Trim()
                    comando.Parameters.AddWithValue("@preco_minimo", preco_minimo.Replace("R$", "").Trim());
                    comando.Parameters.AddWithValue("@acrescimos", acrescimos.Replace("R$", "").Trim());
                    comando.Parameters.AddWithValue("@preco_final", preco_final.Replace("R$", "").Trim());
                    comando.Parameters.AddWithValue("@estoque_minimo", estoque_minimo);
                    comando.Parameters.AddWithValue("@estoque_recomendado", estoque_recomendado);
                    comando.Parameters.AddWithValue("@estoque_atual", estoque_atual);
                    comando.Parameters.AddWithValue("@estoque_maximo", estoque_maximo);
                    comando.Parameters.AddWithValue("@unidade_medida", unidade_medida);
                    comando.Parameters.AddWithValue("@medida", medida);
                    comando.Parameters.AddWithValue("@prateleira", prateleira);
                    comando.Parameters.AddWithValue("@corredor", corredor);
                    comando.Parameters.AddWithValue("@balcao", balcao);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Produto inserido com sucesso.");
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
            else
            {
                MessageBox.Show("Nope");
            }
        }
        public void PesquisarProdutos_Codigo(MySqlConnection Conn, string codigo)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT * FROM produtos WHERE codigo = @codigo";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    leitor = comando.ExecuteReader();
                    if (leitor.HasRows)
                    {
                        while (leitor.Read())
                        {
                            TXTAcrescimos.Text = string.Format("{0:C}", leitor.GetString("acrescimos"));
                            TXTBalcao.Text = leitor.GetString("balcao");
                            TXTCodigo.Text = leitor.GetString("codigo");
                            TXTCorredor.Text = leitor.GetString("corredor");
                            TXTDesconto.Text = string.Format("{0:C}", leitor.GetString("desconto"));
                            TXTDescricao.Text = leitor.GetString("descricao");
                            TXTDespesas.Text = string.Format("{0:C}", leitor.GetString("despesas"));
                            TXTE_Atual.Text = leitor.GetString("estoque_atual");
                            TXTE_Maximo.Text = leitor.GetString("estoque_maximo");
                            TXTE_Minimo.Text = leitor.GetString("estoque_minimo");
                            TXTE_Recomendado.Text = leitor.GetString("estoque_recomendado");
                            TXTImageEnd.Text = leitor.GetString("foto");
                            TXTLucro.Text = string.Format("{0:C}", leitor.GetString("lucro"));
                            TXTMedida.Text = leitor.GetString("medida");
                            TXTNome.Text = leitor.GetString("nome");
                            TXTPrateleira.Text = leitor.GetString("prateleira");
                            TXTPreco_Final.Text = string.Format("{0:C}", leitor.GetString("preco_final"));
                            TXTPreco_Minimo.Text = string.Format("{0:C}", leitor.GetString("preco_minimo"));
                            CBXMedida.Text = leitor.GetString("unidade_medida");
                            MTBFrete.Text = string.Format("{0:C}", leitor.GetString("frete"));
                            MTBICMS.Text = string.Format("{0:C}", leitor.GetString("icms"));
                            MTBP_Custo.Text = string.Format("{0:C}", leitor.GetString("preco_custo"));
                            PTBImage.ImageLocation = leitor.GetString("foto");
                            BTNSalvar.Enabled = true;
                            BTNExcluir.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sua pesquisa não retornou resultados.");
                        FRMPedidoProduto pedido = new FRMPedidoProduto();
                        pedido.MdiParent = FRMPrincipal.ActiveForm;
                        pedido.Show();
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
                    if (leitor.HasRows)
                    {
                        while (leitor.Read())
                        {
                            TXTAcrescimos.Text = string.Format("{0:C}", leitor.GetString("acrescimos"));
                            TXTBalcao.Text = leitor.GetString("balcao");
                            TXTCodigo.Text = leitor.GetString("codigo");
                            TXTCorredor.Text = leitor.GetString("corredor");
                            TXTDesconto.Text = string.Format("{0:C}", leitor.GetString("desconto"));
                            TXTDescricao.Text = leitor.GetString("descricao");
                            TXTDespesas.Text = string.Format("{0:C}", leitor.GetString("despesas"));
                            TXTE_Atual.Text = leitor.GetString("estoque_atual");
                            TXTE_Maximo.Text = leitor.GetString("estoque_maximo");
                            TXTE_Minimo.Text = leitor.GetString("estoque_minimo");
                            TXTE_Recomendado.Text = leitor.GetString("estoque_recomendado");
                            TXTImageEnd.Text = leitor.GetString("foto");
                            TXTLucro.Text = string.Format("{0:C}", leitor.GetString("lucro"));
                            TXTMedida.Text = leitor.GetString("medida");
                            TXTNome.Text = leitor.GetString("nome");
                            TXTPrateleira.Text = leitor.GetString("prateleira");
                            TXTPreco_Final.Text = string.Format("{0:C}", leitor.GetString("preco_final"));
                            TXTPreco_Minimo.Text = string.Format("{0:C}", leitor.GetString("preco_minimo"));
                            CBXMedida.Text = leitor.GetString("unidade_medida");
                            MTBFrete.Text = string.Format("{0:C}", Convert.ToDouble(leitor.GetString("frete")));
                            MTBICMS.Text = string.Format("{0:C}", Convert.ToDouble(leitor.GetString("icms")));
                            MTBP_Custo.Text = string.Format("{0:C}", Convert.ToDouble(leitor.GetString("preco_custo")));
                            PTBImage.ImageLocation = leitor.GetString("foto");
                            BTNSalvar.Enabled = true;
                            BTNExcluir.Enabled = true;
                        }
                    }
                    else
                    {
                        FRMPedidoProduto pedido = new FRMPedidoProduto();
                        pedido.MdiParent = FRMPrincipal.ActiveForm;
                        pedido.Show();
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
        public void ExcluirProdutos(MySqlConnection Conn, string codigo)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "DELETE from produtos WHERE codigo = @codigo";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Produto excluido com sucesso.");
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
            else
            {
                MessageBox.Show("Produto não selecionado.");
            }
        }
        public void EditarProdutos(MySqlConnection Conn, string codigo, string nome, string descrição, string categoria, string marca, string foto, string fornecedor, string preco_custo, string frete, string icms, string despesas, string lucro, string desconto, string preco_minimo, string acrescimos, string preco_final, string estoque_minimo, string estoque_recomendado, string estoque_atual, string estoque_maximo, string unidade_medida, string medida, string prateleira, string corredor, string balcao)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "UPDATE produtos set codigo = @codigo, nome = @nome, descricao = @descricao, categoria = @categoria, marca =  @marca, foto = @foto, fornecedor = @fornecedor, preco_custo = @preco_custo, frete = @frete, icms = @icms, despesas = @despesas, lucro = @lucro, desconto = @desconto, preco_minimo = @preco_minimo, acrescimos = @acrescimos, preco_final = @preco_final, estoque_minimo = @estoque_minimo, estoque_recomendado = @estoque_recomendado, estoque_atual = @estoque_atual, estoque_maximo = @estoque_maximo, unidade_medida = @unidade_medida, medida = @medida, prateleira = @prateleira, corredor = @corredor, balcao = @balcao";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@descricao", descrição);
                    comando.Parameters.AddWithValue("@categoria", categoria);
                    comando.Parameters.AddWithValue("@marca", marca);
                    comando.Parameters.AddWithValue("@foto", foto);
                    comando.Parameters.AddWithValue("@fornecedor", fornecedor);
                    comando.Parameters.AddWithValue("@preco_custo", preco_custo);
                    comando.Parameters.AddWithValue("@frete", frete);
                    comando.Parameters.AddWithValue("@icms", icms);
                    comando.Parameters.AddWithValue("@despesas", despesas);
                    comando.Parameters.AddWithValue("@lucro", lucro);
                    comando.Parameters.AddWithValue("@desconto", desconto);
                    comando.Parameters.AddWithValue("@preco_minimo", preco_minimo);
                    comando.Parameters.AddWithValue("@acrescimos", acrescimos);
                    comando.Parameters.AddWithValue("@preco_final", preco_final);
                    comando.Parameters.AddWithValue("@estoque_minimo", estoque_minimo);
                    comando.Parameters.AddWithValue("@estoque_recomendado", estoque_recomendado);
                    comando.Parameters.AddWithValue("@estoque_atual", estoque_atual);
                    comando.Parameters.AddWithValue("@estoque_maximo", estoque_maximo);
                    comando.Parameters.AddWithValue("@unidade_medida", unidade_medida);
                    comando.Parameters.AddWithValue("@medida", medida);
                    comando.Parameters.AddWithValue("@prateleira", prateleira);
                    comando.Parameters.AddWithValue("@corredor", corredor);
                    comando.Parameters.AddWithValue("@balcao", balcao);
                    comando.ExecuteNonQuery();
                    limpar();
                    MessageBox.Show("Produto alterado com sucesso.");
                    PesquisarProdutos_Codigo(BDClass.AbrirConexao(), codigo);
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
        public void InserirEstoque(MySqlConnection Conn, string codigo, string quantidade_atual, string quantidade)
        {
            Conn.Open();
            comando.Connection = Conn;
            //MessageBox.Show(variaveis.Codigo_Produto);
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "UPDATE produtos set estoque_atual = @estoque_atual WHERE codigo = @codigo";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.AddWithValue("@estoque_atual", int.Parse(quantidade) + int.Parse(quantidade_atual));
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Estoque atualizado com sucesso.");
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
            else
            {
                MessageBox.Show("Nope");
            }
        }

        private void BTNPesq_Codigo_Click(object sender, EventArgs e)
        {
            string codigo = Microsoft.VisualBasic.Interaction.InputBox("Insira o código para pesquisar:", "Pesquisa", "");
            PesquisarProdutos_Codigo(BDClass.AbrirConexao(), codigo);
        }

        private void BTNPesq_Nome_Click(object sender, EventArgs e)
        {
            string codigo = Microsoft.VisualBasic.Interaction.InputBox("Insira o código para pesquisar:", "Pesquisa", "");
            PesquisarProdutos_Nome(BDClass.AbrirConexao(), codigo);
        }

        private void TXTAcrescimos_Leave(object sender, EventArgs e)
        {
            if(TXTAcrescimos.Text == "")
            {
                LBLAcrescimos.Visible = true;
                TXTAcrescimos.Focus();
            }
            else
            {
                LBLAcrescimos.Visible = false;
                double preco_minimo = double.Parse(TXTPreco_Minimo.Text.Replace("R$", ""));
                double acrescimos = double.Parse(TXTAcrescimos.Text.Replace("R$", ""));
                resultado = preco_minimo + acrescimos;
                TXTPreco_Final.Text = string.Format("{0:C}", Convert.ToDouble(resultado.ToString()));
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
                double frete = double.Parse(MTBFrete.Text.Replace("R$", ""));
                double preco_custo = double.Parse(MTBP_Custo.Text.Replace("R$", ""));
                double icms = double.Parse(MTBICMS.Text.Replace("R$", ""));
                double lucro = double.Parse(TXTLucro.Text.Replace("R$", ""));
                double desconto = double.Parse(TXTDesconto.Text.Replace("R$", ""));
                double despesas = double.Parse(TXTDespesas.Text.Replace("R$", ""));
                resultado = (preco_custo + icms + despesas + lucro + frete) - (desconto);
                TXTPreco_Minimo.Text = string.Format("{0:C}", Convert.ToDouble(resultado.ToString()));
            }
            
        }

        private void CKBMedida_CheckedChanged(object sender, EventArgs e)
        {
            if(CKBMedida.Checked == true)
            {
                CBXMedida.Enabled = true;
                TXTMedida.Enabled = true;
            }
            else
            {
                CBXMedida.Enabled = false;
                TXTMedida.Enabled = false;
            }
        }

        private void TXTE_Maximo_Leave(object sender, EventArgs e)
        {
            if(TXTE_Maximo.Text == "")
            {
                LBLEstoquMaximo.Visible = true;
                TXTE_Maximo.Focus();
            }
            else
            {
                LBLEstoquMaximo.Visible = false;
                int minimo = int.Parse(TXTE_Minimo.Text);
                int maximo = int.Parse(TXTE_Maximo.Text);
            }
        }

        private void BTNAdicionarEstoque_Click(object sender, EventArgs e)
        {
            string codigo = Microsoft.VisualBasic.Interaction.InputBox("Insira a quantidade para ser acrescida ao estoque:", "Aumento de estoque", "");
            InserirEstoque(BDClass.AbrirConexao(), TXTCodigo.Text, TXTE_Atual.Text, codigo);
            PesquisarProdutos_Codigo(BDClass.AbrirConexao(), TXTCodigo.Text);
        }

        private void TXTCodigo_Leave(object sender, EventArgs e)
        {
            if(TXTCodigo.Text == "")
            {
                LBLCodigo.Visible = true;
                TXTCodigo.Focus();
            }
            else
            {
                LBLCodigo.Visible = false;
            }
        }

        private void TXTNome_Leave(object sender, EventArgs e)
        {
            if (TXTNome.Text == "")
            {
                LBLProduto.Visible = true;
                TXTNome.Focus();
            }
            else
            {
                LBLProduto.Visible = false;
            }
        }

        private void CBXCategoria_Leave(object sender, EventArgs e)
        {
        }

        private void CBXMarca_Leave(object sender, EventArgs e)
        {
        }

        private void CBXFornecedor_Leave(object sender, EventArgs e)
        {
        }

        private void MTBP_Custo_Leave(object sender, EventArgs e)
        {
            if (MTBP_Custo.Text == "")
            {
                LBLPrecoCusto.Visible = true;
                MTBP_Custo.Focus();
            }
            else
            {
                LBLPrecoCusto.Visible = false;
            }
        }

        private void MTBFrete_Leave(object sender, EventArgs e)
        {
            if (MTBFrete.Text == "")
            {
                LBLFrete.Visible = true;
                MTBFrete.Focus();
            }
            else
            {
                LBLFrete.Visible = false;
            }
        }

        private void TXTDespesas_Leave(object sender, EventArgs e)
        {
            if (TXTDespesas.Text == "")
            {
                LBLDespesas.Visible = true;
                TXTDespesas.Focus();
            }
            else
            {
                LBLDespesas.Visible = false;
            }
        }

        private void TXTLucro_Leave(object sender, EventArgs e)
        {
            if (TXTLucro.Text == "")
            {
                LBLLucro.Visible = true;
                TXTLucro.Focus();
            }
            else
            {
                LBLLucro.Visible = false;
            }
        }

        private void TXTPreco_Minimo_Leave(object sender, EventArgs e)
        {
            if (TXTPreco_Minimo.Text == "")
            {
                LBLPrecoMinimo.Visible = true;
                TXTPreco_Minimo.Focus();
            }
            else
            {
                LBLPrecoMinimo.Visible = false;
            }
        }

        private void TXTPreco_Final_Leave(object sender, EventArgs e)
        {
            if (TXTPreco_Final.Text == "")
            {
                LBLPrecoFinal.Visible = true;
                TXTPreco_Final.Focus();
            }
            else
            {
                LBLPrecoFinal.Visible = false;
            }
        }

        private void TXTE_Minimo_Leave(object sender, EventArgs e)
        {
            if (TXTE_Minimo.Text == "")
            {
                LBLEstoquMinimo.Visible = true;
                TXTE_Minimo.Focus();
            }
            else
            {
                LBLEstoquMinimo.Visible = false;
                TXTE_Maximo.Text = (int.Parse(TXTE_Minimo.Text) * 3).ToString();
                TXTE_Recomendado.Text = (int.Parse(TXTE_Minimo.Text) * 2).ToString();
            }
        }

        private void TXTE_Recomendado_Leave(object sender, EventArgs e)
        {
            if (TXTE_Recomendado.Text == "")
            {
                LBLEstoquRec.Visible = true;
                TXTE_Recomendado.Focus();
            }
            else
            {
                LBLEstoquRec.Visible = false;
            }
        }

        private void TXTE_Atual_Leave(object sender, EventArgs e)
        {
            if (TXTE_Atual.Text == "")
            {
                LBLAtual.Visible = true;
                TXTE_Atual.Focus();
                TXTE_Recomendado.Text = (int.Parse(TXTE_Minimo.Text) * 2).ToString();
                TXTE_Maximo.Text = (int.Parse(TXTE_Minimo.Text) * 3).ToString();
            }
            else
            {
                LBLAtual.Visible = false;
            }
        }

        private void BTNPesq_Codigo_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNPesq_Codigo, "Pesuisar produto");
        }

        private void BTNPesq_Nome_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNPesq_Nome, "Pesquisar produto");
        }

        private void BTNCategoria_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNCategoria, "Adicionar categoria");
        }

        private void BTNMarca_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNMarca, "Adicionar Marca");
        }

        private void BTNImage_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNImage, "Adicionar foto do produto");
        }

        private void BTNFornecedor_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNFornecedor, "Adicionar fornecedor");
        }

        private void BTNAdicionarEstoque_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNAdicionarEstoque, "Adicionar estoque");
        }

        private void BTNSalvar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNSalvar, "Salvar Produto");
        }

        private void BTNLimpar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNLimpar, "Limpar Campos");
        }

        private void BTNExcluir_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNExcluir, "Excluir produto atual");
        }

        private void BTNVoltar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNVoltar, "Voltar para a Tela principal");
        }

        private void TXTCodigo_MouseHover(object sender, EventArgs e)
        {
            //MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            //MytoolTip.IsBalloon = true;
            //MytoolTip.ShowAlways = true;
            //MytoolTip.SetToolTip(TXTCodigo, "Recomenda-se Colocar no código as Iniciais do Produto + a marca. Exemplo: Cano de 10 Amanco, Código = C10AMANCO");
        }

        private void TXTMarca_Click(object sender, EventArgs e)
        {
            var source = new AutoCompleteStringCollection();
            string[] valores;
            if (File.Exists("Config_Marca.xml") == true)
            {
                using (XmlReader leitor_Xml = XmlReader.Create("Config_Marca.xml"))
                {
                    while (leitor_Xml.Read())
                    {
                        if (leitor_Xml.IsStartElement())
                        {
                            switch (leitor_Xml.Name)
                            {
                                case "Marcas":
                                    break;
                                case "Valor":
                                    string atributo_no = leitor_Xml["name"];
                                    if (atributo_no != null)
                                    {
                                        MessageBox.Show(atributo_no);
                                    }
                                    if (leitor_Xml.Read())
                                    {
                                        valores = new string[] { leitor_Xml.Value.Trim() };
                                        source.AddRange(valores);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            TXTMarca.AutoCompleteCustomSource = source;
        }

        private void TXTCategoria_Click(object sender, EventArgs e)
        {
            var source = new AutoCompleteStringCollection();
            string[] valores;
            if (File.Exists("Config_Categoria.xml") == true)
            {
                using (XmlReader leitor_Xml = XmlReader.Create("Config_Categoria.xml"))
                {
                    while (leitor_Xml.Read())
                    {
                        if (leitor_Xml.IsStartElement())
                        {
                            switch (leitor_Xml.Name)
                            {
                                case "Categorias":
                                    break;
                                case "Nome":
                                    string atributo_no = leitor_Xml["name"];
                                    if (atributo_no != null)
                                    {
                                        MessageBox.Show(atributo_no);
                                    }
                                    if (leitor_Xml.Read())
                                    {
                                        valores = new string[] { leitor_Xml.Value.Trim() };
                                        source.AddRange(valores);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            TXTCategoria.AutoCompleteCustomSource = source;
        }

        public void PesquisarFornecedor(MySqlConnection Conn)
        {
            string[] valores;
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT * FROM fornecedores";
                    comando.Prepare();
                    leitor = comando.ExecuteReader();
                    var source = new AutoCompleteStringCollection();
                    while (leitor.Read())
                    {
                        valores = new string[] { leitor.GetString("nome_fantasia") };
                        source.AddRange(valores);
                    }
                    TXTFornecedor.AutoCompleteCustomSource = source;
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

        private void TXTFornecedor_Click(object sender, EventArgs e)
        {
            PesquisarFornecedor(BDClass.AbrirConexao());
        }
    }
}

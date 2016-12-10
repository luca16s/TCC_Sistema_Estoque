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
    public partial class FRMRelatorio : Form
    {
        public FRMRelatorio()
        {
            InitializeComponent();
        }

        ConexaoBD BDClass = new ConexaoBD();
        ToolTip MytoolTip = new ToolTip();
        Variaveis variaveis = new Variaveis();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlCommand comandoQuery = new MySqlCommand();
        private MySqlDataReader leitor;
        private int selecao = 0;
        private string ordem;

        private void BTNPesquisar_Click(object sender, EventArgs e)
        {
            if (RDBListarProdutos.Checked == true)
            {
                limpar(selecao);
                selecao = 1;
                DGVRelatorios.Columns.Add("Codigo", "Codigo");
                DGVRelatorios.Columns.Add("Nome", "Nome");
                DGVRelatorios.Columns.Add("Categoria", "Categoria");
                DGVRelatorios.Columns.Add("Marca", "Marca");
                DGVRelatorios.Columns.Add("Fornecedor", "Fornecedor");
                if (RDBCodigo.Checked == true)
                {
                    ordem = "codigo";
                }
                else
                {
                    ordem = "nome";
                }
                listar_produtos(BDClass.AbrirConexao(), ordem);
            }
            else
            {
                if (RDBMarcas.Checked == true)
                {
                    limpar(selecao);
                    selecao = 2;
                    DGVRelatorios.Columns.Add("Marcas", "Marcas");
                    DGVRelatorios.Columns.Add("Fornecedor", "Fornecedor");
                    DGVRelatorios.Columns.Add("Preco_Custo", "Preço de Custo");
                    if (RDBCodigo.Checked == true)
                    {
                        ordem = "codigo";
                    }
                    else
                    {
                        ordem = "nome";
                    }
                    marcas(BDClass.AbrirConexao(), ordem);
                }
                else
                {
                    if (RDBProdutos_Falta.Checked == true)
                    {
                        limpar(selecao);
                        selecao = 3;
                        DGVRelatorios.Columns.Add("Codigo", "Código");
                        DGVRelatorios.Columns.Add("Nome", "Nome");
                        DGVRelatorios.Columns.Add("Fornecedor", "Fornecedor");
                        DGVRelatorios.Columns.Add("Categoria", "Categoria");
                        DGVRelatorios.Columns.Add("Quantidade", "Quantidade");
                        if (RDBCodigo.Checked == true)
                        {
                            ordem = "codigo";
                        }
                        else
                        {
                            ordem = "nome";
                        }
                        produtos_Falta(BDClass.AbrirConexao(), ordem);
                    }
                    else
                    {
                        if (RDBQuantidade_Produto.Checked == true)
                        {
                            limpar(selecao);
                            selecao = 4;
                            DGVRelatorios.Columns.Add("Codigo", "Codigo");
                            DGVRelatorios.Columns.Add("Nome", "Nome");
                            DGVRelatorios.Columns.Add("Quantidade", "Quantidade");
                            if (RDBCodigo.Checked == true)
                            {
                                ordem = "codigo";
                            }
                            else
                            {
                                ordem = "nome";
                            }
                            quantidade_Produtos(BDClass.AbrirConexao(), ordem);
                        }
                        else
                        {
                            if (RDBTabelaPreco_Produto.Checked == true)
                            {
                                limpar(selecao);
                                selecao = 5;
                                DGVRelatorios.Columns.Add("Nome", "Nome");
                                DGVRelatorios.Columns.Add("Preco_Custo", "Preço de Custo");
                                DGVRelatorios.Columns.Add("Preco_Final", "Preço Final");
                                if (RDBCodigo.Checked == true)
                                {
                                    ordem = "codigo";
                                }
                                else
                                {
                                    ordem = "nome";
                                }
                                tabela_Precos(BDClass.AbrirConexao(), ordem);
                            }
                            else
                            {
                                if (RDBFornecedor.Checked == true)
                                {
                                    limpar(selecao);
                                    selecao = 6;
                                    DGVRelatorios.Columns.Add("Cnpj", "CNPJ");
                                    DGVRelatorios.Columns.Add("Razao_Social", "Razão Social");
                                    DGVRelatorios.Columns.Add("Telefone", "Telefone");
                                    DGVRelatorios.Columns.Add("Email", "Email");
                                    DGVRelatorios.Columns.Add("Representante", "Representante");
                                    DGVRelatorios.Columns.Add("Rep_Fone", "Telefone do representante");
                                    DGVRelatorios.Columns.Add("Rep_Email", "Email do representante");
                                    if(RDBCodigo.Checked == true)
                                    {
                                        ordem = "codigo";
                                    }
                                    else
                                    {
                                        ordem = "nome";
                                    }
                                    Listar_fornecedor(BDClass.AbrirConexao(), ordem);
                                }
                                else
                                {
                                    if (RDBPedidos.Checked == true)
                                    {
                                        limpar(selecao);
                                        selecao = 7;
                                        DGVRelatorios.Columns.Add("Codigo", "Código");
                                        DGVRelatorios.Columns.Add("Produto", "Produto");
                                        DGVRelatorios.Columns.Add("Descricao", "Descrição");
                                        if (RDBCodigo.Checked == true)
                                        {
                                            ordem = "codigo";
                                        }
                                        else
                                        {
                                            ordem = "nome";
                                        }
                                        pedidos(BDClass.AbrirConexao(), ordem);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void Listar_fornecedor(MySqlConnection Conn, string ordem)
        {
            Conn.Open();
            int i;
            int j = 0;
            comando.Connection = Conn;
            comandoQuery.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT COUNT(*) FROM fornecedores";
                    comando.Prepare();
                    comandoQuery.Parameters.Clear();
                    if(ordem == "nome")
                    {
                        comandoQuery.CommandText = "SELECT * FROM fornecedores ORDER BY razao_social DESC";
                    }
                    else
                    {
                        comandoQuery.CommandText = "SELECT * FROM fornecedores ORDER BY cnpj DESC";
                    }
                    comandoQuery.Prepare();
                    j = int.Parse(comando.ExecuteScalar().ToString());
                    leitor = comandoQuery.ExecuteReader();
                    for (i = 0; i < j; i++)
                    {
                        while (leitor.Read())
                        {
                            this.DGVRelatorios.Rows.Insert(i, leitor.GetString("cnpj"), leitor.GetString("razao_social"), leitor.GetString("telefone"), leitor.GetString("email"), leitor.GetString("representante"), leitor.GetString("telefone_representante"), leitor.GetString("email_representante"));
                            TBCRelatorio.SelectedIndex = 1;
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
        public void produtos_Falta(MySqlConnection Conn, string ordem)
        {
            Conn.Open();
            int i;
            int j = 0;
            comando.Connection = Conn;
            comandoQuery.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT COUNT(*) FROM produtos";
                    comando.Prepare();
                    comandoQuery.Parameters.Clear();
                    if (ordem == "nome")
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos WHERE estoque_atual < estoque_minimo ORDER BY nome DESC";
                    }
                    else
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos WHERE estoque_atual < estoque_minimo ORDER BY codigo DESC";
                    }
                    comandoQuery.Prepare();
                    j = int.Parse(comando.ExecuteScalar().ToString());
                    leitor = comandoQuery.ExecuteReader();
                    for (i = 0; i < j; i++)
                    {
                        while (leitor.Read())
                        {
                            this.DGVRelatorios.Rows.Insert(i, leitor.GetString("codigo"), leitor.GetString("nome"), leitor.GetString("fornecedor"), leitor.GetString("categoria"), leitor.GetString("estoque_atual"));
                            TBCRelatorio.SelectedIndex = 1;
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
        public void listar_produtos(MySqlConnection Conn, string ordem)
        {
            Conn.Open();
            int i;
            int j = 0;
            comando.Connection = Conn;
            comandoQuery.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT COUNT(*) FROM produtos";
                    comando.Prepare();
                    comandoQuery.Parameters.Clear();
                    if (ordem == "nome")
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos ORDER BY nome DESC";
                    }
                    else
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos ORDER BY codigo DESC";
                    }
                    comandoQuery.Prepare();
                    j = int.Parse(comando.ExecuteScalar().ToString());
                    leitor = comandoQuery.ExecuteReader();
                    for (i = 0; i < j; i++)
                    {
                        while (leitor.Read())
                        {
                            this.DGVRelatorios.Rows.Insert(i, leitor.GetString("codigo"), leitor.GetString("nome"), leitor.GetString("categoria"), leitor.GetString("marca"), leitor.GetString("fornecedor"));
                            TBCRelatorio.SelectedIndex = 1;
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
        public void tabela_Precos(MySqlConnection Conn, string ordem)
        {
            Conn.Open();
            int i;
            int j = 0;
            comando.Connection = Conn;
            comandoQuery.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT COUNT(*) FROM produtos";
                    comando.Prepare();
                    comandoQuery.Parameters.Clear();
                    if (ordem == "nome")
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos ORDER BY nome DESC";
                    }
                    else
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos ORDER BY codigo DESC";
                    }
                    comandoQuery.Prepare();
                    j = int.Parse(comando.ExecuteScalar().ToString());
                    leitor = comandoQuery.ExecuteReader();
                    for (i = 0; i < j; i++)
                    {
                        while (leitor.Read())
                        {
                            this.DGVRelatorios.Rows.Insert(i, leitor.GetString("nome"), leitor.GetString("preco_custo"), leitor.GetString("preco_final"));
                            TBCRelatorio.SelectedIndex = 1;
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
        public void quantidade_Produtos(MySqlConnection Conn, string ordem)
        {
            Conn.Open();
            int i;
            int j = 0;
            comando.Connection = Conn;
            comandoQuery.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT COUNT(*) FROM produtos";
                    comando.Prepare();
                    comandoQuery.Parameters.Clear();
                    if (ordem == "nome")
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos ORDER BY nome DESC";
                    }
                    else
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos ORDER BY codigo DESC";
                    }
                    comandoQuery.Prepare();
                    j = int.Parse(comando.ExecuteScalar().ToString());
                    leitor = comandoQuery.ExecuteReader();
                    for (i = 0; i < j; i++)
                    {
                        while (leitor.Read())
                        {
                            this.DGVRelatorios.Rows.Insert(i, leitor.GetString("codigo"), leitor.GetString("nome"), leitor.GetString("estoque_atual"));
                            TBCRelatorio.SelectedIndex = 1;
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
        public void marcas(MySqlConnection Conn, string ordem)
        {
            Conn.Open();
            int i;
            int j = 0;
            comando.Connection = Conn;
            comandoQuery.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT COUNT(*) FROM produtos";
                    comando.Prepare();
                    comandoQuery.Parameters.Clear();
                    if (ordem == "nome")
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos ORDER BY nome DESC";
                    }
                    else
                    {
                        comandoQuery.CommandText = "SELECT * FROM produtos ORDER BY codigo DESC";
                    }
                    comandoQuery.Prepare();
                    j = int.Parse(comando.ExecuteScalar().ToString());
                    leitor = comandoQuery.ExecuteReader();
                    for (i = 0; i < j; i++)
                    {
                        while (leitor.Read())
                        {
                            this.DGVRelatorios.Rows.Insert(i, leitor.GetString("marca"), leitor.GetString("fornecedor"), leitor.GetString("preco_custo"));
                            TBCRelatorio.SelectedIndex = 1;
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
        public void pedidos(MySqlConnection Conn, string ordem)
        {
            Conn.Open();
            int i;
            int j = 0;
            comando.Connection = Conn;
            comandoQuery.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT COUNT(*) FROM pedido_produtos";
                    comando.Prepare();
                    comandoQuery.Parameters.Clear();
                    if (ordem == "nome")
                    {
                        comandoQuery.CommandText = "SELECT * FROM pedido_produtos ORDER BY nome DESC";
                    }
                    else
                    {
                        comandoQuery.CommandText = "SELECT * FROM pedido_produtos ORDER BY idpedido_produtos DESC";
                    }
                    comandoQuery.Prepare();
                    j = int.Parse(comando.ExecuteScalar().ToString());
                    leitor = comandoQuery.ExecuteReader();
                    for (i = 0; i < j; i++)
                    {
                        while (leitor.Read())
                        {
                            this.DGVRelatorios.Rows.Insert(i, leitor.GetString("idpedido_produtos"), leitor.GetString("nome"), leitor.GetString("descricao"));
                            TBCRelatorio.SelectedIndex = 1;
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
        public void limpar(int codigo)
        {
            ordem = null;
            switch (codigo)
            {
                case 1:
                    DGVRelatorios.Columns.Remove("Codigo");
                    DGVRelatorios.Columns.Remove("Nome");
                    DGVRelatorios.Columns.Remove("Categoria");
                    DGVRelatorios.Columns.Remove("Marca");
                    DGVRelatorios.Columns.Remove("Fornecedor");
                    break;
                case 2:
                    DGVRelatorios.Columns.Remove("Marcas");
                    DGVRelatorios.Columns.Remove("Fornecedor");
                    DGVRelatorios.Columns.Remove("Preco_custo");
                    break;
                case 3:
                    DGVRelatorios.Columns.Remove("Codigo");
                    DGVRelatorios.Columns.Remove("Nome");
                    DGVRelatorios.Columns.Remove("Fornecedor");
                    DGVRelatorios.Columns.Remove("Categoria");
                    DGVRelatorios.Columns.Remove("Quantidade");
                    break;
                case 4:
                    DGVRelatorios.Columns.Remove("Codigo");
                    DGVRelatorios.Columns.Remove("Nome");
                    DGVRelatorios.Columns.Remove("Quantidade");
                    break;
                case 5:
                    DGVRelatorios.Columns.Remove("Nome");
                    DGVRelatorios.Columns.Remove("Preco_Custo");
                    DGVRelatorios.Columns.Remove("Preco_Final");
                    break;
                case 6:
                    DGVRelatorios.Columns.Remove("Cnpj");
                    DGVRelatorios.Columns.Remove("Razao_Social");
                    DGVRelatorios.Columns.Remove("Telefone");
                    DGVRelatorios.Columns.Remove("Email");
                    DGVRelatorios.Columns.Remove("Representante");
                    DGVRelatorios.Columns.Remove("Rep_Fone");
                    DGVRelatorios.Columns.Remove("Rep_Email");
                    break;
                case 7:
                    DGVRelatorios.Columns.Remove("Codigo");
                    DGVRelatorios.Columns.Remove("Produto");
                    DGVRelatorios.Columns.Remove("Descricao");
                    break;
                case 0:
                    break;
            }
        }

        private void BTNSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(button2, "Voltar para tela principal");
        }

        private void BTNImprimir_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNImprimir, "Imprimir Relatório");
        }

        private void BTNSair_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNSair, "Voltar para a Tela Principal");
        }

        private void BTNPesquisar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNPesquisar, "Gerar relatório");
        }
    }
}

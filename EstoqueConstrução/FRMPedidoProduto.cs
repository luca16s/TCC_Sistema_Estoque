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
    public partial class FRMPedidoProduto : Form
    {
        public FRMPedidoProduto()
        {
            InitializeComponent();
        }
        ToolTip MytoolTip = new ToolTip();
        ConexaoBD BDClass = new ConexaoBD();
        Variaveis variaveis = new Variaveis();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        protected Boolean tipo_Codigo = false;

        private void BTNLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void BTNSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNExcluir_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Tem certeza que deseja excluir este pedido?", "Exclusão de pedido.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (escolha == DialogResult.Yes)
            {
                excluir(BDClass.AbrirConexao(), TXTProduto.Text);
                limpar();
            }
        }

        private void BTNPesquisar_Click(object sender, EventArgs e)
        {
            string codigo = Microsoft.VisualBasic.Interaction.InputBox("Insira o código para pesquisar:", "Pesquisa", "");
            pesquisar(BDClass.AbrirConexao(), codigo);
        }

        private void BTNSalvar_Click(object sender, EventArgs e)
        {
            inserir(BDClass.AbrirConexao(), TXTProduto.Text, TXTDescrição.Text);
            limpar();
        }

        public void excluir(MySqlConnection Conn, string codigo)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "DELETE from pedido_produtos WHERE nome = @codigo";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Pedido excluido com sucesso.");
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

        public void inserir(MySqlConnection Conn, string nome, string descricao)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "Insert into pedido_produtos (nome, descricao) values (@nome, @descricao)";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@descricao", descricao);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Pedido solicitado com sucesso.");
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

        public void pesquisar(MySqlConnection Conn, string codigo)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT * FROM pedido_produtos WHERE idpedido_produtos = @codigo";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    leitor = comando.ExecuteReader();
                    if (leitor.HasRows)
                    {
                        while (leitor.Read())
                        {
                            TXTProduto.Text = leitor.GetString("nome");
                            TXTDescrição.Text = leitor.GetString("descricao");
                            BTNSalvar.Enabled = true;
                            BTNExcluir.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sua pesquisa não retornou resultados.");
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

        public void limpar()
        {
            TXTDescrição.Text = null;
            TXTProduto.Text = null;
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

        private void TXTDescrição_Leave(object sender, EventArgs e)
        {
            if(TXTDescrição.Text == "")
            {
                LBLDescricao.Visible = true;
                TXTDescrição.Focus();
            }
            else
            {
                LBLDescricao.Visible = false;
            }
        }

        private void BTNSalvar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNSalvar, "Inserir pedido");
        }

        private void BTNPesquisar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNPesquisar, "Pesquisar pedido");
        }

        private void BTNExcluir_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNExcluir,  "Excluir pedido atual");
        }

        private void BTNLimpar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNLimpar, "Limpar campos");
        }

        private void BTNSair_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNSair, "Voltar para a tela principal");
        }
    }
}

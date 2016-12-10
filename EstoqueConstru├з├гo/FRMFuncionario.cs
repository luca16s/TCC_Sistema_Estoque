using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Estoque_Material_Construção
{
    public partial class FRMFuncionario : Form
    {
        ConexaoBD BDClass = new ConexaoBD();
        Variaveis variaveis = new Variaveis();
        protected string permissao = "";
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        ToolTip MytoolTip = new ToolTip();
        protected Boolean tipo_Codigo = false;
        public FRMFuncionario()
        {
            InitializeComponent();
        }

        private void BTNCadastrar_Click(object sender, EventArgs e)
        {
            variaveis.VarFuncionario(MTXCPF.Text, TXTNome.Text, TXTLogin.Text, TXTSenha.Text, MTXIdentidade.Text, MTXAniversario.Text, TXTEndereco.Text, MTXCep.Text, TXTComplemento.Text, TXTCidade.Text, CBXUF.Text, MTXTelefone.Text, MTXCelular.Text, TXTEmail.Text, permissao);
                if (RDBMestre.Checked == true)
                {
                    permissao = "mestre";
                }
                if (RDBFuncionario.Checked == true)
                {
                    permissao = "funcionario";
                }

                if (tipo_Codigo == false)
                {
                    InserirFuncionario(BDClass.AbrirConexao(), variaveis.Cpf, variaveis.Nome, variaveis.Login, variaveis.Senha, variaveis.Identidade, variaveis.Nascimento, variaveis.Endereco, variaveis.Cep, variaveis.Complemento, variaveis.Cidade, variaveis.Uf, variaveis.Telefone, variaveis.Celular, variaveis.Email, variaveis.Permissao);
                    limpar();
                }
                else
                if (tipo_Codigo == true)
                {
                    EditarFuncionario(BDClass.AbrirConexao(), variaveis.Cpf, variaveis.Nome, variaveis.Login, variaveis.Senha, variaveis.Identidade, variaveis.Nascimento, variaveis.Endereco, variaveis.Cep, variaveis.Complemento, variaveis.Cidade, variaveis.Uf, variaveis.Telefone, variaveis.Celular, variaveis.Email, variaveis.Permissao);
                    limpar();
                }
            tipo_Codigo = false;
        }

        private void BTNPesquisar_Click(object sender, EventArgs e)
        {
            LBLNomeImp.Visible = false;
            string codigo = Microsoft.VisualBasic.Interaction.InputBox("Insira um nome ou CPF para pesquisar:", "Pesquisa", "");
            PesquisarFuncionarios(BDClass.AbrirConexao(), codigo);
            BTNCadastrar.Enabled = true;
            BTNExcluir.Enabled = true;
            tipo_Codigo = true;
        }

        private void BTNVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TXTNome_Leave(object sender, EventArgs e)
        {
            if(TXTNome.Text == "")
            {
                LBLNomeImp.Visible = true;
                BTNCadastrar.Enabled = false;
                TXTNome.Focus();
            }
            else
            {
                LBLNomeImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void MTXCPF_Leave(object sender, EventArgs e)
        {
            if (MTXCPF.Text == "")
            {
                LBLCpfImp.Visible = true;
                BTNCadastrar.Enabled = false;
                MTXCPF.Focus();
            }
            else
            {
                LBLCpfImp.Visible = false;
                BTNCadastrar.Enabled = true;
                if (ValidaCPF(MTXCPF.Text) == false)
                {
                    MessageBox.Show("CPF inválido.","Verificador de CPF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MTXCPF.Text = "";
                    MTXCPF.Focus();
                }
            }
        }

        private void TXTLogin_Leave(object sender, EventArgs e)
        {
            if (TXTLogin.Text == "")
            {
                LBLLoginImp.Visible = true;
                BTNCadastrar.Enabled = false;
                TXTLogin.Focus();
            }
            else
            {
                LBLLoginImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void TXTSenha_Leave(object sender, EventArgs e)
        {
            if (TXTSenha.Text == "")
            {
                LBLSenhaImp.Visible = true;
                BTNCadastrar.Enabled = false;
                TXTSenha.Focus();
            }
            else
            {
                LBLSenhaImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void MTXIdentidade_Leave(object sender, EventArgs e)
        {
            if (MTXIdentidade.Text == "")
            {
                LBLIdentidadeImp.Visible = true;
                BTNCadastrar.Enabled = false;
                MTXIdentidade.Focus();
            }
            else
            {
                LBLIdentidadeImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void MTXAniversario_Leave(object sender, EventArgs e)
        {
            if (MTXAniversario.Text == "")
            {
                LBLDataImp.Visible = true;
                BTNCadastrar.Enabled = false;
                MTXAniversario.Focus();
            }
            else
            {
                LBLDataImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void BTNLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void BTNExcluir_Click(object sender, EventArgs e)
        {
            variaveis.Cpf = MTXCPF.Text;
                DialogResult escolha = MessageBox.Show("Tem certeza que deseja excluir este usuário?", "Exclusão de funcionários.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(escolha == DialogResult.Yes)
                    {
                        ExcluirFuncionario(BDClass.AbrirConexao(), variaveis.Cpf);
                        limpar();
                    }
        }

        private void limpar()
        {
            TXTNome.Text = "";
            TXTSenha.Text = "";
            TXTLogin.Text = "";
            TXTEmail.Text = "";
            TXTCidade.Text = "";
            TXTEndereco.Text = "";
            MTXTelefone.Text = "";
            MTXAniversario.Text = "";
            MTXCelular.Text = "";
            MTXCep.Text = "";
            MTXCPF.Text = "";
            TXTComplemento.Text = "";
            MTXIdentidade.Text = "";
            MTXTelefone.Text = "";
            RDBMestre.Checked = false;
            RDBFuncionario.Checked = false;
            BTNCadastrar.Enabled = false;
            BTNExcluir.Enabled = false;
            CBXUF.Text = "";
        }

        public void InserirFuncionario(MySqlConnection Conn, string cpf, string nome, string login, string senha, string identidade, string aniversario, string endereco, string cep, string complemento, string cidade, string uf, string telefone, string celular, string email, string permissao)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "Insert into funcionarios values (@cpf, @nome, @login, @senha, @Identidade, @Nascimento, @Endereco, @CEP, @Complemento, @Cidade, @UF, @Telefone, @Celular, @Email, @Permissao)";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@senha", senha);
                    comando.Parameters.AddWithValue("@identidade", identidade);
                    comando.Parameters.AddWithValue("@Nascimento", aniversario);
                    comando.Parameters.AddWithValue("@Endereco", endereco);
                    comando.Parameters.AddWithValue("@CEP", cep);
                    comando.Parameters.AddWithValue("@Complemento", complemento);
                    comando.Parameters.AddWithValue("@Cidade", cidade);
                    comando.Parameters.AddWithValue("@UF", uf);
                    comando.Parameters.AddWithValue("@Telefone", telefone);
                    comando.Parameters.AddWithValue("@Celular", celular);
                    comando.Parameters.AddWithValue("@Email", email);
                    comando.Parameters.AddWithValue("@Permissao", permissao);
                    comando.ExecuteNonQuery();
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
        public void PesquisarFuncionarios(MySqlConnection Conn, string codigo)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    if (Regex.IsMatch(codigo, @"^[ a-zA-Z á é í ó ã]*$"))
                    {
                        comando.CommandText = "SELECT * FROM funcionarios WHERE nome = @codigo";
                    }
                    else
                    {
                        comando.CommandText = "SELECT * FROM funcionarios WHERE cpf = @codigo";
                    }
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo.Replace(".", "").Replace("-", ""));
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        TXTNome.Text = leitor.GetString("nome");
                        MTXCPF.Text = leitor.GetString("cpf");
                        MTXTelefone.Text = leitor.GetString("telefone");
                        MTXIdentidade.Text = leitor.GetString("identidade");
                        TXTLogin.Text = leitor.GetString("login");
                        TXTSenha.Text = leitor.GetString("senha");
                        TXTEndereco.Text = leitor.GetString("endereco");
                        TXTEmail.Text = leitor.GetString("email");
                        TXTComplemento.Text = leitor.GetString("complemento");
                        TXTCidade.Text = leitor.GetString("cidade");
                        CBXUF.Text = leitor.GetString("uf");
                        MTXCep.Text = leitor.GetString("cep");
                        MTXAniversario.Text = leitor.GetString("aniversario");
                        MTXCelular.Text = leitor.GetString("celular");
                        if (leitor.GetString("permissao") == "mestre")
                        {
                            RDBMestre.Checked = true;
                        }
                        else
                        {
                            RDBFuncionario.Checked = true;
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
        public void ExcluirFuncionario(MySqlConnection Conn, string cpf)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "DELETE from funcionarios WHERE cpf = @cpf";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.ExecuteNonQuery();
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
                MessageBox.Show("Funcionário não selecionado.");
            }
        }
        public void EditarFuncionario(MySqlConnection Conn, string cpf, string nome, string login, string senha, string identidade, string aniversario, string endereco, string cep, string complemento, string cidade, string uf, string telefone, string celular, string email, string permissao)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "UPDATE funcionarios set nome = @nome, login = @login, senha = @senha, identidade = @Identidade, aniversario = @Nascimento, endereco = @Endereco, cep = @CEP, complemento = @Complemento, cidade = @Cidade, uf = @UF, telefone = @Telefone, celular = @Celular, email = @Email, permissao = @Permissao WHERE cpf = @cpf";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@senha", senha);
                    comando.Parameters.AddWithValue("@identidade", identidade);
                    comando.Parameters.AddWithValue("@Nascimento", aniversario);
                    comando.Parameters.AddWithValue("@Endereco", endereco);
                    comando.Parameters.AddWithValue("@CEP", cep);
                    comando.Parameters.AddWithValue("@Complemento", complemento);
                    comando.Parameters.AddWithValue("@Cidade", cidade);
                    comando.Parameters.AddWithValue("@UF", uf);
                    comando.Parameters.AddWithValue("@Telefone", telefone);
                    comando.Parameters.AddWithValue("@Celular", celular);
                    comando.Parameters.AddWithValue("@Email", email);
                    comando.Parameters.AddWithValue("@Permissao", permissao);
                    comando.ExecuteNonQuery();
                    limpar();
                    PesquisarFuncionarios(BDClass.AbrirConexao(), cpf);
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

        private void TXTEndereco_Leave(object sender, EventArgs e)
        {
            if (TXTEndereco.Text == "")
            {
                LBLEnderecoImp.Visible = true;
                BTNCadastrar.Enabled = false;
                TXTEndereco.Focus();
            }
            else
            {
                LBLEnderecoImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void MTXCep_Leave(object sender, EventArgs e)
        {
            if (MTXCep.Text == "")
            {
                LBLCepImp.Visible = true;
                BTNCadastrar.Enabled = false;
                MTXCep.Focus();
            }
            else
            {
                LBLCepImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void TXTComplemento_Leave(object sender, EventArgs e)
        {
            if (TXTComplemento.Text == "")
            {
                LBLComplementoImp.Visible = true;
                BTNCadastrar.Enabled = false;
                TXTComplemento.Focus();
            }
            else
            {
                LBLComplementoImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void TXTCidade_Leave(object sender, EventArgs e)
        {
            if (TXTCidade.Text == "")
            {
                LBLCidadeImp.Visible = true;
                BTNCadastrar.Enabled = false;
                TXTCidade.Focus();
            }
            else
            {
                LBLCidadeImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void CBXUF_Leave(object sender, EventArgs e)
        {
            if (CBXUF.Text == "")
            {
                LBLUfImp.Visible = true;
                BTNCadastrar.Enabled = false;
                CBXUF.Focus();
            }
            else
            {
                LBLUfImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void MTXTelefone_Leave(object sender, EventArgs e)
        {
            if (MTXTelefone.Text == "")
            {
                LBLTelefoneImp.Visible = true;
                BTNCadastrar.Enabled = false;
                MTXTelefone.Focus();
            }
            else
            {
                LBLTelefoneImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void MTXCelular_Leave(object sender, EventArgs e)
        {
            if (MTXCelular.Text == "")
            {
                LBLCelularImp.Visible = true;
                BTNCadastrar.Enabled = false;
                MTXCelular.Focus();
            }
            else
            {
                LBLCelularImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void TXTEmail_Leave(object sender, EventArgs e)
        {
            if (TXTEmail.Text == "")
            {
                LBLEmailImp.Visible = true;
                BTNCadastrar.Enabled = false;
                TXTEmail.Focus();
            }
            else
            {
                LBLEmailImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void RDBMestre_Leave(object sender, EventArgs e)
        {
            if (RDBMestre.Checked == false && RDBFuncionario.Checked == false)
            {
                LBLPermissaoImp.Visible = true;
                BTNCadastrar.Enabled = false;
                RDBMestre.Focus();
            }
            else
            {
                LBLPermissaoImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void RDBFuncionario_Leave(object sender, EventArgs e)
        {
            if (RDBMestre.Checked == false && RDBFuncionario.Checked == false)
            {
                LBLPermissaoImp.Visible = true;
                BTNCadastrar.Enabled = false;
                RDBFuncionario.Focus();
            }
            else
            {
                LBLPermissaoImp.Visible = false;
                BTNCadastrar.Enabled = true;
            }
        }

        private void BTNCadastrar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNCadastrar, "Cadastrar novo funcionário");
        }

        private void BTNPesquisar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNPesquisar, "Pesquisar um funcionário");
        }

        private void BTNLimpar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNLimpar, "Limpar campos");
        }

        private void BTNExcluir_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNExcluir, "Excluir funcionário atual");
        }

        private void BTNVoltar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNVoltar, "Voltar para tela principal");
        }
    }
}

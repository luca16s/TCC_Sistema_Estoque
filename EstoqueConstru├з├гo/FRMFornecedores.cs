using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque_Material_Construção
{
    public partial class FRMFornecedores : Form
    {

        ConexaoBD BDClass = new ConexaoBD();
        Variaveis variaveis = new Variaveis();
        protected string permissao = "";
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        protected Boolean tipo_Codigo = false;
        ToolTip MytoolTip = new ToolTip();

        public FRMFornecedores()
        {
            InitializeComponent();
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

        private void BTNSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNSalvar_Click(object sender, EventArgs e)
        {
            variaveis.VarFornecedor(MTXCNPJ.Text, TXTFantasia.Text, TXTSocial.Text, MTXIE.Text, MTXTelefone.Text, TXTEmail.Text, TXTEndereco.Text, MTXCep.Text, TXTComplemento.Text, TXTBairro.Text, TXTCidade.Text, CBXUF.Text, TXTRepresentante.Text, MTXTelefone_Rep.Text, TXTEmail_Rep.Text, MTXCelular_Rep.Text, TXTObservacoes.Text);
            if (tipo_Codigo == false)
                {
                    InserirFornecedor(BDClass.AbrirConexao(), variaveis.Cnpj, variaveis.Fantasia, variaveis.Social, variaveis.IE, variaveis.Telefone_Empresa, variaveis.Email_Empresa, variaveis.Endereco_Empresa, variaveis.Cep_Empresa, variaveis.Complemento_Empresa, variaveis.Bairro_Empresa, variaveis.Cidade_Empresa, variaveis.Uf_Empresa, variaveis.Representante, variaveis.Telefone_Representante, variaveis.Email_Representante, variaveis.Celular_Representante, variaveis.Obs);
                    limpar();
                }
                else
                if (tipo_Codigo == true)
                {
                    EditarFornecedor(BDClass.AbrirConexao(), variaveis.Cnpj, variaveis.Fantasia, variaveis.Social, variaveis.IE, variaveis.Telefone_Empresa, variaveis.Email_Empresa, variaveis.Endereco_Empresa, variaveis.Cep_Empresa, variaveis.Complemento_Empresa, variaveis.Bairro_Empresa, variaveis.Cidade_Empresa, variaveis.Uf_Empresa, variaveis.Representante, variaveis.Telefone_Representante, variaveis.Email_Representante, variaveis.Celular_Representante, variaveis.Obs);
                    limpar();
                }
            tipo_Codigo = false;
        }

        private void BTNPesquisar_Click(object sender, EventArgs e)
        {
            string codigo = Microsoft.VisualBasic.Interaction.InputBox("Insira o CNPJ para pesquisar:", "Pesquisa", "");
            PesquisarFornecedor(BDClass.AbrirConexao(), codigo);
            BTNSalvar.Enabled = true;
            BTNExcluir.Enabled = true;
            tipo_Codigo = true;
        }

        private void BTNLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void BTNExcluir_Click(object sender, EventArgs e)
        {
            variaveis.Cnpj = MTXCNPJ.Text;
            DialogResult escolha = MessageBox.Show("Tem certeza que deseja excluir este Fornecedor?", "Exclusão de fornecedor.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (escolha == DialogResult.Yes)
            {
                //MessageBox.Show(variaveis.Cnpj);
                ExcluirFornecedor(BDClass.AbrirConexao(), variaveis.Cnpj.Replace("-", "").Replace(".", "").Replace("/", ""));
                limpar();
            }
        }

        private void limpar()
        {
            MTXTelefone.Text = "";
            MTXCelular_Rep.Text = "";
            MTXCNPJ.Text = "";
            MTXIE.Text = "";
            MTXTelefone_Rep.Text = "";
            TXTSocial.Text = "";
            TXTRepresentante.Text = "";
            TXTObservacoes.Text = "";
            TXTFantasia.Text = "";
            TXTEndereco.Text = "";
            TXTEmail_Rep.Text = "";
            TXTEmail.Text = "";
            TXTComplemento.Text = "";
            TXTCidade.Text = "";
            MTXCep.Text = "";
            TXTBairro.Text = "";
            BTNSalvar.Enabled = false;
            BTNExcluir.Enabled = false;
            CBXUF.Text = "";
        }

        public void InserirFornecedor(MySqlConnection Conn, string cnpj, string nome_fantasia, string razao_social, string ie, string telefone, string email, string endereco, string cep, string complemento, string bairro, string cidade, string uf, string representante, string telefone_representante, string email_representante, string celular_representante, string observacoes)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "Insert into fornecedores values (@cnpj, @nome_fantasia, @razao_social, @ie, @telefone, @email, @endereco, @cep, @complemento, @bairro, @cidade, @uf, @Representante, @telefone_representante, @email_representante, @celular_representante, @observacoes)";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@cnpj", cnpj);
                    comando.Parameters.AddWithValue("@nome_fantasia", nome_fantasia);
                    comando.Parameters.AddWithValue("@razao_social", razao_social);
                    comando.Parameters.AddWithValue("@ie", ie);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@endereco", endereco);
                    comando.Parameters.AddWithValue("@cep", cep);
                    comando.Parameters.AddWithValue("@complemento", complemento);
                    comando.Parameters.AddWithValue("@bairro", bairro);
                    comando.Parameters.AddWithValue("@cidade", cidade);
                    comando.Parameters.AddWithValue("@uf", uf);
                    comando.Parameters.AddWithValue("@representante", representante);
                    comando.Parameters.AddWithValue("@telefone_representante", telefone_representante);
                    comando.Parameters.AddWithValue("@email_representante", email_representante);
                    comando.Parameters.AddWithValue("@celular_representante", celular_representante);
                    comando.Parameters.AddWithValue("@observacoes", observacoes);
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
        public void PesquisarFornecedor(MySqlConnection Conn, string codigo)
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
                        comando.CommandText = "SELECT * FROM fornecedores WHERE razao_social = @codigo";
                    }
                    else
                    {
                        comando.CommandText = "SELECT * FROM fornecedores WHERE cnpj = @codigo";
                    }
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo.Replace("-", "").Replace("/", "").Replace(".", ""));
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        MTXTelefone.Text = leitor.GetString("telefone");
                        MTXCelular_Rep.Text = leitor.GetString("celular_representante");
                        MTXCNPJ.Text = leitor.GetString("cnpj");
                        MTXIE.Text = leitor.GetString("ie");
                        MTXTelefone_Rep.Text = leitor.GetString("telefone_representante");
                        TXTSocial.Text = leitor.GetString("razao_social");
                        TXTRepresentante.Text = leitor.GetString("representante");
                        TXTObservacoes.Text = leitor.GetString("observacoes");
                        TXTFantasia.Text = leitor.GetString("nome_fantasia");
                        TXTEndereco.Text = leitor.GetString("endereco");
                        TXTEmail_Rep.Text = leitor.GetString("email_representante");
                        TXTEmail.Text = leitor.GetString("email");
                        TXTComplemento.Text = leitor.GetString("complemento");
                        TXTCidade.Text = leitor.GetString("cidade");
                        MTXCep.Text = leitor.GetString("cep");
                        TXTBairro.Text = leitor.GetString("bairro");
                        CBXUF.Text = leitor.GetString("uf");
                        BTNSalvar.Enabled = true;
                        BTNExcluir.Enabled = true;
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
        public void ExcluirFornecedor(MySqlConnection Conn, string cnpj)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "DELETE from fornecedores WHERE cnpj = @cnpj";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@cnpj", cnpj);
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
                MessageBox.Show("Fornecedor não selecionado.");
            }
        }
        public void EditarFornecedor(MySqlConnection Conn, string cnpj, string nome_fantasia, string razao_social, string ie, string telefone, string email, string endereco, string cep, string complemento, string bairro, string cidade, string uf, string representante, string telefone_representante, string email_representante, string celular_representante, string observacoes)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "UPDATE fornecedores set cnpj = @cnpj, nome_fantasia = @nome_fantasia, razao_social = @razao_social, ie = @ie, telefone = @telefone, email = @email, endereco = @endereco, cep = @cep, complemento = @complemento, bairro = @bairro, cidade = @cidade, uf = @uf, representante = @representante, telefone_representante = @telefone_representante, email_representante = @email_representante, celular_representante = @celular_representante, observacoes = @observacoes WHERE cnpj = @cnpj";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@cnpj", cnpj);
                    comando.Parameters.AddWithValue("@nome_fantasia", nome_fantasia);
                    comando.Parameters.AddWithValue("@razao_social", razao_social);
                    comando.Parameters.AddWithValue("@ie", ie);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@endereco", endereco);
                    comando.Parameters.AddWithValue("@cep", cep);
                    comando.Parameters.AddWithValue("@complemento", complemento);
                    comando.Parameters.AddWithValue("@bairro", bairro);
                    comando.Parameters.AddWithValue("@cidade", cidade);
                    comando.Parameters.AddWithValue("@uf", uf);
                    comando.Parameters.AddWithValue("@representante", representante);
                    comando.Parameters.AddWithValue("@telefone_representante", telefone_representante);
                    comando.Parameters.AddWithValue("@email_representante", email_representante);
                    comando.Parameters.AddWithValue("@celular_representante", celular_representante);
                    comando.Parameters.AddWithValue("@observacoes", observacoes);
                    comando.ExecuteNonQuery();
                    limpar();
                    PesquisarFornecedor(BDClass.AbrirConexao(), cnpj);
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
        public static bool ValidaCNPJ(string vrCNPJ)
        {
            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");
            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;
            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;
            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                        CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig + 1, 1)));
                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig, 1)));
                }
                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (
                         resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == (
                        11 - resultado[nrDig]));
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }

        private void MTXCNPJ_Leave(object sender, EventArgs e)
        {
            if (MTXCNPJ.Text == "")
            {
                LBLCNPJ.Visible = true;
                BTNSalvar.Enabled = false;
                MTXCNPJ.Focus();
            }
            else
            {
                BTNSalvar.Enabled = true;
                if (ValidaCNPJ(MTXCNPJ.Text) == false)
                {
                    MessageBox.Show("CNPJ inválido.", "Verificador de CNPJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MTXCNPJ.Text = "";
                    LBLCNPJ.Visible = true;
                    MTXCNPJ.Focus();
                }
                else
                {
                    LBLCNPJ.Visible = false;
                }
            }
        }

        private void BTNSalvar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNSalvar, "Botão para cadastrar ou editar Fornecedores.");
        }

        private void BTNPesquisar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNPesquisar, "Botão para pesquisar Fornecedores.");
        }

        private void BTNLimpar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNLimpar, "Botão para limpar os campos do formulário Fornecedores.");
        }

        private void BTNExcluir_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNExcluir, "Botão para excluir Fornecedores.");
        }

        private void TXTSocial_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTSocial, "Campo de nome jurídico da empresa.");
        }

        private void MTXCNPJ_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(MTXCNPJ, "CNPJ da empresa.");
        }

        private void MTXIE_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(MTXIE, "Inscrição estadual da empresa.");
        }

        private void MTXTelefone_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(MTXTelefone, "Telefone da empresa.");
        }

        private void TXTEmail_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTEmail, "Email da empresa.");
        }

        private void TXTEndereco_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTEndereco, "Endreço da Empresa.");
        }

        private void MTXCep_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(MTXCep, "Código de endereçamento postal da empresa.");
        }

        private void TXTComplemento_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTComplemento, "Informações adicionais sobre endereço.");
        }

        private void TXTBairro_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTBairro, "Bairro da empresa.");
        }

        private void TXTCidade_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTCidade, "Cidade onde está localizada a empresa.");
        }

        private void CBXUF_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(CBXUF, "Estado da empresa.");
        }

        private void TXTRepresentante_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTRepresentante, "Nome do representante da empresa.");
        }

        private void MTXTelefone_Rep_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(MTXTelefone_Rep, "Telefone do representante.");
        }

        private void TXTEmail_Rep_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTEmail_Rep, "Email do representante.");
        }

        private void MTXCelular_Rep_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(MTXCelular_Rep, "Celular do representante.");
        }

        private void TXTObservacoes_MouseLeave(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTObservacoes, "Observações adicionais sobre a empresa ou o representante.");
        }

        private void TXTFantasia_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(TXTFantasia, "Local para inserir o nome amigável da Empresa.");
        }

        private void TXTSocial_Leave(object sender, EventArgs e)
        {
            if ((TXTSocial.Text == string.Empty))
            {
                LBLSocial.Visible = true;
                TXTSocial.Focus();
            }
            else
            {
                LBLSocial.Visible = false;
            }
        }

        private void TXTFantasia_Leave(object sender, EventArgs e)
        {
            if ((TXTFantasia.Text == string.Empty))
            {
                LBLFantasia.Visible = true;
                TXTFantasia.Focus();
            }
            else
            {
                LBLFantasia.Visible = false;
            }
        }

        private void MTXIE_Leave(object sender, EventArgs e)
        {
            if ((MTXIE.Text == string.Empty))
            {
                LBLIE.Visible = true;
                MTXIE.Focus();
            }
            else
            {
                LBLIE.Visible = false;
            }
        }

        private void TXTEndereco_Leave(object sender, EventArgs e)
        {
            if ((TXTEndereco.Text == string.Empty))
            {
                LBLEndereco.Visible = true;
                TXTEndereco.Focus();
            }
            else
            {
                LBLEndereco.Visible = false;
            }
        }

        private void MTXCep_Leave(object sender, EventArgs e)
        {
            if ((MTXCep.Text.Replace("-","") == string.Empty))
            {
                LBLCep.Visible = true;
                MTXCep.Focus();
            }
            else
            {
                LBLCep.Visible = false;
            }
        }

        private void MTXTelefone_Leave(object sender, EventArgs e)
        {
            if(MTXTelefone.Text.Replace("(","").Replace(")", "").Replace("-", "").Replace("_","") == "")
            {
                LBLTelefone.Visible = true;
                MTXTelefone.Focus();
            }
            else
            {
                LBLTelefone.Visible = false;
            }
        }

        private void TXTEmail_Leave(object sender, EventArgs e)
        {
            if(TXTEmail.Text == "")
            {
                LBLEmail.Visible = true;
                TXTEmail.Focus();
            }
            else
            {
                LBLEmail.Visible = false;
            }
        }

        private void TXTBairro_Leave(object sender, EventArgs e)
        {
            if ((TXTBairro.Text == string.Empty))
            {
                LBLBairro.Visible = true;
                TXTBairro.Focus();
            }
            else
            {
                LBLBairro.Visible = false;
            }
        }

        private void TXTCidade_Leave(object sender, EventArgs e)
        {
            if(TXTCidade.Text == "")
            {
                LBLCidade.Visible = true;
                TXTCidade.Focus();
            }
            else
            {
                LBLCidade.Visible = false;
            }
        }

        private void CBXUF_Leave(object sender, EventArgs e)
        {
            if ((CBXUF.Text == string.Empty))
            {
                LBLUf.Visible = true;
                CBXUF.Focus();
            }
            else
            {
                LBLUf.Visible = false;
            }
        }
    }
}

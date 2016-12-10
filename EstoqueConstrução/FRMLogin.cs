using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Estoque_Material_Construção
{
    public partial class FRMLogin : Form
    {
        ConexaoBD Banco = new ConexaoBD();
        Variaveis valores = new Variaveis();
        ToolTip MytoolTip = new ToolTip();
        int contador = 0;
        Thread thread;
        Thread fundo;

        public void SplahStart()
        {
            Application.Run(new FRMSplashScreen());
        }
        public void SplashBackground()
        {
            Application.Run(new FRMBackground());
        }

        public FRMLogin()
        {
            InitializeComponent();
        }

        private void BTNLogin_Click(object sender, EventArgs e)
        {
            valores.VarLogin(TXTLogin.Text, TXTSenha.Text);
            //MessageBox.Show(valores.getLogin());
            //MessageBox.Show(valores.getSenha());
            if (Banco.Login(Banco.AbrirConexao(), valores.Login, valores.Senha) == true)
            {
                FRMLogin FrmLogin = new FRMLogin();
                FRMPrincipal FrmPrincipal = new FRMPrincipal(Banco.nomeBD, Banco.permissao);
                fundo.Abort();
                FrmPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login ou senha incorretos!");
                contador += 1;
                TXTLogin.Text = "";
                TXTSenha.Text = "";
                if (contador == 3)
                {
                    fundo.Abort();
                    Banco.AbrirConexao().Close();
                    MessageBox.Show("Encerrando sistema.");
                    Environment.Exit(0);
                }
            }
        }

        private void BTNSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void BTNVisibilidade_MouseDown(object sender, MouseEventArgs e)
        {
            TXTSenha.UseSystemPasswordChar = false;
            BTNVisibilidade.BackgroundImage = new Bitmap("resources\\ic_visibility_off_black_18dp_1x.png");
        }

        private void BTNVisibilidade_MouseUp(object sender, MouseEventArgs e)
        {
            TXTSenha.UseSystemPasswordChar = true;
            BTNVisibilidade.BackgroundImage = new Bitmap("resources\\ic_visibility_black_18dp_1x.png");
        }

        private void TXTLogin_Leave(object sender, EventArgs e)
        {
            if (TXTLogin.Text == "")
            {
                LBLLoginImp.Visible = true;
                BTNLogin.Enabled = false;
                TXTLogin.Focus();
            }
            else
            {
                LBLLoginImp.Visible = false;
                BTNLogin.Enabled = true;
            }
        }

        private void TXTSenha_Leave(object sender, EventArgs e)
        {
            if (TXTSenha.Text == "")
            {
                LBLSenhaImp.Visible = true;
                BTNLogin.Enabled = false;
                TXTSenha.Focus();
            }
            else
            {
                LBLSenhaImp.Visible = false;
                BTNLogin.Enabled = true;
            }
        }

        private void TXTLogin_TabIndexChanged(object sender, EventArgs e)
        {
            if (TXTLogin.Text == "")
            {
                LBLLoginImp.Visible = true;
                BTNLogin.Enabled = false;
                TXTLogin.Focus();
            }
            else
            {
                LBLLoginImp.Visible = false;
                BTNLogin.Enabled = true;
            }
        }

        private void TXTSenha_TabIndexChanged(object sender, EventArgs e)
        {
            if (TXTSenha.Text == "")
            {
                LBLSenhaImp.Visible = true;
                BTNLogin.Enabled = false;
                TXTSenha.Focus();
            }
            else
            {
                LBLSenhaImp.Visible = false;
                BTNLogin.Enabled = true;
            }
        }

        private void BTNLimpar_Click(object sender, EventArgs e)
        {
            TXTLogin.Text = null;
            TXTSenha.Text = null;
        }

        private void BTNLogin_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNLogin, "Botão para fazer login.");
        }

        private void BTNLimpar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNLimpar, "Botão para limpar campos.");
        }

        private void BTNSair_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNSair, "Botão para encerrar software.");
        }

        private void BTNVisibilidade_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNVisibilidade, "Botão para mostrar o campo Senha.");
        }

        private void LBLLoginImp_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(LBLLoginImp, "Campo Obrigatório.");
        }

        private void LBLSenhaImp_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(LBLSenhaImp, "Campo Obrigatório.");
        }

        private void FRMLogin_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(SplahStart));
            thread.Start();
            Thread.Sleep(4800);
            thread.Abort();
            fundo = new Thread(new ThreadStart(SplashBackground));
            fundo.Start();
        }

        private void FRMLogin_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }

    }
}

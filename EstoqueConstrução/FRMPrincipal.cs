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
    public partial class FRMPrincipal : Form
    {
        string nome_venda;

        public FRMPrincipal(string nome, string permissao)
        {
            InitializeComponent();
            DateTime tempo = DateTime.Now;
            TSSHoraTempo.Text = tempo.ToString();
            TSLNome.Text = "Bem vindo, " + nome;
            if(permissao == "mestre")
            {
                BTNConfiguracoes.Visible = true;
            }
            else
            {
                BTNConfiguracoes.Visible = false;
            }
            nome_venda = nome;
            FRMAvisoProdutos aviso = new FRMAvisoProdutos();
            aviso.MdiParent = this;
            //MessageBox.Show(aviso.Controle.ToString());
            if(aviso.Controle > 0)
            {
                DialogResult escolha = MessageBox.Show("Deseja conferir os produtos em falta?", "Produtos em falta.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (escolha == DialogResult.Yes)
                {
                    aviso.Show();
                }
            }
        }

        ConexaoBD Banco = new ConexaoBD();
        ToolTip MytoolTip = new ToolTip();

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

        private void BTNProdutos_Click(object sender, EventArgs e)
        {
            FRMProduto FRMProduto = new FRMProduto();
            FRMProduto.MdiParent = this;
            FRMProduto.Show();
        }

        private void BTNFuncionarios_Click(object sender, EventArgs e)
        {
            FRMFuncionario FRMFuncionario = new FRMFuncionario();
            FRMFuncionario.MdiParent = this;
            FRMFuncionario.Show();
        }

        private void FRMPrincipal_Load(object sender, EventArgs e)
        {
            //Para maximizar mostrando a barra
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
            //Para maximizar ocultando a barra
            //this.MaximizeBox = false;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void BTNVendas_Click(object sender, EventArgs e)
        {
            FRMVendas FRMVendas = new FRMVendas(nome_venda);
            FRMVendas.MdiParent = this;
            FRMVendas.Show();
        }

        private void BTNFornecedores_Click(object sender, EventArgs e)
        {
            FRMFornecedores FRMFornecedores = new FRMFornecedores();
            FRMFornecedores.MdiParent = this;
            FRMFornecedores.Show();
        }

        private void BTNConfiguracoes_Click(object sender, EventArgs e)
        {
            FRMConfig FRMConfig = new FRMConfig();
            FRMConfig.MdiParent = this;
            FRMConfig.Show();
        }

        private void BTNEncerrar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void BTNOrcamentos_Click(object sender, EventArgs e)
        {
            FRMOrcamento Orcamento = new FRMOrcamento(nome_venda);
            Orcamento.MdiParent = this;
            Orcamento.Show();
        }

        private void BTNRelatorios_Click(object sender, EventArgs e)
        {
            FRMRelatorio Relatorio = new FRMRelatorio();
            Relatorio.MdiParent = this;
            Relatorio.Show();
        }

        private void BTNFornecedores_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNFornecedores, "Botão para modificar, cadastrar, editar e excluir Fornecedores.");
        }

        private void BTNFuncionarios_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNFuncionarios, "Botão para modificar, cadastrar, editar e excluir Funcionários.");
        }

        private void BTNProdutos_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNProdutos, "Botão para modificar, cadastrar, editar e excluir Produtos.");
        }

        private void BTNVendas_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNVendas, "Botão para criar vendas, fazer trocas de produtos e devoluções.");
        }

        private void BTNOrcamentos_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNOrcamentos, "Botão para gerar Orçamentos.");
        }

        private void BTNRelatorios_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNRelatorios, "Botão para gerar, vizualizar e imprimir relatórios.");
        }

        private void BTNConfiguracoes_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNConfiguracoes, "Botão para modificar o sistema.");
        }

        private void BTNEncerrar_MouseHover(object sender, EventArgs e)
        {
            MytoolTip.ToolTipIcon = ToolTipIcon.Info;
            MytoolTip.IsBalloon = true;
            MytoolTip.ShowAlways = true;
            MytoolTip.SetToolTip(BTNEncerrar, "Botão para encerrar o sistema.");
        }
    }
}

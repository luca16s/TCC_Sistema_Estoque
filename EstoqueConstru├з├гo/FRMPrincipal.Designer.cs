namespace Estoque_Material_Construção
{
    partial class FRMPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMPrincipal));
            this.SSPrincipal = new System.Windows.Forms.StatusStrip();
            this.TSSNome = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSLNome = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSHoraTempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.BTNFornecedores = new System.Windows.Forms.Button();
            this.BTNRelatorios = new System.Windows.Forms.Button();
            this.BTNFuncionarios = new System.Windows.Forms.Button();
            this.BTNVendas = new System.Windows.Forms.Button();
            this.BTNOrcamentos = new System.Windows.Forms.Button();
            this.BTNProdutos = new System.Windows.Forms.Button();
            this.GBXMenu = new System.Windows.Forms.GroupBox();
            this.BTNEncerrar = new System.Windows.Forms.Button();
            this.BTNConfiguracoes = new System.Windows.Forms.Button();
            this.SSPrincipal.SuspendLayout();
            this.GBXMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SSPrincipal
            // 
            this.SSPrincipal.Enabled = false;
            this.SSPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSNome,
            this.TSLNome,
            this.TSSHoraTempo});
            this.SSPrincipal.Location = new System.Drawing.Point(0, 705);
            this.SSPrincipal.Name = "SSPrincipal";
            this.SSPrincipal.Size = new System.Drawing.Size(1350, 24);
            this.SSPrincipal.SizingGrip = false;
            this.SSPrincipal.TabIndex = 1;
            this.SSPrincipal.Text = "Bazar Construir";
            // 
            // TSSNome
            // 
            this.TSSNome.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TSSNome.Name = "TSSNome";
            this.TSSNome.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.TSSNome.Size = new System.Drawing.Size(119, 19);
            this.TSSNome.Text = "Bazar da Construção";
            // 
            // TSLNome
            // 
            this.TSLNome.AutoSize = false;
            this.TSLNome.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TSLNome.Margin = new System.Windows.Forms.Padding(100, 3, 0, 2);
            this.TSLNome.Name = "TSLNome";
            this.TSLNome.Size = new System.Drawing.Size(300, 19);
            this.TSLNome.Text = "TSLNome";
            this.TSLNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TSSHoraTempo
            // 
            this.TSSHoraTempo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TSSHoraTempo.Margin = new System.Windows.Forms.Padding(700, 3, 0, 0);
            this.TSSHoraTempo.Name = "TSSHoraTempo";
            this.TSSHoraTempo.Size = new System.Drawing.Size(38, 21);
            this.TSSHoraTempo.Text = "Teste";
            // 
            // BTNFornecedores
            // 
            this.BTNFornecedores.AutoSize = true;
            this.BTNFornecedores.Image = global::Estoque_Material_Construção.Properties.Resources.ic_local_convenience_store_black_36dp_2x;
            this.BTNFornecedores.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTNFornecedores.Location = new System.Drawing.Point(627, 16);
            this.BTNFornecedores.Name = "BTNFornecedores";
            this.BTNFornecedores.Size = new System.Drawing.Size(117, 100);
            this.BTNFornecedores.TabIndex = 1;
            this.BTNFornecedores.Text = "Fornecedores";
            this.BTNFornecedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNFornecedores.UseVisualStyleBackColor = true;
            this.BTNFornecedores.Click += new System.EventHandler(this.BTNFornecedores_Click);
            this.BTNFornecedores.MouseHover += new System.EventHandler(this.BTNFornecedores_MouseHover);
            // 
            // BTNRelatorios
            // 
            this.BTNRelatorios.AutoSize = true;
            this.BTNRelatorios.Image = global::Estoque_Material_Construção.Properties.Resources.ic_pie_chart_black_36dp_2x;
            this.BTNRelatorios.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTNRelatorios.Location = new System.Drawing.Point(504, 16);
            this.BTNRelatorios.Name = "BTNRelatorios";
            this.BTNRelatorios.Size = new System.Drawing.Size(117, 100);
            this.BTNRelatorios.TabIndex = 6;
            this.BTNRelatorios.Text = "Relatórios";
            this.BTNRelatorios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNRelatorios.UseVisualStyleBackColor = true;
            this.BTNRelatorios.Click += new System.EventHandler(this.BTNRelatorios_Click);
            this.BTNRelatorios.MouseHover += new System.EventHandler(this.BTNRelatorios_MouseHover);
            // 
            // BTNFuncionarios
            // 
            this.BTNFuncionarios.AutoSize = true;
            this.BTNFuncionarios.Image = global::Estoque_Material_Construção.Properties.Resources.ic_person_add_black_36dp_2x;
            this.BTNFuncionarios.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTNFuncionarios.Location = new System.Drawing.Point(381, 16);
            this.BTNFuncionarios.Name = "BTNFuncionarios";
            this.BTNFuncionarios.Size = new System.Drawing.Size(117, 100);
            this.BTNFuncionarios.TabIndex = 2;
            this.BTNFuncionarios.Text = "Funcionários";
            this.BTNFuncionarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNFuncionarios.UseVisualStyleBackColor = true;
            this.BTNFuncionarios.Click += new System.EventHandler(this.BTNFuncionarios_Click);
            this.BTNFuncionarios.MouseHover += new System.EventHandler(this.BTNFuncionarios_MouseHover);
            // 
            // BTNVendas
            // 
            this.BTNVendas.AutoSize = true;
            this.BTNVendas.Image = global::Estoque_Material_Construção.Properties.Resources.ic_shopping_cart_black_36dp_2x;
            this.BTNVendas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTNVendas.Location = new System.Drawing.Point(12, 16);
            this.BTNVendas.Name = "BTNVendas";
            this.BTNVendas.Size = new System.Drawing.Size(117, 100);
            this.BTNVendas.TabIndex = 4;
            this.BTNVendas.Text = "Vendas";
            this.BTNVendas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNVendas.UseVisualStyleBackColor = true;
            this.BTNVendas.Click += new System.EventHandler(this.BTNVendas_Click);
            this.BTNVendas.MouseHover += new System.EventHandler(this.BTNVendas_MouseHover);
            // 
            // BTNOrcamentos
            // 
            this.BTNOrcamentos.AutoSize = true;
            this.BTNOrcamentos.Image = global::Estoque_Material_Construção.Properties.Resources.ic_receipt_black_36dp_2x;
            this.BTNOrcamentos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTNOrcamentos.Location = new System.Drawing.Point(135, 16);
            this.BTNOrcamentos.Name = "BTNOrcamentos";
            this.BTNOrcamentos.Size = new System.Drawing.Size(117, 100);
            this.BTNOrcamentos.TabIndex = 5;
            this.BTNOrcamentos.Text = "Orçamentos";
            this.BTNOrcamentos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNOrcamentos.UseVisualStyleBackColor = true;
            this.BTNOrcamentos.Click += new System.EventHandler(this.BTNOrcamentos_Click);
            this.BTNOrcamentos.MouseHover += new System.EventHandler(this.BTNOrcamentos_MouseHover);
            // 
            // BTNProdutos
            // 
            this.BTNProdutos.AutoSize = true;
            this.BTNProdutos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BTNProdutos.Image = global::Estoque_Material_Construção.Properties.Resources.ic_local_parking_black_36dp_2x;
            this.BTNProdutos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTNProdutos.Location = new System.Drawing.Point(258, 16);
            this.BTNProdutos.Name = "BTNProdutos";
            this.BTNProdutos.Size = new System.Drawing.Size(117, 100);
            this.BTNProdutos.TabIndex = 3;
            this.BTNProdutos.Text = "Produtos";
            this.BTNProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNProdutos.UseVisualStyleBackColor = true;
            this.BTNProdutos.Click += new System.EventHandler(this.BTNProdutos_Click);
            this.BTNProdutos.MouseHover += new System.EventHandler(this.BTNProdutos_MouseHover);
            // 
            // GBXMenu
            // 
            this.GBXMenu.AutoSize = true;
            this.GBXMenu.BackColor = System.Drawing.SystemColors.Control;
            this.GBXMenu.Controls.Add(this.BTNEncerrar);
            this.GBXMenu.Controls.Add(this.BTNProdutos);
            this.GBXMenu.Controls.Add(this.BTNConfiguracoes);
            this.GBXMenu.Controls.Add(this.BTNOrcamentos);
            this.GBXMenu.Controls.Add(this.BTNVendas);
            this.GBXMenu.Controls.Add(this.BTNFuncionarios);
            this.GBXMenu.Controls.Add(this.BTNRelatorios);
            this.GBXMenu.Controls.Add(this.BTNFornecedores);
            this.GBXMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.GBXMenu.Location = new System.Drawing.Point(0, 0);
            this.GBXMenu.Margin = new System.Windows.Forms.Padding(0);
            this.GBXMenu.Name = "GBXMenu";
            this.GBXMenu.Padding = new System.Windows.Forms.Padding(0);
            this.GBXMenu.Size = new System.Drawing.Size(1350, 132);
            this.GBXMenu.TabIndex = 10;
            this.GBXMenu.TabStop = false;
            // 
            // BTNEncerrar
            // 
            this.BTNEncerrar.AutoSize = true;
            this.BTNEncerrar.Image = global::Estoque_Material_Construção.Properties.Resources.ic_power_settings_new_black_36dp_2x;
            this.BTNEncerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTNEncerrar.Location = new System.Drawing.Point(1221, 16);
            this.BTNEncerrar.Name = "BTNEncerrar";
            this.BTNEncerrar.Size = new System.Drawing.Size(117, 100);
            this.BTNEncerrar.TabIndex = 8;
            this.BTNEncerrar.Text = "Encerrar Sistema";
            this.BTNEncerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNEncerrar.UseVisualStyleBackColor = true;
            this.BTNEncerrar.Click += new System.EventHandler(this.BTNEncerrar_Click);
            this.BTNEncerrar.MouseHover += new System.EventHandler(this.BTNEncerrar_MouseHover);
            // 
            // BTNConfiguracoes
            // 
            this.BTNConfiguracoes.AutoSize = true;
            this.BTNConfiguracoes.Image = global::Estoque_Material_Construção.Properties.Resources.ic_build_black_36dp_2x;
            this.BTNConfiguracoes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTNConfiguracoes.Location = new System.Drawing.Point(750, 16);
            this.BTNConfiguracoes.Name = "BTNConfiguracoes";
            this.BTNConfiguracoes.Size = new System.Drawing.Size(117, 100);
            this.BTNConfiguracoes.TabIndex = 7;
            this.BTNConfiguracoes.Text = "Configurações";
            this.BTNConfiguracoes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNConfiguracoes.UseVisualStyleBackColor = true;
            this.BTNConfiguracoes.Visible = false;
            this.BTNConfiguracoes.Click += new System.EventHandler(this.BTNConfiguracoes_Click);
            this.BTNConfiguracoes.MouseHover += new System.EventHandler(this.BTNConfiguracoes_MouseHover);
            // 
            // FRMPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Estoque_Material_Construção.Properties.Resources.LOGO;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.SSPrincipal);
            this.Controls.Add(this.GBXMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "FRMPrincipal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GET Sistemas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRMPrincipal_Load);
            this.SSPrincipal.ResumeLayout(false);
            this.SSPrincipal.PerformLayout();
            this.GBXMenu.ResumeLayout(false);
            this.GBXMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip SSPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel TSSNome;
        private System.Windows.Forms.ToolStripStatusLabel TSSHoraTempo;
        private System.Windows.Forms.Button BTNFornecedores;
        private System.Windows.Forms.Button BTNRelatorios;
        private System.Windows.Forms.Button BTNFuncionarios;
        private System.Windows.Forms.Button BTNVendas;
        private System.Windows.Forms.Button BTNOrcamentos;
        private System.Windows.Forms.Button BTNProdutos;
        private System.Windows.Forms.GroupBox GBXMenu;
        private System.Windows.Forms.Button BTNConfiguracoes;
        private System.Windows.Forms.ToolStripStatusLabel TSLNome;
        private System.Windows.Forms.Button BTNEncerrar;
    }
}
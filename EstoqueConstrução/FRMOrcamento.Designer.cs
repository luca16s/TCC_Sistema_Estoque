namespace Estoque_Material_Construção
{
    partial class FRMOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMOrcamento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LBLCliente = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LBLProduto = new System.Windows.Forms.Label();
            this.LBLQuantidade = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TXTQuantidade = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TXTNome_Produto = new System.Windows.Forms.TextBox();
            this.BTNAdicionar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TXTProduto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DGVProdutos = new System.Windows.Forms.DataGridView();
            this.DGTCCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LBLTipoVenda = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LBLNumeroParcelas = new System.Windows.Forms.Label();
            this.TXTNumero_Parcelas = new System.Windows.Forms.TextBox();
            this.TXTValor_Parcela = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LBLDesconto = new System.Windows.Forms.Label();
            this.LBLValorItems = new System.Windows.Forms.Label();
            this.TXTTotal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TXTDesconto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TXTValorItems = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RDBPrazo = new System.Windows.Forms.RadioButton();
            this.RDBVista = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTVendedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTCliente = new System.Windows.Forms.TextBox();
            this.TXTData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNLimpar = new System.Windows.Forms.Button();
            this.BTNVoltar = new System.Windows.Forms.Button();
            this.BTNImprimir = new System.Windows.Forms.Button();
            this.PDOrcamento = new System.Drawing.Printing.PrintDocument();
            this.PPDOrcamento = new System.Windows.Forms.PrintPreviewDialog();
            this.PSDOrcamento = new System.Windows.Forms.PageSetupDialog();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProdutos)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LBLCliente);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TXTVendedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TXTCliente);
            this.groupBox1.Controls.Add(this.TXTData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 484);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // LBLCliente
            // 
            this.LBLCliente.Image = global::Estoque_Material_Construção.Properties.Resources.ic_priority_high_black_18dp_1x;
            this.LBLCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBLCliente.Location = new System.Drawing.Point(407, 58);
            this.LBLCliente.Name = "LBLCliente";
            this.LBLCliente.Size = new System.Drawing.Size(18, 18);
            this.LBLCliente.TabIndex = 47;
            this.LBLCliente.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(3, 134);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(441, 347);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LBLProduto);
            this.tabPage1.Controls.Add(this.LBLQuantidade);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.TXTQuantidade);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.TXTNome_Produto);
            this.tabPage1.Controls.Add(this.BTNAdicionar);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.TXTProduto);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.DGVProdutos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(433, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Produtos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LBLProduto
            // 
            this.LBLProduto.Image = global::Estoque_Material_Construção.Properties.Resources.ic_priority_high_black_18dp_1x;
            this.LBLProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBLProduto.Location = new System.Drawing.Point(292, 8);
            this.LBLProduto.Name = "LBLProduto";
            this.LBLProduto.Size = new System.Drawing.Size(18, 18);
            this.LBLProduto.TabIndex = 49;
            this.LBLProduto.Visible = false;
            // 
            // LBLQuantidade
            // 
            this.LBLQuantidade.Image = global::Estoque_Material_Construção.Properties.Resources.ic_priority_high_black_18dp_1x;
            this.LBLQuantidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBLQuantidade.Location = new System.Drawing.Point(179, 69);
            this.LBLQuantidade.Name = "LBLQuantidade";
            this.LBLQuantidade.Size = new System.Drawing.Size(18, 18);
            this.LBLQuantidade.TabIndex = 48;
            this.LBLQuantidade.Visible = false;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(-2, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(710, 1);
            this.label13.TabIndex = 13;
            this.label13.Text = "label13";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(-3, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(710, 1);
            this.label10.TabIndex = 12;
            this.label10.Text = "label10";
            // 
            // TXTQuantidade
            // 
            this.TXTQuantidade.Location = new System.Drawing.Point(82, 69);
            this.TXTQuantidade.Name = "TXTQuantidade";
            this.TXTQuantidade.Size = new System.Drawing.Size(91, 20);
            this.TXTQuantidade.TabIndex = 8;
            this.TXTQuantidade.Leave += new System.EventHandler(this.TXTQuantidade_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Quantidade:";
            // 
            // TXTNome_Produto
            // 
            this.TXTNome_Produto.Enabled = false;
            this.TXTNome_Produto.Location = new System.Drawing.Point(51, 43);
            this.TXTNome_Produto.Name = "TXTNome_Produto";
            this.TXTNome_Produto.Size = new System.Drawing.Size(207, 20);
            this.TXTNome_Produto.TabIndex = 7;
            // 
            // BTNAdicionar
            // 
            this.BTNAdicionar.Image = global::Estoque_Material_Construção.Properties.Resources.ic_add_black_18dp_2x;
            this.BTNAdicionar.Location = new System.Drawing.Point(216, 73);
            this.BTNAdicionar.Name = "BTNAdicionar";
            this.BTNAdicionar.Size = new System.Drawing.Size(42, 42);
            this.BTNAdicionar.TabIndex = 9;
            this.BTNAdicionar.UseVisualStyleBackColor = true;
            this.BTNAdicionar.Click += new System.EventHandler(this.BTNAdicionar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Nome:";
            // 
            // button1
            // 
            this.button1.Image = global::Estoque_Material_Construção.Properties.Resources.ic_search_black_18dp_1x;
            this.button1.Location = new System.Drawing.Point(264, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 22);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BTNPesquisar_Click);
            // 
            // TXTProduto
            // 
            this.TXTProduto.Location = new System.Drawing.Point(61, 10);
            this.TXTProduto.Name = "TXTProduto";
            this.TXTProduto.Size = new System.Drawing.Size(197, 20);
            this.TXTProduto.TabIndex = 5;
            this.TXTProduto.Leave += new System.EventHandler(this.TXTProduto_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Produto:";
            // 
            // DGVProdutos
            // 
            this.DGVProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGTCCodigo,
            this.Column4,
            this.Column1,
            this.Column2,
            this.DGVMarca});
            this.DGVProdutos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVProdutos.Location = new System.Drawing.Point(3, 129);
            this.DGVProdutos.Name = "DGVProdutos";
            this.DGVProdutos.ReadOnly = true;
            this.DGVProdutos.Size = new System.Drawing.Size(427, 189);
            this.DGVProdutos.TabIndex = 1;
            // 
            // DGTCCodigo
            // 
            this.DGTCCodigo.HeaderText = "Código";
            this.DGTCCodigo.Name = "DGTCCodigo";
            this.DGTCCodigo.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Produto";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Quantidade";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Valor";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // DGVMarca
            // 
            this.DGVMarca.HeaderText = "Marca";
            this.DGVMarca.Name = "DGVMarca";
            this.DGVMarca.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LBLTipoVenda);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(433, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Valor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LBLTipoVenda
            // 
            this.LBLTipoVenda.Image = global::Estoque_Material_Construção.Properties.Resources.ic_priority_high_black_18dp_1x;
            this.LBLTipoVenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBLTipoVenda.Location = new System.Drawing.Point(102, 115);
            this.LBLTipoVenda.Name = "LBLTipoVenda";
            this.LBLTipoVenda.Size = new System.Drawing.Size(18, 18);
            this.LBLTipoVenda.TabIndex = 52;
            this.LBLTipoVenda.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LBLNumeroParcelas);
            this.groupBox4.Controls.Add(this.TXTNumero_Parcelas);
            this.groupBox4.Controls.Add(this.TXTValor_Parcela);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(6, 191);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 70);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parcelas";
            // 
            // LBLNumeroParcelas
            // 
            this.LBLNumeroParcelas.Image = global::Estoque_Material_Construção.Properties.Resources.ic_priority_high_black_18dp_1x;
            this.LBLNumeroParcelas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBLNumeroParcelas.Location = new System.Drawing.Point(197, 18);
            this.LBLNumeroParcelas.Name = "LBLNumeroParcelas";
            this.LBLNumeroParcelas.Size = new System.Drawing.Size(18, 18);
            this.LBLNumeroParcelas.TabIndex = 51;
            this.LBLNumeroParcelas.Visible = false;
            // 
            // TXTNumero_Parcelas
            // 
            this.TXTNumero_Parcelas.Enabled = false;
            this.TXTNumero_Parcelas.Location = new System.Drawing.Point(124, 15);
            this.TXTNumero_Parcelas.Name = "TXTNumero_Parcelas";
            this.TXTNumero_Parcelas.Size = new System.Drawing.Size(67, 20);
            this.TXTNumero_Parcelas.TabIndex = 15;
            this.TXTNumero_Parcelas.Leave += new System.EventHandler(this.TXTNumero_Parcelas_Leave);
            // 
            // TXTValor_Parcela
            // 
            this.TXTValor_Parcela.Enabled = false;
            this.TXTValor_Parcela.Location = new System.Drawing.Point(96, 38);
            this.TXTValor_Parcela.Name = "TXTValor_Parcela";
            this.TXTValor_Parcela.Size = new System.Drawing.Size(95, 20);
            this.TXTValor_Parcela.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Número de Parcelas:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Valor da Parcela";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LBLDesconto);
            this.groupBox3.Controls.Add(this.LBLValorItems);
            this.groupBox3.Controls.Add(this.TXTTotal);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.TXTDesconto);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.TXTValorItems);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(227, 103);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total";
            // 
            // LBLDesconto
            // 
            this.LBLDesconto.Image = global::Estoque_Material_Construção.Properties.Resources.ic_priority_high_black_18dp_1x;
            this.LBLDesconto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBLDesconto.Location = new System.Drawing.Point(200, 48);
            this.LBLDesconto.Name = "LBLDesconto";
            this.LBLDesconto.Size = new System.Drawing.Size(18, 18);
            this.LBLDesconto.TabIndex = 49;
            this.LBLDesconto.Visible = false;
            // 
            // LBLValorItems
            // 
            this.LBLValorItems.Image = global::Estoque_Material_Construção.Properties.Resources.ic_priority_high_black_18dp_1x;
            this.LBLValorItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBLValorItems.Location = new System.Drawing.Point(200, 22);
            this.LBLValorItems.Name = "LBLValorItems";
            this.LBLValorItems.Size = new System.Drawing.Size(18, 18);
            this.LBLValorItems.TabIndex = 48;
            this.LBLValorItems.Visible = false;
            // 
            // TXTTotal
            // 
            this.TXTTotal.Enabled = false;
            this.TXTTotal.Location = new System.Drawing.Point(94, 71);
            this.TXTTotal.Name = "TXTTotal";
            this.TXTTotal.Size = new System.Drawing.Size(100, 20);
            this.TXTTotal.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Valor Total:";
            // 
            // TXTDesconto
            // 
            this.TXTDesconto.Location = new System.Drawing.Point(94, 45);
            this.TXTDesconto.Name = "TXTDesconto";
            this.TXTDesconto.Size = new System.Drawing.Size(100, 20);
            this.TXTDesconto.TabIndex = 11;
            this.TXTDesconto.Leave += new System.EventHandler(this.TXTDesconto_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Desconto:";
            // 
            // TXTValorItems
            // 
            this.TXTValorItems.Location = new System.Drawing.Point(94, 19);
            this.TXTValorItems.Name = "TXTValorItems";
            this.TXTValorItems.Size = new System.Drawing.Size(100, 20);
            this.TXTValorItems.TabIndex = 10;
            this.TXTValorItems.Enter += new System.EventHandler(this.TXTValorItems_Enter);
            this.TXTValorItems.Leave += new System.EventHandler(this.TXTValorItems_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Valor dos Items:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RDBPrazo);
            this.groupBox2.Controls.Add(this.RDBVista);
            this.groupBox2.Location = new System.Drawing.Point(5, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 70);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Venda";
            // 
            // RDBPrazo
            // 
            this.RDBPrazo.AutoSize = true;
            this.RDBPrazo.Location = new System.Drawing.Point(6, 42);
            this.RDBPrazo.Name = "RDBPrazo";
            this.RDBPrazo.Size = new System.Drawing.Size(62, 17);
            this.RDBPrazo.TabIndex = 14;
            this.RDBPrazo.TabStop = true;
            this.RDBPrazo.Text = "À Prazo";
            this.RDBPrazo.UseVisualStyleBackColor = true;
            this.RDBPrazo.CheckedChanged += new System.EventHandler(this.RDBPrazo_CheckedChanged);
            // 
            // RDBVista
            // 
            this.RDBVista.AutoSize = true;
            this.RDBVista.Location = new System.Drawing.Point(6, 19);
            this.RDBVista.Name = "RDBVista";
            this.RDBVista.Size = new System.Drawing.Size(58, 17);
            this.RDBVista.TabIndex = 13;
            this.RDBVista.TabStop = true;
            this.RDBVista.Text = "À Vista";
            this.RDBVista.UseVisualStyleBackColor = true;
            this.RDBVista.CheckedChanged += new System.EventHandler(this.RDBVista_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Vendedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Cliente:";
            // 
            // TXTVendedor
            // 
            this.TXTVendedor.Enabled = false;
            this.TXTVendedor.Location = new System.Drawing.Point(73, 96);
            this.TXTVendedor.Name = "TXTVendedor";
            this.TXTVendedor.Size = new System.Drawing.Size(328, 20);
            this.TXTVendedor.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(0, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(699, 1);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // TXTCliente
            // 
            this.TXTCliente.Location = new System.Drawing.Point(73, 58);
            this.TXTCliente.Name = "TXTCliente";
            this.TXTCliente.Size = new System.Drawing.Size(328, 20);
            this.TXTCliente.TabIndex = 3;
            this.TXTCliente.Leave += new System.EventHandler(this.TXTCliente_Leave);
            // 
            // TXTData
            // 
            this.TXTData.Enabled = false;
            this.TXTData.Location = new System.Drawing.Point(58, 12);
            this.TXTData.Name = "TXTData";
            this.TXTData.Size = new System.Drawing.Size(100, 20);
            this.TXTData.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data:";
            // 
            // BTNLimpar
            // 
            this.BTNLimpar.Image = global::Estoque_Material_Construção.Properties.Resources.ic_restore_page_black_18dp_2x;
            this.BTNLimpar.Location = new System.Drawing.Point(358, 487);
            this.BTNLimpar.Name = "BTNLimpar";
            this.BTNLimpar.Size = new System.Drawing.Size(40, 40);
            this.BTNLimpar.TabIndex = 18;
            this.BTNLimpar.UseVisualStyleBackColor = true;
            this.BTNLimpar.Click += new System.EventHandler(this.BTNLimpar_Click);
            this.BTNLimpar.MouseHover += new System.EventHandler(this.BTNLimpar_MouseHover);
            // 
            // BTNVoltar
            // 
            this.BTNVoltar.Image = global::Estoque_Material_Construção.Properties.Resources.ic_exit_to_app_black_18dp_2x;
            this.BTNVoltar.Location = new System.Drawing.Point(404, 487);
            this.BTNVoltar.Name = "BTNVoltar";
            this.BTNVoltar.Size = new System.Drawing.Size(40, 40);
            this.BTNVoltar.TabIndex = 19;
            this.BTNVoltar.UseVisualStyleBackColor = true;
            this.BTNVoltar.Click += new System.EventHandler(this.BTNVoltar_Click);
            this.BTNVoltar.MouseHover += new System.EventHandler(this.BTNVoltar_MouseHover);
            // 
            // BTNImprimir
            // 
            this.BTNImprimir.Image = global::Estoque_Material_Construção.Properties.Resources.ic_local_printshop_black_18dp_2x;
            this.BTNImprimir.Location = new System.Drawing.Point(312, 487);
            this.BTNImprimir.Name = "BTNImprimir";
            this.BTNImprimir.Size = new System.Drawing.Size(40, 40);
            this.BTNImprimir.TabIndex = 17;
            this.BTNImprimir.UseVisualStyleBackColor = true;
            this.BTNImprimir.Click += new System.EventHandler(this.BTNImprimir_Click);
            this.BTNImprimir.Leave += new System.EventHandler(this.BTNImprimir_Leave);
            // 
            // PDOrcamento
            // 
            this.PDOrcamento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PDOrcamento_PrintPage);
            // 
            // PPDOrcamento
            // 
            this.PPDOrcamento.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PPDOrcamento.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PPDOrcamento.ClientSize = new System.Drawing.Size(400, 300);
            this.PPDOrcamento.Document = this.PDOrcamento;
            this.PPDOrcamento.Enabled = true;
            this.PPDOrcamento.Icon = ((System.Drawing.Icon)(resources.GetObject("PPDOrcamento.Icon")));
            this.PPDOrcamento.Name = "PPDOrcamento";
            this.PPDOrcamento.Visible = false;
            // 
            // PSDOrcamento
            // 
            this.PSDOrcamento.Document = this.PDOrcamento;
            // 
            // FRMOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 533);
            this.ControlBox = false;
            this.Controls.Add(this.BTNLimpar);
            this.Controls.Add(this.BTNVoltar);
            this.Controls.Add(this.BTNImprimir);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMOrcamento";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Orçamento";
            this.Load += new System.EventHandler(this.FRMOrcamento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProdutos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TXTVendedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TXTQuantidade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TXTNome_Produto;
        private System.Windows.Forms.Button BTNAdicionar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TXTProduto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView DGVProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGTCCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVMarca;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TXTTotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TXTDesconto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TXTValorItems;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RDBPrazo;
        private System.Windows.Forms.RadioButton RDBVista;
        private System.Windows.Forms.Button BTNLimpar;
        private System.Windows.Forms.Button BTNVoltar;
        private System.Windows.Forms.Button BTNImprimir;
        private System.Drawing.Printing.PrintDocument PDOrcamento;
        private System.Windows.Forms.PrintPreviewDialog PPDOrcamento;
        private System.Windows.Forms.TextBox TXTData;
        private System.Windows.Forms.PageSetupDialog PSDOrcamento;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TXTNumero_Parcelas;
        private System.Windows.Forms.TextBox TXTValor_Parcela;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label LBLCliente;
        private System.Windows.Forms.Label LBLProduto;
        private System.Windows.Forms.Label LBLQuantidade;
        private System.Windows.Forms.Label LBLNumeroParcelas;
        private System.Windows.Forms.Label LBLDesconto;
        private System.Windows.Forms.Label LBLValorItems;
        private System.Windows.Forms.Label LBLTipoVenda;
    }
}
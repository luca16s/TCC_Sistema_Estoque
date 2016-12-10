namespace Estoque_Material_Construção
{
    partial class FRMRelatorio
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
            this.TBCRelatorio = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.BTNPesquisar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RDBCodigo = new System.Windows.Forms.RadioButton();
            this.RDBNome = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RDBPedidos = new System.Windows.Forms.RadioButton();
            this.RDBProdutos_Falta = new System.Windows.Forms.RadioButton();
            this.RDBMarcas = new System.Windows.Forms.RadioButton();
            this.RDBFornecedor = new System.Windows.Forms.RadioButton();
            this.RDBQuantidade_Produto = new System.Windows.Forms.RadioButton();
            this.RDBTabelaPreco_Produto = new System.Windows.Forms.RadioButton();
            this.RDBListarProdutos = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BTNSair = new System.Windows.Forms.Button();
            this.BTNImprimir = new System.Windows.Forms.Button();
            this.DGVRelatorios = new System.Windows.Forms.DataGridView();
            this.TBCRelatorio.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRelatorios)).BeginInit();
            this.SuspendLayout();
            // 
            // TBCRelatorio
            // 
            this.TBCRelatorio.Controls.Add(this.tabPage1);
            this.TBCRelatorio.Controls.Add(this.tabPage2);
            this.TBCRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBCRelatorio.Location = new System.Drawing.Point(0, 0);
            this.TBCRelatorio.Name = "TBCRelatorio";
            this.TBCRelatorio.SelectedIndex = 0;
            this.TBCRelatorio.Size = new System.Drawing.Size(632, 455);
            this.TBCRelatorio.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.BTNPesquisar);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(624, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tipos de Relatórios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = global::Estoque_Material_Construção.Properties.Resources.ic_exit_to_app_black_18dp_2x;
            this.button2.Location = new System.Drawing.Point(576, 381);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BTNSair_Click);
            this.button2.MouseHover += new System.EventHandler(this.button2_MouseHover);
            // 
            // BTNPesquisar
            // 
            this.BTNPesquisar.Image = global::Estoque_Material_Construção.Properties.Resources.ic_search_black_18dp_2x;
            this.BTNPesquisar.Location = new System.Drawing.Point(530, 381);
            this.BTNPesquisar.Name = "BTNPesquisar";
            this.BTNPesquisar.Size = new System.Drawing.Size(40, 40);
            this.BTNPesquisar.TabIndex = 7;
            this.BTNPesquisar.UseVisualStyleBackColor = true;
            this.BTNPesquisar.Click += new System.EventHandler(this.BTNPesquisar_Click);
            this.BTNPesquisar.MouseHover += new System.EventHandler(this.BTNPesquisar_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RDBCodigo);
            this.groupBox2.Controls.Add(this.RDBNome);
            this.groupBox2.Location = new System.Drawing.Point(3, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(79, 70);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordenação";
            // 
            // RDBCodigo
            // 
            this.RDBCodigo.AutoSize = true;
            this.RDBCodigo.Location = new System.Drawing.Point(6, 42);
            this.RDBCodigo.Name = "RDBCodigo";
            this.RDBCodigo.Size = new System.Drawing.Size(58, 17);
            this.RDBCodigo.TabIndex = 1;
            this.RDBCodigo.TabStop = true;
            this.RDBCodigo.Text = "Código";
            this.RDBCodigo.UseVisualStyleBackColor = true;
            // 
            // RDBNome
            // 
            this.RDBNome.AutoSize = true;
            this.RDBNome.Location = new System.Drawing.Point(6, 19);
            this.RDBNome.Name = "RDBNome";
            this.RDBNome.Size = new System.Drawing.Size(53, 17);
            this.RDBNome.TabIndex = 0;
            this.RDBNome.TabStop = true;
            this.RDBNome.Text = "Nome";
            this.RDBNome.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RDBPedidos);
            this.groupBox1.Controls.Add(this.RDBProdutos_Falta);
            this.groupBox1.Controls.Add(this.RDBMarcas);
            this.groupBox1.Controls.Add(this.RDBFornecedor);
            this.groupBox1.Controls.Add(this.RDBQuantidade_Produto);
            this.groupBox1.Controls.Add(this.RDBTabelaPreco_Produto);
            this.groupBox1.Controls.Add(this.RDBListarProdutos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 161);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relatórios";
            // 
            // RDBPedidos
            // 
            this.RDBPedidos.AutoSize = true;
            this.RDBPedidos.Location = new System.Drawing.Point(246, 19);
            this.RDBPedidos.Name = "RDBPedidos";
            this.RDBPedidos.Size = new System.Drawing.Size(118, 17);
            this.RDBPedidos.TabIndex = 6;
            this.RDBPedidos.TabStop = true;
            this.RDBPedidos.Text = "Pedidos de Clientes";
            this.RDBPedidos.UseVisualStyleBackColor = true;
            // 
            // RDBProdutos_Falta
            // 
            this.RDBProdutos_Falta.AutoSize = true;
            this.RDBProdutos_Falta.Location = new System.Drawing.Point(12, 134);
            this.RDBProdutos_Falta.Name = "RDBProdutos_Falta";
            this.RDBProdutos_Falta.Size = new System.Drawing.Size(110, 17);
            this.RDBProdutos_Falta.TabIndex = 5;
            this.RDBProdutos_Falta.TabStop = true;
            this.RDBProdutos_Falta.Text = "Produtos em Falta";
            this.RDBProdutos_Falta.UseVisualStyleBackColor = true;
            // 
            // RDBMarcas
            // 
            this.RDBMarcas.AutoSize = true;
            this.RDBMarcas.Location = new System.Drawing.Point(12, 111);
            this.RDBMarcas.Name = "RDBMarcas";
            this.RDBMarcas.Size = new System.Drawing.Size(88, 17);
            this.RDBMarcas.TabIndex = 4;
            this.RDBMarcas.TabStop = true;
            this.RDBMarcas.Text = "Listar Marcas";
            this.RDBMarcas.UseVisualStyleBackColor = true;
            // 
            // RDBFornecedor
            // 
            this.RDBFornecedor.AutoSize = true;
            this.RDBFornecedor.Location = new System.Drawing.Point(12, 88);
            this.RDBFornecedor.Name = "RDBFornecedor";
            this.RDBFornecedor.Size = new System.Drawing.Size(107, 17);
            this.RDBFornecedor.TabIndex = 3;
            this.RDBFornecedor.TabStop = true;
            this.RDBFornecedor.Text = "Listar Fornecedor";
            this.RDBFornecedor.UseVisualStyleBackColor = true;
            // 
            // RDBQuantidade_Produto
            // 
            this.RDBQuantidade_Produto.AutoSize = true;
            this.RDBQuantidade_Produto.Location = new System.Drawing.Point(12, 65);
            this.RDBQuantidade_Produto.Name = "RDBQuantidade_Produto";
            this.RDBQuantidade_Produto.Size = new System.Drawing.Size(188, 17);
            this.RDBQuantidade_Produto.TabIndex = 2;
            this.RDBQuantidade_Produto.TabStop = true;
            this.RDBQuantidade_Produto.Text = "Relatório de Quantidade / Produto";
            this.RDBQuantidade_Produto.UseVisualStyleBackColor = true;
            // 
            // RDBTabelaPreco_Produto
            // 
            this.RDBTabelaPreco_Produto.AutoSize = true;
            this.RDBTabelaPreco_Produto.Location = new System.Drawing.Point(12, 42);
            this.RDBTabelaPreco_Produto.Name = "RDBTabelaPreco_Produto";
            this.RDBTabelaPreco_Produto.Size = new System.Drawing.Size(152, 17);
            this.RDBTabelaPreco_Produto.TabIndex = 1;
            this.RDBTabelaPreco_Produto.TabStop = true;
            this.RDBTabelaPreco_Produto.Text = "Tabela de Preço / Produto";
            this.RDBTabelaPreco_Produto.UseVisualStyleBackColor = true;
            // 
            // RDBListarProdutos
            // 
            this.RDBListarProdutos.AutoSize = true;
            this.RDBListarProdutos.Location = new System.Drawing.Point(12, 19);
            this.RDBListarProdutos.Name = "RDBListarProdutos";
            this.RDBListarProdutos.Size = new System.Drawing.Size(95, 17);
            this.RDBListarProdutos.TabIndex = 0;
            this.RDBListarProdutos.TabStop = true;
            this.RDBListarProdutos.Text = "Listar Produtos";
            this.RDBListarProdutos.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BTNSair);
            this.tabPage2.Controls.Add(this.BTNImprimir);
            this.tabPage2.Controls.Add(this.DGVRelatorios);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(624, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vizualizar Relatórios";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BTNSair
            // 
            this.BTNSair.Image = global::Estoque_Material_Construção.Properties.Resources.ic_exit_to_app_black_18dp_2x;
            this.BTNSair.Location = new System.Drawing.Point(576, 381);
            this.BTNSair.Name = "BTNSair";
            this.BTNSair.Size = new System.Drawing.Size(40, 40);
            this.BTNSair.TabIndex = 2;
            this.BTNSair.UseVisualStyleBackColor = true;
            this.BTNSair.Click += new System.EventHandler(this.BTNSair_Click);
            this.BTNSair.MouseHover += new System.EventHandler(this.BTNSair_MouseHover);
            // 
            // BTNImprimir
            // 
            this.BTNImprimir.Image = global::Estoque_Material_Construção.Properties.Resources.ic_local_printshop_black_18dp_2x;
            this.BTNImprimir.Location = new System.Drawing.Point(530, 381);
            this.BTNImprimir.Name = "BTNImprimir";
            this.BTNImprimir.Size = new System.Drawing.Size(40, 40);
            this.BTNImprimir.TabIndex = 1;
            this.BTNImprimir.UseVisualStyleBackColor = true;
            this.BTNImprimir.MouseHover += new System.EventHandler(this.BTNImprimir_MouseHover);
            // 
            // DGVRelatorios
            // 
            this.DGVRelatorios.AllowUserToDeleteRows = false;
            this.DGVRelatorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRelatorios.Dock = System.Windows.Forms.DockStyle.Top;
            this.DGVRelatorios.Location = new System.Drawing.Point(3, 3);
            this.DGVRelatorios.Name = "DGVRelatorios";
            this.DGVRelatorios.ReadOnly = true;
            this.DGVRelatorios.Size = new System.Drawing.Size(618, 374);
            this.DGVRelatorios.TabIndex = 0;
            // 
            // FRMRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 455);
            this.ControlBox = false;
            this.Controls.Add(this.TBCRelatorio);
            this.Name = "FRMRelatorio";
            this.Text = "Relatórios";
            this.TBCRelatorio.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVRelatorios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TBCRelatorio;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BTNPesquisar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RDBCodigo;
        private System.Windows.Forms.RadioButton RDBNome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RDBProdutos_Falta;
        private System.Windows.Forms.RadioButton RDBMarcas;
        private System.Windows.Forms.RadioButton RDBFornecedor;
        private System.Windows.Forms.RadioButton RDBQuantidade_Produto;
        private System.Windows.Forms.RadioButton RDBTabelaPreco_Produto;
        private System.Windows.Forms.RadioButton RDBListarProdutos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BTNImprimir;
        private System.Windows.Forms.DataGridView DGVRelatorios;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BTNSair;
        private System.Windows.Forms.RadioButton RDBPedidos;
    }
}
namespace Estoque_Material_Construção
{
    partial class FRMPedidoProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMPedidoProduto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LBLDescricao = new System.Windows.Forms.Label();
            this.LBLProduto = new System.Windows.Forms.Label();
            this.TXTDescrição = new System.Windows.Forms.TextBox();
            this.TXTProduto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNSalvar = new System.Windows.Forms.Button();
            this.BTNLimpar = new System.Windows.Forms.Button();
            this.BTNExcluir = new System.Windows.Forms.Button();
            this.BTNPesquisar = new System.Windows.Forms.Button();
            this.BTNSair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LBLDescricao);
            this.groupBox1.Controls.Add(this.LBLProduto);
            this.groupBox1.Controls.Add(this.TXTDescrição);
            this.groupBox1.Controls.Add(this.TXTProduto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // LBLDescricao
            // 
            this.LBLDescricao.Image = global::Estoque_Material_Construção.Properties.Resources.ic_priority_high_black_18dp_1x;
            this.LBLDescricao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBLDescricao.Location = new System.Drawing.Point(304, 56);
            this.LBLDescricao.Name = "LBLDescricao";
            this.LBLDescricao.Size = new System.Drawing.Size(18, 18);
            this.LBLDescricao.TabIndex = 10;
            this.LBLDescricao.Visible = false;
            // 
            // LBLProduto
            // 
            this.LBLProduto.Image = global::Estoque_Material_Construção.Properties.Resources.ic_priority_high_black_18dp_1x;
            this.LBLProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBLProduto.Location = new System.Drawing.Point(304, 15);
            this.LBLProduto.Name = "LBLProduto";
            this.LBLProduto.Size = new System.Drawing.Size(18, 18);
            this.LBLProduto.TabIndex = 9;
            this.LBLProduto.Visible = false;
            // 
            // TXTDescrição
            // 
            this.TXTDescrição.Location = new System.Drawing.Point(76, 56);
            this.TXTDescrição.Multiline = true;
            this.TXTDescrição.Name = "TXTDescrição";
            this.TXTDescrição.Size = new System.Drawing.Size(222, 58);
            this.TXTDescrição.TabIndex = 3;
            this.TXTDescrição.Leave += new System.EventHandler(this.TXTDescrição_Leave);
            // 
            // TXTProduto
            // 
            this.TXTProduto.Location = new System.Drawing.Point(65, 12);
            this.TXTProduto.Name = "TXTProduto";
            this.TXTProduto.Size = new System.Drawing.Size(233, 20);
            this.TXTProduto.TabIndex = 2;
            this.TXTProduto.Leave += new System.EventHandler(this.TXTProduto_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrição:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto:";
            // 
            // BTNSalvar
            // 
            this.BTNSalvar.Image = global::Estoque_Material_Construção.Properties.Resources.ic_save_black_18dp_2x;
            this.BTNSalvar.Location = new System.Drawing.Point(92, 142);
            this.BTNSalvar.Name = "BTNSalvar";
            this.BTNSalvar.Size = new System.Drawing.Size(40, 40);
            this.BTNSalvar.TabIndex = 1;
            this.BTNSalvar.UseVisualStyleBackColor = true;
            this.BTNSalvar.Click += new System.EventHandler(this.BTNSalvar_Click);
            this.BTNSalvar.MouseHover += new System.EventHandler(this.BTNSalvar_MouseHover);
            // 
            // BTNLimpar
            // 
            this.BTNLimpar.Image = global::Estoque_Material_Construção.Properties.Resources.ic_restore_page_black_18dp_2x1;
            this.BTNLimpar.Location = new System.Drawing.Point(230, 142);
            this.BTNLimpar.Name = "BTNLimpar";
            this.BTNLimpar.Size = new System.Drawing.Size(40, 40);
            this.BTNLimpar.TabIndex = 2;
            this.BTNLimpar.UseVisualStyleBackColor = true;
            this.BTNLimpar.Click += new System.EventHandler(this.BTNLimpar_Click);
            this.BTNLimpar.MouseHover += new System.EventHandler(this.BTNLimpar_MouseHover);
            // 
            // BTNExcluir
            // 
            this.BTNExcluir.Image = global::Estoque_Material_Construção.Properties.Resources.ic_delete_black_18dp_2x;
            this.BTNExcluir.Location = new System.Drawing.Point(184, 142);
            this.BTNExcluir.Name = "BTNExcluir";
            this.BTNExcluir.Size = new System.Drawing.Size(40, 40);
            this.BTNExcluir.TabIndex = 3;
            this.BTNExcluir.UseVisualStyleBackColor = true;
            this.BTNExcluir.Click += new System.EventHandler(this.BTNExcluir_Click);
            this.BTNExcluir.MouseHover += new System.EventHandler(this.BTNExcluir_MouseHover);
            // 
            // BTNPesquisar
            // 
            this.BTNPesquisar.Image = global::Estoque_Material_Construção.Properties.Resources.ic_search_black_18dp_2x;
            this.BTNPesquisar.Location = new System.Drawing.Point(138, 142);
            this.BTNPesquisar.Name = "BTNPesquisar";
            this.BTNPesquisar.Size = new System.Drawing.Size(40, 40);
            this.BTNPesquisar.TabIndex = 4;
            this.BTNPesquisar.UseVisualStyleBackColor = true;
            this.BTNPesquisar.Click += new System.EventHandler(this.BTNPesquisar_Click);
            this.BTNPesquisar.MouseHover += new System.EventHandler(this.BTNPesquisar_MouseHover);
            // 
            // BTNSair
            // 
            this.BTNSair.Image = global::Estoque_Material_Construção.Properties.Resources.ic_exit_to_app_black_18dp_2x;
            this.BTNSair.Location = new System.Drawing.Point(276, 142);
            this.BTNSair.Name = "BTNSair";
            this.BTNSair.Size = new System.Drawing.Size(40, 40);
            this.BTNSair.TabIndex = 5;
            this.BTNSair.UseVisualStyleBackColor = true;
            this.BTNSair.Click += new System.EventHandler(this.BTNSair_Click);
            this.BTNSair.MouseHover += new System.EventHandler(this.BTNSair_MouseHover);
            // 
            // FRMPedidoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 187);
            this.ControlBox = false;
            this.Controls.Add(this.BTNSair);
            this.Controls.Add(this.BTNPesquisar);
            this.Controls.Add(this.BTNExcluir);
            this.Controls.Add(this.BTNLimpar);
            this.Controls.Add(this.BTNSalvar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FRMPedidoProduto";
            this.Text = "Pedido de Produtos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TXTDescrição;
        private System.Windows.Forms.TextBox TXTProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNSalvar;
        private System.Windows.Forms.Button BTNLimpar;
        private System.Windows.Forms.Button BTNExcluir;
        private System.Windows.Forms.Button BTNPesquisar;
        private System.Windows.Forms.Button BTNSair;
        private System.Windows.Forms.Label LBLDescricao;
        private System.Windows.Forms.Label LBLProduto;
    }
}
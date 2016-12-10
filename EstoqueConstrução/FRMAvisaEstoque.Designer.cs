namespace Estoque_Material_Construção
{
    partial class FRMAvisoProdutos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGVFaltas = new System.Windows.Forms.DataGridView();
            this.BTNSair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFaltas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGVFaltas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DGVFaltas
            // 
            this.DGVFaltas.AllowUserToAddRows = false;
            this.DGVFaltas.AllowUserToDeleteRows = false;
            this.DGVFaltas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVFaltas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVFaltas.Location = new System.Drawing.Point(3, 16);
            this.DGVFaltas.Name = "DGVFaltas";
            this.DGVFaltas.ReadOnly = true;
            this.DGVFaltas.Size = new System.Drawing.Size(639, 309);
            this.DGVFaltas.TabIndex = 0;
            // 
            // BTNSair
            // 
            this.BTNSair.Dock = System.Windows.Forms.DockStyle.Right;
            this.BTNSair.Image = global::Estoque_Material_Construção.Properties.Resources.ic_exit_to_app_black_18dp_2x;
            this.BTNSair.Location = new System.Drawing.Point(605, 328);
            this.BTNSair.Name = "BTNSair";
            this.BTNSair.Size = new System.Drawing.Size(40, 61);
            this.BTNSair.TabIndex = 1;
            this.BTNSair.UseVisualStyleBackColor = true;
            this.BTNSair.Click += new System.EventHandler(this.BTNSair_Click);
            this.BTNSair.MouseHover += new System.EventHandler(this.BTNSair_MouseHover);
            // 
            // FRMAvisoProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(645, 389);
            this.ControlBox = false;
            this.Controls.Add(this.BTNSair);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMAvisoProdutos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos em Falta";
            this.Load += new System.EventHandler(this.FRMPesquisaResultado_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVFaltas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNSair;
        private System.Windows.Forms.DataGridView DGVFaltas;
    }
}
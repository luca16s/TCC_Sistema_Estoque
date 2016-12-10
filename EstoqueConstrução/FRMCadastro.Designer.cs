namespace Estoque_Material_Construção
{
    partial class FRMCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMCadastro));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TXTCatMar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNSair = new System.Windows.Forms.Button();
            this.BTNInserir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TXTCatMar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BTNSair);
            this.groupBox1.Controls.Add(this.BTNInserir);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TXTCatMar
            // 
            this.TXTCatMar.Dock = System.Windows.Forms.DockStyle.Right;
            this.TXTCatMar.Location = new System.Drawing.Point(117, 16);
            this.TXTCatMar.Name = "TXTCatMar";
            this.TXTCatMar.Size = new System.Drawing.Size(130, 20);
            this.TXTCatMar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Categoria/Marca:";
            // 
            // BTNSair
            // 
            this.BTNSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNSair.Image = global::Estoque_Material_Construção.Properties.Resources.ic_exit_to_app_black_18dp_2x;
            this.BTNSair.Location = new System.Drawing.Point(198, 42);
            this.BTNSair.Name = "BTNSair";
            this.BTNSair.Size = new System.Drawing.Size(40, 40);
            this.BTNSair.TabIndex = 3;
            this.BTNSair.UseVisualStyleBackColor = true;
            this.BTNSair.Click += new System.EventHandler(this.BTNSair_Click);
            this.BTNSair.MouseHover += new System.EventHandler(this.BTNSair_MouseHover);
            // 
            // BTNInserir
            // 
            this.BTNInserir.Image = global::Estoque_Material_Construção.Properties.Resources.ic_save_black_18dp_2x;
            this.BTNInserir.Location = new System.Drawing.Point(152, 42);
            this.BTNInserir.Name = "BTNInserir";
            this.BTNInserir.Size = new System.Drawing.Size(40, 40);
            this.BTNInserir.TabIndex = 2;
            this.BTNInserir.UseVisualStyleBackColor = true;
            this.BTNInserir.Click += new System.EventHandler(this.BTNInserir_Click);
            this.BTNInserir.MouseHover += new System.EventHandler(this.BTNInserir_MouseHover);
            // 
            // FRMCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTNSair;
            this.ClientSize = new System.Drawing.Size(250, 92);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMCadastro";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMCadastro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNSair;
        private System.Windows.Forms.Button BTNInserir;
        private System.Windows.Forms.TextBox TXTCatMar;
    }
}
namespace Estoque_Material_Construção
{
    partial class FRMConfig
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
            this.GBBackup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNImportar = new System.Windows.Forms.Button();
            this.BTNGerar = new System.Windows.Forms.Button();
            this.BTNVoltar = new System.Windows.Forms.Button();
            this.FBDBackup = new System.Windows.Forms.FolderBrowserDialog();
            this.GBBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBBackup
            // 
            this.GBBackup.Controls.Add(this.label2);
            this.GBBackup.Controls.Add(this.label1);
            this.GBBackup.Controls.Add(this.BTNImportar);
            this.GBBackup.Controls.Add(this.BTNGerar);
            this.GBBackup.Location = new System.Drawing.Point(12, 12);
            this.GBBackup.Name = "GBBackup";
            this.GBBackup.Size = new System.Drawing.Size(273, 89);
            this.GBBackup.TabIndex = 0;
            this.GBBackup.TabStop = false;
            this.GBBackup.Text = "Backup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Restaurar Banco de Dados:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gerar cópia do Banco de dados:";
            // 
            // BTNImportar
            // 
            this.BTNImportar.Location = new System.Drawing.Point(173, 48);
            this.BTNImportar.Name = "BTNImportar";
            this.BTNImportar.Size = new System.Drawing.Size(75, 23);
            this.BTNImportar.TabIndex = 1;
            this.BTNImportar.Text = "Importar";
            this.BTNImportar.UseVisualStyleBackColor = true;
            this.BTNImportar.Click += new System.EventHandler(this.BTNImportar_Click);
            // 
            // BTNGerar
            // 
            this.BTNGerar.Location = new System.Drawing.Point(173, 19);
            this.BTNGerar.Name = "BTNGerar";
            this.BTNGerar.Size = new System.Drawing.Size(75, 23);
            this.BTNGerar.TabIndex = 0;
            this.BTNGerar.Text = "Gerar Backup";
            this.BTNGerar.UseVisualStyleBackColor = true;
            this.BTNGerar.Click += new System.EventHandler(this.BTNGerar_Click);
            // 
            // BTNVoltar
            // 
            this.BTNVoltar.Image = global::Estoque_Material_Construção.Properties.Resources.ic_exit_to_app_black_18dp_2x;
            this.BTNVoltar.Location = new System.Drawing.Point(246, 107);
            this.BTNVoltar.Name = "BTNVoltar";
            this.BTNVoltar.Size = new System.Drawing.Size(39, 39);
            this.BTNVoltar.TabIndex = 1;
            this.BTNVoltar.UseVisualStyleBackColor = true;
            this.BTNVoltar.Click += new System.EventHandler(this.BTNVoltar_Click);
            // 
            // FRMConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 155);
            this.ControlBox = false;
            this.Controls.Add(this.BTNVoltar);
            this.Controls.Add(this.GBBackup);
            this.Name = "FRMConfig";
            this.Text = "Configurações";
            this.GBBackup.ResumeLayout(false);
            this.GBBackup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBBackup;
        private System.Windows.Forms.Button BTNGerar;
        private System.Windows.Forms.Button BTNImportar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNVoltar;
        private System.Windows.Forms.FolderBrowserDialog FBDBackup;
    }
}
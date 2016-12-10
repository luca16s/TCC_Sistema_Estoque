namespace Estoque_Material_Construção
{
    partial class FRMSplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMSplashScreen));
            this.PGBSplash = new System.Windows.Forms.ProgressBar();
            this.TMRSplash = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PGBSplash
            // 
            this.PGBSplash.Location = new System.Drawing.Point(688, 365);
            this.PGBSplash.Name = "PGBSplash";
            this.PGBSplash.Size = new System.Drawing.Size(100, 23);
            this.PGBSplash.Step = 1;
            this.PGBSplash.TabIndex = 1;
            // 
            // TMRSplash
            // 
            this.TMRSplash.Enabled = true;
            this.TMRSplash.Interval = 32;
            this.TMRSplash.Tick += new System.EventHandler(this.TMRSplash_Tick);
            // 
            // FRMSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Estoque_Material_Construção.Properties.Resources.LOGO;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.PGBSplash);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMSplashScreen";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar PGBSplash;
        private System.Windows.Forms.Timer TMRSplash;
    }
}
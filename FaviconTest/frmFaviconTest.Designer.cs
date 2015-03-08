namespace FaviconTest
{
    partial class frmFaviconTest
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbFav = new System.Windows.Forms.PictureBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnGetAsyc = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFav)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFav
            // 
            this.pbFav.Location = new System.Drawing.Point(12, 12);
            this.pbFav.Name = "pbFav";
            this.pbFav.Size = new System.Drawing.Size(16, 16);
            this.pbFav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFav.TabIndex = 0;
            this.pbFav.TabStop = false;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(34, 10);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(346, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "http://www.google.de";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(386, 8);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(89, 23);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Get Favicon";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnGetAsyc
            // 
            this.btnGetAsyc.Location = new System.Drawing.Point(481, 8);
            this.btnGetAsyc.Name = "btnGetAsyc";
            this.btnGetAsyc.Size = new System.Drawing.Size(112, 23);
            this.btnGetAsyc.TabIndex = 3;
            this.btnGetAsyc.Text = "Get Favicon Async";
            this.btnGetAsyc.UseVisualStyleBackColor = true;
            this.btnGetAsyc.Click += new System.EventHandler(this.btnGetAsyc_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(35, 33);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 4;
            // 
            // frmFaviconTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 54);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnGetAsyc);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.pbFav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFaviconTest";
            this.Text = "FaviconTest";
            ((System.ComponentModel.ISupportInitialize)(this.pbFav)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFav;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnGetAsyc;
        private System.Windows.Forms.Label lblError;
    }
}


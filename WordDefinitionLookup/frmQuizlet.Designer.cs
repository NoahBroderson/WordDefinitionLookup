namespace WordDefinitionLookup
{
    partial class frmQuizlet
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
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.wbAuthorize = new System.Windows.Forms.WebBrowser();
            this.txtURI = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(1, 7);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(176, 241);
            this.txtInfo.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1, 322);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(199, 7);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorize.TabIndex = 2;
            this.btnAuthorize.Text = "Authorize";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
            // 
            // wbAuthorize
            // 
            this.wbAuthorize.Location = new System.Drawing.Point(199, 92);
            this.wbAuthorize.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbAuthorize.Name = "wbAuthorize";
            this.wbAuthorize.Size = new System.Drawing.Size(715, 290);
            this.wbAuthorize.TabIndex = 3;
            // 
            // txtURI
            // 
            this.txtURI.Location = new System.Drawing.Point(199, 66);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(707, 20);
            this.txtURI.TabIndex = 4;
            // 
            // frmQuizlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 401);
            this.Controls.Add(this.txtURI);
            this.Controls.Add(this.wbAuthorize);
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtInfo);
            this.Name = "frmQuizlet";
            this.Text = "frmQuizlet";
            this.Load += new System.EventHandler(this.frmQuizlet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAuthorize;
        private System.Windows.Forms.WebBrowser wbAuthorize;
        private System.Windows.Forms.TextBox txtURI;
    }
}
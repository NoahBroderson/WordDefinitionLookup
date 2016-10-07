namespace WordLookup
{
    partial class frmQuizletAuthorize
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
            this.wbAuthorize = new System.Windows.Forms.WebBrowser();
            this.txtURI = new System.Windows.Forms.TextBox();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.lblClientID = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.lblSecretKey = new System.Windows.Forms.Label();
            this.txtSecretKey = new System.Windows.Forms.TextBox();
            this.lblRedirectURI = new System.Windows.Forms.Label();
            this.txtRedirectURI = new System.Windows.Forms.TextBox();
            this.lblAuthCode = new System.Windows.Forms.Label();
            this.txtAuthCode = new System.Windows.Forms.TextBox();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.lblAccessToken = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wbAuthorize
            // 
            this.wbAuthorize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wbAuthorize.Location = new System.Drawing.Point(245, 41);
            this.wbAuthorize.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbAuthorize.Name = "wbAuthorize";
            this.wbAuthorize.Size = new System.Drawing.Size(879, 365);
            this.wbAuthorize.TabIndex = 3;
            // 
            // txtURI
            // 
            this.txtURI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURI.Location = new System.Drawing.Point(245, 12);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(879, 20);
            this.txtURI.TabIndex = 4;
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(26, 161);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorize.TabIndex = 2;
            this.btnAuthorize.Text = "Authorize";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Location = new System.Drawing.Point(23, 41);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(47, 13);
            this.lblClientID.TabIndex = 5;
            this.lblClientID.Text = "Client ID";
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(26, 57);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(203, 20);
            this.txtClientID.TabIndex = 6;
            // 
            // lblSecretKey
            // 
            this.lblSecretKey.AutoSize = true;
            this.lblSecretKey.Location = new System.Drawing.Point(23, 80);
            this.lblSecretKey.Name = "lblSecretKey";
            this.lblSecretKey.Size = new System.Drawing.Size(59, 13);
            this.lblSecretKey.TabIndex = 7;
            this.lblSecretKey.Text = "Secret Key";
            // 
            // txtSecretKey
            // 
            this.txtSecretKey.Location = new System.Drawing.Point(26, 96);
            this.txtSecretKey.Name = "txtSecretKey";
            this.txtSecretKey.Size = new System.Drawing.Size(203, 20);
            this.txtSecretKey.TabIndex = 8;
            // 
            // lblRedirectURI
            // 
            this.lblRedirectURI.AutoSize = true;
            this.lblRedirectURI.Location = new System.Drawing.Point(23, 119);
            this.lblRedirectURI.Name = "lblRedirectURI";
            this.lblRedirectURI.Size = new System.Drawing.Size(69, 13);
            this.lblRedirectURI.TabIndex = 9;
            this.lblRedirectURI.Text = "Redirect URI";
            // 
            // txtRedirectURI
            // 
            this.txtRedirectURI.Location = new System.Drawing.Point(26, 135);
            this.txtRedirectURI.Name = "txtRedirectURI";
            this.txtRedirectURI.Size = new System.Drawing.Size(203, 20);
            this.txtRedirectURI.TabIndex = 10;
            // 
            // lblAuthCode
            // 
            this.lblAuthCode.AutoSize = true;
            this.lblAuthCode.Location = new System.Drawing.Point(23, 245);
            this.lblAuthCode.Name = "lblAuthCode";
            this.lblAuthCode.Size = new System.Drawing.Size(57, 13);
            this.lblAuthCode.TabIndex = 11;
            this.lblAuthCode.Text = "Auth Code";
            // 
            // txtAuthCode
            // 
            this.txtAuthCode.Location = new System.Drawing.Point(26, 261);
            this.txtAuthCode.Name = "txtAuthCode";
            this.txtAuthCode.Size = new System.Drawing.Size(203, 20);
            this.txtAuthCode.TabIndex = 12;
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(26, 322);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(203, 20);
            this.txtAccessToken.TabIndex = 14;
            // 
            // lblAccessToken
            // 
            this.lblAccessToken.AutoSize = true;
            this.lblAccessToken.Location = new System.Drawing.Point(23, 306);
            this.lblAccessToken.Name = "lblAccessToken";
            this.lblAccessToken.Size = new System.Drawing.Size(76, 13);
            this.lblAccessToken.TabIndex = 13;
            this.lblAccessToken.Text = "Access Token";
            // 
            // frmQuizletAuthorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 479);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.lblAccessToken);
            this.Controls.Add(this.txtAuthCode);
            this.Controls.Add(this.lblAuthCode);
            this.Controls.Add(this.txtRedirectURI);
            this.Controls.Add(this.lblRedirectURI);
            this.Controls.Add(this.txtSecretKey);
            this.Controls.Add(this.lblSecretKey);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.lblClientID);
            this.Controls.Add(this.txtURI);
            this.Controls.Add(this.wbAuthorize);
            this.Controls.Add(this.btnAuthorize);
            this.Name = "frmQuizletAuthorize";
            this.Text = "frmQuizlet";
            this.Load += new System.EventHandler(this.frmQuizletAuthorize_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser wbAuthorize;
        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.Button btnAuthorize;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label lblSecretKey;
        private System.Windows.Forms.TextBox txtSecretKey;
        private System.Windows.Forms.Label lblRedirectURI;
        private System.Windows.Forms.TextBox txtRedirectURI;
        private System.Windows.Forms.Label lblAuthCode;
        private System.Windows.Forms.TextBox txtAuthCode;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.Label lblAccessToken;
    }
}
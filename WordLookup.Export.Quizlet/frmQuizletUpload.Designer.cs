namespace WordLookup
{
    partial class frmQuizletUpload
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
            this.lbVocabList = new System.Windows.Forms.ListBox();
            this.lbSets = new System.Windows.Forms.ListBox();
            this.lblVocabList = new System.Windows.Forms.Label();
            this.lblSets = new System.Windows.Forms.Label();
            this.cboUploadType = new System.Windows.Forms.ComboBox();
            this.lblUploadType = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtNewSet = new System.Windows.Forms.TextBox();
            this.lblNewSet = new System.Windows.Forms.Label();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbVocabList
            // 
            this.lbVocabList.FormattingEnabled = true;
            this.lbVocabList.Location = new System.Drawing.Point(12, 44);
            this.lbVocabList.Name = "lbVocabList";
            this.lbVocabList.Size = new System.Drawing.Size(120, 368);
            this.lbVocabList.TabIndex = 0;
            // 
            // lbSets
            // 
            this.lbSets.FormattingEnabled = true;
            this.lbSets.Location = new System.Drawing.Point(164, 109);
            this.lbSets.Name = "lbSets";
            this.lbSets.Size = new System.Drawing.Size(193, 303);
            this.lbSets.TabIndex = 1;
            // 
            // lblVocabList
            // 
            this.lblVocabList.AutoSize = true;
            this.lblVocabList.Location = new System.Drawing.Point(12, 28);
            this.lblVocabList.Name = "lblVocabList";
            this.lblVocabList.Size = new System.Drawing.Size(57, 13);
            this.lblVocabList.TabIndex = 2;
            this.lblVocabList.Text = "Vocab List";
            // 
            // lblSets
            // 
            this.lblSets.AutoSize = true;
            this.lblSets.Location = new System.Drawing.Point(161, 93);
            this.lblSets.Name = "lblSets";
            this.lblSets.Size = new System.Drawing.Size(74, 13);
            this.lblSets.TabIndex = 3;
            this.lblSets.Text = "Available Sets";
            // 
            // cboUploadType
            // 
            this.cboUploadType.FormattingEnabled = true;
            this.cboUploadType.Items.AddRange(new object[] {
            "Create New",
            "Add to Existing"});
            this.cboUploadType.Location = new System.Drawing.Point(164, 56);
            this.cboUploadType.Name = "cboUploadType";
            this.cboUploadType.Size = new System.Drawing.Size(193, 21);
            this.cboUploadType.TabIndex = 4;
            this.cboUploadType.SelectedIndexChanged += new System.EventHandler(this.cboUploadType_SelectedIndexChanged);
            // 
            // lblUploadType
            // 
            this.lblUploadType.AutoSize = true;
            this.lblUploadType.Location = new System.Drawing.Point(161, 35);
            this.lblUploadType.Name = "lblUploadType";
            this.lblUploadType.Size = new System.Drawing.Size(68, 13);
            this.lblUploadType.TabIndex = 5;
            this.lblUploadType.Text = "Upload Type";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(378, 109);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtNewSet
            // 
            this.txtNewSet.Location = new System.Drawing.Point(378, 57);
            this.txtNewSet.Name = "txtNewSet";
            this.txtNewSet.Size = new System.Drawing.Size(125, 20);
            this.txtNewSet.TabIndex = 7;
            // 
            // lblNewSet
            // 
            this.lblNewSet.AutoSize = true;
            this.lblNewSet.Location = new System.Drawing.Point(375, 35);
            this.lblNewSet.Name = "lblNewSet";
            this.lblNewSet.Size = new System.Drawing.Size(48, 13);
            this.lblNewSet.TabIndex = 8;
            this.lblNewSet.Text = "New Set";
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(559, 9);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorize.TabIndex = 9;
            this.btnAuthorize.Text = "Authorize";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            // 
            // frmQuizletUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 430);
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.lblNewSet);
            this.Controls.Add(this.txtNewSet);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblUploadType);
            this.Controls.Add(this.cboUploadType);
            this.Controls.Add(this.lblSets);
            this.Controls.Add(this.lblVocabList);
            this.Controls.Add(this.lbSets);
            this.Controls.Add(this.lbVocabList);
            this.Name = "frmQuizletUpload";
            this.Text = "frmQuizletUpload";
            this.Load += new System.EventHandler(this.frmQuizletUpload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbVocabList;
        private System.Windows.Forms.ListBox lbSets;
        private System.Windows.Forms.Label lblVocabList;
        private System.Windows.Forms.Label lblSets;
        private System.Windows.Forms.ComboBox cboUploadType;
        private System.Windows.Forms.Label lblUploadType;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtNewSet;
        private System.Windows.Forms.Label lblNewSet;
        private System.Windows.Forms.Button btnAuthorize;
    }
}
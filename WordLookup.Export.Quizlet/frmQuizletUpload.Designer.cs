using System;

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
            this.btnUpload = new System.Windows.Forms.Button();
            this.lbUploadedTerms = new System.Windows.Forms.ListBox();
            this.lblUploadedTerms = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbVocabList
            // 
            this.lbVocabList.FormattingEnabled = true;
            this.lbVocabList.Location = new System.Drawing.Point(39, 44);
            this.lbVocabList.Name = "lbVocabList";
            this.lbVocabList.Size = new System.Drawing.Size(120, 368);
            this.lbVocabList.TabIndex = 0;
            // 
            // lbSets
            // 
            this.lbSets.FormattingEnabled = true;
            this.lbSets.Location = new System.Drawing.Point(191, 44);
            this.lbSets.Name = "lbSets";
            this.lbSets.Size = new System.Drawing.Size(193, 368);
            this.lbSets.TabIndex = 1;
            this.lbSets.SelectedIndexChanged += new System.EventHandler(this.lbSets_SelectedIndexChanged);
            // 
            // lblVocabList
            // 
            this.lblVocabList.AutoSize = true;
            this.lblVocabList.Location = new System.Drawing.Point(39, 28);
            this.lblVocabList.Name = "lblVocabList";
            this.lblVocabList.Size = new System.Drawing.Size(57, 13);
            this.lblVocabList.TabIndex = 2;
            this.lblVocabList.Text = "Vocab List";
            // 
            // lblSets
            // 
            this.lblSets.AutoSize = true;
            this.lblSets.Location = new System.Drawing.Point(188, 28);
            this.lblSets.Name = "lblSets";
            this.lblSets.Size = new System.Drawing.Size(74, 13);
            this.lblSets.TabIndex = 3;
            this.lblSets.Text = "Available Sets";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(407, 44);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lbUploadedTerms
            // 
            this.lbUploadedTerms.FormattingEnabled = true;
            this.lbUploadedTerms.Location = new System.Drawing.Point(513, 44);
            this.lbUploadedTerms.Name = "lbUploadedTerms";
            this.lbUploadedTerms.Size = new System.Drawing.Size(120, 368);
            this.lbUploadedTerms.TabIndex = 7;
            // 
            // lblUploadedTerms
            // 
            this.lblUploadedTerms.AutoSize = true;
            this.lblUploadedTerms.Location = new System.Drawing.Point(501, 28);
            this.lblUploadedTerms.Name = "lblUploadedTerms";
            this.lblUploadedTerms.Size = new System.Drawing.Size(85, 13);
            this.lblUploadedTerms.TabIndex = 8;
            this.lblUploadedTerms.Text = "Uploaded Terms";
            // 
            // frmQuizletUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 430);
            this.Controls.Add(this.lblUploadedTerms);
            this.Controls.Add(this.lbUploadedTerms);
            this.Controls.Add(this.btnUpload);
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

        private void cboSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ListBox lbVocabList;
        private System.Windows.Forms.ListBox lbSets;
        private System.Windows.Forms.Label lblVocabList;
        private System.Windows.Forms.Label lblSets;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ListBox lbUploadedTerms;
        private System.Windows.Forms.Label lblUploadedTerms;
    }
}
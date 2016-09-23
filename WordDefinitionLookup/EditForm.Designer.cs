namespace WordDefinitionLookup
{
    partial class frmEdit
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
            this.txtEditField = new System.Windows.Forms.TextBox();
            this.btnSaveDef = new System.Windows.Forms.Button();
            this.btnCancelDef = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEditField
            // 
            this.txtEditField.Location = new System.Drawing.Point(12, 12);
            this.txtEditField.Multiline = true;
            this.txtEditField.Name = "txtEditField";
            this.txtEditField.Size = new System.Drawing.Size(451, 227);
            this.txtEditField.TabIndex = 0;
            // 
            // btnSaveDef
            // 
            this.btnSaveDef.Location = new System.Drawing.Point(97, 269);
            this.btnSaveDef.Name = "btnSaveDef";
            this.btnSaveDef.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDef.TabIndex = 1;
            this.btnSaveDef.Text = "Save";
            this.btnSaveDef.UseVisualStyleBackColor = true;
            this.btnSaveDef.Click += new System.EventHandler(this.btnSaveDef_Click);
            // 
            // btnCancelDef
            // 
            this.btnCancelDef.Location = new System.Drawing.Point(222, 269);
            this.btnCancelDef.Name = "btnCancelDef";
            this.btnCancelDef.Size = new System.Drawing.Size(75, 23);
            this.btnCancelDef.TabIndex = 2;
            this.btnCancelDef.Text = "Cancel";
            this.btnCancelDef.UseVisualStyleBackColor = true;
            this.btnCancelDef.Click += new System.EventHandler(this.btnCancelDef_Click);
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 313);
            this.Controls.Add(this.btnCancelDef);
            this.Controls.Add(this.btnSaveDef);
            this.Controls.Add(this.txtEditField);
            this.Name = "frmEdit";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.frmEditDefinition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEditField;
        private System.Windows.Forms.Button btnSaveDef;
        private System.Windows.Forms.Button btnCancelDef;
    }
}
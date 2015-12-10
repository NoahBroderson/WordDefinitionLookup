namespace WordDefinitionLookup
{
    partial class frmWordLookup
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
            this.txtWordList = new System.Windows.Forms.TextBox();
            this.lblWordList = new System.Windows.Forms.Label();
            this.btnLookup = new System.Windows.Forms.Button();
            this.lblTopDefs = new System.Windows.Forms.Label();
            this.lblAltDefinitions = new System.Windows.Forms.Label();
            this.lbTopDefinitions = new System.Windows.Forms.ListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.lbAltDefinitions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtWordList
            // 
            this.txtWordList.Location = new System.Drawing.Point(25, 63);
            this.txtWordList.Multiline = true;
            this.txtWordList.Name = "txtWordList";
            this.txtWordList.Size = new System.Drawing.Size(201, 343);
            this.txtWordList.TabIndex = 0;
            this.txtWordList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblWordList
            // 
            this.lblWordList.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWordList.Location = new System.Drawing.Point(25, 37);
            this.lblWordList.Name = "lblWordList";
            this.lblWordList.Size = new System.Drawing.Size(201, 23);
            this.lblWordList.TabIndex = 1;
            this.lblWordList.Text = "Word List";
            this.lblWordList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(64, 412);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(75, 23);
            this.btnLookup.TabIndex = 4;
            this.btnLookup.Text = "Lookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // lblTopDefs
            // 
            this.lblTopDefs.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopDefs.Location = new System.Drawing.Point(263, 37);
            this.lblTopDefs.Name = "lblTopDefs";
            this.lblTopDefs.Size = new System.Drawing.Size(201, 23);
            this.lblTopDefs.TabIndex = 7;
            this.lblTopDefs.Text = "Top Definitions";
            this.lblTopDefs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAltDefinitions
            // 
            this.lblAltDefinitions.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltDefinitions.Location = new System.Drawing.Point(561, 37);
            this.lblAltDefinitions.Name = "lblAltDefinitions";
            this.lblAltDefinitions.Size = new System.Drawing.Size(201, 23);
            this.lblAltDefinitions.TabIndex = 8;
            this.lblAltDefinitions.Text = "Alternate Definitions";
            this.lblAltDefinitions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTopDefinitions
            // 
            this.lbTopDefinitions.ColumnWidth = 100;
            this.lbTopDefinitions.FormattingEnabled = true;
            this.lbTopDefinitions.HorizontalScrollbar = true;
            this.lbTopDefinitions.Location = new System.Drawing.Point(247, 63);
            this.lbTopDefinitions.MultiColumn = true;
            this.lbTopDefinitions.Name = "lbTopDefinitions";
            this.lbTopDefinitions.Size = new System.Drawing.Size(299, 342);
            this.lbTopDefinitions.TabIndex = 9;
            this.lbTopDefinitions.SelectedIndexChanged += new System.EventHandler(this.lbTopDefinitions_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(331, 411);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export List";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lbAltDefinitions
            // 
            this.lbAltDefinitions.FormattingEnabled = true;
            this.lbAltDefinitions.HorizontalScrollbar = true;
            this.lbAltDefinitions.Location = new System.Drawing.Point(565, 64);
            this.lbAltDefinitions.Name = "lbAltDefinitions";
            this.lbAltDefinitions.Size = new System.Drawing.Size(301, 342);
            this.lbAltDefinitions.TabIndex = 11;
            this.lbAltDefinitions.DoubleClick += new System.EventHandler(this.lbAltDefinitions_DoubleClick);
            // 
            // frmWordLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 528);
            this.Controls.Add(this.lbAltDefinitions);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lbTopDefinitions);
            this.Controls.Add(this.lblAltDefinitions);
            this.Controls.Add(this.lblTopDefs);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.lblWordList);
            this.Controls.Add(this.txtWordList);
            this.Name = "frmWordLookup";
            this.Text = "Word Lookup";
            this.Load += new System.EventHandler(this.frmWordLookup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWordList;
        private System.Windows.Forms.Label lblWordList;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Label lblTopDefs;
        private System.Windows.Forms.Label lblAltDefinitions;
        private System.Windows.Forms.ListBox lbTopDefinitions;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ListBox lbAltDefinitions;
    }
}


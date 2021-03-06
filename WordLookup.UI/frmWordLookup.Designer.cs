﻿namespace WordLookup
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
            this.lblTopDefs = new System.Windows.Forms.Label();
            this.lblAltDefinitions = new System.Windows.Forms.Label();
            this.lbTopDefinitions = new System.Windows.Forms.ListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.lbAltDefinitions = new System.Windows.Forms.ListBox();
            this.btnPasteList = new System.Windows.Forms.Button();
            this.lbWordList = new System.Windows.Forms.ListBox();
            this.lblWordList = new System.Windows.Forms.Label();
            this.btnLookup = new System.Windows.Forms.Button();
            this.lblIn = new System.Windows.Forms.Label();
            this.cboExportTo = new System.Windows.Forms.ComboBox();
            this.lblExportTo = new System.Windows.Forms.Label();
            this.checkedLBDictionaries = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblTopDefs
            // 
            this.lblTopDefs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopDefs.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopDefs.Location = new System.Drawing.Point(205, 37);
            this.lblTopDefs.Name = "lblTopDefs";
            this.lblTopDefs.Size = new System.Drawing.Size(490, 23);
            this.lblTopDefs.TabIndex = 7;
            this.lblTopDefs.Text = "Top Definitions";
            this.lblTopDefs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAltDefinitions
            // 
            this.lblAltDefinitions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAltDefinitions.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltDefinitions.Location = new System.Drawing.Point(734, 37);
            this.lblAltDefinitions.Name = "lblAltDefinitions";
            this.lblAltDefinitions.Size = new System.Drawing.Size(484, 23);
            this.lblAltDefinitions.TabIndex = 8;
            this.lblAltDefinitions.Text = "Alternate Definitions";
            this.lblAltDefinitions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTopDefinitions
            // 
            this.lbTopDefinitions.AllowDrop = true;
            this.lbTopDefinitions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTopDefinitions.ColumnWidth = 100;
            this.lbTopDefinitions.FormattingEnabled = true;
            this.lbTopDefinitions.HorizontalScrollbar = true;
            this.lbTopDefinitions.Location = new System.Drawing.Point(205, 64);
            this.lbTopDefinitions.MinimumSize = new System.Drawing.Size(90, 342);
            this.lbTopDefinitions.Name = "lbTopDefinitions";
            this.lbTopDefinitions.Size = new System.Drawing.Size(490, 342);
            this.lbTopDefinitions.TabIndex = 9;
            this.lbTopDefinitions.SelectedIndexChanged += new System.EventHandler(this.lbTopDefinitions_SelectedIndexChanged);
            this.lbTopDefinitions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTopDefinitions_MouseDoubleClick);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(575, 441);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 23);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lbAltDefinitions
            // 
            this.lbAltDefinitions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAltDefinitions.FormattingEnabled = true;
            this.lbAltDefinitions.HorizontalScrollbar = true;
            this.lbAltDefinitions.Location = new System.Drawing.Point(734, 64);
            this.lbAltDefinitions.MinimumSize = new System.Drawing.Size(84, 342);
            this.lbAltDefinitions.Name = "lbAltDefinitions";
            this.lbAltDefinitions.Size = new System.Drawing.Size(484, 342);
            this.lbAltDefinitions.TabIndex = 11;
            this.lbAltDefinitions.DoubleClick += new System.EventHandler(this.lbAltDefinitions_DoubleClick);
            // 
            // btnPasteList
            // 
            this.btnPasteList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPasteList.Location = new System.Drawing.Point(34, 412);
            this.btnPasteList.Name = "btnPasteList";
            this.btnPasteList.Size = new System.Drawing.Size(61, 23);
            this.btnPasteList.TabIndex = 14;
            this.btnPasteList.Text = "Paste List";
            this.btnPasteList.UseVisualStyleBackColor = true;
            this.btnPasteList.Click += new System.EventHandler(this.btnPasteList_Click);
            // 
            // lbWordList
            // 
            this.lbWordList.AllowDrop = true;
            this.lbWordList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbWordList.ColumnWidth = 100;
            this.lbWordList.FormattingEnabled = true;
            this.lbWordList.HorizontalScrollbar = true;
            this.lbWordList.Location = new System.Drawing.Point(34, 64);
            this.lbWordList.Name = "lbWordList";
            this.lbWordList.Size = new System.Drawing.Size(132, 342);
            this.lbWordList.TabIndex = 13;
            this.lbWordList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbWordList_KeyDown);
            this.lbWordList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbWordList_MouseDoubleClick);
            // 
            // lblWordList
            // 
            this.lblWordList.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWordList.Location = new System.Drawing.Point(34, 38);
            this.lblWordList.Name = "lblWordList";
            this.lblWordList.Size = new System.Drawing.Size(132, 23);
            this.lblWordList.TabIndex = 12;
            this.lblWordList.Text = "Word List";
            this.lblWordList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLookup
            // 
            this.btnLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLookup.Location = new System.Drawing.Point(101, 412);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(65, 23);
            this.btnLookup.TabIndex = 15;
            this.btnLookup.Text = "Lookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // lblIn
            // 
            this.lblIn.AutoSize = true;
            this.lblIn.Location = new System.Drawing.Point(202, 417);
            this.lblIn.Name = "lblIn";
            this.lblIn.Size = new System.Drawing.Size(37, 13);
            this.lblIn.TabIndex = 17;
            this.lblIn.Text = "Using:";
            // 
            // cboExportTo
            // 
            this.cboExportTo.FormattingEnabled = true;
            this.cboExportTo.Location = new System.Drawing.Point(574, 414);
            this.cboExportTo.Name = "cboExportTo";
            this.cboExportTo.Size = new System.Drawing.Size(121, 21);
            this.cboExportTo.TabIndex = 19;
            // 
            // lblExportTo
            // 
            this.lblExportTo.AutoSize = true;
            this.lblExportTo.Location = new System.Drawing.Point(515, 417);
            this.lblExportTo.Name = "lblExportTo";
            this.lblExportTo.Size = new System.Drawing.Size(56, 13);
            this.lblExportTo.TabIndex = 20;
            this.lblExportTo.Text = "Export To:";
            // 
            // checkedLBDictionaries
            // 
            this.checkedLBDictionaries.CheckOnClick = true;
            this.checkedLBDictionaries.FormattingEnabled = true;
            this.checkedLBDictionaries.Location = new System.Drawing.Point(245, 417);
            this.checkedLBDictionaries.Name = "checkedLBDictionaries";
            this.checkedLBDictionaries.Size = new System.Drawing.Size(120, 79);
            this.checkedLBDictionaries.TabIndex = 21;
            this.checkedLBDictionaries.ThreeDCheckBoxes = true;
            // 
            // frmWordLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 528);
            this.Controls.Add(this.checkedLBDictionaries);
            this.Controls.Add(this.lblExportTo);
            this.Controls.Add(this.cboExportTo);
            this.Controls.Add(this.lblIn);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.btnPasteList);
            this.Controls.Add(this.lbWordList);
            this.Controls.Add(this.lblWordList);
            this.Controls.Add(this.lbAltDefinitions);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lbTopDefinitions);
            this.Controls.Add(this.lblAltDefinitions);
            this.Controls.Add(this.lblTopDefs);
            this.KeyPreview = true;
            this.Name = "frmWordLookup";
            this.Text = "Word Lookup";
            this.Load += new System.EventHandler(this.frmWordLookup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmWordLookup_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTopDefs;
        private System.Windows.Forms.Label lblAltDefinitions;
        private System.Windows.Forms.ListBox lbTopDefinitions;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ListBox lbAltDefinitions;
        private System.Windows.Forms.Button btnPasteList;
        private System.Windows.Forms.ListBox lbWordList;
        private System.Windows.Forms.Label lblWordList;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Label lblIn;
        private System.Windows.Forms.ComboBox cboExportTo;
        private System.Windows.Forms.Label lblExportTo;
        private System.Windows.Forms.CheckedListBox checkedLBDictionaries;
    }
}


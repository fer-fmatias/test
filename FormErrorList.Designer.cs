namespace WinErrorInfo
{
  partial class FormErrorList
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormErrorList));
      this.LvErrors = new System.Windows.Forms.ListView();
      this.ChErrorCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ChDefine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ChErrorText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.CmItems = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.MiCopyErrorCode = new System.Windows.Forms.ToolStripMenuItem();
      this.MiCopyDefine = new System.Windows.Forms.ToolStripMenuItem();
      this.MiCopyErrorString = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.MiCopyAll = new System.Windows.Forms.ToolStripMenuItem();
      this.LabSearch = new System.Windows.Forms.Label();
      this.TbSearch = new System.Windows.Forms.TextBox();
      this.ButClose = new System.Windows.Forms.Button();
      this.ButCopyErrorCode = new System.Windows.Forms.Button();
      this.ButCopyDefine = new System.Windows.Forms.Button();
      this.ButCopyErrorString = new System.Windows.Forms.Button();
      this.ButCopyAll = new System.Windows.Forms.Button();
      this.ButFindNext = new System.Windows.Forms.Button();
      this.LabLang = new System.Windows.Forms.Label();
      this.CbLang = new System.Windows.Forms.ComboBox();
      this.CmItems.SuspendLayout();
      this.SuspendLayout();
      // 
      // LvErrors
      // 
      this.LvErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LvErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChErrorCode,
            this.ChDefine,
            this.ChErrorText});
      this.LvErrors.ContextMenuStrip = this.CmItems;
      this.LvErrors.FullRowSelect = true;
      this.LvErrors.GridLines = true;
      this.LvErrors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.LvErrors.HideSelection = false;
      this.LvErrors.Location = new System.Drawing.Point(12, 10);
      this.LvErrors.MultiSelect = false;
      this.LvErrors.Name = "LvErrors";
      this.LvErrors.ShowItemToolTips = true;
      this.LvErrors.Size = new System.Drawing.Size(725, 356);
      this.LvErrors.TabIndex = 0;
      this.LvErrors.UseCompatibleStateImageBehavior = false;
      this.LvErrors.View = System.Windows.Forms.View.Details;
      this.LvErrors.SelectedIndexChanged += new System.EventHandler(this.LvErrors_SelectedIndexChanged);
      // 
      // ChErrorCode
      // 
      this.ChErrorCode.Text = "Error Code";
      this.ChErrorCode.Width = 91;
      // 
      // ChDefine
      // 
      this.ChDefine.Text = "#define";
      this.ChDefine.Width = 200;
      // 
      // ChErrorText
      // 
      this.ChErrorText.Text = "Error Text";
      this.ChErrorText.Width = 500;
      // 
      // CmItems
      // 
      this.CmItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiCopyErrorCode,
            this.MiCopyDefine,
            this.MiCopyErrorString,
            this.toolStripSeparator1,
            this.MiCopyAll});
      this.CmItems.Name = "CmItems";
      this.CmItems.Size = new System.Drawing.Size(234, 98);
      // 
      // MiCopyErrorCode
      // 
      this.MiCopyErrorCode.Name = "MiCopyErrorCode";
      this.MiCopyErrorCode.Size = new System.Drawing.Size(233, 22);
      this.MiCopyErrorCode.Text = "Copy Error Code to Clipboard";
      this.MiCopyErrorCode.Click += new System.EventHandler(this.MiCopyErrorCode_Click);
      // 
      // MiCopyDefine
      // 
      this.MiCopyDefine.Name = "MiCopyDefine";
      this.MiCopyDefine.Size = new System.Drawing.Size(233, 22);
      this.MiCopyDefine.Text = "Copy #define to Clipboard";
      this.MiCopyDefine.Click += new System.EventHandler(this.MiCopyDefine_Click);
      // 
      // MiCopyErrorString
      // 
      this.MiCopyErrorString.Name = "MiCopyErrorString";
      this.MiCopyErrorString.Size = new System.Drawing.Size(233, 22);
      this.MiCopyErrorString.Text = "Copy Error String to Clipboard";
      this.MiCopyErrorString.Click += new System.EventHandler(this.MiCopyErrorString_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
      // 
      // MiCopyAll
      // 
      this.MiCopyAll.Name = "MiCopyAll";
      this.MiCopyAll.Size = new System.Drawing.Size(233, 22);
      this.MiCopyAll.Text = "Copy All to Clipboard";
      this.MiCopyAll.Click += new System.EventHandler(this.MiCopyAll_Click);
      // 
      // LabSearch
      // 
      this.LabSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.LabSearch.AutoSize = true;
      this.LabSearch.Location = new System.Drawing.Point(256, 375);
      this.LabSearch.Name = "LabSearch";
      this.LabSearch.Size = new System.Drawing.Size(44, 13);
      this.LabSearch.TabIndex = 6;
      this.LabSearch.Text = "Search:";
      // 
      // TbSearch
      // 
      this.TbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TbSearch.Location = new System.Drawing.Point(306, 372);
      this.TbSearch.Name = "TbSearch";
      this.TbSearch.Size = new System.Drawing.Size(344, 20);
      this.TbSearch.TabIndex = 7;
      this.TbSearch.TextChanged += new System.EventHandler(this.TbSearch_TextChanged);
      // 
      // ButClose
      // 
      this.ButClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ButClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ButClose.Location = new System.Drawing.Point(743, 375);
      this.ButClose.Name = "ButClose";
      this.ButClose.Size = new System.Drawing.Size(81, 23);
      this.ButClose.TabIndex = 5;
      this.ButClose.Text = "Close";
      this.ButClose.UseVisualStyleBackColor = true;
      this.ButClose.Click += new System.EventHandler(this.ButClose_Click);
      // 
      // ButCopyErrorCode
      // 
      this.ButCopyErrorCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ButCopyErrorCode.Enabled = false;
      this.ButCopyErrorCode.Location = new System.Drawing.Point(743, 10);
      this.ButCopyErrorCode.Name = "ButCopyErrorCode";
      this.ButCopyErrorCode.Size = new System.Drawing.Size(81, 59);
      this.ButCopyErrorCode.TabIndex = 1;
      this.ButCopyErrorCode.Text = "Copy Error Code to Clipboard";
      this.ButCopyErrorCode.UseVisualStyleBackColor = true;
      this.ButCopyErrorCode.Click += new System.EventHandler(this.ButCopyErrorCode_Click);
      // 
      // ButCopyDefine
      // 
      this.ButCopyDefine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ButCopyDefine.Enabled = false;
      this.ButCopyDefine.Location = new System.Drawing.Point(743, 77);
      this.ButCopyDefine.Name = "ButCopyDefine";
      this.ButCopyDefine.Size = new System.Drawing.Size(81, 59);
      this.ButCopyDefine.TabIndex = 2;
      this.ButCopyDefine.Text = "Copy #define to Clipboard";
      this.ButCopyDefine.UseVisualStyleBackColor = true;
      this.ButCopyDefine.Click += new System.EventHandler(this.ButCopyDefine_Click);
      // 
      // ButCopyErrorString
      // 
      this.ButCopyErrorString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ButCopyErrorString.Enabled = false;
      this.ButCopyErrorString.Location = new System.Drawing.Point(743, 142);
      this.ButCopyErrorString.Name = "ButCopyErrorString";
      this.ButCopyErrorString.Size = new System.Drawing.Size(81, 59);
      this.ButCopyErrorString.TabIndex = 3;
      this.ButCopyErrorString.Text = "Copy Error String to Clipboard";
      this.ButCopyErrorString.UseVisualStyleBackColor = true;
      this.ButCopyErrorString.Click += new System.EventHandler(this.ButCopyErrorString_Click);
      // 
      // ButCopyAll
      // 
      this.ButCopyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ButCopyAll.Enabled = false;
      this.ButCopyAll.Location = new System.Drawing.Point(743, 207);
      this.ButCopyAll.Name = "ButCopyAll";
      this.ButCopyAll.Size = new System.Drawing.Size(81, 59);
      this.ButCopyAll.TabIndex = 4;
      this.ButCopyAll.Text = "Copy All to Clipboard";
      this.ButCopyAll.UseVisualStyleBackColor = true;
      this.ButCopyAll.Click += new System.EventHandler(this.ButCopyAll_Click);
      // 
      // ButFindNext
      // 
      this.ButFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ButFindNext.Enabled = false;
      this.ButFindNext.Location = new System.Drawing.Point(656, 369);
      this.ButFindNext.Name = "ButFindNext";
      this.ButFindNext.Size = new System.Drawing.Size(81, 23);
      this.ButFindNext.TabIndex = 8;
      this.ButFindNext.Text = "Find Next (F3)";
      this.ButFindNext.UseVisualStyleBackColor = true;
      this.ButFindNext.Click += new System.EventHandler(this.ButFindNext_Click);
      // 
      // LabLang
      // 
      this.LabLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.LabLang.AutoSize = true;
      this.LabLang.Location = new System.Drawing.Point(9, 374);
      this.LabLang.Name = "LabLang";
      this.LabLang.Size = new System.Drawing.Size(58, 13);
      this.LabLang.TabIndex = 10;
      this.LabLang.Text = "Language:";
      // 
      // CbLang
      // 
      this.CbLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CbLang.FormattingEnabled = true;
      this.CbLang.Location = new System.Drawing.Point(73, 372);
      this.CbLang.Name = "CbLang";
      this.CbLang.Size = new System.Drawing.Size(177, 21);
      this.CbLang.TabIndex = 12;
      this.CbLang.SelectedIndexChanged += new System.EventHandler(this.CbLang_SelectedIndexChanged);
      // 
      // FormErrorList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButClose;
      this.ClientSize = new System.Drawing.Size(831, 403);
      this.Controls.Add(this.CbLang);
      this.Controls.Add(this.ButFindNext);
      this.Controls.Add(this.ButCopyAll);
      this.Controls.Add(this.ButCopyErrorString);
      this.Controls.Add(this.LabLang);
      this.Controls.Add(this.ButCopyDefine);
      this.Controls.Add(this.ButCopyErrorCode);
      this.Controls.Add(this.TbSearch);
      this.Controls.Add(this.LabSearch);
      this.Controls.Add(this.LvErrors);
      this.Controls.Add(this.ButClose);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MinimumSize = new System.Drawing.Size(450, 400);
      this.Name = "FormErrorList";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Error List";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormErrorList_KeyDown);
      this.CmItems.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListView LvErrors;
    private System.Windows.Forms.ColumnHeader ChErrorCode;
    private System.Windows.Forms.ColumnHeader ChDefine;
    private System.Windows.Forms.ColumnHeader ChErrorText;
    private System.Windows.Forms.ContextMenuStrip CmItems;
    private System.Windows.Forms.ToolStripMenuItem MiCopyErrorCode;
    private System.Windows.Forms.ToolStripMenuItem MiCopyDefine;
    private System.Windows.Forms.ToolStripMenuItem MiCopyErrorString;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem MiCopyAll;
    private System.Windows.Forms.Label LabSearch;
    private System.Windows.Forms.TextBox TbSearch;
    private System.Windows.Forms.Button ButClose;
    private System.Windows.Forms.Button ButCopyErrorCode;
    private System.Windows.Forms.Button ButCopyDefine;
    private System.Windows.Forms.Button ButCopyErrorString;
    private System.Windows.Forms.Button ButCopyAll;
    private System.Windows.Forms.Button ButFindNext;
    private System.Windows.Forms.Label LabLang;
    private System.Windows.Forms.ComboBox CbLang;
  }
}
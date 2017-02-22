namespace WinErrorInfo
{
  partial class FormMain
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
      this.TbError = new System.Windows.Forms.TextBox();
      this.LabError = new System.Windows.Forms.Label();
      this.TbText = new System.Windows.Forms.TextBox();
      this.ButClose = new System.Windows.Forms.Button();
      this.ButWinErrorH = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // TbError
      // 
      this.TbError.Location = new System.Drawing.Point(78, 6);
      this.TbError.Name = "TbError";
      this.TbError.Size = new System.Drawing.Size(164, 20);
      this.TbError.TabIndex = 0;
      this.TbError.TextChanged += new System.EventHandler(this.TbError_TextChanged);
      // 
      // LabError
      // 
      this.LabError.AutoSize = true;
      this.LabError.Location = new System.Drawing.Point(12, 9);
      this.LabError.Name = "LabError";
      this.LabError.Size = new System.Drawing.Size(60, 13);
      this.LabError.TabIndex = 1;
      this.LabError.Text = "Error Code:";
      // 
      // TbText
      // 
      this.TbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.TbText.Location = new System.Drawing.Point(9, 32);
      this.TbText.Multiline = true;
      this.TbText.Name = "TbText";
      this.TbText.ReadOnly = true;
      this.TbText.Size = new System.Drawing.Size(441, 121);
      this.TbText.TabIndex = 3;
      // 
      // ButClose
      // 
      this.ButClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ButClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ButClose.Location = new System.Drawing.Point(375, 159);
      this.ButClose.Name = "ButClose";
      this.ButClose.Size = new System.Drawing.Size(75, 23);
      this.ButClose.TabIndex = 4;
      this.ButClose.Text = "&Close";
      this.ButClose.UseVisualStyleBackColor = true;
      this.ButClose.Click += new System.EventHandler(this.ButClose_Click);
      // 
      // ButWinErrorH
      // 
      this.ButWinErrorH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ButWinErrorH.Location = new System.Drawing.Point(364, 4);
      this.ButWinErrorH.Name = "ButWinErrorH";
      this.ButWinErrorH.Size = new System.Drawing.Size(86, 23);
      this.ButWinErrorH.TabIndex = 5;
      this.ButWinErrorH.Text = "WinError List";
      this.ButWinErrorH.UseVisualStyleBackColor = true;
      this.ButWinErrorH.Click += new System.EventHandler(this.ButWinErrorH_Click);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButClose;
      this.ClientSize = new System.Drawing.Size(457, 188);
      this.Controls.Add(this.ButWinErrorH);
      this.Controls.Add(this.ButClose);
      this.Controls.Add(this.TbText);
      this.Controls.Add(this.LabError);
      this.Controls.Add(this.TbError);
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(361, 189);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Window Error Information";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TbError;
    private System.Windows.Forms.Label LabError;
    private System.Windows.Forms.TextBox TbText;
    private System.Windows.Forms.Button ButClose;
    private System.Windows.Forms.Button ButWinErrorH;
  }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace WinErrorInfo
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Interpretar código de error.
    /// </summary>
    private void TbError_TextChanged(object sender, EventArgs e)
    {
      // Obtener código del error
      string errStr = TbError.Text.Trim();
      if (errStr.Length == 0)
      {
        TbText.Text = "";
        return;
      }
      int errCode;
      NumberStyles style;
      if (errStr.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase))
      {
        style = NumberStyles.HexNumber;
        errStr = errStr.Substring(2);
      }
      else
        style = NumberStyles.Integer;
      try
      {
        errCode = Int32.Parse(errStr, style);
      }
      catch (Exception excp)
      {
        TbText.Text = String.Format("Value is not a valid number:\r\n{0}", excp.Message);
        return;
      }

      // Obtener texto asociado al error
      try
      {
        throw new Win32Exception(errCode);
      }
      catch (Exception excp)
      {
        TbText.Text = excp.Message;
      }

    }

    private void ButClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ButWinErrorH_Click(object sender, EventArgs e)
    {
      WinErrorInfo wei;
      try
      {
        wei = new WinErrorInfo();
      }
      catch (Exception excp)
      {
        MessageBox.Show(this, excp.Message, "Windows Error Information",  MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      FormErrorList frm = new FormErrorList(wei);
      frm.ShowDialog(this);
      frm.Dispose();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinErrorInfo
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      WinErrorInfo wei;
      try
      {
        wei = new WinErrorInfo();
      }
      catch (Exception excp)
      {
        MessageBox.Show(excp.Message, "Windows Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      FormErrorList frm = new FormErrorList(wei);
      Application.Run(frm);
    }
  }
}

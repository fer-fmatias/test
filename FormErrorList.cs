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
  public partial class FormErrorList : Form
  {
    public FormErrorList(WinErrorInfo wei)
    {
      InitializeComponent();
      m_WEI = wei;
      m_SelectedIndex = -1;
      CbLang.BeginUpdate();
      foreach (var item in WErrorItem.EnumLocales())
      {
        try
        {
          CbLang.Items.Add(item.ToString() + " - " + CultureInfo.GetCultureInfo((int)item).DisplayName);
        }
        catch
        {
        }
      }
      CbLang.SelectedIndex = 0;
    }

    // Lista de errores.
    private WinErrorInfo m_WEI;

    /// <summary>
    /// Rellenar los elementos de la lista de errores.
    /// </summary>
    private void FillItems(ushort lang)
    {
      LvErrors.BeginUpdate();
      LvErrors.Items.Clear();
      foreach(var item in m_WEI.List)
      {
        ListViewItem lvi;
        if(item.Hexadecimal)
          lvi = LvErrors.Items.Add(String.Format("0x{0:X8}", item.ErrorCode));
        else
          lvi = LvErrors.Items.Add(item.ErrorCode.ToString());
        lvi.SubItems.Add(item.DefineValue);
        lvi.SubItems.Add(item.GetErrorString(lang));
      }
      LvErrors.Columns[0].Width = -1;
      LvErrors.Columns[2].Width = -1;
      LvErrors.EndUpdate();
    }

    private void MiCopyErrorCode_Click(object sender, EventArgs e)
    {
      ButCopyErrorCode.PerformClick();
    }

    private void MiCopyDefine_Click(object sender, EventArgs e)
    {
      ButCopyDefine.PerformClick();
    }

    private void MiCopyErrorString_Click(object sender, EventArgs e)
    {
      ButCopyErrorString.PerformClick();
    }

    private void MiCopyAll_Click(object sender, EventArgs e)
    {
      ButCopyAll.PerformClick();
    }

    private void ButCopyErrorCode_Click(object sender, EventArgs e)
    {
      if (LvErrors.SelectedItems.Count != 1)
        return;
      Clipboard.SetData(DataFormats.UnicodeText, LvErrors.SelectedItems[0].SubItems[0].Text);
    }

    private void ButCopyDefine_Click(object sender, EventArgs e)
    {
      if (LvErrors.SelectedItems.Count != 1)
        return;
      Clipboard.SetData(DataFormats.UnicodeText, LvErrors.SelectedItems[0].SubItems[1].Text);
    }

    private void ButCopyErrorString_Click(object sender, EventArgs e)
    {
      if (LvErrors.SelectedItems.Count != 1)
        return;
      Clipboard.SetData(DataFormats.UnicodeText, LvErrors.SelectedItems[0].SubItems[2].Text);
    }

    private void ButCopyAll_Click(object sender, EventArgs e)
    {
      if (LvErrors.SelectedItems.Count != 1)
        return;
      var si = LvErrors.SelectedItems[0].SubItems;
      string str = String.Format("{0} {1} {2}", si[0].Text, si[1].Text, si[2].Text);
      Clipboard.SetData(DataFormats.UnicodeText, str);
    }

    /// <summary>
    /// Seleccionar elemento.
    /// </summary>
    /// <param name="indexStart">Indice donde comenzar.</param>
    /// <param name="str">Texto a buscar.</param>
    private int SearchItem(int indexStart, string str)
    {
      if (str.Length == 0)
        return -1;
      for (int n = 0; n < m_WEI.List.Count; n++)
      {
        if (indexStart >= m_WEI.List.Count)
          indexStart = indexStart % m_WEI.List.Count;
        foreach (ListViewItem.ListViewSubItem item in LvErrors.Items[indexStart].SubItems)
        {
          if (item.Text.IndexOf(str, StringComparison.InvariantCultureIgnoreCase) != -1)
            return indexStart;
        }
        ++indexStart;
      }
      return -1;
    }

    /// <summary>
    /// Cambiar la selección del error.
    /// </summary>
    /// <param name="newSelection">Nueva selección.</param>
    private void ChangeSelection(int newSelection)
    {
      if(LvErrors.SelectedItems.Count == 1)
      {
        ListViewItem lvi = LvErrors.SelectedItems[0];
        if (lvi.Index == newSelection)
          return;
        lvi.Selected = false;
        lvi.Focused = false;
      }
      if (newSelection != -1)
      {
        ListViewItem lvi = LvErrors.Items[newSelection];
        lvi.Selected = true;
        lvi.Focused = true;
        lvi.EnsureVisible();
      }
    }

    private int m_SelectedIndex;

    private void TbSearch_TextChanged(object sender, EventArgs e)
    {
      m_SelectedIndex = SearchItem(0, TbSearch.Text.Trim());
      ChangeSelection(m_SelectedIndex);
      ButFindNext.Enabled = (m_SelectedIndex != -1);
    }

    private void ButFindNext_Click(object sender, EventArgs e)
    {
      if (m_SelectedIndex == -1)
        return;
      int ndx = SearchItem(m_SelectedIndex + 1, TbSearch.Text.Trim());
      if ((ndx == -1) || (ndx == m_SelectedIndex))
      {
        ChangeSelection(ndx);
        ButFindNext.Enabled = false;
        TbSearch.Focus();
        return;
      }
      m_SelectedIndex = ndx;
      ChangeSelection(m_SelectedIndex);
    }

    private void LvErrors_SelectedIndexChanged(object sender, EventArgs e)
    {
      bool fEnable = (LvErrors.SelectedItems.Count == 1);
      ButCopyErrorCode.Enabled = fEnable;
      ButCopyDefine.Enabled = fEnable;
      ButCopyErrorString.Enabled = fEnable;
      ButCopyAll.Enabled = fEnable;
    }

    private void FormErrorList_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F3)
      {
        if (ButFindNext.Enabled)
        {
          ButFindNext.PerformClick();
          e.Handled = true;
        }
      }
    }

    private void ButClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void CbLang_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (CbLang.SelectedIndex == -1)
        return;
      string str = (string)CbLang.Items[CbLang.SelectedIndex];
      str = str.Split('-')[0].Trim();
      FillItems(ushort.Parse(str));
    }
  }
}
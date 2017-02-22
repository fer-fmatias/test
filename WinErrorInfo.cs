using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;
using System.Globalization;
using WinErrorInfo.Properties;

namespace WinErrorInfo
{
  /// <summary>
  /// Estructura con información de un error de Windows.
  /// </summary>
  public class WErrorItem
  {
    [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
    private static extern uint FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, [Out] StringBuilder lpBuffer, uint nSize, string[] Arguments);

    private const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
    private const uint FORMAT_MESSAGE_MAX_WIDTH_MASK = 0x000000FF;
    private const ushort LANG_ENGLISH = 0x09;
    private const ushort LANG_NEUTRAL = 0x00;
    private const ushort SUBLANG_DEFAULT = 0x01;

    private uint MAKELANGID(ushort lang, ushort subLang)
    {
      return (uint)((subLang << 10) | lang);
    }

    /// <summary>
    /// Código de error.
    /// </summary>
    public uint ErrorCode;

    /// <summary>
    /// Valor de su constante #define asociada.
    /// </summary>
    public string DefineValue;

    /// <summary>
    /// Texto asociado al error.
    /// </summary>
    public string GetErrorString(ushort langID)
    {
      try
      {
        StringBuilder str = new StringBuilder(250);
        uint errCode = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_MAX_WIDTH_MASK, IntPtr.Zero, (uint)ErrorCode, langID, str, (uint)str.Capacity, null);
        if (errCode == 0)
          return "<No info>";
        return str.ToString();
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// Indicador de que el número estaba en hexadecimal.
    /// </summary>
    public bool Hexadecimal;

    /// <summary>
    /// Obtener lista de lenguajes aplicables para obtener textos de error.
    /// </summary>
    /// <returns>Lista de indentificadores de lenguaje.</returns>
    static public List<ushort> EnumLocales()
    {
      List<ushort> lList = new List<ushort>();
      lList.Add((ushort)(CultureInfo.CurrentCulture.LCID & 0xFFFF));
      StringBuilder str = new StringBuilder(250);
      foreach (var item in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
      {
        ushort langID = (ushort)(item.LCID & 0xFFFF);
        try
        {
          uint errCode = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_MAX_WIDTH_MASK, IntPtr.Zero, 3, (uint)langID, str, (uint)str.Capacity, null);
          if (errCode != 0)
          {
            if (!lList.Contains(langID))
              lList.Add(langID);
          }
        }
        catch { }
      }
      return lList;
    }
  }

  public class WinErrorInfo
  {
    /// <summary>
    /// Comprobar si el sistema operativo es de 64 bits.
    /// </summary>
    /// <returns>true si el SO es de 64 bits.</returns>
    private bool IsOperatingSystem64()
    {
      return (IntPtr.Size == 8);
    }

    // Lista de errores disponibles.
    private List<WErrorItem> m_List;

    /// <summary>
    /// Lista de errores disponibles.
    /// </summary>
    public List<WErrorItem> List
    {
      get { return m_List; }
    }

    /// <summary>
    /// Construir objeto con la lista de errores de Windows.
    /// </summary>
    public WinErrorInfo()
    {
      m_List = new List<WErrorItem>();
      m_Separator = new char[] {' ', '\t'};

      // Obtener stream.
      StreamReader sr = GetStreamErrorTextInstalled();
      if (sr == null)
      {
        sr = GetStreamErrorTextResource();
        if (sr == null)
          throw new Exception("Could not locate WinError.h");
      }

      // Abrir fichero de errores "include\WinError.h".
      using (sr)
      {
        // Leer todas las líneas del fichero.
        while (true)
        {
          string line = sr.ReadLine();
          if (line == null)
            break;
          WErrorItem wei = ParseWinErrorLine(line.Trim());
          if (wei == null)
            continue;
          List.Add(wei);
        }
      }
    }

    /// <summary>
    /// Obtener stream del fichero de errores si el SDK está instalado.
    /// </summary>
    private StreamReader GetStreamErrorTextInstalled()
    {
      // The Windows SDK team has received a number of questions about how we manage
      // our registry, so I wanted to take a minute to describe the way that the Windows
      // SDK writes to the registry.
      // On installation of a Windows SDK, including Windows SDK components installed
      // with Visual Studio 2008, the following registry keys are written:
      // On an X86 computer:
      //    HKLM\SOFTWARE\Microsoft\Microsoft SDKs\Windows
      //    HKCU\SOFTWARE\Microsoft\Microsoft SDKs\Windows
      // In addition to the keys listed above, this key is set when installing on an X64
      // or IA64 computer:
      //    HKLM\SOFTWARE\Wow6432Node\Microsoft\Microsoft SDKs\Windows
      // At the root of each of those folders, the SDK sets the following keys:
      // Name                     Data
      // ----                     ----
      // CurrentIA64Folder        If Visual Studio 2008 is installed, this key points to
      //                          the install location of the IA64 Libraries that are installed.
      // CurrentIA64Version       If Visual Studio 2008 is installed, this key points to
      //                          the latest version of the IA64 Libraries that are installed.
      // CurrentInstallFolder     Install location for the most recently installed Windows SDK.
      // CurrentVersion           Version number of the most recently installed Windows SDK.
      // ProductVersion           Version number of the newest version of the Windows SDK
      //                          installed to disk.

      // Comprobar si el SDK está instalado.
      string rPath;
      if (IsOperatingSystem64())
        rPath = @"SOFTWARE\Wow6432Node\Microsoft\Microsoft SDKs\Windows";
      else
        rPath = @"SOFTWARE\Microsoft\Microsoft SDKs\Windows";
      RegistryKey rk = Registry.LocalMachine.OpenSubKey(rPath);
      if (rk == null)
        return null;
      object sdkFolder = rk.GetValue("CurrentInstallFolder");
      if ((sdkFolder == null) || !(sdkFolder is string))
        return null;
      try
      {
        return new StreamReader(Path.Combine((string)sdkFolder, @"include\WinError.h"));
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// Obtener stream del fichero de errores como recurso.
    /// </summary>
    private StreamReader GetStreamErrorTextResource()
    {
      string tmpFile = Path.Combine(Path.GetTempPath(), "WinError.h");
      try
      {
        File.WriteAllText(tmpFile, Resources.WinError);
        return new StreamReader(tmpFile);
      }
      catch
      {
        return null;
      }
    }

    private static char[] m_Separator;

    /// <summary>
    /// Parsear un línea de WinError.h
    /// </summary>
    /// <param name="str">Cadena de texto con la línea a parsear.</param>
    /// <returns>Información del error o null.</returns>
    private WErrorItem ParseWinErrorLine(string str)
    {
      // Los errores son del tipo:
      //    #define ERROR_TOO_MANY_OPEN_FILES        4L
      //    #define FWP_E_CALLOUT_NOTIFICATION_FAILED _HRESULT_TYPEDEF_(0x80320037L)
      if(str.Length < 20)
        return null;
      if (!str.StartsWith("#define"))
        return null;

      // Buscar nombre del '#define' asociado.
      int ndxDef1 = 7;
      int ndxDef2;
      try
      {
        while (char.IsSeparator(str[ndxDef1]))
          ++ndxDef1;
        ndxDef2 = ndxDef1;
        while (!char.IsSeparator(str[ndxDef2]))
          ++ndxDef2;
      }
      catch
      {
        return null; 
      }

      // Buscar código de error (terminado en L)
      int ndxCode1 = ndxDef2;
      int ndxCode2;
      try
      {
        while (!char.IsDigit(str[ndxCode1]))
          ++ndxCode1;
        ndxCode2 = ndxCode1;
        while (str[ndxCode2] != 'L')
          ++ndxCode2;
      }
      catch
      {
        return null;
      }
      string strCode = str.Substring(ndxCode1, ndxCode2 - ndxCode1);
      uint errCode;
      bool fHex;
      if (strCode.StartsWith("0x", StringComparison.InvariantCultureIgnoreCase))
      {
        if (!uint.TryParse(strCode.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out errCode))
          return null;
        fHex = true;
      }
      else
      {
        if (!uint.TryParse(strCode, out errCode))
          return null;
        fHex = false;
      }

      // Devolver información del error.
      WErrorItem wei = new WErrorItem();
      wei.DefineValue = str.Substring(ndxDef1, ndxDef2 - ndxDef1);
      wei.ErrorCode = errCode;
      wei.Hexadecimal = fHex;
      return wei;
    }
  }
}

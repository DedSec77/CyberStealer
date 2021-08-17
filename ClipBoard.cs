using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CyberStyler
{
    class ClipBoard
    {
        private const uint CF_UNICODETEXT = 0xD;

        public static string GetClipBorad()
        {
            if (WinAPI.IsClipboardFormatAvailable(CF_UNICODETEXT) && WinAPI.OpenClipboard(IntPtr.Zero))
            {
                string data = string.Empty;
                IntPtr hGlobal = WinAPI.GetClipboardData(CF_UNICODETEXT);
                if (!hGlobal.Equals(IntPtr.Zero))
                {
                    IntPtr lpwcstr = WinAPI.GlobalLock(hGlobal);
                    if (!lpwcstr.Equals(IntPtr.Zero))
                    {
                        try
                        {
                            data = Marshal.PtrToStringUni(lpwcstr);
                            WinAPI.GlobalUnlock(lpwcstr);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                WinAPI.CloseClipboard();
                return data;
            }
            return null;
        }
    }
}

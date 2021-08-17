using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CyberStyler
{
    class WinAPI
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr GetClipboardData(uint uFormat);

        [DllImport("user32.dll")]
        public static extern bool IsClipboardFormatAvailable(uint format);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool CloseClipboard();

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("kernel32.dll")]
        internal static extern bool GlobalUnlock(IntPtr hMem);

    }
}
    

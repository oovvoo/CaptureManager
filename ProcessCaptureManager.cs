using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureManager
{
    public class ProcessCaptureManager
    {
        #region  win32API
        [DllImport("user32.dll")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);
    
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect); // client랑 window랑 차이있음 인지할것

        [DllImport("user32.dll")]
        private static extern IntPtr GetClientRect(IntPtr hWnd, ref Rect rect);


        [DllImport("dwmapi.dll")]
        private static extern int DwmGetWindowAttribute(IntPtr handle, int dwAttribute, out Rect pvAttribute, int cbAttribute);

        
        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int
        wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr ptr);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, UInt32 nFlags);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
        #endregion
                
        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        private static Control mControl;
        public ProcessCaptureManager(Control f)
        {
            mControl = f;            
        }
     
        public Bitmap GetBitmap(Process p)
        {
            if (p == null) return null;

            try
            {
                
                IntPtr handle = p.MainWindowHandle;

                IntPtr hRgn = CreateRectRgn(0, 0, 0, 0);
                GetWindowRgn(handle, hRgn);

                Graphics g = mControl.CreateGraphics();

                Rect rect = new Rect();
                IntPtr error = GetClientRect(handle, ref rect);

                int retctengleSize = Marshal.SizeOf(typeof(Rectangle));
                DwmGetWindowAttribute(handle, 9, out rect, retctengleSize);

                int width = rect.right - rect.left;
                int height = rect.bottom - rect.top;

                Bitmap bmp = new Bitmap(width, height, g);
                using (Graphics memoryGraphics = Graphics.FromImage(bmp))
                {
                    IntPtr dc = memoryGraphics.GetHdc();
                    // nFlags : 0=include border , 1=client area only , 2= directX 포함
                    try
                    {
                        PrintWindow(handle, dc, 1);
                    }
                    finally
                    {
                        memoryGraphics.ReleaseHdc(dc);
                    }
                }

                return bmp;
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }
        public Bitmap GetBitmap(TabPage webViewTab)
        {
            try
            {
                return ScreenCapture.captureControl(webViewTab);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }

        public Bitmap captureControl(Control control)
        {
            //  API  
            IntPtr hSrce = GetWindowDC(control.Handle);
            IntPtr hDest = CreateCompatibleDC(hSrce);
            IntPtr hBmp = CreateCompatibleBitmap(hSrce, control.Width, control.Height);
            IntPtr hOldBmp = SelectObject(hDest, hBmp);
            if (BitBlt(hDest, 0, 0, control.Width, control.Height, hSrce, 0, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt))
            {
                Bitmap bmp = Image.FromHbitmap(hBmp);
                SelectObject(hDest, hOldBmp);
                DeleteObject(hBmp);
                DeleteDC(hDest);
                ReleaseDC(control.Handle, hSrce);
                return bmp;
            }
            return null;

        }

        public void Save(Process p, string fileName)
        {
            GetBitmap(p).Save(fileName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureManager
{
    class ScreenCapture
    {
        #region     
        /// <summary>
        ///     (     )
        /// </summary>
        /// <param name="x">       </param>
        /// <param name="y">       </param>
        /// <param name="width">    </param>
        /// <param name="height">    </param>
        /// <returns></returns>
        public static Bitmap captureScreen(int x, int y, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(new Point(x, y), new Point(0, 0), bmp.Size);
                g.Dispose();
            }
            //bit.Save(@"capture2.png");
            return bmp;
        }

        /// <summary>
        ///        
        /// </summary>
        /// <returns></returns>
        public static Bitmap captureScreen()
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            return captureScreen(0, 0, screenSize.Width, screenSize.Height);
        }
        #endregion

        #region   BitBlt      ，         
        /// <summary>
        ///   (  )   ，       (        )          ，  BitBlt  
        /// </summary>
        /// <param name="control">        </param>
        /// <returns>      ，             </returns>
        public static Bitmap captureControl(Control control)
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
                // bmp.Save(@"a.png");
                // bmp.Dispose();
                return bmp;
            }
            return null;

        }

        //         /// <summary>
        //         ///    ！！！！！         
        //         ///   (  )       ，       (        )          ，  BitBlt  
        //         /// </summary>
        //         /// <param name="control">        </param>
        //         /// <returns>  (  )       </returns>
        //         public static Bitmap captureClientArea(Control control)
        //         {
        // 
        //             Size sz = control.Size;
        //             Rectangle rect = control.ClientRectangle;
        //             
        // 
        //             //  API  
        //             IntPtr hSrce = GetWindowDC(control.Handle);
        //             IntPtr hDest = CreateCompatibleDC(hSrce);
        //             IntPtr hBmp = CreateCompatibleBitmap(hSrce, rect.Width, rect.Height);
        //             IntPtr hOldBmp = SelectObject(hDest, hBmp);
        //             if (BitBlt(hDest, 0, 0, rect.Width, rect.Height, hSrce, rect.X, rect.Y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt))
        //             {
        //                 Bitmap bmp = Image.FromHbitmap(hBmp);
        //                 SelectObject(hDest, hOldBmp);
        //                 DeleteObject(hBmp);
        //                 DeleteDC(hDest);
        //                 ReleaseDC(control.Handle, hSrce);
        //                 // bmp.Save(@"a.png");
        //                 // bmp.Dispose();
        //                 return bmp;
        //             }
        //             return null;
        // 
        //         }
        #endregion


        #region   PrintWindow      ，         
        /// <summary>
        ///      ，             ，  PrintWindow  
        /// </summary>
        /// <param name="control">        </param>
        /// <returns>     ，             </returns>
        public static Bitmap captureWindowUsingPrintWindow(Form form)
        {
            return GetWindow(form.Handle);
        }


        private static Bitmap GetWindow(IntPtr hWnd)
        {
            IntPtr hscrdc = GetWindowDC(hWnd);
            Control control = Control.FromHandle(hWnd);
            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, control.Width, control.Height);
            IntPtr hmemdc = CreateCompatibleDC(hscrdc);
            SelectObject(hmemdc, hbitmap);
            PrintWindow(hWnd, hmemdc, 0);
            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);
            DeleteDC(hscrdc);//       
            DeleteDC(hmemdc);//       
            return bmp;
        }
        #endregion

        #region  DLL calls
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
    }
}

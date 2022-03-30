using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CaptureManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        private static extern int IsIconic(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        public IntPtr Client_Connection(string clientname)
        {
            IntPtr iResulthwnd = new IntPtr();
            int inthwnd = FindWindow(clientname,null);
            if(inthwnd == 0) inthwnd  = FindWindow(null, clientname);

            int test = IsIconic((IntPtr)inthwnd);

            if (test != 0)
            {
                //최소화된 창을 복원
                ShowWindow((IntPtr)inthwnd, SW_RESTORE);
            }

            if (inthwnd == 0)
            {
                iResulthwnd = new IntPtr(inthwnd);
            }
            else
            {
                iResulthwnd = new IntPtr(inthwnd);

            }
            return iResulthwnd;

        }

        [DllImport("user32.dll", SetLastError = true)]

        static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("gdi32.dll")]

        static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect); // client랑 window랑 차이있음 인지할것
        
        [DllImport("user32.dll")]
        public static extern IntPtr GetClientRect(IntPtr hWnd, ref Rect rect);  

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            IntPtr handle = Client_Connection("notepad");
            
            IntPtr hRgn = CreateRectRgn(0, 0, 0, 0);

            GetWindowRgn(handle, hRgn);
            Graphics g = this.CreateGraphics();
            
            Rect rect = new Rect();
            IntPtr error = GetClientRect(handle, ref rect);
            
            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            Bitmap bmp = new Bitmap(width, height, g);            
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            IntPtr dc = memoryGraphics.GetHdc();
            // nFlags : 0=include border , 1=client area only
            bool success = PrintWindow(handle, dc, 1);
            memoryGraphics.ReleaseHdc(dc);

            bmp.Save(@"d:\a.bmp");
            pictureBox1.Image = bmp;

        }
    }
}

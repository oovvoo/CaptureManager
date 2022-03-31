using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureManager
{
    public class WebViewTab : TabPage
    {
        private WebBrowser webBrowser;
        private string url;
        private ProcessCaptureManager captureProcess;
        private Timer timer;

        public WebViewTab(string url)
        {
            this.url = url;
            webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Url = new Uri(url);
            this.Text = url;
            this.Controls.Add(webBrowser);
            captureProcess = new ProcessCaptureManager(this);
            startCapture();

        }

        public WebViewTab(string url,string name)
        {
            this.url = url;
            this.Text = name;

            webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Url = new Uri(url);
            this.Controls.Add(webBrowser);
            captureProcess = new ProcessCaptureManager(this);
            startCapture();

        }

        public void startCapture()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {

                Bitmap bitmap = captureProcess.GetBitmap(this);
                bitmap.Save(@"d:\test.bmp");
                bitmap.Dispose();
            };
            timer.Start();
        }

    }
}

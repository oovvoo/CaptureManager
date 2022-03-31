using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureManager
{
    public class AppViewTab : TabPage
    {
        private PictureBox captured;
        private Process process;
        private Timer timer;
        private ProcessCaptureManager captureProcess;

        public AppViewTab(string name,string targetProcessName)
        {
            captured = new PictureBox();
            captured.Dock = DockStyle.Fill;
            captured.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(captured);
            this.Text = name;

            this.process = ProcessManager.getProcessByName(targetProcessName);

            captureProcess = new ProcessCaptureManager(this);
            captured.Image =  captureProcess.GetBitmap(process);            
        }
        public AppViewTab(string targetProcessName)
        {
            captured = new PictureBox();
            captured.Dock = DockStyle.Fill;
            captured.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(captured);
            this.Text = targetProcessName;

            this.process = ProcessManager.getProcessByName(targetProcessName);

            captureProcess = new ProcessCaptureManager(this);
            
            timer = new Timer();
            timer.Interval =1000;
            timer.Tick += (s, e) =>
            {
                ProcessManager.setProcessShow(process);
                Bitmap capturedImage = captureProcess.GetBitmap(process);
                if (capturedImage != null)
                {
                    capturedImage.Save(@"d:\" + targetProcessName + ".bmp");

                    if (captured.Image != null)
                        captured.Image.Dispose();

                    captured.Image = capturedImage;
                }
                    

            };
            timer.Start();
        }



    }
}

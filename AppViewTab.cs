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
            init();          
            
            this.Text = name;            
            this.process = ProcessManager.getProcessByName(targetProcessName);

            captureProcess = new ProcessCaptureManager(this);
            captured.Image =  captureProcess.GetBitmap(process);
                      
            startProcess(targetProcessName);

        }
        public AppViewTab(string targetProcessName)
        {
            init();         

            this.Text = targetProcessName;
            this.process = ProcessManager.getProcessByName(targetProcessName);

            captureProcess = new ProcessCaptureManager(this);
       
            startProcess(targetProcessName);
        }

        public AppViewTab(Process targetProcess)
        {
            init();
            this.Text = targetProcess.ProcessName;
            this.process = targetProcess;
            captureProcess = new ProcessCaptureManager(this);

            startProcess(targetProcess);
        }
        public void init()
        {
            captured = new PictureBox();
            captured.Dock = DockStyle.Fill;
            captured.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(captured);
        }
        public void startProcess(string targetProcessName)
        {

            timer = new Timer();
            timer.Interval = MainForm.CAPTURE_INTERVAL;
            timer.Tick += (s, e) =>
            {

                if (this.process == null)
                    this.process = ProcessManager.getProcessByName(targetProcessName);

                ProcessManager.setProcessShow(process);
                Bitmap capturedImage = captureProcess.GetBitmap(process);
                if (capturedImage != null)
                {
                    capturedImage.Save(@".\" + targetProcessName + ".bmp");

                    if (captured.Image != null)
                        captured.Image.Dispose();

                    captured.Image = capturedImage;
                }


            };
            timer.Start();
        }

        public void startProcess(Process targetProcess)
        {

            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += (s, e) =>
            {

                ProcessManager.setProcessShow(targetProcess);
                Bitmap capturedImage = captureProcess.GetBitmap(process);
                if (capturedImage != null)
                {
                    capturedImage.Save(@"d:\" + targetProcess.ProcessName + ".bmp");

                    if (captured.Image != null)
                        captured.Image.Dispose();

                    captured.Image = capturedImage;
                }


            };
            timer.Start();
        }


        protected override void Dispose(bool disposing)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

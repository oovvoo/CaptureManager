using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
namespace CaptureManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            foreach(Process p in ProcessManager.getWindowProcesses())
            {
                Console.WriteLine(p.ProcessName +" "+ p.MainWindowTitle);
                try
                {
                    Icon icon = Icon.ExtractAssociatedIcon(p.MainModule.FileName);
                }
                catch
                {

                }
            }

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //TODO: 웹브라우저 내용도 스크린샷 할것
            WebViewTab wTab = new WebViewTab("http://www.naver.com");
          
            tabControl1.TabPages.Add(wTab);

            //AppViewTab aTab = new AppViewTab("CSCfms");
            //tabControl1.TabPages.Add(aTab);

            AppViewTab aTab2 = new AppViewTab("notepad");
            tabControl1.TabPages.Add(aTab2);

            AppViewTab aTab3 = new AppViewTab("KakaoTalk");
            tabControl1.TabPages.Add(aTab3);


        }
    }
}

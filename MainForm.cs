using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CaptureManager
{
    public partial class MainForm : Form
    {
        public const int CAPTURE_INTERVAL = 1000;
        public MainForm()
        {
            InitializeComponent();
            mainTabControl.ControlRemoved += (o, e) =>
            {
                //TabPage에서 타이머들이 돌고있음으로, Dispose 시에 Timer 리소스를 해제 해 준다.
                TabPage page = e.Control as TabPage;
                page.Dispose();
            };
                       
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //로딩 후, 저장된 프로세스들을 모두 찾아서 로딩
        }

        private void btnTabAdd_Click(object sender, EventArgs e)
        {
           

            SelectType type = new SelectType();            
            type.ShowDialog();
            
            if (type.DialogResult != DialogResult.OK)
                return;
              
            if(type.type == SelectType.ADD_TYPE.APP)
            {
                AppAddSetup setup = new AppAddSetup();
                setup.ShowDialog();

                if(setup.DialogResult == DialogResult.OK)
                {
                    AppViewTab tab = new AppViewTab(setup.selectedProcess);
                    mainTabControl.TabPages.Add(tab);
                    mainTabControl.SelectedTab = tab;
                }

            }
            else
            {
                WebAddSetup setup = new WebAddSetup();
                setup.ShowDialog();

                if (setup.DialogResult == DialogResult.OK)
                {
                    WebViewTab tab = new WebViewTab(setup.url);
                    mainTabControl.TabPages.Add(tab);
                    mainTabControl.SelectedTab = tab;
                }

            }
                  
        }     
        private void btnTabRemove_Click(object sender, EventArgs e)
        {
            if(mainTabControl.SelectedTab != null)
                mainTabControl.TabPages.Remove(mainTabControl.SelectedTab);

        }

    }
}

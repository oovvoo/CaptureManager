using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureManager
{
    public partial class SelectType : Form
    {
        public enum ADD_TYPE{
            APP,WEB
        }

        public ADD_TYPE type;

        public SelectType()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSetupApp_Click(object sender, EventArgs e)
        {
            type = ADD_TYPE.APP;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSetupWeb_Click(object sender, EventArgs e)
        {
            type = ADD_TYPE.WEB;
            DialogResult = DialogResult.OK;
            this.Close();
        }     
    }
}

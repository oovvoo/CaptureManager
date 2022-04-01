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
    public partial class WebAddSetup : Form
    {
        public AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        public string url;

        public WebAddSetup()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            source.Add("http://");

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            url = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}

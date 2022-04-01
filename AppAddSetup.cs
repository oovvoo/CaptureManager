using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureManager
{
    public partial class AppAddSetup : Form
    {
        private DataTable processList;
        public Process selectedProcess { get; set; }

        public AppAddSetup()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            loadProcessList();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            DataRowView row = processListBox.SelectedItem as DataRowView;

            selectedProcess = row["process"] as Process;


            if (selectedProcess != null)
                this.DialogResult = DialogResult.OK;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadProcessList();
        }
        private void loadProcessList()
        {
            processList = new DataTable();
            processList.Columns.Add("name");
            processList.Columns.Add("title");
            processList.Columns.Add("process", typeof(Process));
            
            processListBox.ValueMember = "process";
            processListBox.DisplayMember = "title";

            ProcessManager.getWindowProcesses().ToList().ForEach(p => {

                DataRow row = processList.NewRow();
                row["name"] = p.ProcessName;
                row["title"] = string.Format("{0} - [{1}]", p.ProcessName, p.MainWindowTitle);
                row["process"] = p;
                processList.Rows.Add(row);

            });

            processListBox.DataSource = processList;
        }

        private void processListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("processListBox_SelectedIndexChanged");
        }
    }

}

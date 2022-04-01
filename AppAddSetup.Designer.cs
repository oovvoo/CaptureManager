namespace CaptureManager
{
    partial class AppAddSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.processListBox = new System.Windows.Forms.ListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // processListBox
            // 
            this.processListBox.FormattingEnabled = true;
            this.processListBox.ItemHeight = 21;
            this.processListBox.Location = new System.Drawing.Point(12, 12);
            this.processListBox.Name = "processListBox";
            this.processListBox.Size = new System.Drawing.Size(752, 403);
            this.processListBox.Sorted = true;
            this.processListBox.TabIndex = 0;
            this.processListBox.SelectedIndexChanged += new System.EventHandler(this.processListBox_SelectedIndexChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("현대하모니 B", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelect.Location = new System.Drawing.Point(12, 422);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(607, 102);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "프로세스선택";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("현대하모니 B", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefresh.Location = new System.Drawing.Point(625, 422);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(139, 102);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // AppAddSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(776, 536);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.processListBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AppAddSetup";
            this.Text = "중계할 프로세스를 선택하세요";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox processListBox;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnRefresh;
    }
}
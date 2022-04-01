
namespace CaptureManager
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTabAdd = new System.Windows.Forms.Button();
            this.btnTabRemove = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainTabControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 60);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.mainPanel.Size = new System.Drawing.Size(1896, 934);
            this.mainPanel.TabIndex = 0;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mainTabControl.Location = new System.Drawing.Point(5, 5);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(2);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1886, 924);
            this.mainTabControl.TabIndex = 0;
            // 
            // mainStatus
            // 
            this.mainStatus.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.mainStatus.Location = new System.Drawing.Point(0, 994);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.mainStatus.Size = new System.Drawing.Size(1896, 22);
            this.mainStatus.TabIndex = 1;
            this.mainStatus.Text = "statusStrip1";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.btnTabAdd);
            this.buttonPanel.Controls.Add(this.btnTabRemove);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(1896, 60);
            this.buttonPanel.TabIndex = 0;
            // 
            // btnTabAdd
            // 
            this.btnTabAdd.Font = new System.Drawing.Font("현대하모니 B", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTabAdd.Location = new System.Drawing.Point(1793, 3);
            this.btnTabAdd.Name = "btnTabAdd";
            this.btnTabAdd.Size = new System.Drawing.Size(100, 50);
            this.btnTabAdd.TabIndex = 0;
            this.btnTabAdd.Text = "Add";
            this.btnTabAdd.UseVisualStyleBackColor = true;
            this.btnTabAdd.Click += new System.EventHandler(this.btnTabAdd_Click);
            // 
            // btnTabRemove
            // 
            this.btnTabRemove.Font = new System.Drawing.Font("현대하모니 B", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTabRemove.Location = new System.Drawing.Point(1687, 3);
            this.btnTabRemove.Name = "btnTabRemove";
            this.btnTabRemove.Size = new System.Drawing.Size(100, 50);
            this.btnTabRemove.TabIndex = 1;
            this.btnTabRemove.Text = "Remove";
            this.btnTabRemove.UseVisualStyleBackColor = true;
            this.btnTabRemove.Click += new System.EventHandler(this.btnTabRemove_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1896, 1016);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.mainStatus);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "현황판 중계 서비스";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Button btnTabAdd;
        private System.Windows.Forms.Button btnTabRemove;
    }
}


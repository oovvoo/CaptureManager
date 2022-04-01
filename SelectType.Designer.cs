namespace CaptureManager
{
    partial class SelectType
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
            this.btnSetupApp = new System.Windows.Forms.Button();
            this.btnSetupWeb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetupApp
            // 
            this.btnSetupApp.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetupApp.Location = new System.Drawing.Point(12, 12);
            this.btnSetupApp.Name = "btnSetupApp";
            this.btnSetupApp.Size = new System.Drawing.Size(183, 175);
            this.btnSetupApp.TabIndex = 0;
            this.btnSetupApp.Text = "Application";
            this.btnSetupApp.UseVisualStyleBackColor = true;
            this.btnSetupApp.Click += new System.EventHandler(this.btnSetupApp_Click);
            // 
            // btnSetupWeb
            // 
            this.btnSetupWeb.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetupWeb.Location = new System.Drawing.Point(210, 12);
            this.btnSetupWeb.Name = "btnSetupWeb";
            this.btnSetupWeb.Size = new System.Drawing.Size(183, 175);
            this.btnSetupWeb.TabIndex = 1;
            this.btnSetupWeb.Text = "Web";
            this.btnSetupWeb.UseVisualStyleBackColor = true;
            this.btnSetupWeb.Click += new System.EventHandler(this.btnSetupWeb_Click);
            // 
            // SelectType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 199);
            this.Controls.Add(this.btnSetupWeb);
            this.Controls.Add(this.btnSetupApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectType";
            this.Text = "타입을 선택하세요";         
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetupApp;
        private System.Windows.Forms.Button btnSetupWeb;
    }
}
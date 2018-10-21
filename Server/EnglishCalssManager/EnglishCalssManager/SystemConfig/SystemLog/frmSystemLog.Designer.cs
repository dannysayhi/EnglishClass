namespace EnglishCalssManager.SystemConfig.SystemLog
{
    partial class frmSystemLog
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
            this.hLogger1 = new AOISystem.Utility.Logging.HLogger();
            this.SuspendLayout();
            // 
            // hLogger1
            // 
            this.hLogger1.Location = new System.Drawing.Point(3, 12);
            this.hLogger1.Name = "hLogger1";
            this.hLogger1.Size = new System.Drawing.Size(881, 362);
            this.hLogger1.TabIndex = 0;
            // 
            // frmSystemLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 386);
            this.Controls.Add(this.hLogger1);
            this.Name = "frmSystemLog";
            this.Text = "frmSystemLog";
            this.Load += new System.EventHandler(this.frmSystemLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AOISystem.Utility.Logging.HLogger hLogger1;
    }
}
namespace AOISystem.Utility.Logging
{
    partial class HLogger
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbCommand = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbCommand
            // 
            this.lbCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCommand.FormattingEnabled = true;
            this.lbCommand.ItemHeight = 12;
            this.lbCommand.Location = new System.Drawing.Point(0, 0);
            this.lbCommand.Name = "lbCommand";
            this.lbCommand.Size = new System.Drawing.Size(389, 106);
            this.lbCommand.TabIndex = 0;
            this.lbCommand.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCommand_MouseDoubleClick);
            // 
            // HLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbCommand);
            this.Name = "HLogger";
            this.Size = new System.Drawing.Size(389, 106);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbCommand;
    }
}

namespace EnglishClassManager
{
    partial class frmMain
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系統管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通訊錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.學生通訊錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.員工通訊錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.群組設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.員工考勤管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出缺勤查勤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排班表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.員工班別管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班別設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.權限管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.線上打卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.學生線上打卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.員工線上打卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.推播管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手動推播ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷卡通知ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.訊息預設ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.推播訊息設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷卡通知設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.歷史訊息紀錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.報表管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.學生出勤紀錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.員工出勤紀錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系統紀錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系統紀錄ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Systimer = new System.Windows.Forms.Timer(this.components);
            this.ckb_Systimer = new System.Windows.Forms.CheckBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnAccountEditor = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.labAccountName = new System.Windows.Forms.Label();
            this.labAccountLevel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系統管理ToolStripMenuItem,
            this.員工考勤管理ToolStripMenuItem,
            this.線上打卡ToolStripMenuItem,
            this.推播管理ToolStripMenuItem,
            this.報表管理ToolStripMenuItem,
            this.系統紀錄ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系統管理ToolStripMenuItem
            // 
            this.系統管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通訊錄ToolStripMenuItem,
            this.群組設定ToolStripMenuItem});
            this.系統管理ToolStripMenuItem.Name = "系統管理ToolStripMenuItem";
            this.系統管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.系統管理ToolStripMenuItem.Text = "系統管理";
            // 
            // 通訊錄ToolStripMenuItem
            // 
            this.通訊錄ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.學生通訊錄ToolStripMenuItem,
            this.員工通訊錄ToolStripMenuItem});
            this.通訊錄ToolStripMenuItem.Name = "通訊錄ToolStripMenuItem";
            this.通訊錄ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.通訊錄ToolStripMenuItem.Text = "通訊錄";
            this.通訊錄ToolStripMenuItem.Click += new System.EventHandler(this.通訊錄ToolStripMenuItem_Click);
            // 
            // 學生通訊錄ToolStripMenuItem
            // 
            this.學生通訊錄ToolStripMenuItem.Name = "學生通訊錄ToolStripMenuItem";
            this.學生通訊錄ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.學生通訊錄ToolStripMenuItem.Text = "學生通訊錄";
            this.學生通訊錄ToolStripMenuItem.Click += new System.EventHandler(this.學生通訊錄ToolStripMenuItem_Click);
            // 
            // 員工通訊錄ToolStripMenuItem
            // 
            this.員工通訊錄ToolStripMenuItem.Name = "員工通訊錄ToolStripMenuItem";
            this.員工通訊錄ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.員工通訊錄ToolStripMenuItem.Text = "員工通訊錄";
            this.員工通訊錄ToolStripMenuItem.Click += new System.EventHandler(this.員工通訊錄ToolStripMenuItem_Click);
            // 
            // 群組設定ToolStripMenuItem
            // 
            this.群組設定ToolStripMenuItem.Name = "群組設定ToolStripMenuItem";
            this.群組設定ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.群組設定ToolStripMenuItem.Text = "群組管理";
            this.群組設定ToolStripMenuItem.Click += new System.EventHandler(this.群組設定ToolStripMenuItem_Click);
            // 
            // 員工考勤管理ToolStripMenuItem
            // 
            this.員工考勤管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.出缺勤查勤ToolStripMenuItem,
            this.排班表ToolStripMenuItem,
            this.員工班別管理ToolStripMenuItem,
            this.班別設定ToolStripMenuItem,
            this.權限管理ToolStripMenuItem});
            this.員工考勤管理ToolStripMenuItem.Name = "員工考勤管理ToolStripMenuItem";
            this.員工考勤管理ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.員工考勤管理ToolStripMenuItem.Text = "員工考勤管理";
            // 
            // 出缺勤查勤ToolStripMenuItem
            // 
            this.出缺勤查勤ToolStripMenuItem.Name = "出缺勤查勤ToolStripMenuItem";
            this.出缺勤查勤ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.出缺勤查勤ToolStripMenuItem.Text = "出缺勤查勤";
            this.出缺勤查勤ToolStripMenuItem.Visible = false;
            this.出缺勤查勤ToolStripMenuItem.Click += new System.EventHandler(this.出缺勤查勤ToolStripMenuItem_Click);
            // 
            // 排班表ToolStripMenuItem
            // 
            this.排班表ToolStripMenuItem.Name = "排班表ToolStripMenuItem";
            this.排班表ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.排班表ToolStripMenuItem.Text = "排班表";
            this.排班表ToolStripMenuItem.Click += new System.EventHandler(this.排班表ToolStripMenuItem_Click);
            // 
            // 員工班別管理ToolStripMenuItem
            // 
            this.員工班別管理ToolStripMenuItem.Name = "員工班別管理ToolStripMenuItem";
            this.員工班別管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.員工班別管理ToolStripMenuItem.Text = "員工班別管理";
            this.員工班別管理ToolStripMenuItem.Visible = false;
            this.員工班別管理ToolStripMenuItem.Click += new System.EventHandler(this.員工班別管理ToolStripMenuItem_Click);
            // 
            // 班別設定ToolStripMenuItem
            // 
            this.班別設定ToolStripMenuItem.Name = "班別設定ToolStripMenuItem";
            this.班別設定ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.班別設定ToolStripMenuItem.Text = "班別基礎設定";
            this.班別設定ToolStripMenuItem.Click += new System.EventHandler(this.班別設定ToolStripMenuItem_Click);
            // 
            // 權限管理ToolStripMenuItem
            // 
            this.權限管理ToolStripMenuItem.Name = "權限管理ToolStripMenuItem";
            this.權限管理ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.權限管理ToolStripMenuItem.Text = "權限管理";
            this.權限管理ToolStripMenuItem.Click += new System.EventHandler(this.權限管理ToolStripMenuItem_Click);
            // 
            // 線上打卡ToolStripMenuItem
            // 
            this.線上打卡ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.學生線上打卡ToolStripMenuItem,
            this.員工線上打卡ToolStripMenuItem});
            this.線上打卡ToolStripMenuItem.Name = "線上打卡ToolStripMenuItem";
            this.線上打卡ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.線上打卡ToolStripMenuItem.Text = "線上打卡";
            // 
            // 學生線上打卡ToolStripMenuItem
            // 
            this.學生線上打卡ToolStripMenuItem.Name = "學生線上打卡ToolStripMenuItem";
            this.學生線上打卡ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.學生線上打卡ToolStripMenuItem.Text = "學生線上打卡";
            this.學生線上打卡ToolStripMenuItem.Click += new System.EventHandler(this.學生線上打卡ToolStripMenuItem_Click);
            // 
            // 員工線上打卡ToolStripMenuItem
            // 
            this.員工線上打卡ToolStripMenuItem.Name = "員工線上打卡ToolStripMenuItem";
            this.員工線上打卡ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.員工線上打卡ToolStripMenuItem.Text = "員工線上打卡";
            this.員工線上打卡ToolStripMenuItem.Click += new System.EventHandler(this.員工線上打卡ToolStripMenuItem_Click);
            // 
            // 推播管理ToolStripMenuItem
            // 
            this.推播管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.手動推播ToolStripMenuItem,
            this.刷卡通知ToolStripMenuItem,
            this.訊息預設ToolStripMenuItem,
            this.歷史訊息紀錄ToolStripMenuItem});
            this.推播管理ToolStripMenuItem.Name = "推播管理ToolStripMenuItem";
            this.推播管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.推播管理ToolStripMenuItem.Text = "推播管理";
            // 
            // 手動推播ToolStripMenuItem
            // 
            this.手動推播ToolStripMenuItem.Name = "手動推播ToolStripMenuItem";
            this.手動推播ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.手動推播ToolStripMenuItem.Text = "手動推播";
            this.手動推播ToolStripMenuItem.Click += new System.EventHandler(this.手動推播ToolStripMenuItem_Click);
            // 
            // 刷卡通知ToolStripMenuItem
            // 
            this.刷卡通知ToolStripMenuItem.Name = "刷卡通知ToolStripMenuItem";
            this.刷卡通知ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.刷卡通知ToolStripMenuItem.Text = "刷卡通知";
            this.刷卡通知ToolStripMenuItem.Visible = false;
            this.刷卡通知ToolStripMenuItem.Click += new System.EventHandler(this.刷卡通知ToolStripMenuItem_Click);
            // 
            // 訊息預設ToolStripMenuItem
            // 
            this.訊息預設ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.推播訊息設定ToolStripMenuItem,
            this.刷卡通知設定ToolStripMenuItem});
            this.訊息預設ToolStripMenuItem.Name = "訊息預設ToolStripMenuItem";
            this.訊息預設ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.訊息預設ToolStripMenuItem.Text = "訊息預設";
            this.訊息預設ToolStripMenuItem.Click += new System.EventHandler(this.訊息預設ToolStripMenuItem_Click);
            // 
            // 推播訊息設定ToolStripMenuItem
            // 
            this.推播訊息設定ToolStripMenuItem.Name = "推播訊息設定ToolStripMenuItem";
            this.推播訊息設定ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.推播訊息設定ToolStripMenuItem.Text = "推播訊息設定";
            this.推播訊息設定ToolStripMenuItem.Click += new System.EventHandler(this.推播訊息設定ToolStripMenuItem_Click);
            // 
            // 刷卡通知設定ToolStripMenuItem
            // 
            this.刷卡通知設定ToolStripMenuItem.Name = "刷卡通知設定ToolStripMenuItem";
            this.刷卡通知設定ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.刷卡通知設定ToolStripMenuItem.Text = "刷卡通知設定";
            this.刷卡通知設定ToolStripMenuItem.Click += new System.EventHandler(this.刷卡通知設定ToolStripMenuItem_Click);
            // 
            // 歷史訊息紀錄ToolStripMenuItem
            // 
            this.歷史訊息紀錄ToolStripMenuItem.Name = "歷史訊息紀錄ToolStripMenuItem";
            this.歷史訊息紀錄ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.歷史訊息紀錄ToolStripMenuItem.Text = "歷史訊息紀錄";
            this.歷史訊息紀錄ToolStripMenuItem.Click += new System.EventHandler(this.歷史訊息紀錄ToolStripMenuItem_Click);
            // 
            // 報表管理ToolStripMenuItem
            // 
            this.報表管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.學生出勤紀錄ToolStripMenuItem,
            this.員工出勤紀錄ToolStripMenuItem});
            this.報表管理ToolStripMenuItem.Name = "報表管理ToolStripMenuItem";
            this.報表管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.報表管理ToolStripMenuItem.Text = "報表管理";
            // 
            // 學生出勤紀錄ToolStripMenuItem
            // 
            this.學生出勤紀錄ToolStripMenuItem.Name = "學生出勤紀錄ToolStripMenuItem";
            this.學生出勤紀錄ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.學生出勤紀錄ToolStripMenuItem.Text = "學生出勤紀錄";
            this.學生出勤紀錄ToolStripMenuItem.Click += new System.EventHandler(this.學生出勤紀錄ToolStripMenuItem_Click);
            // 
            // 員工出勤紀錄ToolStripMenuItem
            // 
            this.員工出勤紀錄ToolStripMenuItem.Name = "員工出勤紀錄ToolStripMenuItem";
            this.員工出勤紀錄ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.員工出勤紀錄ToolStripMenuItem.Text = "員工出勤紀錄";
            this.員工出勤紀錄ToolStripMenuItem.Click += new System.EventHandler(this.員工出勤紀錄ToolStripMenuItem_Click);
            // 
            // 系統紀錄ToolStripMenuItem
            // 
            this.系統紀錄ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系統紀錄ToolStripMenuItem1});
            this.系統紀錄ToolStripMenuItem.Name = "系統紀錄ToolStripMenuItem";
            this.系統紀錄ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.系統紀錄ToolStripMenuItem.Text = "系統設定";
            // 
            // 系統紀錄ToolStripMenuItem1
            // 
            this.系統紀錄ToolStripMenuItem1.Name = "系統紀錄ToolStripMenuItem1";
            this.系統紀錄ToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.系統紀錄ToolStripMenuItem1.Text = "系統紀錄";
            this.系統紀錄ToolStripMenuItem1.Click += new System.EventHandler(this.系統紀錄ToolStripMenuItem1_Click);
            // 
            // Systimer
            // 
            this.Systimer.Interval = 3000;
            this.Systimer.Tick += new System.EventHandler(this.Systimer_Tick);
            // 
            // ckb_Systimer
            // 
            this.ckb_Systimer.AutoSize = true;
            this.ckb_Systimer.Location = new System.Drawing.Point(723, 3);
            this.ckb_Systimer.Name = "ckb_Systimer";
            this.ckb_Systimer.Size = new System.Drawing.Size(100, 16);
            this.ckb_Systimer.TabIndex = 1;
            this.ckb_Systimer.Text = "SystemScanStart";
            this.ckb_Systimer.UseVisualStyleBackColor = true;
            this.ckb_Systimer.CheckedChanged += new System.EventHandler(this.ckb_Systimer_CheckedChanged);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(748, 25);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 23);
            this.btn_test.TabIndex = 2;
            this.btn_test.Text = "測試用";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(587, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 22);
            this.textBox1.TabIndex = 4;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(587, 109);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 5;
            this.btnLogIn.Text = "登入";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnAccountEditor
            // 
            this.btnAccountEditor.Location = new System.Drawing.Point(587, 175);
            this.btnAccountEditor.Name = "btnAccountEditor";
            this.btnAccountEditor.Size = new System.Drawing.Size(75, 23);
            this.btnAccountEditor.TabIndex = 6;
            this.btnAccountEditor.Text = "編輯";
            this.btnAccountEditor.UseVisualStyleBackColor = true;
            this.btnAccountEditor.Click += new System.EventHandler(this.btnAccountEditor_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(587, 146);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "登出";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // labAccountName
            // 
            this.labAccountName.AutoSize = true;
            this.labAccountName.Location = new System.Drawing.Point(587, 57);
            this.labAccountName.Name = "labAccountName";
            this.labAccountName.Size = new System.Drawing.Size(137, 12);
            this.labAccountName.TabIndex = 8;
            this.labAccountName.Text = "______________________";
            // 
            // labAccountLevel
            // 
            this.labAccountLevel.AutoSize = true;
            this.labAccountLevel.Location = new System.Drawing.Point(587, 86);
            this.labAccountLevel.Name = "labAccountLevel";
            this.labAccountLevel.Size = new System.Drawing.Size(137, 12);
            this.labAccountLevel.TabIndex = 9;
            this.labAccountLevel.Text = "______________________";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 354);
            this.Controls.Add(this.labAccountLevel);
            this.Controls.Add(this.labAccountName);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnAccountEditor);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.ckb_Systimer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem 系統管理ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 通訊錄ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 學生通訊錄ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 員工通訊錄ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 群組設定ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 員工考勤管理ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 出缺勤查勤ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 排班表ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 班別設定ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 權限管理ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 線上打卡ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 學生線上打卡ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 員工線上打卡ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 推播管理ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 手動推播ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 刷卡通知ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 訊息預設ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 報表管理ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 學生出勤紀錄ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 員工出勤紀錄ToolStripMenuItem;
        private System.Windows.Forms.Timer Systimer;
        private System.Windows.Forms.CheckBox ckb_Systimer;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ToolStripMenuItem 推播訊息設定ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 刷卡通知設定ToolStripMenuItem;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnAccountEditor;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label labAccountName;
        private System.Windows.Forms.Label labAccountLevel;
        private System.Windows.Forms.ToolStripMenuItem 系統紀錄ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系統紀錄ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 員工班別管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 歷史訊息紀錄ToolStripMenuItem;
    }
}


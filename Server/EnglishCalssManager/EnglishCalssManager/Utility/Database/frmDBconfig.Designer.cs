﻿namespace EnglishCalssManager.Utility.Database
{
    partial class frmDBconfig
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
            this.btn_connectTest = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.cbox_ConnectStr = new System.Windows.Forms.ComboBox();
            this.btn_Recipefrm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_connectTest
            // 
            this.btn_connectTest.Location = new System.Drawing.Point(735, 12);
            this.btn_connectTest.Name = "btn_connectTest";
            this.btn_connectTest.Size = new System.Drawing.Size(147, 26);
            this.btn_connectTest.TabIndex = 0;
            this.btn_connectTest.Text = "連線測試";
            this.btn_connectTest.UseVisualStyleBackColor = true;
            this.btn_connectTest.Click += new System.EventHandler(this.btn_connectTest_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(12, 98);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(870, 340);
            this.propertyGrid1.TabIndex = 2;
            // 
            // cbox_ConnectStr
            // 
            this.cbox_ConnectStr.FormattingEnabled = true;
            this.cbox_ConnectStr.Location = new System.Drawing.Point(12, 16);
            this.cbox_ConnectStr.Name = "cbox_ConnectStr";
            this.cbox_ConnectStr.Size = new System.Drawing.Size(717, 20);
            this.cbox_ConnectStr.TabIndex = 1;
            // 
            // btn_Recipefrm
            // 
            this.btn_Recipefrm.Location = new System.Drawing.Point(12, 57);
            this.btn_Recipefrm.Name = "btn_Recipefrm";
            this.btn_Recipefrm.Size = new System.Drawing.Size(147, 26);
            this.btn_Recipefrm.TabIndex = 3;
            this.btn_Recipefrm.Text = "工單變更";
            this.btn_Recipefrm.UseVisualStyleBackColor = true;
            this.btn_Recipefrm.Click += new System.EventHandler(this.btn_Recipefrm_Click);
            // 
            // frmDBconfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 463);
            this.Controls.Add(this.btn_Recipefrm);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.cbox_ConnectStr);
            this.Controls.Add(this.btn_connectTest);
            this.Name = "frmDBconfig";
            this.Text = "frmDBconfig";
            this.Load += new System.EventHandler(this.frmDBconfig_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_connectTest;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ComboBox cbox_ConnectStr;
        private System.Windows.Forms.Button btn_Recipefrm;
    }
}
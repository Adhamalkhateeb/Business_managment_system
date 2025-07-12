using BMS.BAL;
using BMS.UI;

namespace BMS
{
    partial class frmDepartmentDetails
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
            label1 = new Label();
            btnClose = new Button();
            ctrlDepartmenttInfo2 = new ctrlDepartmenttInfo();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 35F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(291, 9);
            label1.Name = "label1";
            label1.Size = new Size(200, 55);
            label1.TabIndex = 1;
            label1.Text = "بينات القسم";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.error;
            btnClose.Location = new Point(11, 271);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(119, 56);
            btnClose.TabIndex = 4;
            btnClose.Text = "إغلاق";
            btnClose.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlDepartmenttInfo2
            // 
            ctrlDepartmenttInfo2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlDepartmenttInfo2.Location = new Point(13, 81);
            ctrlDepartmenttInfo2.Margin = new Padding(4, 5, 4, 5);
            ctrlDepartmenttInfo2.Name = "ctrlDepartmenttInfo2";
            ctrlDepartmenttInfo2.RightToLeft = RightToLeft.Yes;
            ctrlDepartmenttInfo2.ShowUpdateDepartment = true;
            ctrlDepartmenttInfo2.Size = new Size(758, 234);
            ctrlDepartmenttInfo2.TabIndex = 5;
            // 
            // frmDepartmentDetails
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnClose;
            ClientSize = new Size(782, 338);
            Controls.Add(btnClose);
            Controls.Add(ctrlDepartmenttInfo2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(6);
            Name = "frmDepartmentDetails";
            RightToLeft = RightToLeft.Yes;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            
            Load += frmDepartmentDetails_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private ctrlDepartmenttInfo departmenttInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private ctrlDepartmenttInfo ctrlDepartmenttInfo1;
        public ctrlDepartmenttInfo ctrlDepartmenttInfo2;
    }
}
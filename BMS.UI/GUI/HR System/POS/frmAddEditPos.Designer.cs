namespace BMS.GUI.HR_System.POS
{
    partial class frmAddEditPos
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
            components = new System.ComponentModel.Container();
            btnNew = new Button();
            txtBalance = new TextBox();
            label2 = new Label();
            lblTitle = new Label();
            btnClose = new Button();
            btnSave = new Button();
            txtPos = new TextBox();
            label3 = new Label();
            lblDepartmentID = new Label();
            label1 = new Label();
            ep = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            SuspendLayout();
            // 
            // btnNew
            // 
            btnNew.BackColor = SystemColors.Control;
            btnNew.CausesValidation = false;
            btnNew.Cursor = Cursors.Hand;
            btnNew.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNew.Image = Properties.Resources.add__3_;
            btnNew.ImageAlign = ContentAlignment.MiddleLeft;
            btnNew.Location = new Point(412, 235);
            btnNew.Margin = new Padding(2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(104, 40);
            btnNew.TabIndex = 4;
            btnNew.Text = "جديد";
            btnNew.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Visible = false;
            btnNew.Click += btnNew_Click;
            // 
            // txtBalance
            // 
            txtBalance.BorderStyle = BorderStyle.FixedSingle;
            txtBalance.Location = new Point(50, 183);
            txtBalance.Margin = new Padding(2);
            txtBalance.Multiline = true;
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(289, 33);
            txtBalance.TabIndex = 1;
            txtBalance.KeyPress += txtBalance_KeyPress;
            txtBalance.Validating += txtBalance_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(358, 185);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(147, 23);
            label2.TabIndex = 17;
            label2.Text = "الرصيد الحالي :";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Tahoma", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(61, 9);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(403, 46);
            lblTitle.TabIndex = 16;
            lblTitle.Text = "اضافة نقطة بيع";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.error;
            btnClose.Location = new Point(119, 235);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(104, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "إغلاق";
            btnClose.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.WhiteSmoke;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.diskette;
            btnSave.Location = new Point(11, 235);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 40);
            btnSave.TabIndex = 2;
            btnSave.Text = "حفظ  ";
            btnSave.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtPos
            // 
            txtPos.BorderStyle = BorderStyle.FixedSingle;
            txtPos.Location = new Point(50, 129);
            txtPos.Margin = new Padding(2);
            txtPos.Name = "txtPos";
            txtPos.Size = new Size(289, 30);
            txtPos.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(350, 136);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(167, 23);
            label3.TabIndex = 15;
            label3.Text = "اسم نقطة البيع : ";
            // 
            // lblDepartmentID
            // 
            lblDepartmentID.AutoSize = true;
            lblDepartmentID.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartmentID.Location = new Point(271, 88);
            lblDepartmentID.Margin = new Padding(2, 0, 2, 0);
            lblDepartmentID.Name = "lblDepartmentID";
            lblDepartmentID.Size = new Size(68, 23);
            lblDepartmentID.TabIndex = 14;
            lblDepartmentID.Text = "تلقائي";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(358, 88);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(159, 23);
            label1.TabIndex = 13;
            label1.Text = " رقم نقطة البيع :";
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // frmAddEditPos
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnClose;
            ClientSize = new Size(527, 290);
            Controls.Add(btnNew);
            Controls.Add(txtBalance);
            Controls.Add(label2);
            Controls.Add(lblTitle);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(txtPos);
            Controls.Add(label3);
            Controls.Add(lblDepartmentID);
            Controls.Add(label1);
            Font = new Font("Tahoma", 14F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmAddEditPos";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmAddEditPos_Load;
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNew;
        private TextBox txtBalance;
        private Label label2;
        private Label lblTitle;
        private Button btnClose;
        private Button btnSave;
        private TextBox txtPos;
        private Label label3;
        private Label lblDepartmentID;
        private Label label1;
        private ErrorProvider ep;
    }
}
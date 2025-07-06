namespace BMS
{
    partial class frmAddEditDepartments
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
            label1 = new Label();
            lblDepartmentID = new Label();
            label3 = new Label();
            txtDepartment = new TextBox();
            ep = new ErrorProvider(components);
            lblTitle = new Label();
            label2 = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnClose = new Button();
            btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(390, 84);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 23);
            label1.TabIndex = 2;
            label1.Text = " رقم القسم :";
            // 
            // lblDepartmentID
            // 
            lblDepartmentID.AutoSize = true;
            lblDepartmentID.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartmentID.Location = new Point(303, 84);
            lblDepartmentID.Margin = new Padding(2, 0, 2, 0);
            lblDepartmentID.Name = "lblDepartmentID";
            lblDepartmentID.Size = new Size(68, 23);
            lblDepartmentID.TabIndex = 3;
            lblDepartmentID.Text = "تلقائي";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(383, 133);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(135, 23);
            label3.TabIndex = 4;
            label3.Text = "اسم القسم : ";
            // 
            // txtDepartment
            // 
            txtDepartment.BorderStyle = BorderStyle.FixedSingle;
            txtDepartment.Location = new Point(29, 127);
            txtDepartment.Margin = new Padding(2);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(344, 30);
            txtDepartment.TabIndex = 0;
            txtDepartment.Validating += txtDepartment_Validating;
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Tahoma", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(62, 7);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(403, 46);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "اضافة قسم";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(390, 183);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 23);
            label2.TabIndex = 7;
            label2.Text = "الوصف  :";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Location = new Point(29, 183);
            txtDescription.Margin = new Padding(2);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(344, 96);
            txtDescription.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.WhiteSmoke;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.diskette;
            btnSave.Location = new Point(11, 304);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "حفظ  ";
            btnSave.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.error;
            btnClose.Location = new Point(119, 304);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(104, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "إغلاق";
            btnClose.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.WhiteSmoke;
            btnNew.CausesValidation = false;
            btnNew.Cursor = Cursors.Hand;
            btnNew.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNew.Image = Properties.Resources.add__3_;
            btnNew.ImageAlign = ContentAlignment.MiddleLeft;
            btnNew.Location = new Point(412, 304);
            btnNew.Margin = new Padding(2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(104, 45);
            btnNew.TabIndex = 9;
            btnNew.Text = "جديد";
            btnNew.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Visible = false;
            btnNew.Click += btnNew_Click;
            // 
            // frmAddEditDepartments
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnClose;
            ClientSize = new Size(527, 355);
            Controls.Add(btnNew);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(lblTitle);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(txtDepartment);
            Controls.Add(label3);
            Controls.Add(lblDepartmentID);
            Controls.Add(label1);
            Font = new Font("Tahoma", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2);
            Name = "frmAddEditDepartments";
            RightToLeft = RightToLeft.Yes;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddEditDepartments";
            Load += frmAddEditDepartments_Load_1;
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDepartmentID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private Button btnNew;
    }
}
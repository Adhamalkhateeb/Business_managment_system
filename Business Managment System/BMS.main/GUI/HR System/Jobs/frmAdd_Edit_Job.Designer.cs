namespace BMS
{
    partial class frmAdd_Edit_Job_ٍShow
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
            btnClose = new Button();
            btnSave = new Button();
            lblTitle = new Label();
            txtJob = new TextBox();
            label3 = new Label();
            lblJobID = new Label();
            label1 = new Label();
            ep = new ErrorProvider(components);
            label2 = new Label();
            cbDeaprtments = new ComboBox();
            pnlShowData = new Panel();
            lblUserID = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            pnlShowData.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.error;
            btnClose.Location = new Point(127, 274);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 50);
            btnClose.TabIndex = 9;
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
            btnSave.Location = new Point(9, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 50);
            btnSave.TabIndex = 8;
            btnSave.Text = "حفظ  ";
            btnSave.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Tahoma", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(65, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(504, 57);
            lblTitle.TabIndex = 14;
            lblTitle.Text = "اضافة  وظيفة";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtJob
            // 
            txtJob.BorderStyle = BorderStyle.FixedSingle;
            txtJob.Location = new Point(20, 133);
            txtJob.Name = "txtJob";
            txtJob.Size = new Size(429, 30);
            txtJob.TabIndex = 10;
            txtJob.Validating += txtDepartment_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(475, 135);
            label3.Name = "label3";
            label3.Size = new Size(98, 23);
            label3.TabIndex = 13;
            label3.Text = "الوظيفة : ";
            // 
            // lblJobID
            // 
            lblJobID.Anchor = AnchorStyles.None;
            lblJobID.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJobID.Location = new Point(270, 93);
            lblJobID.Name = "lblJobID";
            lblJobID.Size = new Size(179, 23);
            lblJobID.TabIndex = 12;
            lblJobID.Text = "[????]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(484, 93);
            label1.Name = "label1";
            label1.Size = new Size(143, 23);
            label1.TabIndex = 11;
            label1.Text = "  رقم الوظيفة :";
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(475, 182);
            label2.Name = "label2";
            label2.Size = new Size(138, 23);
            label2.TabIndex = 15;
            label2.Text = "القسم التابع : ";
            // 
            // cbDeaprtments
            // 
            cbDeaprtments.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbDeaprtments.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbDeaprtments.FormattingEnabled = true;
            cbDeaprtments.Location = new Point(230, 174);
            cbDeaprtments.Name = "cbDeaprtments";
            cbDeaprtments.Size = new Size(219, 31);
            cbDeaprtments.TabIndex = 16;
            cbDeaprtments.Validating += cbDeaprtments_Validating;
            // 
            // pnlShowData
            // 
            pnlShowData.Controls.Add(lblUserID);
            pnlShowData.Controls.Add(label4);
            pnlShowData.Location = new Point(20, 223);
            pnlShowData.Name = "pnlShowData";
            pnlShowData.Size = new Size(627, 45);
            pnlShowData.TabIndex = 17;
            pnlShowData.Visible = false;
            // 
            // lblUserID
            // 
            lblUserID.Anchor = AnchorStyles.None;
            lblUserID.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserID.Location = new Point(14, 12);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(415, 23);
            lblUserID.TabIndex = 19;
            lblUserID.Text = "[????]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(455, 12);
            label4.Name = "label4";
            label4.Size = new Size(163, 23);
            label4.TabIndex = 18;
            label4.Text = "انشئ بواسطة : ";
            // 
            // frmAdd_Edit_Job_ٍShow
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnClose;
            ClientSize = new Size(659, 336);
            Controls.Add(pnlShowData);
            Controls.Add(cbDeaprtments);
            Controls.Add(label2);
            Controls.Add(lblTitle);
            Controls.Add(txtJob);
            Controls.Add(label3);
            Controls.Add(lblJobID);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Font = new Font("Tahoma", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAdd_Edit_Job_ٍShow";
            RightToLeft = RightToLeft.Yes;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة وظيفة";
            Load += frmAdd_Edit_Job_Load;
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            pnlShowData.ResumeLayout(false);
            pnlShowData.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblJobID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDeaprtments;
        private Panel pnlShowData;
        private Label lblUserID;
        private Label label4;
    }
}
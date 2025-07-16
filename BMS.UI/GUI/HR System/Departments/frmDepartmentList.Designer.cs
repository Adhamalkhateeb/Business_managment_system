namespace BMS
{
    partial class frmDepartmentList
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            cmsDepartments = new ContextMenuStrip(components);
            ShwoDepartmentDetailsToolStripMenuItem = new ToolStripMenuItem();
            AddDepartmentToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem = new ToolStripMenuItem();
            UpdateDepartmentToolStripMenuItem = new ToolStripMenuItem();
            dgvList = new DataGridView();
            label1 = new Label();
            txtFilter = new TextBox();
            cbFilter = new ComboBox();
            lblTitle = new Label();
            label2 = new Label();
            lblCount = new Label();
            panel1 = new Panel();
            lblLoading = new Label();
            btnExport = new Button();
            btnSearch = new Button();
            btnForward = new Button();
            btnBack = new Button();
            pictureBox1 = new PictureBox();
            btnClose = new Button();
            btnAdd = new Button();
            timerLoading = new System.Windows.Forms.Timer(components);
            cmsDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cmsDepartments
            // 
            cmsDepartments.Font = new Font("Segoe UI", 9F);
            cmsDepartments.ImageScalingSize = new Size(20, 20);
            cmsDepartments.Items.AddRange(new ToolStripItem[] { ShwoDepartmentDetailsToolStripMenuItem, AddDepartmentToolStripMenuItem, ToolStripMenuItem, UpdateDepartmentToolStripMenuItem });
            cmsDepartments.Name = "cmsDepartments";
            cmsDepartments.RightToLeft = RightToLeft.Yes;
            cmsDepartments.Size = new Size(211, 156);
            // 
            // ShwoDepartmentDetailsToolStripMenuItem
            // 
            ShwoDepartmentDetailsToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ShwoDepartmentDetailsToolStripMenuItem.Image = Properties.Resources.presentation;
            ShwoDepartmentDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            ShwoDepartmentDetailsToolStripMenuItem.Name = "ShwoDepartmentDetailsToolStripMenuItem";
            ShwoDepartmentDetailsToolStripMenuItem.Size = new Size(210, 38);
            ShwoDepartmentDetailsToolStripMenuItem.Text = "عرض بينات القسم";
            ShwoDepartmentDetailsToolStripMenuItem.Click += ShwoDepartmentDetailsToolStripMenuItem_Click;
            // 
            // AddDepartmentToolStripMenuItem
            // 
            AddDepartmentToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            AddDepartmentToolStripMenuItem.Image = Properties.Resources.add__2_;
            AddDepartmentToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            AddDepartmentToolStripMenuItem.Name = "AddDepartmentToolStripMenuItem";
            AddDepartmentToolStripMenuItem.Size = new Size(210, 38);
            AddDepartmentToolStripMenuItem.Text = "اضافة قسم";
            AddDepartmentToolStripMenuItem.Click += AddDepartmentToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            ToolStripMenuItem.Image = Properties.Resources.delete__1_;
            ToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.Size = new Size(210, 38);
            ToolStripMenuItem.Text = "حذف القسم";
            ToolStripMenuItem.Click += DeleteDepartmentToolStripMenuItem_Click;
            // 
            // UpdateDepartmentToolStripMenuItem
            // 
            UpdateDepartmentToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            UpdateDepartmentToolStripMenuItem.Image = Properties.Resources.updated;
            UpdateDepartmentToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            UpdateDepartmentToolStripMenuItem.Name = "UpdateDepartmentToolStripMenuItem";
            UpdateDepartmentToolStripMenuItem.Size = new Size(210, 38);
            UpdateDepartmentToolStripMenuItem.Text = "تعديل القسم";
            UpdateDepartmentToolStripMenuItem.Click += UpdateDepartmentToolStripMenuItem_Click;
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToOrderColumns = true;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AllowUserToResizeRows = false;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.ColumnHeadersHeight = 20;
            dgvList.ContextMenuStrip = cmsDepartments;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle2;
            dgvList.Location = new Point(10, 277);
            dgvList.Margin = new Padding(2);
            dgvList.Name = "dgvList";
            dgvList.ReadOnly = true;
            dgvList.RightToLeft = RightToLeft.Yes;
            dgvList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvList.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowTemplate.Height = 40;
            dgvList.Size = new Size(830, 375);
            dgvList.TabIndex = 0;
            dgvList.CellDoubleClick += dgvList_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(732, 236);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(108, 36);
            label1.TabIndex = 5;
            label1.Text = "ابحث :";
            // 
            // txtFilter
            // 
            txtFilter.BorderStyle = BorderStyle.FixedSingle;
            txtFilter.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilter.Location = new Point(401, 246);
            txtFilter.Margin = new Padding(2);
            txtFilter.Multiline = true;
            txtFilter.Name = "txtFilter";
            txtFilter.RightToLeft = RightToLeft.Yes;
            txtFilter.Size = new Size(185, 27);
            txtFilter.TabIndex = 2;
            txtFilter.Visible = false;
            txtFilter.KeyPress += txtFilter_KeyPress;
            // 
            // cbFilter
            // 
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.Font = new Font("Tahoma", 12.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFilter.FormattingEnabled = true;
            cbFilter.Items.AddRange(new object[] { "الكل", "رقم المسلسل", "اسم القسم" });
            cbFilter.Location = new Point(590, 245);
            cbFilter.Margin = new Padding(2);
            cbFilter.Name = "cbFilter";
            cbFilter.RightToLeft = RightToLeft.Yes;
            cbFilter.Size = new Size(138, 29);
            cbFilter.TabIndex = 2;
            cbFilter.Visible = false;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Tahoma", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(346, 150);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(161, 46);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "الأقسام";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 14.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(702, 664);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(139, 23);
            label2.TabIndex = 13;
            label2.Text = "عدد الأقسام : ";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCount.Location = new Point(674, 665);
            lblCount.Margin = new Padding(2, 0, 2, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(39, 23);
            lblCount.TabIndex = 14;
            lblCount.Text = "[?]";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblLoading);
            panel1.Controls.Add(btnExport);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(btnForward);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(lblCount);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(cbFilter);
            panel1.Controls.Add(txtFilter);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(dgvList);
            panel1.Cursor = Cursors.Hand;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(850, 706);
            panel1.TabIndex = 4;
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.BackColor = Color.Transparent;
            lblLoading.Font = new Font("Tahoma", 16F, FontStyle.Bold);
            lblLoading.Location = new Point(346, 455);
            lblLoading.Name = "lblLoading";
            lblLoading.RightToLeft = RightToLeft.Yes;
            lblLoading.Size = new Size(157, 27);
            lblLoading.TabIndex = 19;
            lblLoading.Text = "جاري التحميل";
            // 
            // btnExport
            // 
            btnExport.Cursor = Cursors.Hand;
            btnExport.DialogResult = DialogResult.Cancel;
            btnExport.Font = new Font("Tahoma", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.Image = Properties.Resources.export;
            btnExport.Location = new Point(118, 200);
            btnExport.Margin = new Padding(2);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(103, 72);
            btnExport.TabIndex = 1;
            btnExport.Text = "تصدير";
            btnExport.TextImageRelation = TextImageRelation.ImageAboveText;
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.DialogResult = DialogResult.Cancel;
            btnSearch.Enabled = false;
            btnSearch.Image = Properties.Resources.search__1_;
            btnSearch.Location = new Point(351, 236);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(46, 37);
            btnSearch.TabIndex = 3;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Visible = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnForward
            // 
            btnForward.BackColor = Color.WhiteSmoke;
            btnForward.Cursor = Cursors.Hand;
            btnForward.DialogResult = DialogResult.Cancel;
            btnForward.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnForward.Image = Properties.Resources.fast_forward_double_Left_arrows_symbol;
            btnForward.Location = new Point(318, 657);
            btnForward.Margin = new Padding(2);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(104, 40);
            btnForward.TabIndex = 4;
            btnForward.Text = "التالي";
            btnForward.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnForward.UseVisualStyleBackColor = false;
            btnForward.Click += buttonForward_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.WhiteSmoke;
            btnBack.Cursor = Cursors.Hand;
            btnBack.DialogResult = DialogResult.Cancel;
            btnBack.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Image = Properties.Resources.fast_forward_double_right_arrows_symbol;
            btnBack.Location = new Point(426, 657);
            btnBack.Margin = new Padding(2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(106, 40);
            btnBack.TabIndex = 5;
            btnBack.Text = "السابق";
            btnBack.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += buttonBack_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.supermaket;
            pictureBox1.Location = new Point(319, 0);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 148);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.error;
            btnClose.Location = new Point(10, 657);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(104, 40);
            btnClose.TabIndex = 6;
            btnClose.Text = "إغلاق";
            btnClose.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click_1;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.DialogResult = DialogResult.Cancel;
            btnAdd.Font = new Font("Tahoma", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Image = Properties.Resources.plus__1_;
            btnAdd.Location = new Point(11, 200);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(103, 72);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "إضافة";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // timerLoading
            // 
            timerLoading.Tick += timerLoading_Tick;
            // 
            // frmDepartmentList
            // 
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnClose;
            ClientSize = new Size(850, 706);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "frmDepartmentList";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += frmDepartmentList_FormClosing;
            Load += frmDepartments_Load;
            cmsDepartments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsDepartments;
        private System.Windows.Forms.ToolStripMenuItem AddDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateDepartmentToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem ShwoDepartmentDetailsToolStripMenuItem;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBack;
        private Button btnSearch;
        private Button btnExport;
        private Label lblLoading;
        private System.Windows.Forms.Timer timerLoading;
    }
}
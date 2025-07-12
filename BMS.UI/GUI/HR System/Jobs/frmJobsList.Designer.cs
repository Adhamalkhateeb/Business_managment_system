//namespace BMS
//{
//    partial class frmJobsList
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            components = new System.ComponentModel.Container();
//            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
//            lblTitle = new Label();
//            cbFilter = new ComboBox();
//            label1 = new Label();
//            dgvJobs = new DataGridView();
//            cmsJobs = new ContextMenuStrip(components);
//            عرضالوظيفةToolStripMenuItem = new ToolStripMenuItem();
//            AddJobToolStripMenuItem = new ToolStripMenuItem();
//            UpdateJobToolStripMenuItem = new ToolStripMenuItem();
//            DeleteJobToolStripMenuItem = new ToolStripMenuItem();
//            panel1 = new Panel();
//            btnSearch = new Button();
//            btnForward = new Button();
//            btnBack = new Button();
//            lblCount = new Label();
//            label2 = new Label();
//            pictureBox1 = new PictureBox();
//            btnClose = new Button();
//            txtFilter = new TextBox();
//            btnAdd = new Button();
//            ((System.ComponentModel.ISupportInitialize)dgvJobs).BeginInit();
//            cmsJobs.SuspendLayout();
//            panel1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
//            SuspendLayout();
//            // 
//            // lblTitle
//            // 
//            lblTitle.AutoSize = true;
//            lblTitle.Font = new Font("Tahoma", 27F, FontStyle.Bold, GraphicsUnit.Point, 0);
//            lblTitle.ForeColor = Color.DarkRed;
//            lblTitle.Location = new Point(235, 134);
//            lblTitle.Margin = new Padding(2, 0, 2, 0);
//            lblTitle.Name = "lblTitle";
//            lblTitle.Size = new Size(153, 43);
//            lblTitle.TabIndex = 11;
//            lblTitle.Text = "الوظائف";
//            lblTitle.TextAlign = ContentAlignment.TopCenter;
//            // 
//            // cbFilter
//            // 
//            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
//            cbFilter.Font = new Font("Tahoma", 12.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
//            cbFilter.FormattingEnabled = true;
//            cbFilter.Items.AddRange(new object[] { "الكل", "الوظيفة", "القسم" });
//            cbFilter.Location = new Point(374, 243);
//            cbFilter.Margin = new Padding(2);
//            cbFilter.Name = "cbFilter";
//            cbFilter.RightToLeft = RightToLeft.Yes;
//            cbFilter.Size = new Size(138, 29);
//            cbFilter.TabIndex = 7;
//            cbFilter.Visible = false;
//            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
//            // 
//            // label1
//            // 
//            label1.AutoSize = true;
//            label1.Font = new Font("Tahoma", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
//            label1.Location = new Point(495, 236);
//            label1.Margin = new Padding(2, 0, 2, 0);
//            label1.Name = "label1";
//            label1.Size = new Size(126, 36);
//            label1.TabIndex = 5;
//            label1.Text = " : ابحث ";
//            // 
//            // dgvJobs
//            // 
//            dgvJobs.AllowUserToAddRows = false;
//            dgvJobs.AllowUserToDeleteRows = false;
//            dgvJobs.AllowUserToOrderColumns = true;
//            dgvJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
//            dgvJobs.BackgroundColor = SystemColors.ButtonHighlight;
//            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
//            dataGridViewCellStyle1.BackColor = SystemColors.Control;
//            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
//            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
//            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
//            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
//            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
//            dgvJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
//            dgvJobs.ColumnHeadersHeight = 20;
//            dgvJobs.ContextMenuStrip = cmsJobs;
//            dgvJobs.Location = new Point(10, 277);
//            dgvJobs.Margin = new Padding(2);
//            dgvJobs.Name = "dgvJobs";
//            dgvJobs.ReadOnly = true;
//            dgvJobs.RightToLeft = RightToLeft.Yes;
//            dgvJobs.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
//            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
//            dataGridViewCellStyle2.BackColor = SystemColors.Control;
//            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
//            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
//            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
//            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
//            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
//            dgvJobs.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
//            dgvJobs.RowHeadersWidth = 51;
//            dataGridViewCellStyle3.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
//            dgvJobs.RowsDefaultCellStyle = dataGridViewCellStyle3;
//            dgvJobs.RowTemplate.Height = 40;
//            dgvJobs.Size = new Size(603, 375);
//            dgvJobs.TabIndex = 0;
//            // 
//            // cmsJobs
//            // 
//            cmsJobs.Font = new Font("Segoe UI", 9F);
//            cmsJobs.ImageScalingSize = new Size(20, 20);
//            cmsJobs.Items.AddRange(new ToolStripItem[] { عرضالوظيفةToolStripMenuItem, AddJobToolStripMenuItem, UpdateJobToolStripMenuItem, DeleteJobToolStripMenuItem });
//            cmsJobs.Name = "cmsDepartments";
//            cmsJobs.RightToLeft = RightToLeft.Yes;
//            cmsJobs.Size = new Size(201, 156);
//            // 
//            // عرضالوظيفةToolStripMenuItem
//            // 
//            عرضالوظيفةToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
//            عرضالوظيفةToolStripMenuItem.Image = Properties.Resources.programmer;
//            عرضالوظيفةToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
//            عرضالوظيفةToolStripMenuItem.Name = "عرضالوظيفةToolStripMenuItem";
//            عرضالوظيفةToolStripMenuItem.Size = new Size(200, 38);
//            عرضالوظيفةToolStripMenuItem.Text = "عرض الوظيفة";
//            عرضالوظيفةToolStripMenuItem.Click += عرضالوظيفةToolStripMenuItem_Click;
//            // 
//            // AddJobToolStripMenuItem
//            // 
//            AddJobToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
//            AddJobToolStripMenuItem.Image = Properties.Resources.suitcase;
//            AddJobToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
//            AddJobToolStripMenuItem.Name = "AddJobToolStripMenuItem";
//            AddJobToolStripMenuItem.Size = new Size(200, 38);
//            AddJobToolStripMenuItem.Text = "اضافة وظيفة";
//            AddJobToolStripMenuItem.Click += AddDepartmentToolStripMenuItem_Click;
//            // 
//            // UpdateJobToolStripMenuItem
//            // 
//            UpdateJobToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
//            UpdateJobToolStripMenuItem.Image = Properties.Resources.updated;
//            UpdateJobToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
//            UpdateJobToolStripMenuItem.Name = "UpdateJobToolStripMenuItem";
//            UpdateJobToolStripMenuItem.Size = new Size(200, 38);
//            UpdateJobToolStripMenuItem.Text = "تعديل وظيفة";
//            UpdateJobToolStripMenuItem.Click += UpdateJobToolStripMenuItem_Click;
//            // 
//            // DeleteJobToolStripMenuItem
//            // 
//            DeleteJobToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
//            DeleteJobToolStripMenuItem.Image = Properties.Resources.delete__1_;
//            DeleteJobToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
//            DeleteJobToolStripMenuItem.Name = "DeleteJobToolStripMenuItem";
//            DeleteJobToolStripMenuItem.Size = new Size(200, 38);
//            DeleteJobToolStripMenuItem.Text = "حذف وظيفة";
//            DeleteJobToolStripMenuItem.Click += حذفالقسمToolStripMenuItem_Click;
//            // 
//            // panel1
//            // 
//            panel1.Controls.Add(btnSearch);
//            panel1.Controls.Add(btnForward);
//            panel1.Controls.Add(btnBack);
//            panel1.Controls.Add(lblCount);
//            panel1.Controls.Add(label2);
//            panel1.Controls.Add(lblTitle);
//            panel1.Controls.Add(pictureBox1);
//            panel1.Controls.Add(btnClose);
//            panel1.Controls.Add(cbFilter);
//            panel1.Controls.Add(txtFilter);
//            panel1.Controls.Add(label1);
//            panel1.Controls.Add(btnAdd);
//            panel1.Controls.Add(dgvJobs);
//            panel1.Cursor = Cursors.Hand;
//            panel1.Dock = DockStyle.Fill;
//            panel1.Location = new Point(0, 0);
//            panel1.Margin = new Padding(2);
//            panel1.Name = "panel1";
//            panel1.Size = new Size(622, 706);
//            panel1.TabIndex = 5;
//            // 
//            // btnSearch
//            // 
//            btnSearch.Cursor = Cursors.Hand;
//            btnSearch.DialogResult = DialogResult.Cancel;
//            btnSearch.Enabled = false;
//            btnSearch.Image = Properties.Resources.search__1_;
//            btnSearch.Location = new Point(171, 233);
//            btnSearch.Margin = new Padding(2);
//            btnSearch.Name = "btnSearch";
//            btnSearch.Size = new Size(46, 37);
//            btnSearch.TabIndex = 19;
//            btnSearch.UseVisualStyleBackColor = true;
//            btnSearch.Visible = false;
//            btnSearch.Click += btnSearch_Click;
//            // 
//            // btnForward
//            // 
//            btnForward.BackColor = Color.WhiteSmoke;
//            btnForward.Cursor = Cursors.Hand;
//            btnForward.DialogResult = DialogResult.Cancel;
//            btnForward.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
//            btnForward.Image = Properties.Resources.fast_forward_double_Left_arrows_symbol;
//            btnForward.Location = new Point(174, 657);
//            btnForward.Margin = new Padding(2);
//            btnForward.Name = "btnForward";
//            btnForward.Size = new Size(104, 40);
//            btnForward.TabIndex = 18;
//            btnForward.Text = "التالي";
//            btnForward.TextImageRelation = TextImageRelation.ImageBeforeText;
//            btnForward.UseVisualStyleBackColor = false;
//            btnForward.Click += btnForward_Click;
//            // 
//            // btnBack
//            // 
//            btnBack.BackColor = Color.WhiteSmoke;
//            btnBack.Cursor = Cursors.Hand;
//            btnBack.DialogResult = DialogResult.Cancel;
//            btnBack.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
//            btnBack.Image = Properties.Resources.fast_forward_double_right_arrows_symbol;
//            btnBack.Location = new Point(282, 657);
//            btnBack.Margin = new Padding(2);
//            btnBack.Name = "btnBack";
//            btnBack.Size = new Size(106, 40);
//            btnBack.TabIndex = 17;
//            btnBack.Text = "السابق";
//            btnBack.TextImageRelation = TextImageRelation.TextBeforeImage;
//            btnBack.UseVisualStyleBackColor = false;
//            btnBack.Click += btnBack_Click;
//            // 
//            // lblCount
//            // 
//            lblCount.AutoSize = true;
//            lblCount.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
//            lblCount.Location = new Point(430, 664);
//            lblCount.Margin = new Padding(2, 0, 2, 0);
//            lblCount.Name = "lblCount";
//            lblCount.Size = new Size(39, 23);
//            lblCount.TabIndex = 14;
//            lblCount.Text = "[?]";
//            // 
//            // label2
//            // 
//            label2.AutoSize = true;
//            label2.Font = new Font("Tahoma", 14.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
//            label2.Location = new Point(449, 664);
//            label2.Margin = new Padding(2, 0, 2, 0);
//            label2.Name = "label2";
//            label2.RightToLeft = RightToLeft.Yes;
//            label2.Size = new Size(163, 23);
//            label2.TabIndex = 13;
//            label2.Text = "الوظائف الحالية : ";
//            // 
//            // pictureBox1
//            // 
//            pictureBox1.Image = Properties.Resources.office_bag;
//            pictureBox1.Location = new Point(221, 2);
//            pictureBox1.Margin = new Padding(2);
//            pictureBox1.Name = "pictureBox1";
//            pictureBox1.Size = new Size(181, 130);
//            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
//            pictureBox1.TabIndex = 1;
//            pictureBox1.TabStop = false;
//            // 
//            // btnClose
//            // 
//            btnClose.BackColor = Color.WhiteSmoke;
//            btnClose.Cursor = Cursors.Hand;
//            btnClose.DialogResult = DialogResult.Cancel;
//            btnClose.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
//            btnClose.Image = Properties.Resources.error;
//            btnClose.Location = new Point(10, 657);
//            btnClose.Margin = new Padding(2);
//            btnClose.Name = "btnClose";
//            btnClose.Size = new Size(104, 40);
//            btnClose.TabIndex = 10;
//            btnClose.Text = "إغلاق";
//            btnClose.TextImageRelation = TextImageRelation.TextBeforeImage;
//            btnClose.UseVisualStyleBackColor = false;
//            btnClose.Click += btnClose_Click;
//            // 
//            // txtFilter
//            // 
//            txtFilter.BorderStyle = BorderStyle.FixedSingle;
//            txtFilter.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
//            txtFilter.Location = new Point(221, 243);
//            txtFilter.Margin = new Padding(2);
//            txtFilter.Multiline = true;
//            txtFilter.Name = "txtFilter";
//            txtFilter.RightToLeft = RightToLeft.Yes;
//            txtFilter.Size = new Size(148, 27);
//            txtFilter.TabIndex = 6;
//            // 
//            // btnAdd
//            // 
//            btnAdd.Cursor = Cursors.Hand;
//            btnAdd.DialogResult = DialogResult.Cancel;
//            btnAdd.Image = Properties.Resources.add__3_;
//            btnAdd.Location = new Point(10, 230);
//            btnAdd.Margin = new Padding(2);
//            btnAdd.Name = "btnAdd";
//            btnAdd.Size = new Size(48, 42);
//            btnAdd.TabIndex = 4;
//            btnAdd.UseVisualStyleBackColor = true;
//            btnAdd.Click += btnAdd_Click;
//            // 
//            // frmJobsList
//            // 
//            AcceptButton = btnSearch;
//            AutoScaleDimensions = new SizeF(96F, 96F);
//            AutoScaleMode = AutoScaleMode.Dpi;
//            CancelButton = btnClose;
//            ClientSize = new Size(622, 706);
//            Controls.Add(panel1);
//            FormBorderStyle = FormBorderStyle.FixedToolWindow;
//            Margin = new Padding(2);
//            Name = "frmJobsList";
//            ShowInTaskbar = false;
//            StartPosition = FormStartPosition.CenterScreen;
//            Text = "Job List";
//            FormClosing += frmJobsList_FormClosing;
//            Load += frmJobsList_Load;
//            ((System.ComponentModel.ISupportInitialize)dgvJobs).EndInit();
//            cmsJobs.ResumeLayout(false);
//            panel1.ResumeLayout(false);
//            panel1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
//            ResumeLayout(false);

//        }

//        #endregion
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.PictureBox pictureBox1;
//        private System.Windows.Forms.Button btnClose;
//        private System.Windows.Forms.ComboBox cbFilter;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Button btnAdd;
//        private System.Windows.Forms.DataGridView dgvJobs;
//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.TextBox txtFilter;
//        private System.Windows.Forms.ContextMenuStrip cmsJobs;
//        private System.Windows.Forms.ToolStripMenuItem AddJobToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem DeleteJobToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem UpdateJobToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem عرضالوظيفةToolStripMenuItem;
//        private Button btnForward;
//        private Button btnBack;
//        private Label lblCount;
//        private Button btnSearch;
//    }
//}
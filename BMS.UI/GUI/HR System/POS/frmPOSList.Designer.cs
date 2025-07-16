namespace BMS.GUI.HR_System.POS
{
    partial class frmPOSList
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
            panel1 = new Panel();
            lblLoading = new Label();
            btnExport = new Button();
            btnSearch = new Button();
            btnForward = new Button();
            btnBack = new Button();
            lblCount = new Label();
            label2 = new Label();
            lblTitle = new Label();
            pbMain = new PictureBox();
            btnClose = new Button();
            cbFilter = new ComboBox();
            txtFilter = new TextBox();
            label1 = new Label();
            btnAdd = new Button();
            dgvPOS = new DataGridView();
            timerLoading = new System.Windows.Forms.Timer(components);
            cmsPos = new ContextMenuStrip(components);
            ShowPosDetailsToolStripMenuItem = new ToolStripMenuItem();
            AddPosToolStripMenuItem = new ToolStripMenuItem();
            DeletePosToolStripMenuItem = new ToolStripMenuItem();
            UpdatePosToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPOS).BeginInit();
            cmsPos.SuspendLayout();
            SuspendLayout();
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
            panel1.Controls.Add(pbMain);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(cbFilter);
            panel1.Controls.Add(txtFilter);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(dgvPOS);
            panel1.Cursor = Cursors.Hand;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(850, 706);
            panel1.TabIndex = 5;
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
            btnExport.Image = Properties.Resources.excel;
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
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Tahoma", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(330, 147);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(191, 46);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "نقاط البيع";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // pbMain
            // 
            pbMain.Image = Properties.Resources.Pos_;
            pbMain.Location = new Point(349, 2);
            pbMain.Margin = new Padding(2);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(152, 143);
            pbMain.SizeMode = PictureBoxSizeMode.Zoom;
            pbMain.TabIndex = 1;
            pbMain.TabStop = false;
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
            // cbFilter
            // 
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.Font = new Font("Tahoma", 12.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFilter.FormattingEnabled = true;
            cbFilter.Items.AddRange(new object[] { "الكل", "رقم المسلسل", "اسم نقطة البيع" });
            cbFilter.Location = new Point(590, 245);
            cbFilter.Margin = new Padding(2);
            cbFilter.Name = "cbFilter";
            cbFilter.RightToLeft = RightToLeft.Yes;
            cbFilter.Size = new Size(138, 29);
            cbFilter.TabIndex = 2;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
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
            // dgvPOS
            // 
            dgvPOS.AllowUserToAddRows = false;
            dgvPOS.AllowUserToDeleteRows = false;
            dgvPOS.AllowUserToOrderColumns = true;
            dgvPOS.AllowUserToResizeColumns = false;
            dgvPOS.AllowUserToResizeRows = false;
            dgvPOS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPOS.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPOS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPOS.ColumnHeadersHeight = 20;
            dgvPOS.ContextMenuStrip = cmsPos;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPOS.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPOS.Location = new Point(10, 277);
            dgvPOS.Margin = new Padding(2);
            dgvPOS.Name = "dgvPOS";
            dgvPOS.ReadOnly = true;
            dgvPOS.RightToLeft = RightToLeft.Yes;
            dgvPOS.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPOS.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPOS.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvPOS.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvPOS.RowTemplate.Height = 40;
            dgvPOS.Size = new Size(830, 375);
            dgvPOS.TabIndex = 0;
            dgvPOS.CellDoubleClick += dgvPos_CellDoubleClick;
            // 
            // timerLoading
            // 
            timerLoading.Tick += timerLoading_Tick;
            // 
            // cmsPos
            // 
            cmsPos.Font = new Font("Segoe UI", 9F);
            cmsPos.ImageScalingSize = new Size(20, 20);
            cmsPos.Items.AddRange(new ToolStripItem[] { ShowPosDetailsToolStripMenuItem, AddPosToolStripMenuItem, DeletePosToolStripMenuItem, UpdatePosToolStripMenuItem });
            cmsPos.Name = "cmsDepartments";
            cmsPos.RightToLeft = RightToLeft.Yes;
            cmsPos.Size = new Size(242, 156);
            // 
            // ShowPosDetailsToolStripMenuItem
            // 
            ShowPosDetailsToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ShowPosDetailsToolStripMenuItem.Image = Properties.Resources.presentation;
            ShowPosDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            ShowPosDetailsToolStripMenuItem.Name = "ShowPosDetailsToolStripMenuItem";
            ShowPosDetailsToolStripMenuItem.Size = new Size(241, 38);
            ShowPosDetailsToolStripMenuItem.Text = "عرض بينات نقطة البيع ";
            ShowPosDetailsToolStripMenuItem.Click += ShowPosDetailsToolStripMenuItem_Click;
            // 
            // AddPosToolStripMenuItem
            // 
            AddPosToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            AddPosToolStripMenuItem.Image = Properties.Resources.add__2_;
            AddPosToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            AddPosToolStripMenuItem.Name = "AddPosToolStripMenuItem";
            AddPosToolStripMenuItem.Size = new Size(241, 38);
            AddPosToolStripMenuItem.Text = "اضافة نقطة بيع";
            AddPosToolStripMenuItem.Click += AddPosToolStripMenuItem_Click;
            // 
            // DeletePosToolStripMenuItem
            // 
            DeletePosToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            DeletePosToolStripMenuItem.Image = Properties.Resources.delete__1_;
            DeletePosToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            DeletePosToolStripMenuItem.Name = "DeletePosToolStripMenuItem";
            DeletePosToolStripMenuItem.Size = new Size(241, 38);
            DeletePosToolStripMenuItem.Text = "حذف نقطه البيع";
            DeletePosToolStripMenuItem.Click += DeletePosToolStripMenuItem_Click;
            // 
            // UpdatePosToolStripMenuItem
            // 
            UpdatePosToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            UpdatePosToolStripMenuItem.Image = Properties.Resources.updated;
            UpdatePosToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            UpdatePosToolStripMenuItem.Name = "UpdatePosToolStripMenuItem";
            UpdatePosToolStripMenuItem.Size = new Size(241, 38);
            UpdatePosToolStripMenuItem.Text = "تعديل نقطة البيع";
            UpdatePosToolStripMenuItem.Click += UpdatePosToolStripMenuItem_Click;
            // 
            // frmPOSList
            // 
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(850, 706);
            Controls.Add(panel1);
            Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPOSList";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += frmPosList_FormClosing;
            Load += frmPOS_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPOS).EndInit();
            cmsPos.ResumeLayout(false);
            ResumeLayout(false);
        }



        #endregion

        private Panel panel1;
        private Label lblLoading;
        private Button btnExport;
        private Button btnSearch;
        private Button btnForward;
        private Button btnBack;
        private Label lblCount;
        private Label label2;
        private Label lblTitle;
        private PictureBox pbMain;
        private Button btnClose;
        private ComboBox cbFilter;
        private TextBox txtFilter;
        private Label label1;
        private Button btnAdd;
        private DataGridView dgvPOS;
        private System.Windows.Forms.Timer timerLoading;
        private ContextMenuStrip cmsPos;
        private ToolStripMenuItem ShowPosDetailsToolStripMenuItem;
        private ToolStripMenuItem AddPosToolStripMenuItem;
        private ToolStripMenuItem DeletePosToolStripMenuItem;
        private ToolStripMenuItem UpdatePosToolStripMenuItem;
    }
}
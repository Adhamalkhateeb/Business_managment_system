namespace BMS.GUI.Controls
{
    partial class ctrlListOf
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbxImage = new PictureBox();
            lblTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnExport = new Button();
            label1 = new Label();
            btnAdd = new Button();
            panel1 = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            cbxFilter = new ComboBox();
            panel2 = new Panel();
            panel3 = new Panel();
            dgvList = new DataGridView();
            btnForward = new Button();
            btnBack = new Button();
            lblCount = new Label();
            lblRowsCountTitle = new Label();
            btnClose = new Button();
            panel4 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel13 = new Panel();
            label2 = new Label();
            panel12 = new Panel();
            lblCurrentPage = new Label();
            panel11 = new Panel();
            lblTotalPages = new Label();
            panel9 = new Panel();
            panel10 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbxImage).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // pbxImage
            // 
            pbxImage.Anchor = AnchorStyles.None;
            pbxImage.Image = Properties.Resources.List;
            pbxImage.Location = new Point(416, 3);
            pbxImage.Name = "pbxImage";
            pbxImage.Size = new Size(167, 118);
            pbxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImage.TabIndex = 1;
            pbxImage.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(445, 133);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(110, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "List Title";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += label1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 1);
            tableLayoutPanel1.Controls.Add(pbxImage, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(1000, 181);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.Cursor = Cursors.Hand;
            btnExport.DialogResult = DialogResult.Cancel;
            btnExport.Dock = DockStyle.Right;
            btnExport.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            btnExport.Image = Properties.Resources.export;
            btnExport.ImageAlign = ContentAlignment.MiddleLeft;
            btnExport.Location = new Point(147, 0);
            btnExport.Margin = new Padding(2);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(115, 50);
            btnExport.TabIndex = 24;
            btnExport.Text = "تصدير";
            btnExport.TextAlign = ContentAlignment.MiddleRight;
            btnExport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font("Tahoma", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(444, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(126, 36);
            label1.TabIndex = 20;
            label1.Text = " : ابحث ";
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.DialogResult = DialogResult.Cancel;
            btnAdd.Dock = DockStyle.Left;
            btnAdd.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            btnAdd.Image = Properties.Resources.plus__1_;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(0, 0);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(123, 50);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "إضافة";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(cbxFilter);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(425, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(575, 50);
            panel1.TabIndex = 25;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Left;
            txtSearch.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(49, 5);
            txtSearch.Margin = new Padding(10, 3, 3, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(201, 39);
            txtSearch.TabIndex = 24;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.DialogResult = DialogResult.Cancel;
            btnSearch.Dock = DockStyle.Left;
            btnSearch.Enabled = false;
            btnSearch.Image = Properties.Resources.search__1_;
            btnSearch.Location = new Point(5, 5);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(0, 0, 2, 0);
            btnSearch.Size = new Size(44, 40);
            btnSearch.TabIndex = 23;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Visible = false;
            // 
            // cbxFilter
            // 
            cbxFilter.Dock = DockStyle.Right;
            cbxFilter.Font = new Font("Segoe UI", 16F);
            cbxFilter.FormattingEnabled = true;
            cbxFilter.Location = new Point(256, 5);
            cbxFilter.Name = "cbxFilter";
            cbxFilter.Size = new Size(188, 38);
            cbxFilter.TabIndex = 21;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(btnExport);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 50);
            panel2.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(panel2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 181);
            panel3.Name = "panel3";
            panel3.Size = new Size(1000, 50);
            panel3.TabIndex = 27;
            // 
            // dgvList
            // 
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.Dock = DockStyle.Fill;
            dgvList.Location = new Point(0, 231);
            dgvList.Name = "dgvList";
            dgvList.Size = new Size(1000, 337);
            dgvList.TabIndex = 28;
            // 
            // btnForward
            // 
            btnForward.BackColor = Color.WhiteSmoke;
            btnForward.Cursor = Cursors.Hand;
            btnForward.DialogResult = DialogResult.Cancel;
            btnForward.Dock = DockStyle.Right;
            btnForward.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnForward.Image = Properties.Resources.fast_forward_double_Left_arrows_symbol;
            btnForward.Location = new Point(127, 0);
            btnForward.Margin = new Padding(2);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(104, 58);
            btnForward.TabIndex = 33;
            btnForward.Text = "التالي";
            btnForward.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnForward.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.WhiteSmoke;
            btnBack.Cursor = Cursors.Hand;
            btnBack.DialogResult = DialogResult.Cancel;
            btnBack.Dock = DockStyle.Left;
            btnBack.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Image = Properties.Resources.fast_forward_double_right_arrows_symbol;
            btnBack.Location = new Point(0, 0);
            btnBack.Margin = new Padding(2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(106, 58);
            btnBack.TabIndex = 32;
            btnBack.Text = "السابق";
            btnBack.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnBack.UseVisualStyleBackColor = false;
            // 
            // lblCount
            // 
            lblCount.Anchor = AnchorStyles.None;
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCount.Location = new Point(18, 15);
            lblCount.Margin = new Padding(2, 0, 2, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(39, 23);
            lblCount.TabIndex = 31;
            lblCount.Text = "[?]";
            // 
            // lblRowsCountTitle
            // 
            lblRowsCountTitle.Anchor = AnchorStyles.None;
            lblRowsCountTitle.AutoSize = true;
            lblRowsCountTitle.Font = new Font("Tahoma", 14.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRowsCountTitle.Location = new Point(61, 14);
            lblRowsCountTitle.Margin = new Padding(2, 0, 2, 0);
            lblRowsCountTitle.Name = "lblRowsCountTitle";
            lblRowsCountTitle.RightToLeft = RightToLeft.Yes;
            lblRowsCountTitle.Size = new Size(122, 23);
            lblRowsCountTitle.TabIndex = 30;
            lblRowsCountTitle.Text = "عدد الصفوف";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.error;
            btnClose.Location = new Point(14, 8);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(104, 40);
            btnClose.TabIndex = 29;
            btnClose.Text = "إغلاق";
            btnClose.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 510);
            panel4.Name = "panel4";
            panel4.Size = new Size(1000, 58);
            panel4.TabIndex = 34;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(panel9);
            panel7.Controls.Add(panel10);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(123, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(670, 58);
            panel7.TabIndex = 34;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel13);
            panel8.Controls.Add(panel12);
            panel8.Controls.Add(panel11);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(231, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(222, 58);
            panel8.TabIndex = 40;
            // 
            // panel13
            // 
            panel13.Controls.Add(label2);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(49, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(119, 58);
            panel13.TabIndex = 39;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(52, 15);
            label2.Name = "label2";
            label2.Size = new Size(25, 32);
            label2.TabIndex = 36;
            label2.Text = "/";
            // 
            // panel12
            // 
            panel12.Controls.Add(lblCurrentPage);
            panel12.Dock = DockStyle.Left;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(49, 58);
            panel12.TabIndex = 38;
            // 
            // lblCurrentPage
            // 
            lblCurrentPage.Anchor = AnchorStyles.None;
            lblCurrentPage.AutoSize = true;
            lblCurrentPage.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCurrentPage.Location = new Point(12, 15);
            lblCurrentPage.Name = "lblCurrentPage";
            lblCurrentPage.Size = new Size(28, 32);
            lblCurrentPage.TabIndex = 34;
            lblCurrentPage.Text = "1";
            // 
            // panel11
            // 
            panel11.Controls.Add(lblTotalPages);
            panel11.Dock = DockStyle.Right;
            panel11.Location = new Point(168, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(54, 58);
            panel11.TabIndex = 37;
            // 
            // lblTotalPages
            // 
            lblTotalPages.Anchor = AnchorStyles.None;
            lblTotalPages.AutoSize = true;
            lblTotalPages.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalPages.Location = new Point(8, 15);
            lblTotalPages.Name = "lblTotalPages";
            lblTotalPages.Size = new Size(42, 32);
            lblTotalPages.TabIndex = 35;
            lblTotalPages.Text = "10";
            // 
            // panel9
            // 
            panel9.Controls.Add(btnBack);
            panel9.Dock = DockStyle.Right;
            panel9.Location = new Point(453, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(217, 58);
            panel9.TabIndex = 38;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnForward);
            panel10.Dock = DockStyle.Left;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(231, 58);
            panel10.TabIndex = 39;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnClose);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(123, 58);
            panel6.TabIndex = 33;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblRowsCountTitle);
            panel5.Controls.Add(lblCount);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(793, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(207, 58);
            panel5.TabIndex = 32;
            // 
            // ctrlListOf
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(dgvList);
            Controls.Add(panel3);
            Controls.Add(tableLayoutPanel1);
            Name = "ctrlListOf";
            Padding = new Padding(0, 0, 5, 0);
            Size = new Size(1005, 568);
            ((System.ComponentModel.ISupportInitialize)pbxImage).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            panel4.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel9.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxImage;
        private Label lblTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnExport;
        private Label label1;
        private Button btnAdd;
        private Panel panel1;
        private ComboBox cbxFilter;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvList;
        private Button btnForward;
        private Button btnBack;
        private Label lblCount;
        private Label lblRowsCountTitle;
        private Button btnClose;
        private Panel panel4;
        private Panel panel5;
        private Panel panel7;
        private Label lblTotalPages;
        private Label lblCurrentPage;
        private Panel panel6;
        private Label label2;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private Panel panel12;
        private Panel panel11;
        private Panel panel13;
    }
}

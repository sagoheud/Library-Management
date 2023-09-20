namespace Library_Management
{
    partial class Dashboard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnBook = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBookAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBookView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStudentAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStudentView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBookIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBookReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBookDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBook,
            this.btnStudent,
            this.btnBookIssue,
            this.btnBookReturn,
            this.btnBookDetail,
            this.btnExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 70);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnBook
            // 
            this.btnBook.AutoSize = false;
            this.btnBook.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBookAdd,
            this.btnBookView});
            this.btnBook.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.Image = global::Library_Management.Properties.Resources.free_icon_book_3403915;
            this.btnBook.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(172, 70);
            this.btnBook.Text = "도서 관리";
            this.btnBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBookAdd
            // 
            this.btnBookAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(143)))), ((int)(((byte)(98)))));
            this.btnBookAdd.Image = global::Library_Management.Properties.Resources.free_icon_medical_book_4613408;
            this.btnBookAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBookAdd.Name = "btnBookAdd";
            this.btnBookAdd.Size = new System.Drawing.Size(212, 46);
            this.btnBookAdd.Text = "신규 도서 추가 ";
            this.btnBookAdd.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnBookAdd.Click += new System.EventHandler(this.btnBookAdd_Click);
            // 
            // btnBookView
            // 
            this.btnBookView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(143)))), ((int)(((byte)(98)))));
            this.btnBookView.Image = global::Library_Management.Properties.Resources.free_icon_book_3387927;
            this.btnBookView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBookView.Name = "btnBookView";
            this.btnBookView.Size = new System.Drawing.Size(212, 46);
            this.btnBookView.Text = "도서 정보 보기";
            this.btnBookView.Click += new System.EventHandler(this.btnBookView_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.AutoSize = false;
            this.btnStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(143)))), ((int)(((byte)(98)))));
            this.btnStudent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStudentAdd,
            this.btnStudentView});
            this.btnStudent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.Image = global::Library_Management.Properties.Resources.free_icon_graduate_949642;
            this.btnStudent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(172, 70);
            this.btnStudent.Text = "학생 관리";
            this.btnStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnStudentAdd
            // 
            this.btnStudentAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnStudentAdd.Image = global::Library_Management.Properties.Resources.free_icon_student_7218043;
            this.btnStudentAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStudentAdd.Name = "btnStudentAdd";
            this.btnStudentAdd.Size = new System.Drawing.Size(208, 46);
            this.btnStudentAdd.Text = "학생 추가";
            this.btnStudentAdd.Click += new System.EventHandler(this.btnStudentAdd_Click);
            // 
            // btnStudentView
            // 
            this.btnStudentView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnStudentView.Image = global::Library_Management.Properties.Resources.free_icon_magnifier_2955512;
            this.btnStudentView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStudentView.Name = "btnStudentView";
            this.btnStudentView.Size = new System.Drawing.Size(208, 46);
            this.btnStudentView.Text = "학생 정보 보기";
            this.btnStudentView.Click += new System.EventHandler(this.btnStudentView_Click);
            // 
            // btnBookIssue
            // 
            this.btnBookIssue.AutoSize = false;
            this.btnBookIssue.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookIssue.Image = global::Library_Management.Properties.Resources.free_icon_book_5766902;
            this.btnBookIssue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBookIssue.Name = "btnBookIssue";
            this.btnBookIssue.Size = new System.Drawing.Size(172, 70);
            this.btnBookIssue.Text = "도서 대여";
            this.btnBookIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBookIssue.Click += new System.EventHandler(this.btnBookIssue_Click);
            // 
            // btnBookReturn
            // 
            this.btnBookReturn.AutoSize = false;
            this.btnBookReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(143)))), ((int)(((byte)(98)))));
            this.btnBookReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookReturn.Image = global::Library_Management.Properties.Resources.free_icon_reading_book_5216256;
            this.btnBookReturn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBookReturn.Name = "btnBookReturn";
            this.btnBookReturn.Size = new System.Drawing.Size(172, 70);
            this.btnBookReturn.Text = "도서 반납";
            this.btnBookReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBookReturn.Click += new System.EventHandler(this.btnBookReturn_Click);
            // 
            // btnBookDetail
            // 
            this.btnBookDetail.AutoSize = false;
            this.btnBookDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookDetail.Image = global::Library_Management.Properties.Resources.free_icon_books_2097068;
            this.btnBookDetail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBookDetail.Name = "btnBookDetail";
            this.btnBookDetail.Size = new System.Drawing.Size(172, 70);
            this.btnBookDetail.Text = "도서 상세 설명";
            this.btnBookDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBookDetail.Click += new System.EventHandler(this.btnBookDetail_Click);
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(143)))), ((int)(((byte)(98)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::Library_Management.Properties.Resources.free_icon_exit_door_7879667;
            this.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(172, 70);
            this.btnExit.Text = "종료";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Library_Management.Properties.Resources.library_4589730_1280;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnBook;
        private System.Windows.Forms.ToolStripMenuItem btnBookAdd;
        private System.Windows.Forms.ToolStripMenuItem btnBookView;
        private System.Windows.Forms.ToolStripMenuItem btnStudent;
        private System.Windows.Forms.ToolStripMenuItem btnStudentAdd;
        private System.Windows.Forms.ToolStripMenuItem btnStudentView;
        private System.Windows.Forms.ToolStripMenuItem btnBookIssue;
        private System.Windows.Forms.ToolStripMenuItem btnBookReturn;
        private System.Windows.Forms.ToolStripMenuItem btnBookDetail;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}
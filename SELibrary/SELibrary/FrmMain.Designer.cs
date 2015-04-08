namespace SELibrary
{
    partial class FrmMainLibrary
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
            this.components = new System.ComponentModel.Container();
            this.LstBookList = new System.Windows.Forms.ListBox();
            this.CBoxPatron = new System.Windows.Forms.ComboBox();
            this.LblPatron = new System.Windows.Forms.Label();
            this.LblMedia = new System.Windows.Forms.Label();
            this.CBoxBook = new System.Windows.Forms.ComboBox();
            this.LblDate = new System.Windows.Forms.Label();
            this.TxtDate = new System.Windows.Forms.TextBox();
            this.BtnDayForward = new System.Windows.Forms.Button();
            this.LblMediaList = new System.Windows.Forms.Label();
            this.RdoListNone = new System.Windows.Forms.RadioButton();
            this.RdoListByPatron = new System.Windows.Forms.RadioButton();
            this.RdoListOverdue = new System.Windows.Forms.RadioButton();
            this.RdoListAll = new System.Windows.Forms.RadioButton();
            this.BtnCheckOut = new System.Windows.Forms.Button();
            this.BtnCheckIn = new System.Windows.Forms.Button();
            this.EProvReport = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EProvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // LstBookList
            // 
            this.LstBookList.FormattingEnabled = true;
            this.LstBookList.Location = new System.Drawing.Point(12, 221);
            this.LstBookList.Name = "LstBookList";
            this.LstBookList.Size = new System.Drawing.Size(574, 212);
            this.LstBookList.TabIndex = 0;
            // 
            // CBoxPatron
            // 
            this.CBoxPatron.FormattingEnabled = true;
            this.CBoxPatron.Location = new System.Drawing.Point(12, 64);
            this.CBoxPatron.Name = "CBoxPatron";
            this.CBoxPatron.Size = new System.Drawing.Size(574, 21);
            this.CBoxPatron.TabIndex = 1;
            // 
            // LblPatron
            // 
            this.LblPatron.AutoSize = true;
            this.LblPatron.Location = new System.Drawing.Point(12, 48);
            this.LblPatron.Name = "LblPatron";
            this.LblPatron.Size = new System.Drawing.Size(38, 13);
            this.LblPatron.TabIndex = 2;
            this.LblPatron.Text = "Patron";
            // 
            // LblMedia
            // 
            this.LblMedia.AutoSize = true;
            this.LblMedia.Location = new System.Drawing.Point(12, 88);
            this.LblMedia.Name = "LblMedia";
            this.LblMedia.Size = new System.Drawing.Size(58, 13);
            this.LblMedia.TabIndex = 3;
            this.LblMedia.Text = "Media item";
            // 
            // CBoxBook
            // 
            this.CBoxBook.FormattingEnabled = true;
            this.CBoxBook.Location = new System.Drawing.Point(12, 104);
            this.CBoxBook.Name = "CBoxBook";
            this.CBoxBook.Size = new System.Drawing.Size(574, 21);
            this.CBoxBook.TabIndex = 4;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(12, 9);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(68, 13);
            this.LblDate.TabIndex = 5;
            this.LblDate.Text = "Today\'s date";
            // 
            // TxtDate
            // 
            this.TxtDate.Enabled = false;
            this.TxtDate.Location = new System.Drawing.Point(12, 25);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Size = new System.Drawing.Size(218, 20);
            this.TxtDate.TabIndex = 6;
            // 
            // BtnDayForward
            // 
            this.BtnDayForward.Location = new System.Drawing.Point(236, 23);
            this.BtnDayForward.Name = "BtnDayForward";
            this.BtnDayForward.Size = new System.Drawing.Size(128, 23);
            this.BtnDayForward.TabIndex = 7;
            this.BtnDayForward.Text = "Forward one day >>";
            this.BtnDayForward.UseVisualStyleBackColor = true;
            this.BtnDayForward.Click += new System.EventHandler(this.BtnDayForward_Click_1);
            // 
            // LblMediaList
            // 
            this.LblMediaList.AutoSize = true;
            this.LblMediaList.Location = new System.Drawing.Point(9, 180);
            this.LblMediaList.Name = "LblMediaList";
            this.LblMediaList.Size = new System.Drawing.Size(57, 13);
            this.LblMediaList.TabIndex = 8;
            this.LblMediaList.Text = "List media:";
            // 
            // RdoListNone
            // 
            this.RdoListNone.AutoSize = true;
            this.RdoListNone.Checked = true;
            this.RdoListNone.Location = new System.Drawing.Point(12, 196);
            this.RdoListNone.Name = "RdoListNone";
            this.RdoListNone.Size = new System.Drawing.Size(51, 17);
            this.RdoListNone.TabIndex = 9;
            this.RdoListNone.TabStop = true;
            this.RdoListNone.Text = "None";
            this.RdoListNone.UseVisualStyleBackColor = true;
            this.RdoListNone.CheckedChanged += new System.EventHandler(this.RdoListNone_CheckedChanged);
            // 
            // RdoListByPatron
            // 
            this.RdoListByPatron.AutoSize = true;
            this.RdoListByPatron.Location = new System.Drawing.Point(266, 196);
            this.RdoListByPatron.Name = "RdoListByPatron";
            this.RdoListByPatron.Size = new System.Drawing.Size(116, 17);
            this.RdoListByPatron.TabIndex = 10;
            this.RdoListByPatron.Text = "All loaned to patron";
            this.RdoListByPatron.UseVisualStyleBackColor = true;
            this.RdoListByPatron.CheckedChanged += new System.EventHandler(this.RdoListByPatron_CheckedChanged);
            // 
            // RdoListOverdue
            // 
            this.RdoListOverdue.AutoSize = true;
            this.RdoListOverdue.Location = new System.Drawing.Point(158, 196);
            this.RdoListOverdue.Name = "RdoListOverdue";
            this.RdoListOverdue.Size = new System.Drawing.Size(78, 17);
            this.RdoListOverdue.TabIndex = 11;
            this.RdoListOverdue.Text = "All overdue";
            this.RdoListOverdue.UseVisualStyleBackColor = true;
            this.RdoListOverdue.CheckedChanged += new System.EventHandler(this.RdoListOverdue_CheckedChanged);
            // 
            // RdoListAll
            // 
            this.RdoListAll.AutoSize = true;
            this.RdoListAll.Location = new System.Drawing.Point(93, 196);
            this.RdoListAll.Name = "RdoListAll";
            this.RdoListAll.Size = new System.Drawing.Size(36, 17);
            this.RdoListAll.TabIndex = 12;
            this.RdoListAll.Text = "All";
            this.RdoListAll.UseVisualStyleBackColor = true;
            this.RdoListAll.CheckedChanged += new System.EventHandler(this.RdoListAll_CheckedChanged);
            // 
            // BtnCheckOut
            // 
            this.BtnCheckOut.Location = new System.Drawing.Point(93, 131);
            this.BtnCheckOut.Name = "BtnCheckOut";
            this.BtnCheckOut.Size = new System.Drawing.Size(75, 23);
            this.BtnCheckOut.TabIndex = 13;
            this.BtnCheckOut.Text = "Check out";
            this.BtnCheckOut.UseVisualStyleBackColor = true;
            // 
            // BtnCheckIn
            // 
            this.BtnCheckIn.Location = new System.Drawing.Point(12, 131);
            this.BtnCheckIn.Name = "BtnCheckIn";
            this.BtnCheckIn.Size = new System.Drawing.Size(75, 23);
            this.BtnCheckIn.TabIndex = 14;
            this.BtnCheckIn.Text = "Check in";
            this.BtnCheckIn.UseVisualStyleBackColor = true;
            // 
            // EProvReport
            // 
            this.EProvReport.ContainerControl = this;
            // 
            // FrmMainLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 445);
            this.Controls.Add(this.BtnCheckIn);
            this.Controls.Add(this.BtnCheckOut);
            this.Controls.Add(this.RdoListAll);
            this.Controls.Add(this.RdoListOverdue);
            this.Controls.Add(this.RdoListByPatron);
            this.Controls.Add(this.RdoListNone);
            this.Controls.Add(this.LblMediaList);
            this.Controls.Add(this.BtnDayForward);
            this.Controls.Add(this.TxtDate);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.CBoxBook);
            this.Controls.Add(this.LblMedia);
            this.Controls.Add(this.LblPatron);
            this.Controls.Add(this.CBoxPatron);
            this.Controls.Add(this.LstBookList);
            this.Name = "FrmMainLibrary";
            this.Text = "Book Manager";
            this.Load += new System.EventHandler(this.FrmMainLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EProvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstBookList;
        private System.Windows.Forms.ComboBox CBoxPatron;
        private System.Windows.Forms.Label LblPatron;
        private System.Windows.Forms.Label LblMedia;
        private System.Windows.Forms.ComboBox CBoxBook;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.TextBox TxtDate;
        private System.Windows.Forms.Button BtnDayForward;
        private System.Windows.Forms.Label LblMediaList;
        private System.Windows.Forms.RadioButton RdoListNone;
        private System.Windows.Forms.RadioButton RdoListByPatron;
        private System.Windows.Forms.RadioButton RdoListOverdue;
        private System.Windows.Forms.RadioButton RdoListAll;
        private System.Windows.Forms.Button BtnCheckOut;
        private System.Windows.Forms.Button BtnCheckIn;
        private System.Windows.Forms.ErrorProvider EProvReport;
    }
}


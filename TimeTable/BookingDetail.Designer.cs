namespace TimeTable
{
    partial class BookingDetail
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
            this.startHour = new System.Windows.Forms.NumericUpDown();
            this.startMinute = new System.Windows.Forms.NumericUpDown();
            this.endMinute = new System.Windows.Forms.NumericUpDown();
            this.endHour = new System.Windows.Forms.NumericUpDown();
            this.room = new System.Windows.Forms.ListBox();
            this.level = new System.Windows.Forms.ListBox();
            this.lesson = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.group = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.ListBox();
            this.day = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.staff = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.infill = new System.Windows.Forms.CheckBox();
            this.delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endHour)).BeginInit();
            this.SuspendLayout();
            // 
            // startHour
            // 
            this.startHour.Location = new System.Drawing.Point(10, 86);
            this.startHour.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.startHour.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.startHour.Name = "startHour";
            this.startHour.Size = new System.Drawing.Size(54, 22);
            this.startHour.TabIndex = 0;
            this.startHour.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.startHour.ValueChanged += new System.EventHandler(this.startHour_ValueChanged);
            // 
            // startMinute
            // 
            this.startMinute.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.startMinute.Location = new System.Drawing.Point(70, 86);
            this.startMinute.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.startMinute.Name = "startMinute";
            this.startMinute.Size = new System.Drawing.Size(60, 22);
            this.startMinute.TabIndex = 1;
            // 
            // endMinute
            // 
            this.endMinute.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.endMinute.Location = new System.Drawing.Point(245, 86);
            this.endMinute.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.endMinute.Name = "endMinute";
            this.endMinute.Size = new System.Drawing.Size(60, 22);
            this.endMinute.TabIndex = 3;
            this.endMinute.ValueChanged += new System.EventHandler(this.endMinute_ValueChanged);
            // 
            // endHour
            // 
            this.endHour.Location = new System.Drawing.Point(185, 86);
            this.endHour.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.endHour.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.endHour.Name = "endHour";
            this.endHour.Size = new System.Drawing.Size(54, 22);
            this.endHour.TabIndex = 2;
            this.endHour.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.endHour.ValueChanged += new System.EventHandler(this.endHour_ValueChanged);
            // 
            // room
            // 
            this.room.FormattingEnabled = true;
            this.room.ItemHeight = 16;
            this.room.Items.AddRange(new object[] {
            "B112",
            "B114",
            "B115A",
            "B115B",
            "B116",
            "B118",
            "B126"});
            this.room.Location = new System.Drawing.Point(164, 136);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(85, 180);
            this.room.TabIndex = 4;
            // 
            // level
            // 
            this.level.FormattingEnabled = true;
            this.level.ItemHeight = 16;
            this.level.Items.AddRange(new object[] {
            "L1",
            "L2",
            "L3",
            "HE",
            "PH"});
            this.level.Location = new System.Drawing.Point(62, 136);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(41, 180);
            this.level.TabIndex = 5;
            // 
            // lesson
            // 
            this.lesson.Location = new System.Drawing.Point(10, 39);
            this.lesson.Name = "lesson";
            this.lesson.Size = new System.Drawing.Size(229, 22);
            this.lesson.TabIndex = 6;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(10, 331);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(73, 26);
            this.add.TabIndex = 7;
            this.add.Text = "Ok";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // group
            // 
            this.group.FormattingEnabled = true;
            this.group.ItemHeight = 16;
            this.group.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.group.Location = new System.Drawing.Point(107, 248);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(51, 68);
            this.group.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Start Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "End Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Unit Name";
            // 
            // year
            // 
            this.year.FormattingEnabled = true;
            this.year.ItemHeight = 16;
            this.year.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.year.Location = new System.Drawing.Point(107, 136);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(51, 68);
            this.year.TabIndex = 12;
            // 
            // day
            // 
            this.day.FormattingEnabled = true;
            this.day.ItemHeight = 16;
            this.day.Items.AddRange(new object[] {
            "Mon",
            "Tue",
            "Wed",
            "Thu",
            "Fri"});
            this.day.Location = new System.Drawing.Point(10, 136);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(46, 180);
            this.day.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Day";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Lev.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Yr.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(105, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Grp.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Room";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(232, 331);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(73, 26);
            this.Cancel.TabIndex = 20;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // staff
            // 
            this.staff.FormattingEnabled = true;
            this.staff.ItemHeight = 16;
            this.staff.Location = new System.Drawing.Point(255, 136);
            this.staff.Name = "staff";
            this.staff.Size = new System.Drawing.Size(50, 180);
            this.staff.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(255, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Staff";
            // 
            // infill
            // 
            this.infill.AutoSize = true;
            this.infill.Location = new System.Drawing.Point(245, 40);
            this.infill.Name = "infill";
            this.infill.Size = new System.Drawing.Size(54, 21);
            this.infill.TabIndex = 23;
            this.infill.Text = "Infill";
            this.infill.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(121, 331);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 26);
            this.delete.TabIndex = 24;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Visible = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // BookingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 368);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.infill);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.staff);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.day);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.group);
            this.Controls.Add(this.add);
            this.Controls.Add(this.lesson);
            this.Controls.Add(this.level);
            this.Controls.Add(this.room);
            this.Controls.Add(this.endMinute);
            this.Controls.Add(this.endHour);
            this.Controls.Add(this.startMinute);
            this.Controls.Add(this.startHour);
            this.Name = "BookingDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Booking Detail";
            this.Load += new System.EventHandler(this.BookingDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown startHour;
        private System.Windows.Forms.NumericUpDown startMinute;
        private System.Windows.Forms.NumericUpDown endMinute;
        private System.Windows.Forms.NumericUpDown endHour;
        private System.Windows.Forms.ListBox room;
        private System.Windows.Forms.ListBox level;
        private System.Windows.Forms.TextBox lesson;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ListBox group;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox year;
        private System.Windows.Forms.ListBox day;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ListBox staff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox infill;
        private System.Windows.Forms.Button delete;


    }
}


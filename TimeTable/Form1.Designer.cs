namespace TimeTable
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endHour)).BeginInit();
            this.SuspendLayout();
            // 
            // startHour
            // 
            this.startHour.Location = new System.Drawing.Point(10, 108);
            this.startHour.Maximum = new decimal(new int[] {
            21,
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
            // 
            // startMinute
            // 
            this.startMinute.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.startMinute.Location = new System.Drawing.Point(70, 108);
            this.startMinute.Maximum = new decimal(new int[] {
            60,
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
            this.endMinute.Location = new System.Drawing.Point(196, 108);
            this.endMinute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.endMinute.Name = "endMinute";
            this.endMinute.Size = new System.Drawing.Size(60, 22);
            this.endMinute.TabIndex = 3;
            // 
            // endHour
            // 
            this.endHour.Location = new System.Drawing.Point(136, 108);
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
            9,
            0,
            0,
            0});
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
            this.room.Location = new System.Drawing.Point(196, 136);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(60, 116);
            this.room.TabIndex = 4;
            // 
            // level
            // 
            this.level.FormattingEnabled = true;
            this.level.ItemHeight = 16;
            this.level.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3",
            "Higher",
            "Higher PT"});
            this.level.Location = new System.Drawing.Point(10, 136);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(73, 84);
            this.level.TabIndex = 5;
            // 
            // lesson
            // 
            this.lesson.Location = new System.Drawing.Point(10, 27);
            this.lesson.Name = "lesson";
            this.lesson.Size = new System.Drawing.Size(246, 22);
            this.lesson.TabIndex = 6;
            this.lesson.TextChanged += new System.EventHandler(this.lesson_TextChanged);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(10, 226);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(73, 26);
            this.add.TabIndex = 7;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
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
            this.group.Location = new System.Drawing.Point(136, 136);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(34, 68);
            this.group.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Start Time";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "End Time";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Unit Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            this.year.Location = new System.Drawing.Point(89, 136);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(41, 68);
            this.year.TabIndex = 12;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mon",
            "Tue",
            "Wed",
            "Thu",
            "Fri"});
            this.comboBox1.Location = new System.Drawing.Point(10, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(246, 24);
            this.comboBox1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 265);
            this.Controls.Add(this.comboBox1);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.ComboBox comboBox1;


    }
}


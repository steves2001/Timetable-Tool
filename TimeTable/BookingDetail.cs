using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTable
{
    public partial class BookingDetail : Form
    {

        public BookingDetail()
        {
            InitializeComponent();
            this.lesson.AutoCompleteCustomSource = RoomBookings.autocompleteLessons;
            this.lesson.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.lesson.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.room.Items.Clear();
            foreach (string r in RoomBookings.roomList)
                this.room.Items.Add(r);

            this.level.Items.Clear();
            foreach (string r in RoomBookings.levelList)
                this.level.Items.Add(r);

            this.year.Items.Clear();
            foreach (string r in RoomBookings.yearList)
                this.year.Items.Add(r);

            this.group.Items.Clear();
            foreach (string r in RoomBookings.groupList)
                this.group.Items.Add(r);

            this.staff.Items.Clear();
            foreach (string r in RoomBookings.staffList)
                this.staff.Items.Add(r);
        }

        public booking getBooking()
        {
            // booking("Lesson", "Day", "Start Hour", "Start Min", "End Hour", "End Min", "Year", "Level", "Group", "Room");
            return new booking(lesson.Text,
                 day.SelectedItem.ToString(),
                 startHour.Value.ToString(),
                 startMinute.Value.ToString(),
                 endHour.Value.ToString(),
                 endMinute.Value.ToString(),
                 year.Text,
                 level.Text,
                 group.Text,
                 room.Text,
                 staff.Text,
                 room.Text,
                 infill.Checked);
        }

        public void setBooking(booking b)
        {
            lesson.Text = b.lesson;
            day.SelectedIndex = day.FindStringExact( b.day);
            
            startHour.Value = (int)b.startTime;
            startMinute.Value = (int)((b.startTime - (float)startHour.Value) * 60f);
            endHour.Value = (int)b.endTime;
            endMinute.Value = (int)((b.endTime - (float)endHour.Value) * 60f);
            year.SelectedIndex = year.FindStringExact(b.year);
            level.SelectedIndex = level.FindStringExact(b.level);
            group.SelectedIndex = group.FindStringExact(b.group);
            room.SelectedIndex = room.FindStringExact(b.room);
            infill.Checked = b.infill;
            staff.SelectedIndex = staff.FindStringExact(b.staff);
        }

        public void enableDelete()
        { delete.Visible = true; }

        private bool validateForm()
        {
            bool validates = false;

            validates = lesson.Text != ""
                && day.SelectedItem != null
                && startHour.Value + startMinute.Value / 60 < endHour.Value + endMinute.Value / 60
                && year.SelectedItem != null
                && level.SelectedItem != null
                && group.SelectedItem != null
                && room.SelectedItem != null
                && staff.SelectedItem != null;

            return validates;
        }

        private void BookingDetail_Load(object sender, EventArgs e)
        {
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                if (MessageBox.Show("The form has not been completed correctly, do you wish to edit it further?", "Error", MessageBoxButtons.YesNo)
                    == System.Windows.Forms.DialogResult.No)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }



        private void endMinute_ValueChanged(object sender, EventArgs e)
        {
            if (endHour.Value == 21)
            { endMinute.Value = 0; }
        }

        private void startHour_ValueChanged(object sender, EventArgs e)
        {
            if (endHour.Value < startHour.Value)
            { endHour.Value = startHour.Value + 1; }
        }

        private void endHour_ValueChanged(object sender, EventArgs e)
        {
            if (startHour.Value > endHour.Value) { startHour.Value = endHour.Value; }
            if (endHour.Value == 21) { endMinute.Value = 0; }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            delete.Visible = false;
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }
    }
}

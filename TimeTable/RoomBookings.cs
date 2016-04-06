using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using Microsoft.VisualBasic.PowerPacks.Printing;
using System.IO;
using System.Xml.Serialization;

namespace TimeTable
{
    // Properties.Settings.Default.Save(); // To save the properties

    public partial class RoomBookings : Form
    {
        public static List<string> roomList = Properties.Settings.Default["roomList"].ToString().Split(',').ToList();// new List<string>() { "B112", "B114", "B115A", "B115B", "B116", "B118", "B126", "DLCA", "DLCB", "C201", "Other" };
        public static List<string> staffList = Properties.Settings.Default["staffList"].ToString().Split(',').ToList();//new List<string>() { "JJ", "NM", "MM", "DR", "JR", "JS", "BS", "SS", "T1", "T2" };
        public static List<string> levelList = Properties.Settings.Default["levelList"].ToString().Split(',').ToList();//new List<string>() { "L1", "L2", "L3", "L4", "P4" };
        public static List<string> dayList = new List<string>() { "Mon", "Tue", "Wed", "Thu", "Fri" };
        public static List<Color> levelColourList = new List<Color>() 
        { 
        Color.LightGreen, Color.MediumAquamarine, Color.LimeGreen,
        Color.CornflowerBlue,Color.Yellow
        };
        public static List<string> yearList = Properties.Settings.Default["yearList"].ToString().Split(',').ToList();//new List<string>() { "1", "2", "3" };
        public static List<string> groupList = Properties.Settings.Default["groupList"].ToString().Split(',').ToList();//new List<string>() { "A", "B", "C" };
        SortedDictionary<string, string> comboSource = new SortedDictionary<string, string>();

        public static List<booking> bookingList = new List<booking>();
        public static AutoCompleteStringCollection autocompleteLessons = new AutoCompleteStringCollection();  // Used to set the autocomplete in lesson desc.
        private ShapeContainer timeTable = new ShapeContainer();
        public Label title = new Label();
        private int offsetX = 20;
        private int offsetY = 0;
        private float scaleX = 1f;
        private float scaleY = 1f;
        public static float virtScaleX = 1000f;
        public static float virtScaleY = 800f;
        private float truncX = 30f;
        private float truncY = 30f;
        private static int oneHour = 4;
        private static int numDivisions = (21 - 9) * oneHour;
        private static int xPixelDiv;
        private static int yPixelDiv;
        private List<LineShape> lines = new List<LineShape>();
        private RectangleShape border;
        private BookingDetail lesson = new BookingDetail();
        private static string currentRoom = roomList.First<string>();
        private static string currentStaff = staffList.First<string>();
        private static string currentGroup = levelList.First<string>() + yearList.First<string>() + groupList.First<string>();
        private static string lastItem = currentRoom;

        public RoomBookings()
        {
            InitializeComponent();
            int bWidth;
            this.Width = 800;
            this.Height = 600;
            xPixelDiv = dx((int)virtScaleX / (numDivisions + 4));
            yPixelDiv = dy((int)virtScaleY / 7); add.Top = this.Height - 80;
            int x = 15; int y = this.Height - 105;
            foreach (Button b in this.Controls.OfType<Button>())
            {

                b.Height = 25;
                b.Width = 75;
                b.Left = x;
                b.Top = y + 30;
                x += 75;
            }

            title.Name = "labelTitle";
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Width = 500;
            title.Height = 40;
            title.Left = 150;
            title.Top = 15;
            title.Font = new Font("Arial", 14);
            title.Text = "Time Tabler V3.0 - Copyright Stephen Smith";
            this.timeTable.Controls.Add(title);

            ComboBox c = new ComboBox();

            foreach (string l in levelList)
                foreach (string yr in yearList)
                    foreach (string g in groupList)
                        comboSource.Add(l + yr + g, "Level " + l + " Year " + yr + " Group " + g);
            c.Name = "courseCombo";           
            c.DataSource = new BindingSource(comboSource, null);
            c.DisplayMember = "Value";
            c.ValueMember = "Key";
            c.Font = new Font("Arial", 10);
            c.Height = 25;
            c.Width = 180;
            c.Top = y + 30;
            c.Left = x;
            c.DropDownStyle = ComboBoxStyle.DropDownList;
            c.SelectedIndexChanged += new System.EventHandler(this.selectGroup);
            this.Controls.Add(c);


            x = 15;
            bWidth = (this.Width - (x * 2 + offsetX)) / roomList.Count();
            foreach (string r in roomList)
            {
                Button b = new Button();
                b.Text = r;
                b.Name = "btn" + r;
                b.Height = 25;
                b.Width = bWidth;
                b.Top = y;
                b.Left = x;
                x = x + bWidth;
                b.Click += new System.EventHandler(this.selectRoom);
                this.Controls.Add(b);
            }
            x = 15; y -= 30;
            bWidth = (this.Width - (x * 2 + offsetX)) / staffList.Count();
            foreach (string r in staffList)
            {
                Button b = new Button();
                b.Text = r;
                b.Name = "btn" + r;
                b.Height = 25;
                b.Width = bWidth;
                b.Top = y;
                b.Left = x;
                x = x + bWidth;
                b.Click += new System.EventHandler(this.selectStaff);
                this.Controls.Add(b);
            }
            // Load a text file containing the auto complete entries
            try {
                autocompleteLessons.AddRange(File.ReadAllLines("Units.txt"));
            }
            catch { autocompleteLessons.AddRange(new string[] {"IT", "GT" }); }

            initTimeTable();
            this.Click += new System.EventHandler(this.formclicked);

        }

        private void highlightActiveButton(string buttonText)
        {
            clearButtonColours();

            foreach (Button b in this.Controls.OfType<Button>())
                if (b.Text == buttonText)
                    b.BackColor = Color.SlateBlue;
        }

        private void clearButtonColours()
        {
            foreach (Button b in this.Controls.OfType<Button>())
                b.BackColor = this.BackColor;
        }

        private int dx(int x) { return (int)(scaleX * (float)x); }

        private int dy(int y) { return (int)(scaleY * (float)y); }

        private int px(int x) { return offsetX + (int)(scaleX * ((float)x + truncX / 2f)); }

        private int py(int y) { return offsetY + (int)(scaleY * ((float)y + truncY / 2f)); }

        private void locateRectangle(int x, int y, int width, int height, ref RectangleShape r)
        {
            r.Size = new System.Drawing.Size(dx(width), dy(height));
            r.Location = new System.Drawing.Point(px(x), py(y));
        }

        private void locateRectangle(int x, int y, int width, int height, ref TextRectangle r)
        {
            r.Size = new System.Drawing.Size(dx(width), dy(height));
            r.Location = new System.Drawing.Point(px(x), py(y));
        }

        private void initTimeTable()
        {
            timeTable.Parent = this;

            scaleX = (float)(timeTable.Width - (int)truncX) / virtScaleX;
            scaleY = (float)(timeTable.Height - (int)truncY - 50) / virtScaleY;

            border = new RectangleShape(timeTable);
            locateRectangle(0, 0, 1000, 700, ref border);
            border.Left = border.Left - offsetX;
            border.Top = border.Top - offsetY;
            border.CornerRadius = 2;
            for (int y = 1; y < 7; y++)
            {
                LineShape l = new LineShape(timeTable);
                l.X1 = px((int)(0.25f * ((float)xPixelDiv * 4f)));
                l.X2 = px((int)(12.25f * ((float)xPixelDiv * 4f)));
                l.Y2 = l.Y1 = py((y) * yPixelDiv);

                lines.Add(l);

            }

            for (int x = 9; x <= 21; x++)
            {
                LineShape l = new LineShape(timeTable);
                l.Y1 = py(yPixelDiv);
                l.Y2 = py(6 * yPixelDiv);
                l.X2 = l.X1 = px((int)(((float)x - 8.75f) * ((float)xPixelDiv * 4f)));

                lines.Add(l);
            }

            for (int x = 9; x <= 21; x++)
            {
                Label label = new Label() { Text = x.ToString(), TextAlign = ContentAlignment.MiddleCenter };
                label.Location = new Point(px((int)(((float)x - 8.9f) * ((float)xPixelDiv * 4f))), py((int)(0.75f * (float)yPixelDiv)));
                label.Size = new Size(20, 14);
                label.BackColor = Color.White;
                this.timeTable.Controls.Add(label);
            }



            for (int y = 1; y < 6; y++)
            {
                Label label = new Label() { Text = dayList[y - 1], TextAlign = ContentAlignment.MiddleLeft };
                label.Location = new Point(px(1) - offsetX, py(y * yPixelDiv + yPixelDiv / 2 - 7));
                label.Size = new Size(30, 14);
                label.BackColor = Color.White;
                this.timeTable.Controls.Add(label);
            }



            highlightActiveButton(currentRoom);

        }

        void displayLessons(string s)
        {
            float totalHours = 0f;
            List<StartEnd> startEnd = new List<StartEnd>();
            int index = -1;
            bool first = true;
            reIndexBookings();
            foreach (booking b in bookingList)
            {
                index = -1;
                if (b.room == s || b.staff == s || b.level + b.year + b.group == s)
                {
                    if (!first) index = startEnd.FindIndex(
                                    delegate(StartEnd se)
                                    {
                                        return se.start == b.startTime && se.end == b.endTime && se.row == b.row && se.id != b.id;
                                    });

                    startEnd.Add(new StartEnd(b.id, b.startTime, b.endTime, b.row)); first = false;

                }
                if (index == -1)
                    if ((b.room == s) || b.staff == s || b.level + b.year + b.group == s)
                    {

                        b.rect.Parent = timeTable;
                        b.rect.BringToFront();
                        totalHours += (b.endTime - 9f) - (b.startTime - 9f);
                        if (b.room == s) title.Text = "Time Table Room : " + s;
                        if (b.staff == s) title.Text = "Time Table Staff : " + s;
                        if (b.level + b.year + b.group == s) title.Text = "Time Table Group : " + "Level " + b.level + " Year " + b.year + " Group " + b.group;
                    }
                    else
                        b.rect.Parent = null;
            }
            highlightActiveButton(s);
            this.title.Text = this.title.Text + " " + totalHours.ToString() + " hours.";

        }

        private void updateCombo()
        {
            ComboBox c = (ComboBox)this.Controls["courseCombo"];

            comboSource.Clear();
            
            foreach (booking b in bookingList)
                if (!comboSource.ContainsKey(b.level + b.year + b.group))
                comboSource.Add(b.level + b.year + b.group, "Level " + b.level + " Year " + b.year + " Group " + b.group);
            
            c.SelectedIndexChanged -= new System.EventHandler(this.selectGroup);
            c.DataSource = new BindingSource(comboSource, null);
            c.SelectedIndexChanged += new System.EventHandler(this.selectGroup);
        }

        private bool checkForClash(booking newBooking, int index, out bool infill)
        {
            bool clash = false;
            infill = false;
            int clashIndex = -1;

            clashIndex = groupClash(newBooking, index);
            if(clashIndex != -1)
            {
                MessageBox.Show("The group is already booked for a lesson at that time " + bookingList[clashIndex].lesson + " in " + bookingList[clashIndex].room,"Group Clash", MessageBoxButtons.OK);
                return true;
            }
            
            clashIndex = roomClash(newBooking, index);
            if(clashIndex != -1)
            {
                if (bookingList[clashIndex].startTime == newBooking.startTime && bookingList[clashIndex].endTime == newBooking.endTime  && bookingList[clashIndex].staff == newBooking.staff)
                {
                    if (
                        MessageBox.Show("Booking matches group " + bookingList[clashIndex].level 
                        + " " + bookingList[clashIndex].year + " " + bookingList[clashIndex].group
                        + " with staff member " + bookingList[clashIndex].staff
                        + "\nDo you want to merge with this group?  Select No to manually correct the problem.", "Clash", MessageBoxButtons.YesNo) 
                        == DialogResult.Yes
                        )
                    {
                        bookingList[clashIndex].rect.Parent = null;
                        bookingList[clashIndex].rect.Text = bookingList[clashIndex].lesson + "\nMulti Group " + "\n" + bookingList[clashIndex].staff + " [" + bookingList[clashIndex].room + "]";
                        bookingList[clashIndex].infill = true;
                        infill = true;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            
            clashIndex = staffClash(newBooking, index);
            if (clashIndex != -1)
            {
                MessageBox.Show("Staff member " + bookingList[clashIndex].staff +" is already booked for a lesson at that time "
                    + bookingList[clashIndex].lesson + " in " + bookingList[clashIndex].room, "Group Clash", MessageBoxButtons.OK);
                return true;
            }

            return clash;
        }

        private int staffClash(booking newBooking, int index)
        {
            int foundIndex = 0;
            bool clash = false;

            if (newBooking.staff == "NS") return -1;  // NS = not staffed so don't check for a clash

            foreach (booking b in bookingList)
            {
                if (index == -1 || index != b.id)
                    if (b.staff == newBooking.staff)
                        if (b.day == newBooking.day)
                        {
                            if (b.startTime >= newBooking.startTime && b.startTime < newBooking.endTime)
                            { clash = true; break; }
                            if (b.endTime > newBooking.startTime && b.endTime <= newBooking.endTime)
                            { clash = true; break; }
                            if (b.startTime == newBooking.startTime && b.endTime == newBooking.endTime)
                            { clash = true; break; }
                        }

                foundIndex++;
            }

            if (clash) return foundIndex; else return -1;
        }

        private int roomClash(booking newBooking, int index)
        {
            int foundIndex = 0;
            bool clash = false;

            foreach (booking b in bookingList)
            {

                if (index == -1 || index != b.id)
                    if (b.room == newBooking.room)
                        if (b.day == newBooking.day)
                        {
                            if (b.startTime >= newBooking.startTime && b.startTime < newBooking.endTime)
                            { clash = true; break; }
                            if (b.endTime > newBooking.startTime && b.endTime <= newBooking.endTime)
                            { clash = true; break; }
                            if (b.startTime == newBooking.startTime && b.endTime == newBooking.endTime)
                            { clash = true; break; }
                        }

                foundIndex++;
            }

            if (clash) return foundIndex; else return -1;
        }

        private int groupClash(booking newBooking, int index)
        {
            int foundIndex = 0;
            bool clash = false;

            foreach (booking b in bookingList)
            {

                if (index == -1 || index != b.id)
                    if (b.day == newBooking.day)
                        if (b.level + b.year + b.group == newBooking.level + newBooking.year + newBooking.group)
                        {
                            if (b.startTime >= newBooking.startTime && b.startTime < newBooking.endTime)
                            { clash = true; break; }
                            if (b.endTime > newBooking.startTime && b.endTime <= newBooking.endTime)
                            { clash = true; break; }
                            if (b.startTime == newBooking.startTime && b.endTime == newBooking.endTime)
                            { clash = true; break; }
                        }

                foundIndex++;
            }

            if (clash) return foundIndex; else return -1;
        }

        public void formclicked(object sender, EventArgs e)
        {
            if (booking.selected != -1)
            {
                int index = bookingList.FindIndex(
                               delegate(booking sb)
                               {
                                   return sb.id == booking.selected;
                               });

                booking b = bookingList[index];

                lesson.setBooking(bookingList[booking.selected]);
                lesson.enableDelete();

                DialogResult r = lesson.ShowDialog();

                if (r == DialogResult.No)
                {
                    int index2 = bookingList.FindIndex(
                       delegate(booking sb)
                       {
                           return sb.startTime == b.startTime
                               && sb.endTime == b.endTime
                               && sb.row == b.row
                               && sb.staff == b.staff
                               && sb.room == sb.room
                               && sb.id != b.id;
                       });

                    if (index2 == -1)
                    {
                        bookingList[index].rect.Dispose();
                        bookingList.RemoveAt(index);
                    }
                    else
                    {
                        if (MessageBox.Show("The lesson you are trying to delete is linked to another do you want to delete both?", "Linked Lesson", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            bookingList[index2].rect.Dispose();
                            bookingList.RemoveAt(index2);
                            index = bookingList.FindIndex(
                                delegate(booking sb)
                                {
                                    return sb.id == b.id;
                                });
                            bookingList[index].rect.Dispose();
                            bookingList.RemoveAt(index);
                        }
                        else
                        {
                            bookingList[index2].infill = false;
                            bookingList[index2].rect.Text = bookingList[index2].lesson + "\n" + bookingList[index2].level + "-Yr " + bookingList[index2].year + "\n Group " + bookingList[index2].group + "\n" + bookingList[index2].staff + " [" + bookingList[index2].room + "]";

                            bookingList[index].rect.Dispose();
                            bookingList.RemoveAt(index);
                        }
                    }
                    booking.selected = -1;

                    }
                if (r == DialogResult.OK)
                {
                    update(booking.selected);
                    booking.selected = -1;
                }
                displayLessons(lastItem);
                updateCombo();
            }
        }

        private void update(int index)
        {
            bool infill;
            booking l = lesson.getBooking();
            if (!checkForClash(l, bookingList[index].id, out infill))
            {
                // Add some clever scaling and positioning here!!!
                bookingList[index].rect.Width = dx((int)((float)xPixelDiv * (l.endTime - l.startTime)) * 4);
                bookingList[index].rect.Height = dy(yPixelDiv);
                bookingList[index].rect.Top = py((int)(yPixelDiv * ((float)l.row + 1f)));
                bookingList[index].rect.Left = px((int)((l.startTime - 8.75f) * ((float)xPixelDiv * 4f)));
                bookingList[index].rect.FillColor = l.rect.FillColor;
                bookingList[index].rect.Text = l.rect.Text;
                bookingList[index].lesson = l.lesson;
                bookingList[index].group = l.group;
                bookingList[index].level = l.level;
                bookingList[index].room = l.room;
                bookingList[index].row = l.row;
                bookingList[index].startTime = l.startTime;
                bookingList[index].endTime = l.endTime;
                bookingList[index].year = l.year;
                bookingList[index].staff = l.staff;
                bookingList[index].day = l.day;
                bookingList[index].infillRoom = l.infillRoom;
                bookingList[index].infill = infill;
                //Am i leaving a rect object in memory?
                lastItem = currentRoom = l.room;
                displayLessons(lastItem);
                updateCombo();
            }

        }

        private void add_Click(object sender, EventArgs e)
        {
            bool infill;
            if (lesson.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                booking l = lesson.getBooking();
                if (!checkForClash(l, -1, out infill))
                {
                    // Add some clever scaling and positioning here!!!
                    l.rect.Width = dx((int)((float)xPixelDiv * (l.endTime - l.startTime)) * 4);
                    l.rect.Height = dy(yPixelDiv);
                    l.rect.Top = py((int)(yPixelDiv * ((float)l.row + 1f)));
                    l.rect.Left = px((int)((l.startTime - 8.75f) * ((float)xPixelDiv * 4f)));
                    l.infill = infill;
                    if (infill) l.rect.Text = l.lesson + "\nMulti Group " + "\n" + l.staff + " [" + l.room + "]";
                    bookingList.Add(l);
                    lastItem = currentRoom = l.room;
                    displayLessons(lastItem);
                    updateCombo();
                }
            }
        }

        private void selectRoom(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            lastItem = currentRoom = b.Text;
            title.Text = "Time Table Room : " + b.Text;
            displayLessons(lastItem);
        }

        private void selectStaff(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            lastItem = currentStaff = b.Text;
            title.Text = "Time Table Staff : " + b.Text;
            displayLessons(lastItem);
        }

        private void selectGroup(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            lastItem = currentGroup = c.SelectedValue.ToString();
            title.Text = "Time Table Room : " + currentGroup;
            displayLessons(lastItem);
        }

        public void readRoomBookings()
        {
            DialogResult r = openFile.ShowDialog();

            if (r == DialogResult.OK)
            {

                for (int index = 0; index < bookingList.Count; index++)
                    bookingList[index].rect.Dispose();

                bookingList.Clear();

                bookingList = ReadFromXmlFile<List<booking>>(openFile.FileName);
                booking.selected = -1;
                booking.idCounter = 0;
                foreach (booking b in bookingList)
                {
                    b.id = booking.idCounter++;  // Reindex the id's
                    b.setupRectangle();
                    b.rect.Width = dx((int)((float)xPixelDiv * (b.endTime - b.startTime)) * 4);
                    b.rect.Height = dy(yPixelDiv);
                    b.rect.Top = py((int)(yPixelDiv * ((float)b.row + 1f)));
                    b.rect.Left = px((int)((b.startTime - 8.75f) * ((float)xPixelDiv * 4f)));
                }
                lastItem = currentRoom = roomList.First<string>();
                displayLessons(lastItem);
                updateCombo();
            }
        }

        public void reIndexBookings()
        {
            booking.idCounter = 0;
            foreach (booking b in bookingList)
                b.id = booking.idCounter++;  // Reindex the id's
        }

        public void writeRoomBookings()
        {
            saveFile.Filter = "XML Files|*.xml|All Files|*.*";
            DialogResult r = saveFile.ShowDialog();

            if (r == DialogResult.OK)
            {
                foreach (booking b in bookingList)
                {
                    b.rect.Parent = null;
                }
                WriteToXmlFile<List<booking>>(saveFile.FileName, bookingList, false);
                displayLessons(lastItem);
            }
        }

        /// <summary>
        /// Writes the given object instance to an XML file.
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [XmlIgnore] attribute.</para>
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>
        /// Reads an object instance from an XML file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the XML file.</returns>
        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            readRoomBookings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            writeRoomBookings();
        }

        private void saveImage_Click(object sender, EventArgs e)
        {
            saveFile.Filter = "PNG Files|*.png|All Files|*.*";
            DialogResult r = saveFile.ShowDialog();

            if (r == DialogResult.OK)
            {
                int dimX = border.Width + offsetX;
                int dimY = border.Height + offsetY + (int)truncY;

                Bitmap bm = new Bitmap(dimX, dimY);
                timeTable.DrawToBitmap(bm, new Rectangle(0, 0, dimX, dimY));
                bm.Save(saveFile.FileName, System.Drawing.Imaging.ImageFormat.Png);

            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            Printout p = new Printout(this);

            p.ShowDialog();
        }
    }

}

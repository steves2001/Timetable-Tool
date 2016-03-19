using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.PowerPacks;
using System.Windows.Forms;

namespace TimeTable
{
    public class booking
    {
        public static  int idCounter = 0;
        public static int selected = -1;
        public int     id   { get; set; }
        public string  lesson { get; set; }
        public string  day { get; set; }
        public float   startTime { get; set; }
        public float   endTime { get; set; }
        public string  year { get; set; }
        public string  level { get; set; }
        public string  group { get; set; }
        public string  room { get; set; }
        public string infillRoom { get; set; }
        public bool infill { get; set; }
        public string staff { get; set; }
        public int     row = 0;
        
        [System.Xml.Serialization.XmlIgnore]
        public TextRectangle rect;

        public booking()
        {
            lesson = "";
            day = "";
            startTime = 9f;
            endTime = 10f;
            year = "";
            level = "";
            group = "";
            room = "";
            infillRoom = "";
            infill = false;
            staff = "";
            rect = new TextRectangle();
            id = idCounter;
            idCounter++;

        }
        
        public booking(string les, string d, string sh, string sm, string eh, string em, string y, string lev, string g, string r, string st, string i, bool ifi) 
        {
            lesson = les;
            day = d;
            startTime = timeConvert(sh, sm);
            endTime = timeConvert(eh, em);
            year = y;
            level = lev;
            group = g;
            room = r;
            staff = st;
            infill = ifi;
            if (infill)
                infillRoom = i;
            else
                infillRoom = "";
            id = idCounter++;

            switch(day)
            {
                case "Mon": row = 0; break;
                case "Tue": row = 1; break;
                case "Wed": row = 2; break;
                case "Thu": row = 3; break;
                case "Fri": row = 4; break;
            }

            rect = new TextRectangle();
            setupRectangle();
        }

        public void setupRectangle()
        {
            //width = startTime - endTime;
            if(infill)
                rect.Text = lesson + "\nMulti Group " + "\n" + staff + " [" + room + "]";
            else
                rect.Text = lesson + "\n" + level + "-Yr " + year + "\n Group " + group + "\n" + staff + " [" + room + "]" ;

            rect.CornerRadius = 5;
            rect.FillStyle = FillStyle.Solid;
            rect.FillColor = RoomBookings.levelColourList[RoomBookings.levelList.IndexOf(level)];
            rect.Click += new System.EventHandler(this.selectRectangle);
        }

        private void selectRectangle(object sender, EventArgs e)
        {
            selected = id;
            RoomBookings f = (RoomBookings)rect.FindForm();
            f.formclicked(sender, e);
        }

        public float timeConvert(string h, string m)
        {
            return Convert.ToSingle(h) + Convert.ToSingle(m)/60;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing;


namespace TimeTable
{
    public class TextRectangle : RectangleShape
    {
        public string Text = "";
        public Font drawFont = new Font("Arial", 8);
        public TextRectangle()
            : base()
        { }

        public TextRectangle(ShapeContainer parent)
            : base(parent)
        { }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e); 
            
            StringFormat myStringFormat = new StringFormat();
            myStringFormat.Alignment = StringAlignment.Center;
            myStringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(Text, drawFont, Brushes.Black, this.Bounds, myStringFormat);
            //e.Graphics.DrawString("Hi");
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using Microsoft.VisualBasic.PowerPacks.Printing;
using System.Drawing.Printing;


namespace TimeTable
{
    public partial class Printout : Form
    {
        private static List<TextRectangle> bookingList = new List<TextRectangle>();
        private PrintDocument printDoc = new PrintDocument();
        private ShapeContainer timeTable = new ShapeContainer();
        Label title = new Label();
        private int offsetX = 20;
        private int offsetY = 0;
        private float scaleX = 1f;
        private float scaleY = 1f;
        public static float virtScaleX = 1000f;
        public static float virtScaleY = 800f;
        private float truncX = 10f;
        private float truncY = 30f;
        private static int oneHour = 4;
        private static int numDivisions = (21 - 9) * oneHour;
        private static int xPixelDiv;
        private static int yPixelDiv;
        private List<LineShape> lines = new List<LineShape>();
        
        private RoomBookings callingForm;

        public Printout(RoomBookings caller)
        {
            callingForm = caller;
            InitializeComponent();
            this.Width = 1280;
            this.Height = 720;

            xPixelDiv = dx((int)virtScaleX / (numDivisions + 4));
            yPixelDiv = dy((int)virtScaleY / 7);

            initTimeTable();

            bookingList.Clear();
            
            foreach(booking l in RoomBookings.bookingList)
            {
                if (l.rect.Parent != null)
                {
                    TextRectangle t = new TextRectangle(timeTable);
                    t.Width = dx((int)((float)xPixelDiv * (l.endTime - l.startTime)) * 4);
                    t.Height = dy(yPixelDiv);
                    t.Top = py((int)(yPixelDiv * ((float)l.row + 1f)));
                    t.Left = px((int)((l.startTime - 8.75f) * ((float)xPixelDiv * 4f)));
                    t.Text = l.rect.Text;
                    t.FillColor = Color.AliceBlue;
                    t.CornerRadius = 5;
                    t.FillStyle = FillStyle.Solid;
                    //t.drawFont = new Font("Arial", 10);
                    t.BringToFront();
                    bookingList.Add(t);
                }
            }

            int x = 15; int y = this.Height - 105;
            foreach (Button b in this.Controls.OfType<Button>())
            {

                b.Height = 25;
                b.Width = 75;
                b.Left = x;
                b.Top = y + 30;
                x += 75;
            }

            //btnPrint.Width = 75;
            //btnPrint.Height = 25;
            //btnPrint.Left = (this.Width - btnPrint.Width) / 2;
            //btnPrint.Top = this.ClientSize.Height - 40;

            //pageSD.Document = printDoc;
            //pageSD.AllowPrinter = true;
            //pageSD.EnableMetric = true;
            //pageSD.PageSettings = new PageSettings();
            //pageSD.PrinterSettings = new PrinterSettings();            
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.DefaultPageSettings.Margins.Left = 30;
            printDoc.DefaultPageSettings.Margins.Right = 30;
            printDoc.DefaultPageSettings.Margins.Top = 30;
            printDoc.DefaultPageSettings.Margins.Bottom = 30;

        
        }

        private void print()
        {
            btnPrint.Visible = false;
            PrintForm pf = new PrintForm();
            pf.Form = this;
            pf.PrinterSettings.DefaultPageSettings.Landscape = true;
            pf.PrinterSettings.DefaultPageSettings.Margins.Left = 30;
            pf.PrinterSettings.DefaultPageSettings.Margins.Right = 30;
            pf.PrinterSettings.DefaultPageSettings.Margins.Top = 30;
            pf.PrinterSettings.DefaultPageSettings.Margins.Bottom = 30;
            pf.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview;
            pf.Print();
            btnPrint.Visible = true;
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

            for (int y = 1; y < 7; y++)
            {
                LineShape l = new LineShape(timeTable);
                l.X1 = px((int)(0.25f * ((float)xPixelDiv * 4f)));
                l.X2 = px((int)(12.25f * ((float)xPixelDiv * 4f)));
                l.Y2 = l.Y1 = py((y) * yPixelDiv);
                l.BorderWidth = 2;
                lines.Add(l);

            }

            for (int x = 9; x <= 21; x++)
            {
                LineShape l = new LineShape(timeTable);
                l.Y1 = py(yPixelDiv);
                l.Y2 = py(6 * yPixelDiv);
                l.X2 = l.X1 = px((int)(((float)x - 8.75f) * ((float)xPixelDiv * 4f)));
                l.BorderWidth = 2;
                lines.Add(l);
            }

            for (int x = 9; x <= 21; x++)
            {
                Label label = new Label() { Text = x.ToString(), TextAlign = ContentAlignment.MiddleCenter };
                label.Location = new Point(px((int)(((float)x - 8.9f) * ((float)xPixelDiv * 4f))), py((int)(0.75f * (float)yPixelDiv)));
                label.Size = new Size(30, 14);
                label.BackColor = Color.White;
                label.Font = new Font("Arial", 10);
                this.timeTable.Controls.Add(label);
            }

            for (int y = 1; y < 6; y++)
            {
                Label label = new Label() { Text = RoomBookings.dayList[y - 1], TextAlign = ContentAlignment.MiddleLeft };
                label.Location = new Point(px(3) - offsetX, py(y * yPixelDiv + yPixelDiv / 2 - 7));
                label.Size = new Size(38, 14);
                label.BackColor = Color.White;
                label.Font = new Font("Arial", 10);
                this.timeTable.Controls.Add(label);
            }

            title.Name = "labelTitle";
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Width = 500;
            title.Height = 40;
            title.Left = (timeTable.Width - title.Width) / 2;
            title.Top = 30;
            title.Font = new Font("Arial", 14);
            title.BackColor = Color.White;
            title.Text = callingForm.title.Text;
            this.timeTable.Controls.Add(title);

            //border = new RectangleShape(timeTable);
            //locateRectangle(0, 0, 900, 700, ref border);
            //border.Left = border.Left - offsetX;
            //border.Top = border.Top - offsetY;
            //border.CornerRadius = 2;
            //border.FillColor = Color.White;
            //border.FillStyle = FillStyle.Solid;
            //border.BorderWidth = 2;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDoc.PrintPage += new PrintPageEventHandler(this.printPage);
            printDoc.Print();
        }

        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            pageSD.Document = printDoc;
        
            pageSD.AllowPrinter = true;
            pageSD.EnableMetric = true;
            if(pageSD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pageSD.PageSettings = new PageSettings();
                pageSD.PrinterSettings = new PrinterSettings();
            }
        }

        private void printPage(Object sender, PrintPageEventArgs e)
        {
            printToGraphics(e.Graphics, e.MarginBounds);
        }

        private void printToGraphics(Graphics g, Rectangle r)
        {
            Bitmap b = new Bitmap(timeTable.Width, timeTable.Height);
            timeTable.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));
            double xScale = (double)b.Width / (double)r.Width;
            double yScale = (double)b.Height / (double)r.Height;
            Rectangle target = new Rectangle(r.Left, r.Top, r.Width, r.Height);
            if (xScale < yScale)
            { target.Width = (int)(xScale * target.Width / yScale); } 
            else
            { target.Height = (int)(yScale * target.Height / xScale); }
            g.PageUnit = GraphicsUnit.Display;
            g.DrawImage(b, target);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPD.Document = printDoc;
            printDoc.PrintPage += new PrintPageEventHandler(this.printPage);
            printPD.ShowDialog();
        }
    }
}

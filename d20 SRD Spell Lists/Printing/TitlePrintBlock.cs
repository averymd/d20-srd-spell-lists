using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using d20_SRD_Spell_Lists.Models;
using System.Windows.Forms;

namespace Printing.DataGridViewPrint.Tools
{
    /// <author>Blaise Braye</author>
    /// <summary>
    /// Reusable Sample of a title to print on first printed sheet
    /// </summary>
    public class TitlePrintBlock : PrintBlock
    {

        public String Title { get; set; }
        public System.Windows.Forms.TableLayoutPanel DCs { get; set; }
        public String CharName { get; set; }
        public String CharClass { get; set; }
        public String CharAttrName { get; set; }
        public String CharAttr { get; set; }
        public String CharAttrMod { get; set; }
        public Color ForeColor { get; set; }
        public Font Font { get; set; }
        public Font BodyFont { get; set; }
        public StringFormat Format { get; set; }
        public StringFormat BodyFormat { get; set; }
        private SizeF titleSize;
        private SizeF nameSize;
        
        public TitlePrintBlock()
        {
            Format = new StringFormat();
            Format.LineAlignment = StringAlignment.Near;
            Format.Alignment = StringAlignment.Center;
            Format.Trimming = StringTrimming.Word;
            Format.FormatFlags = StringFormatFlags.LineLimit;
            this.Font = new Font("Tahoma", 14, FontStyle.Bold);
            this.Title = "this is a sample title";
            this.BodyFont = new Font("Times New Roman", 12, FontStyle.Regular);
            this.ForeColor = Color.Black;
            BodyFormat = new StringFormat();
            BodyFormat.LineAlignment = StringAlignment.Center;
            BodyFormat.Alignment = StringAlignment.Near;
            BodyFormat.Trimming = StringTrimming.Word;
            BodyFormat.FormatFlags = StringFormatFlags.LineLimit;
        }

        public override SizeF GetSize(Graphics g, DocumentMetrics metrics)
        {
            Title += " \u2014 " + CharName + "\r\n";
            titleSize = g.MeasureString(Title, Font, metrics.PrintAbleWidth, Format);
            nameSize = g.MeasureString(Title, BodyFont, metrics.PrintAbleWidth, BodyFormat);
            nameSize.Height += 5;
            SizeF tableSize = DCs.DisplayRectangle.Size;
            tableSize.Height += 100;

            return new SizeF(metrics.PrintAbleWidth, titleSize.Height + tableSize.Height);
        }

        public override void Draw(Graphics g, Dictionary<CodeEnum, string> codes)
        {
            g.DrawString(Title, Font, new SolidBrush(ForeColor), Rectangle, Format);
            float midWidth = Rectangle.Width / 2;
            float thirdWidth = Rectangle.Width / 3;
            float textPadding = 40;
            float tablePadding = 20;
            g.DrawString(CharName + ", " + CharClass + "\r\n", BodyFont, new SolidBrush(ForeColor), thirdWidth, Rectangle.Y + titleSize.Height + textPadding, BodyFormat);
            g.DrawString(CharAttrName + ": " + CharAttr + " | " + CharAttrMod, BodyFont, new SolidBrush(ForeColor), thirdWidth, Rectangle.Y + titleSize.Height + nameSize.Height + textPadding, BodyFormat);
            using (Bitmap printImage = new Bitmap(DCs.Width, DCs.Height)) {
                //Draw the TableLayoutPanel control to the temporary bitmap image
                Color oldBkgd = DCs.BackColor;
                DCs.BackColor = Color.White;
                DCs.DrawToBitmap(printImage, new Rectangle(0, 0, printImage.Width, printImage.Height));
                g.DrawImage(printImage, new PointF(midWidth, Rectangle.Y + titleSize.Height + tablePadding));
                DCs.BackColor = oldBkgd;
            }
        }

    }
}

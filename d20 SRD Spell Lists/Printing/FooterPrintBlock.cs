using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Printing.DataGridViewPrint.Tools {
    public class FooterPrintBlock : PrintBlock {
        public string Footer { get; set; }
        public Font Font { get; set; }
        public StringFormat Format { get; set; }

        public FooterPrintBlock() {
            Format = new StringFormat();
            Format.LineAlignment = StringAlignment.Center;
            Format.Alignment = StringAlignment.Far;
            Format.Trimming = StringTrimming.Word;
            Format.FormatFlags = StringFormatFlags.LineLimit;
            this.Font = new Font("Tahoma", 8);
        }

        public override SizeF GetSize(Graphics g, DocumentMetrics metrics) {
            return g.MeasureString(Footer, Font, metrics.PrintAbleWidth, Format);
        }

        public override void Draw(System.Drawing.Graphics g, Dictionary<CodeEnum, string> codes) {
            g.DrawString(string.Format("Page {0} Of {1}", codes[CodeEnum.SheetNumber], codes[CodeEnum.SheetsCount]), Font, new SolidBrush(Color.Black), Rectangle, Format);
        }
    }
}

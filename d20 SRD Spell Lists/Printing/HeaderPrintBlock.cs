using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Printing.DataGridViewPrint.Tools {
    /// <summary>
    /// The HeaderPrintBlock controls information that prints small at the very top of each page.
    /// </summary>
    public class HeaderPrintBlock : PrintBlock {
        public string Header { get; set; }
        public Font Font { get; set; }
        public StringFormat Format { get; set; }

        public HeaderPrintBlock() {
            Format = new StringFormat();
            Format.LineAlignment = StringAlignment.Center;
            Format.Alignment = StringAlignment.Far;
            Format.Trimming = StringTrimming.Word;
            Format.FormatFlags = StringFormatFlags.LineLimit;
            this.Font = new Font("Tahoma", 8);
        }

        public override SizeF GetSize(Graphics g, DocumentMetrics metrics) {
            return g.MeasureString(Header, Font, metrics.PrintAbleWidth, Format);
        }

        public override void Draw(System.Drawing.Graphics g, Dictionary<CodeEnum, string> codes) {
            g.DrawString(Header, Font, new SolidBrush(Color.Black), Rectangle, Format);
        }
    }
}

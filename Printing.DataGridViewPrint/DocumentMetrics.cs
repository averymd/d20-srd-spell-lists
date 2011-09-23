using System.Drawing.Printing;

namespace Printing.DataGridViewPrint
{
    /// <author>Blaise Braye</author>
    /// <summary>
    /// Usefull to keep the printable coordinates of a document
    /// </summary>
    public class DocumentMetrics
    {
        /// <summary>
        /// The width of the document.
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// The height of the document.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// The left margin of the document.
        /// </summary>
        public int LeftMargin { get; set; }
        /// <summary>
        /// The right margin of the document.
        /// </summary>
        public int RightMargin { get; set; }
        /// <summary>
        /// The top margin of the document.
        /// </summary>
        public int TopMargin { get; set; }
        /// <summary>
        /// The bottom margin of the document.
        /// </summary>
        public int BottomMargin { get; set; }

        /// <summary>
        /// substract the margins from the document width
        /// </summary>
        public int PrintAbleWidth
        {
            get
            {
                return Width - LeftMargin - RightMargin;
            }
        }

        /// <summary>
        /// substract the margins from the document height
        /// </summary>
        public int PrintAbleHeight
        {
            get
            {
                return Height - TopMargin - BottomMargin;
            }
        }


        /// <summary>
        /// DocumentMetrics factory, take information in given PrintDocument object
        /// </summary>
        /// <param name="printDocument"></param>
        /// <returns>printable coordinates</returns>
        public static DocumentMetrics FromPrintDocument(PrintDocument printDocument)
        {
            PageSettings pageSettings = printDocument.DefaultPageSettings;
            
            return new DocumentMetrics()
            {
                Width = 
                    (pageSettings.Landscape)
                        ?pageSettings.PaperSize.Height:pageSettings.PaperSize.Width,
                Height = 
                    (pageSettings.Landscape)
                        ?pageSettings.PaperSize.Width:pageSettings.PaperSize.Height,
                LeftMargin = pageSettings.Margins.Left,
                TopMargin = pageSettings.Margins.Top,
                RightMargin = pageSettings.Margins.Right,
                BottomMargin = pageSettings.Margins.Bottom
            };
        }


    }
}

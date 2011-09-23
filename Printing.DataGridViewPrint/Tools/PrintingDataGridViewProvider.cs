using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Printing.DataGridViewPrint.Tools
{
    /// <summary>
    /// The orchestrator/provider of the print handler.
    /// </summary>
    public class PrintingDataGridViewProvider
    {
        IEnumerator<Partition> drawCursor;
        /// <summary>
        /// The internal representation of the Drawer.
        /// </summary>
        public GridDrawer _Drawer;
        /// <summary>
        /// The publicly editable Drawer.
        /// </summary>
        public GridDrawer Drawer { get { return _Drawer; } }


        PrintPageEventHandler _PrintPageEventHandler;

        PrintDocument _PrintDocument;
        PrintDocument PrintDocument
        {
            get { return _PrintDocument; }
            set
            {
                if (value == null)
                    throw new NullReferenceException();
                if (_PrintDocument != null)
                    _PrintDocument.PrintPage -= _PrintPageEventHandler;
                _PrintDocument = value;
                _PrintDocument.PrintPage += _PrintPageEventHandler;
            }
        }

        /// <summary>
        /// Constructor for the provider.
        /// </summary>
        /// <param name="drawer">An existing Drawer.</param>
        /// <param name="printDocument">The form's print document.</param>
        public PrintingDataGridViewProvider(GridDrawer drawer, PrintDocument printDocument)
        {
            _PrintPageEventHandler = new PrintPageEventHandler(PrintDocument_PrintPage);

            _Drawer = drawer;
            
            this.PrintDocument = printDocument;
        }

        /// <summary>
        /// This is the default and best way to create a provider.
        /// </summary>
        /// <param name="printDocument">The form's print document.</param>
        /// <param name="dgv">The DataGridView to be printed.</param>
        /// <param name="printLevelByLevel">Whether the sheet should print row by row (level by level) [true] or column by column [false].</param>
        /// <param name="mustCenterPartition">Whether the grid should be centered on the printed page.</param>
        /// <param name="mustFitColumnsToPage">Whether the columns can run off the page.</param>
        /// <param name="titlePrintBlock">A PrintBlock representing the title section of the page.</param>
        /// <param name="sheetHeader">A PrintBlock representing the header of the page.</param>
        /// <param name="sheetFooter">A PrintBlock representing the foorter of the page.</param>
        /// <returns></returns>
        public static PrintingDataGridViewProvider Create(PrintDocument printDocument,
            DataGridView dgv, bool printLevelByLevel, bool mustCenterPartition, bool mustFitColumnsToPage,
            PrintBlock titlePrintBlock, PrintBlock sheetHeader, PrintBlock sheetFooter)
        {
            return new PrintingDataGridViewProvider(
                new GridDrawer(dgv, mustCenterPartition, mustFitColumnsToPage)
                {
                    SheetHeader = sheetHeader,
                    SheetFooter = sheetFooter,
                    TitlePrintBlock = titlePrintBlock,
                    MustPrintLevelByLevel = printLevelByLevel
                }, 
                printDocument);
        }


        void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (drawCursor == null)
            {
                Drawer.Initialize(e.Graphics, DocumentMetrics.FromPrintDocument(PrintDocument));

                drawCursor = Drawer.Partitions().GetEnumerator();

                if (!drawCursor.MoveNext())
                    throw new Exception("Nothing to print");
            }
            Drawer.DrawSheet(e.Graphics, drawCursor.Current);
            e.HasMorePages = drawCursor.MoveNext();

            if (!e.HasMorePages) drawCursor = null;
        }
    }
}

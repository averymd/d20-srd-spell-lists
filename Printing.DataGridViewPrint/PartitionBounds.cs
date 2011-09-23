
using System;
using System.Windows.Forms;
namespace Printing.DataGridViewPrint
{
    /// <author>Blaise Braye</author>
    /// <summary>
    /// Bounds of a partition, it covers mostly included rows and columns
    /// but also cordinates information about it (size,..)
    /// </summary>
    public class PartitionBounds
    {
        /// <summary>
        /// The index of the first row being printed.
        /// </summary>
        public int StartRowIndex { get; set; }
        /// <summary>
        /// The index of the last row being printed.
        /// </summary>
        public int EndRowIndex { get; set; }

        /// <summary>
        /// The index of the first column being printed.
        /// </summary>
        public int StartColumnIndex { get; set; }
        /// <summary>
        /// The index of the last column being printed.
        /// </summary>
        public int EndColumnIndex { get; set; }

        /// <summary>
        /// The beginning horizontal position in the partition's Rectangle.
        /// </summary>
        public float StartX { get; set; }
        /// <summary>
        /// The beginning vertical position in the partition's Rectangle.
        /// </summary>
        public float StartY { get; set; }

        /// <summary>
        /// The width of the partition.
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// The height of the partition.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Filters rows.
        /// </summary>
        public Func<DataGridViewRow, bool> RowSelector { get; set; }
        /// <summary>
        /// Filters columns.
        /// </summary>
        public Func<DataGridViewColumn, bool> ColSelector{ get; set; }

        /// <summary>
        /// The total number of columns to be printed in this partition.
        /// </summary>
        public int ColumnCount
        {
            get { return 1 + EndColumnIndex - StartColumnIndex; }
        }

        /// <summary>
        /// The total number of rows to be printed in this partition.
        /// </summary>
        public int RowsCount
        {
            get { return 1 + EndRowIndex - StartRowIndex; }
        }
    }
}

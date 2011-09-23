using System.Collections.Generic;
using System.Drawing;

namespace Printing.DataGridViewPrint
{
    /// <author>Blaise Braye</author>
    /// <summary>
    /// GridDrawer is able to draw object inherited from this class,
    /// a common use case for GridDraw is to call GetSize method first,
    /// then setting a Rectangle in which the Draw method will be allowed to print.
    /// It's usefull for everyone because it allows to defines some blocks to be printed
    /// without modifying library core
    /// </summary>
    public abstract class PrintBlock
    {
        /// <summary>
        /// The area the PrintBlock will fill.
        /// </summary>
        public virtual RectangleF Rectangle { get; set; }

        /// <summary>
        /// Returns the size of the block to be printed.
        /// </summary>
        /// <param name="g">The Graphics object that will ultimately contain the block's contents.</param>
        /// <param name="metrics"></param>
        /// <returns></returns>
        public abstract SizeF GetSize(Graphics g, DocumentMetrics metrics);

        /// <summary>
        /// Draws the block's contents onto the Graphic g.
        /// </summary>
        /// <param name="g">The Graphic to contain the block.</param>
        /// <param name="codes">The various job-related meta data.</param>
        public abstract void Draw(Graphics g, Dictionary<CodeEnum, string> codes);

    }
}

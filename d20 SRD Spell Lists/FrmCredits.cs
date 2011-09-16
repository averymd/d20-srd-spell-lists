using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace d20_SRD_Spell_Lists {
    public partial class FrmCredits : Form {
        public FrmCredits() {
            InitializeComponent();

            lblCredits.Text = "Developer: Melissa Avery-Weir @ http://irrsinn.net\r\n";
        }
    }
}

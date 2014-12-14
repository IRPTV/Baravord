using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baravord.UI
{
    public partial class ShoraPrint : Form
    {
        public ShoraPrint()
        {
            InitializeComponent();
        }

        private void ShoraPrint_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
            
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("sdfsdfsdfsdfsdfsdf", textBox1.Font, new SolidBrush(Color.Red), new Point());
            e.Graphics.DrawLine(Pens.Blue, 0, 100, 10000, 100);
        }
    }
}

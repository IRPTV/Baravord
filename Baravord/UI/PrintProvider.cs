using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baravord.BLL;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.UI
{
    public partial class PrintProvider : Form
    {
        public PrintProvider()
        {
            InitializeComponent();
        }

        private void CmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri(System.Configuration.ConfigurationSettings.AppSettings["WebServerAddress"]+
                "printprovider.aspx?Provider_Id=" + ((NewListItem)CmbProvider.SelectedItem).Value.ToString());
        }

        public void ProviderFill()
        {
            List<ProviderObj> Sub_Lst = ProvidersBll.Select_All_Providers();

            CmbProvider.Items.Clear();

            foreach (ProviderObj item in Sub_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.LASTNAME + " - " + item.Name;
                Lst.Value = item.Id;
                CmbProvider.Items.Add(Lst);
            }
            CmbProvider.SelectedIndex = 0;
        }

        private void PrintProvider_Load(object sender, EventArgs e)
        {
            ProviderFill();
        }

        private void toolStripBtnPrint_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }
    }
}

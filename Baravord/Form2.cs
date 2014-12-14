using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Baravord.BLL;
using Baravord.OBJECTS;


namespace Baravord
{
    public partial class Form2 : Form
    {
        ProgramObj _ProgramGlobalObject = new ProgramObj();
        string _PageUrl = null;

        public Form2(int ProgramId,string PageUrl)
        {
            _ProgramGlobalObject.Id = ProgramId;
            _PageUrl = PageUrl;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");
           // webKitBrowser1.Navigate(System.Configuration.ConfigurationSettings.AppSettings["WebServerAddress"] + _PageUrl + ".aspx?Program_Id=" + _ProgramGlobalObject.Id);
            // Sets the CurrentCulture property to the culture associated with the Web
            // browser's current language setting.

            if (_PageUrl == "PrintSupport" || _PageUrl == "PrintSupport2")
            {
                webBrowser1.Url = new Uri(System.Configuration.ConfigurationSettings.AppSettings["WebServerAddress"] + _PageUrl + ".aspx?Id=" + _ProgramGlobalObject.Id);
            }
            else
            {
                webBrowser1.Url = new Uri(System.Configuration.ConfigurationSettings.AppSettings["WebServerAddress"] + _PageUrl + ".aspx?Program_Id=" + _ProgramGlobalObject.Id);
            }
            
            
        }

        private void toolStripBtnPrint_Click(object sender, EventArgs e)
        {
           webBrowser1.ShowPrintDialog();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
        }       
    }
}

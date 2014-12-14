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
using Baravord.Properties;
using System.IO;

namespace Baravord.UI
{
    public partial class Channels : Form
    {
        public Channels()
        {
            InitializeComponent();
        }

        private void Channels_Load(object sender, EventArgs e)
        {
            ChannelFill();
        }
        public void ChannelFill()
        {
            ChannelBll Chennels_Bll = new ChannelBll();
            List<ChannelObj> Ch_Lst = Chennels_Bll.Select_All_Channel();
            CmbChannel.Items.Clear();

            foreach (ChannelObj item in Ch_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbChannel.Items.Add(Lst);
            }
            CmbChannel.SelectedIndex = 0;
        }

        private void CmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewListItem Lst = (NewListItem)CmbChannel.SelectedItem;
            int ChannelId = int.Parse(Lst.Value.ToString());

            ChannelObj Obj = ChannelBll.Select_Current_Channel(ChannelId);

            txtTitle.Text = Obj.Title;
            txtNumber.Text = Obj.Number;
            nudSort.Value = Obj.Sort;
            pbLogo.ImageLocation = System.Configuration.ConfigurationSettings.AppSettings["ImageAddress"] + Obj.LogoUrl + ".jpg";

            pictureBox1.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pbLogo.ImageLocation = openFileDialog1.FileName;
            checkBox1.Checked = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NewListItem Lst = (NewListItem)CmbChannel.SelectedItem;
            int ChannelId = int.Parse(Lst.Value.ToString());

            ChannelObj Chn = new ChannelObj();
            Chn.Id = ChannelId;
            Chn.Title = txtTitle.Text;
            Chn.Number = txtNumber.Text;
            Chn.Sort = int.Parse(nudSort.Value.ToString());

            if (checkBox1.Checked)
            {
                var filename = openFileDialog1.FileName;
                System.IO.File.Delete(Path.GetFileNameWithoutExtension(filename) + ".jpg");
                System.IO.File.Copy(filename,
                    Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["ImageAddress"], Path.GetFileNameWithoutExtension(filename) + ".jpg"), true);

                Chn.LogoUrl = Path.GetFileNameWithoutExtension(filename);
            }
            else
            {
                ChannelObj Obj = ChannelBll.Select_Current_Channel(ChannelId);
                Chn.LogoUrl = Obj.LogoUrl;
            }

            ChannelBll.UPDATE_CURRENT_CHANNEL(Chn);
            ChannelFill();
        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            txtNumber.Text = "";
            txtTitle.Text = "";
            nudSort.Value = 1;
            pbLogo.ImageLocation = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChannelObj Chn = new ChannelObj();
            Chn.Id = 0;
            Chn.Title = txtTitle.Text;
            Chn.Number = txtNumber.Text;
            Chn.Sort = int.Parse(nudSort.Value.ToString());
            if (checkBox1.Checked)
            {
                var filename = openFileDialog1.FileName;
                System.IO.File.Delete(Path.GetFileNameWithoutExtension(filename) + ".jpg");
                System.IO.File.Copy(filename,
                    Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["ImageAddress"], Path.GetFileNameWithoutExtension(filename) + ".jpg"), true);
            }
            else
            {
                openFileDialog1.ShowDialog();
            }

            Chn.LogoUrl = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

            ChannelBll.INSERT_CHANNEL(Chn);
            ChannelFill();
            pictureBox1.Visible = false;
          

        }
    }
}

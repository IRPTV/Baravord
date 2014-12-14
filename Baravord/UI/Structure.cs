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
    public partial class Structure : Form
    {
        public Structure()
        {
            InitializeComponent();
        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            txtTitle.Text = "";
            nudSort.Value = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Add New
            StructureObj StrObj = new StructureObj();
            StrObj.Title = txtTitle.Text;
            StrObj.Sort = int.Parse(nudSort.Value.ToString());          

          
            if (txtTitle.Text.Length > 2)
            {
                StructureBll.INSERT_STRUCTURE(StrObj);
                StructureFill();
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Update

              StructureObj StrObj=  new StructureObj ();
              StrObj.Title = txtTitle.Text;
              StrObj.Sort = int.Parse(nudSort.Value.ToString());

              NewListItem Lst = (NewListItem)CmbStructure.SelectedItem;
              int StrId = int.Parse(Lst.Value.ToString());

              StrObj.Id = StrId;

         

            if (txtTitle.Text.Length > 2)
            {
                StructureBll.UPDATE_STRUCTURE(StrObj);
                StructureFill();
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }
        }
        public void StructureFill()
        {
            StructureBll Structure_Bll = new StructureBll();
            List<StructureObj> Struct_Lst = Structure_Bll.Select_All_Struct();

            CmbStructure.Items.Clear();

            foreach (StructureObj item in Struct_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbStructure.Items.Add(Lst);
            }

            if (CmbStructure.Items.Count > 0)
                CmbStructure.SelectedIndex = 0;
        }

        private void Structure_Load(object sender, EventArgs e)
        {
            StructureFill();
        }

        private void CmbStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
              NewListItem Lst = (NewListItem)CmbStructure.SelectedItem;
            int StrId = int.Parse(Lst.Value.ToString());

            StructureObj StrObj=  StructureBll.Select_Current_Struct(StrId);

            txtTitle.Text = StrObj.Title;
            nudSort.Value = StrObj.Sort;

            pictureBox1.Visible = false;
        }
    }
}

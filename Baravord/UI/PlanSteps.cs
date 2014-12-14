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
    public partial class PlanSteps : Form
    {
        public PlanSteps()
        {
            InitializeComponent();
        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            txtTitle.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Insert New PlanStep

            PlanStepObj Obj = new PlanStepObj();
            Obj.Title = txtTitle.Text;

           

            if (txtTitle.Text.Length > 2)
            {
                PlanStepBll.Insert_Step_Base(Obj);

                PlanStepFill();

                pictureBox1.Visible = false;
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Update Current Plan Step

            PlanStepObj Obj = new PlanStepObj();
            Obj.Title = txtTitle.Text;
            Obj.Id = int.Parse(((NewListItem)cmbPlanStep.SelectedItem).Value.ToString());

          

            if (txtTitle.Text.Length > 2)
            {
                PlanStepBll.Update_Current_PlanStep(Obj);

                PlanStepFill();
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }
        }

        private void PlanSteps_Load(object sender, EventArgs e)
        {
            PlanStepFill();
        }

        public void PlanStepFill()
        {
            List<PlanStepObj> Pln_Lst = PlanStepBll.Select_All_PlanStep();

            cmbPlanStep.Items.Clear();

            foreach (PlanStepObj item in Pln_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;
                cmbPlanStep.Items.Add(Lst);
            }
            cmbPlanStep.SelectedIndex = 0;
        }

        private void cmbPlanStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlanStepObj Obj =
                PlanStepBll.Select_Current_PlanStep(int.Parse(((NewListItem)cmbPlanStep.SelectedItem).Value.ToString()));

            txtTitle.Text = Obj.Title;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult Rs = MessageBox.Show("آیا مورد انتخاب شده حذف گردد؟", "حذف",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Rs == System.Windows.Forms.DialogResult.Yes)
            {
                List<string[]> Lst =
                    PlanStepBll.Select_PlanStepById(int.Parse(((NewListItem)cmbPlanStep.SelectedItem).Value.ToString()));

                if (Lst.Count > 0)
                {
                    string Str = "";
                    string Dep = "";
                    foreach (string[] item in Lst)
                    {
                        List<ProgramObj> Lst_Prog =
                   ProgramBll.Search_Prgrams("Select * From program  where  Id=" + item[0].ToString());
                        foreach (ProgramObj item2 in Lst_Prog)
                        {
                            Dep = (item2.Dep == 1) ? "    واحد تولید    " : "      واحد اطلاعات و برنامه ریزی     ";
                            Str += item2.Title_Farsi + " " + Dep + "\n";
                        }
                    }
                    MessageBox.Show("   در برنامه های زیر استفاده شده است  " + " \n" + Str);
                }
                else
                {
                    PlanStepBll.Delete_PlanStep(int.Parse(((NewListItem)cmbPlanStep.SelectedItem).Value.ToString()));
                    PlanStepFill();
                }
            }
        }
    }
}

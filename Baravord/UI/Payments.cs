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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            PaymentFill();
        }
        public void PaymentFill()
        {
            PaymentBll Py_Bll = new PaymentBll();
            List<PaymentObj> Py_Lst = Py_Bll.Select_All_Payment();

            CmbPayment.Items.Clear();

            foreach (PaymentObj item in Py_Lst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.Title;
                Lst.Value = item.Id;

                CmbPayment.Items.Add(Lst);
            }
            CmbPayment.SelectedIndex = 0;
        }

        private void pbAddSession_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            txtTitle.Text = "";
            nudSort.Value = 1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Insert
            PaymentObj Obj = new PaymentObj();
            Obj.Title = txtTitle.Text;
            Obj.Sort = int.Parse(nudSort.Value.ToString());




            if (txtTitle.Text.Length > 2)
            {
                PaymentBll.Insert_Payment_Base(Obj);



                pictureBox1.Visible = false;
                PaymentFill();
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PaymentObj Obj = new PaymentObj();
            Obj.Title = txtTitle.Text;
            Obj.Sort = int.Parse(nudSort.Value.ToString());


            Obj.Id = int.Parse(((NewListItem)CmbPayment.SelectedItem).Value.ToString());



            if (txtTitle.Text.Length > 2)
            {
                PaymentBll.Update_Current_Payment(Obj);
                PaymentFill();
            }
            else
            {
                MessageBox.Show("عنوان  باید حداقل سه کاراکتر باشد");
            }
        }

        private void CmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentObj Obj = new PaymentObj();
            Obj.Title = txtTitle.Text;
            Obj.Sort = int.Parse(nudSort.Value.ToString());


            Obj.Id = int.Parse(((NewListItem)CmbPayment.SelectedItem).Value.ToString());

           Obj=  PaymentBll.Select_Current_Payment(Obj.Id);
           txtTitle.Text = Obj.Title;
           nudSort.Value = Obj.Sort;
           pictureBox1.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult Rs = MessageBox.Show("آیا مورد انتخاب شده حذف گردد؟", "حذف",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Rs == System.Windows.Forms.DialogResult.Yes)
            {
                List<string[]> Lst =
                    PaymentBll.Select_PaymentById(int.Parse(((NewListItem)CmbPayment.SelectedItem).Value.ToString()));


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
                    PaymentBll.Delete_Payment(int.Parse(((NewListItem)CmbPayment.SelectedItem).Value.ToString()));
                    PaymentFill();
                }
            }
        }
    }
}

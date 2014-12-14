using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.TOOLS;

namespace Baravord.DAL
{
    class ProgramDal
    {
        public ProgramObj Insert_Prgram(ProgramObj ProgrameObjectInput)
        {
            ProgramObj Obj = new ProgramObj();

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Insert_Program", Con);
                Cmd.CommandType = CommandType.StoredProcedure;


                Cmd.Parameters.Clear();

                Cmd.Parameters.AddWithValue("@Title_farsi", ProgrameObjectInput.Title_Farsi);
                Cmd.Parameters.AddWithValue("@Title_2", ProgrameObjectInput.Title_2);
                Cmd.Parameters.AddWithValue("@Provider_Id", ProgrameObjectInput.Provider_Id);
                Cmd.Parameters.AddWithValue("@Writer_Name", ProgrameObjectInput.Writer_Name);
                Cmd.Parameters.AddWithValue("@Session", ProgrameObjectInput.Session);
                Cmd.Parameters.AddWithValue("@Session_Time", ProgrameObjectInput.Session_Time);
                Cmd.Parameters.AddWithValue("@Percent_Live", ProgrameObjectInput.Percent_Live);
                Cmd.Parameters.AddWithValue("@Percent_Archive", ProgrameObjectInput.Percent_Archive);
                Cmd.Parameters.AddWithValue("@Percent_New", ProgrameObjectInput.Percent_New);
                Cmd.Parameters.AddWithValue("@Percent_Dubbed", ProgrameObjectInput.Percent_Dubbed);
                Cmd.Parameters.AddWithValue("@Director_Name", ProgrameObjectInput.Director_Name);
                Cmd.Parameters.AddWithValue("@Act_DateTime", ProgrameObjectInput.Act_DateTime);
                Cmd.Parameters.AddWithValue("@Description", ProgrameObjectInput.Description);
                Cmd.Parameters.AddWithValue("@price_Minute", ProgrameObjectInput.Price_Minute);
                Cmd.Parameters.AddWithValue("@Latest_Delivery", ProgrameObjectInput.Latest_Delivery);
                Cmd.Parameters.AddWithValue("@ChannelId", ProgrameObjectInput.ChannelId);
                Cmd.Parameters.AddWithValue("@Language_Id", ProgrameObjectInput.LanguageId);
                Cmd.Parameters.AddWithValue("@Baravord_Number", ProgrameObjectInput.Baravord_Number);
                Cmd.Parameters.AddWithValue("@ArchiveBuy", ProgrameObjectInput.ArchiveBuy);
                Cmd.Parameters.AddWithValue("@Music", ProgrameObjectInput.Music);
                Cmd.Parameters.AddWithValue("@VisaByProvider", ProgrameObjectInput.VisaByProvider);
                Cmd.Parameters.AddWithValue("@Viewers", ProgrameObjectInput.Viewers);
                Cmd.Parameters.AddWithValue("@PlanStep", ProgrameObjectInput.PlanStep);

                Cmd.Parameters.AddWithValue("@Notify", ProgrameObjectInput.Notify);
                Cmd.Parameters.AddWithValue("@Dep", ProgrameObjectInput.Dep);
                Cmd.Parameters.AddWithValue("@SendDate", ProgrameObjectInput.SendDate);
                Cmd.Parameters.AddWithValue("@BackProgId", ProgrameObjectInput.BackProgId);
                Cmd.Parameters.AddWithValue("@RcvDate", ProgrameObjectInput.RcvDate);
                Cmd.Parameters.AddWithValue("@TarhNumber", ProgrameObjectInput.TarhNumber);
                Cmd.Parameters.AddWithValue("@Depart", ProgrameObjectInput.Depart);


                Cmd.Parameters.AddWithValue("@Datetime_Edit", ProgrameObjectInput.Datetime_Edit);
                Cmd.Parameters.AddWithValue("@Datetime_Finance", ProgrameObjectInput.Datetime_Finance);
                Cmd.Parameters.AddWithValue("@program_Kind", ProgrameObjectInput.Program_Kind);
                Cmd.Parameters.AddWithValue("@Datetime_Publish", ProgrameObjectInput.Datetime_Publish);
                Cmd.Parameters.AddWithValue("@CheckOut_Kind", ProgrameObjectInput.Checkout_Kind);
                Cmd.Parameters.AddWithValue("@IsCheckedOut", ProgrameObjectInput.IsCheckedOut);


                Cmd.Parameters.AddWithValue("@Datetime_Tarh", ProgrameObjectInput.Datetime_Tarh);




                Obj.Id = int.Parse(Cmd.ExecuteScalar().ToString());

                Con.Close();

            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
            }
            return Obj;

        }

        public bool Delete_Current_Prgram(ProgramObj ProgrameObjectInput)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("Delete_Current_Program", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@Id", ProgrameObjectInput.Id);

                Cmd.ExecuteNonQuery();

                Con.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
            return true;

        }

        public bool Update_Program(ProgramObj ProgrameObjectInput)
        {


            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();


                SqlCommand Cmd = new SqlCommand("Update_Program", Con);
                Cmd.CommandType = CommandType.StoredProcedure;


                Cmd.Parameters.Clear();

                Cmd.Parameters.AddWithValue("@Title_farsi", ProgrameObjectInput.Title_Farsi);
                Cmd.Parameters.AddWithValue("@Title_2", ProgrameObjectInput.Title_2);
                Cmd.Parameters.AddWithValue("@Provider_Id", ProgrameObjectInput.Provider_Id);
                Cmd.Parameters.AddWithValue("@Writer_Name", ProgrameObjectInput.Writer_Name);
                Cmd.Parameters.AddWithValue("@Session", ProgrameObjectInput.Session);
                Cmd.Parameters.AddWithValue("@Session_Time", ProgrameObjectInput.Session_Time);
                Cmd.Parameters.AddWithValue("@Percent_Live", ProgrameObjectInput.Percent_Live);
                Cmd.Parameters.AddWithValue("@Percent_Archive", ProgrameObjectInput.Percent_Archive);
                Cmd.Parameters.AddWithValue("@Percent_New", ProgrameObjectInput.Percent_New);
                Cmd.Parameters.AddWithValue("@Percent_Dubbed", ProgrameObjectInput.Percent_Dubbed);
                Cmd.Parameters.AddWithValue("@Director_Name", ProgrameObjectInput.Director_Name);
                Cmd.Parameters.AddWithValue("@Act_DateTime", ProgrameObjectInput.Act_DateTime);
                Cmd.Parameters.AddWithValue("@Description", ProgrameObjectInput.Description);
                Cmd.Parameters.AddWithValue("@price_Minute", ProgrameObjectInput.Price_Minute);
                Cmd.Parameters.AddWithValue("@Latest_Delivery", ProgrameObjectInput.Latest_Delivery);
                Cmd.Parameters.AddWithValue("@ChannelId", ProgrameObjectInput.ChannelId);
                Cmd.Parameters.AddWithValue("@Language_Id", ProgrameObjectInput.LanguageId);
                Cmd.Parameters.AddWithValue("@Baravord_Number", ProgrameObjectInput.Baravord_Number);
                Cmd.Parameters.AddWithValue("@ArchiveBuy", ProgrameObjectInput.ArchiveBuy);
                Cmd.Parameters.AddWithValue("@Music", ProgrameObjectInput.Music);
                Cmd.Parameters.AddWithValue("@VisaByProvider", ProgrameObjectInput.VisaByProvider);
                Cmd.Parameters.AddWithValue("@Viewers", ProgrameObjectInput.Viewers);
                Cmd.Parameters.AddWithValue("@PlanStep", ProgrameObjectInput.PlanStep);

                Cmd.Parameters.AddWithValue("@Notify", ProgrameObjectInput.Notify);
                Cmd.Parameters.AddWithValue("@Dep", ProgrameObjectInput.Dep);
                Cmd.Parameters.AddWithValue("@SendDate", ProgrameObjectInput.SendDate);
                Cmd.Parameters.AddWithValue("@BackProgId", ProgrameObjectInput.BackProgId);
                Cmd.Parameters.AddWithValue("@RcvDate", ProgrameObjectInput.RcvDate);
                Cmd.Parameters.AddWithValue("@TarhNumber", ProgrameObjectInput.TarhNumber);
                Cmd.Parameters.AddWithValue("@Id", ProgrameObjectInput.Id);
                Cmd.Parameters.AddWithValue("@Depart", ProgrameObjectInput.Depart);




                Cmd.Parameters.AddWithValue("@Datetime_Edit", ProgrameObjectInput.Datetime_Edit);
                Cmd.Parameters.AddWithValue("@Datetime_Finance", ProgrameObjectInput.Datetime_Finance);
                Cmd.Parameters.AddWithValue("@program_Kind", ProgrameObjectInput.Program_Kind);
                Cmd.Parameters.AddWithValue("@Datetime_Publish", ProgrameObjectInput.Datetime_Publish);
                Cmd.Parameters.AddWithValue("@CheckOut_Kind", ProgrameObjectInput.Checkout_Kind);
                Cmd.Parameters.AddWithValue("@IsCheckedOut", ProgrameObjectInput.IsCheckedOut);


                Cmd.Parameters.AddWithValue("@Datetime_Tarh", ProgrameObjectInput.Datetime_Tarh);


                Cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
            return true;
        }

        public ProgramObj Select_Current_Prgram(ProgramObj ProgrameObjectInput)
        {
            ProgramObj RetObj = new ProgramObj();

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("Select_Current_Program", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@Id", ProgrameObjectInput.Id);
                SqlDataReader Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {

                    RetObj.Id = int.Parse(Reader["ID"].ToString());

                    if (Reader["TITLE_Farsi"] != DBNull.Value)
                        RetObj.Title_Farsi = Reader["TITLE_Farsi"].ToString();

                    if (Reader["TITLE_2"] != DBNull.Value)
                        RetObj.Title_2 = Reader["TITLE_2"].ToString();

                    if (Reader["Act_DateTime"] != DBNull.Value)
                        RetObj.Act_DateTime = DateTime.Parse(Reader["Act_DateTime"].ToString());

                    if (Reader["Baravord_Number"] != DBNull.Value)
                        RetObj.Baravord_Number = Reader["Baravord_Number"].ToString();

                    if (Reader["ChannelId"] != DBNull.Value)
                        RetObj.ChannelId = int.Parse(Reader["ChannelId"].ToString());

                    if (Reader["Description"] != DBNull.Value)
                        RetObj.Description = Reader["Description"].ToString();

                    if (Reader["Director_Name"] != DBNull.Value)
                        RetObj.Director_Name = Reader["Director_Name"].ToString();

                    if (Reader["Language_Id"] != DBNull.Value)
                        RetObj.LanguageId = int.Parse(Reader["Language_Id"].ToString());

                    if (Reader["Latest_Delivery"] != DBNull.Value)
                        RetObj.Latest_Delivery = int.Parse(Reader["Latest_Delivery"].ToString());

                    if (Reader["Percent_Archive"] != DBNull.Value)
                        RetObj.Percent_Archive = float.Parse(Reader["Percent_Archive"].ToString());

                    if (Reader["Percent_Dubbed"] != DBNull.Value)
                        RetObj.Percent_Dubbed = float.Parse(Reader["Percent_Dubbed"].ToString());

                    if (Reader["Percent_Live"] != DBNull.Value)
                        RetObj.Percent_Live = float.Parse(Reader["Percent_Live"].ToString());

                    if (Reader["Percent_New"] != DBNull.Value)
                        RetObj.Percent_New = float.Parse(Reader["Percent_New"].ToString());

                    if (Reader["Price_Minute"] != DBNull.Value)
                        RetObj.Price_Minute = Reader["Price_Minute"].ToString();

                    if (Reader["Provider_Id"] != DBNull.Value)
                        RetObj.Provider_Id = int.Parse(Reader["Provider_Id"].ToString());

                    if (Reader["Session"] != DBNull.Value)
                        RetObj.Session = int.Parse(Reader["Session"].ToString());


                    if (Reader["Session_Time"] != DBNull.Value)
                        RetObj.Session_Time = Reader["Session_Time"].ToString();

                    if (Reader["Writer_Name"] != DBNull.Value)
                        RetObj.Writer_Name = Reader["Writer_Name"].ToString();



                    RetObj.ArchiveBuy = bool.Parse(Reader["ArchiveBuy"].ToString());



                    RetObj.Music = int.Parse(Reader["Music"].ToString());



                    RetObj.VisaByProvider = Reader["VisaByProvider"].ToString();

                    if (Reader["Viewers"] != DBNull.Value)
                        RetObj.Viewers = Reader["Viewers"].ToString();

                    if (Reader["PlanStep"] != DBNull.Value)
                        RetObj.PlanStep = int.Parse(Reader["PlanStep"].ToString());


                    if (Reader["Dep"] != DBNull.Value)
                        RetObj.Dep = int.Parse(Reader["Dep"].ToString());

                    if (Reader["BackProgId"] != DBNull.Value)
                        RetObj.BackProgId = int.Parse(Reader["BackProgId"].ToString());

                    if (Reader["Notify"] != DBNull.Value)
                        RetObj.Notify = Reader["Notify"].ToString();

                    if (Reader["RcvDate"] != DBNull.Value)
                    {
                        RetObj.RcvDate = DateTime.Parse(Reader["RcvDate"].ToString());
                    }
                         else
                    {
                        RetObj.RcvDate = DateConversion.JD2GD("1300/01/01");
                    }


                    if (Reader["SendDate"] != DBNull.Value)
                    {
                        RetObj.SendDate = DateTime.Parse(Reader["SendDate"].ToString());
                    }
                    else
                    {
                        RetObj.SendDate = DateConversion.JD2GD("1300/01/01");
                    }

                    

                    if (Reader["TarhNumber"] != DBNull.Value)
                        RetObj.TarhNumber = Reader["TarhNumber"].ToString();


                    if (Reader["Depart"] != DBNull.Value)
                        RetObj.Depart = int.Parse(Reader["Depart"].ToString());






                    if (Reader["Datetime_Edit"] != DBNull.Value)
                    {
                        RetObj.Datetime_Edit = DateTime.Parse(Reader["Datetime_Edit"].ToString());
                    }
                    else
                    {
                        RetObj.Datetime_Edit = DateConversion.JD2GD("1300/01/01");
                    }


                    if (Reader["Datetime_Finance"] != DBNull.Value)
                    {
                        RetObj.Datetime_Finance = DateTime.Parse(Reader["Datetime_Finance"].ToString());
                     }
                    else
                    {
                        RetObj.Datetime_Finance = DateConversion.JD2GD("1300/01/01");
                    }

                    if (Reader["Datetime_Publish"] != DBNull.Value)
                    {
                        RetObj.Datetime_Publish = DateTime.Parse(Reader["Datetime_Publish"].ToString());
                    }
                    else
                    {
                        RetObj.Datetime_Publish = DateConversion.JD2GD("1300/01/01");
                    }

                    if (Reader["Program_Kind"] != DBNull.Value)
                        RetObj.Program_Kind = Reader["Program_Kind"].ToString();


                    if (Reader["Checkout_Kind"] != DBNull.Value)
                        RetObj.Checkout_Kind = Reader["Checkout_Kind"].ToString();


                    if (Reader["IsCheckedOut"] != DBNull.Value)
                        RetObj.IsCheckedOut = bool.Parse(Reader["IsCheckedOut"].ToString());


                    if (Reader["Datetime_Tarh"] != DBNull.Value)
                    {
                        RetObj.Datetime_Tarh = DateTime.Parse(Reader["Datetime_Tarh"].ToString());
                    }
                    else
                    {
                        RetObj.Datetime_Tarh = DateConversion.JD2GD("1300/01/01");
                    }



                }

                Con.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
            }
            return RetObj;
        }


        public List<ProgramObj> Search_Prgrams(string FullQuery)
        {

            List<ProgramObj> RetList = new List<ProgramObj>();

            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand(FullQuery, Con);
                Cmd.CommandType = CommandType.Text;

                //Cmd.Parameters.Clear();
                //Cmd.Parameters.AddWithValue("@Id", ProgrameObjectInput.Id);
                SqlDataReader Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    ProgramObj RetObj = new ProgramObj();
                    RetObj.Id = int.Parse(Reader["ID"].ToString());

                    if (Reader["TITLE_Farsi"] != DBNull.Value)
                        RetObj.Title_Farsi = Reader["TITLE_Farsi"].ToString();

                    if (Reader["TITLE_2"] != DBNull.Value)
                        RetObj.Title_2 = Reader["TITLE_2"].ToString();

                    if (Reader["Act_DateTime"] != DBNull.Value)
                        RetObj.Act_DateTime = DateTime.Parse(Reader["Act_DateTime"].ToString());

                    if (Reader["Baravord_Number"] != DBNull.Value)
                        RetObj.Baravord_Number = Reader["Baravord_Number"].ToString();

                    if (Reader["ChannelId"] != DBNull.Value)
                        RetObj.ChannelId = int.Parse(Reader["ChannelId"].ToString());

                    if (Reader["Description"] != DBNull.Value)
                        RetObj.Description = Reader["Description"].ToString();

                    if (Reader["Director_Name"] != DBNull.Value)
                        RetObj.Director_Name = Reader["Director_Name"].ToString();

                    if (Reader["Language_Id"] != DBNull.Value)
                        RetObj.LanguageId = int.Parse(Reader["Language_Id"].ToString());

                    if (Reader["Latest_Delivery"] != DBNull.Value)
                        RetObj.Latest_Delivery = int.Parse(Reader["Latest_Delivery"].ToString());

                    if (Reader["Percent_Archive"] != DBNull.Value)
                        RetObj.Percent_Archive = float.Parse(Reader["Percent_Archive"].ToString());

                    if (Reader["Percent_Dubbed"] != DBNull.Value)
                        RetObj.Percent_Dubbed = float.Parse(Reader["Percent_Dubbed"].ToString());

                    if (Reader["Percent_Live"] != DBNull.Value)
                        RetObj.Percent_Live = float.Parse(Reader["Percent_Live"].ToString());

                    if (Reader["Percent_New"] != DBNull.Value)
                        RetObj.Percent_New = float.Parse(Reader["Percent_New"].ToString());

                    if (Reader["Price_Minute"] != DBNull.Value)
                        RetObj.Price_Minute = Reader["Price_Minute"].ToString();

                    if (Reader["Provider_Id"] != DBNull.Value)
                        RetObj.Provider_Id = int.Parse(Reader["Provider_Id"].ToString());

                    if (Reader["Session"] != DBNull.Value)
                        RetObj.Session = int.Parse(Reader["Session"].ToString());


                    if (Reader["Session_Time"] != DBNull.Value)
                        RetObj.Session_Time = Reader["Session_Time"].ToString();

                    if (Reader["Writer_Name"] != DBNull.Value)
                        RetObj.Writer_Name = Reader["Writer_Name"].ToString();


                    if (Reader["ArchiveBuy"] != DBNull.Value)
                        RetObj.ArchiveBuy = bool.Parse(Reader["ArchiveBuy"].ToString());


                    if (Reader["Music"] != DBNull.Value)
                        RetObj.Music = int.Parse(Reader["Music"].ToString());


                    if (Reader["VisaByProvider"] != DBNull.Value)
                        RetObj.VisaByProvider = Reader["VisaByProvider"].ToString();

                    if (Reader["Viewers"] != DBNull.Value)
                        RetObj.Viewers = Reader["Viewers"].ToString();

                    if (Reader["PlanStep"] != DBNull.Value)
                        RetObj.PlanStep = int.Parse(Reader["PlanStep"].ToString());

                    if (Reader["Dep"] != DBNull.Value)
                        RetObj.Dep = int.Parse(Reader["Dep"].ToString());

                    if (Reader["BackProgId"] != DBNull.Value)
                        RetObj.BackProgId = int.Parse(Reader["BackProgId"].ToString());

                    if (Reader["Notify"] != DBNull.Value)
                        RetObj.Notify = Reader["Notify"].ToString();

                    if (Reader["RcvDate"] != DBNull.Value)
                        RetObj.RcvDate = DateTime.Parse(Reader["RcvDate"].ToString());

                    if (Reader["SendDate"] != DBNull.Value)
                        RetObj.SendDate = DateTime.Parse(Reader["SendDate"].ToString());

                    if (Reader["TarhNumber"] != DBNull.Value)
                        RetObj.TarhNumber = Reader["TarhNumber"].ToString();


                    if (Reader["Depart"] != DBNull.Value)
                        RetObj.Depart = int.Parse(Reader["Depart"].ToString());




                    if (Reader["Datetime_Edit"] != DBNull.Value)
                        RetObj.Datetime_Edit = DateTime.Parse(Reader["Datetime_Edit"].ToString());


                    if (Reader["Datetime_Finance"] != DBNull.Value)
                        RetObj.Datetime_Finance = DateTime.Parse(Reader["Datetime_Finance"].ToString());

                    if (Reader["Datetime_Publish"] != DBNull.Value)
                        RetObj.Datetime_Publish = DateTime.Parse(Reader["Datetime_Publish"].ToString());

                    if (Reader["Program_Kind"] != DBNull.Value)
                        RetObj.Program_Kind = Reader["Program_Kind"].ToString();


                    if (Reader["Checkout_Kind"] != DBNull.Value)
                        RetObj.Checkout_Kind = Reader["Checkout_Kind"].ToString();


                    if (Reader["IsCheckedOut"] != DBNull.Value)
                        RetObj.IsCheckedOut = bool.Parse(Reader["IsCheckedOut"].ToString());


                    if (Reader["Datetime_Tarh"] != DBNull.Value)
                    {
                        RetObj.Datetime_Tarh = DateTime.Parse(Reader["Datetime_Tarh"].ToString());
                    }
                    else
                    {
                        RetObj.Datetime_Tarh = DateConversion.JD2GD("1300/01/01");
                    }


                    RetList.Add(RetObj);

                }

                Con.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
            }
            return RetList;
        }



        public bool Delete_Prog_And_Details(int ProgramId)
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("Delete_Current_Program_And_Details", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@ProgId", ProgramId);

                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
            return true;
        }

          public bool GenerateBackUp()
        {
            try
            {
                SqlConnection Con = DataBaseTools.CreateSqlConnection();
                Con.Open();

                SqlCommand Cmd = new SqlCommand("  BACKUP DATABASE baravord1 TO DISK = 'd:\\baravord\\Baravord_BackUp.BAK'", Con);
                Cmd.CommandType = CommandType.Text;

                Cmd.Parameters.Clear();
                //Cmd.Parameters.AddWithValue("@ProgId", ProgramId);

                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return false;
            }
        }

      
    }
}

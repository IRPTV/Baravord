using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baravord.OBJECTS
{
    class ProgramObj
    {
        public ProgramObj()
        {
            Act_DateTime = Baravord.TOOLS.GetDate.GetDateTime();
            Title_Farsi = "";
            Title_2 = "";
            Provider_Id = 0;
            Writer_Name = "";
            Session = 0;
            Session_Time = "";
            Percent_Live = Percent_Archive = Percent_New = Percent_Dubbed = 0;
            Director_Name = "";
            Description = "";
            Price_Minute = "";
            Latest_Delivery = 0;
            ChannelId = 0;
            LanguageId = 0;
            Baravord_Number = "";
            Id = 0;
            ArchiveBuy = false;
            Music = 0;
            VisaByProvider = "3";
            Viewers = "";
            PlanStep = 1;
            Notify = "";
            Dep = 1;
            SendDate = Baravord.TOOLS.GetDate.GetDateTime().AddYears(-10);
            BackProgId = 0;
            RcvDate = Baravord.TOOLS.GetDate.GetDateTime();
            TarhNumber = "";
            Depart = 0;
            Datetime_Edit = Baravord.TOOLS.GetDate.GetDateTime().AddYears(-10);
            Datetime_Finance = Baravord.TOOLS.GetDate.GetDateTime().AddYears(-10);
            Datetime_Publish = Baravord.TOOLS.GetDate.GetDateTime().AddYears(-10);
            Program_Kind = "0";
            Checkout_Kind = "0";
            IsCheckedOut = false;
            Datetime_Tarh = Baravord.TOOLS.GetDate.GetDateTime().AddYears(-10);
        }

        public int Id { get; set; }
        public string Title_Farsi { get; set; }
        public string Title_2 { get; set; }
        public int Provider_Id { get; set; }
        public string Writer_Name { get; set; }
        public int Session { get; set; }
        public string Session_Time { get; set; }
        public float Percent_Live { get; set; }
        public float Percent_Archive { get; set; }
        public float Percent_New { get; set; }
        public float Percent_Dubbed { get; set; }
        public string Director_Name { get; set; }
        public DateTime Act_DateTime { get; set; }
        public string Description { get; set; }
        public string Price_Minute { get; set; }
        public int Latest_Delivery { get; set; }
        public int ChannelId { get; set; }
        public int LanguageId { get; set; }
        public string Baravord_Number { get; set; }
        public bool ArchiveBuy { get; set; }
        public int Music { get; set; }
        public string VisaByProvider { get; set; }
        public string Viewers { get; set; }
        public int PlanStep { get; set; }
        public string Notify { get; set; }
        public int Dep { get; set; }
        public DateTime SendDate { get; set; }
        public int BackProgId { get; set; }
        public DateTime RcvDate { get; set; }
        public string TarhNumber { get; set; }
        public int Depart { get; set; }
        public DateTime Datetime_Finance { get; set; }
        public DateTime Datetime_Edit { get; set; }
        public DateTime Datetime_Publish { get; set; }
        public string Program_Kind { get; set; }
        public string Checkout_Kind { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime Datetime_Tarh { get; set; }

    }
}

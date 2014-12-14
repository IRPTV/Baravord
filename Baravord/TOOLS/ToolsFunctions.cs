using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baravord.TOOLS
{
    class ToolsFunctions
    {
        public static string[] SplitTimeCode(string TimeCode)
        {
            return TimeCode.Split(':');
        }
        public static string[] CovertSplitDateToShamsi(DateTime InputDateTime)
        {            
                return DateConversion.GD2JD(InputDateTime).Split('/');                      
        }
        //public static string GenerateBaravordCode(string Year, int ChannelCode)
        //{
        //    Baravord.MyDBTableAdapters.SUPPORTTableAdapter Ta = new MyDBTableAdapters.SUPPORTTableAdapter();
        //    MyDB.SUPPORTDataTable Dt = Ta.Channel_SelectById(ChannelCode);
        //    string ChannelString="";
        //    if (Dt.Rows.Count > 0)
        //    {
        //        ChannelString =Dt.Rows[0]["NUMBER"].ToString();
        //    }
        //    else
        //    {
        //        ChannelString ="0000";
        //    }
        //    return "2/" + Year.Substring(2, 2) + "/" + ChannelString+"/";
        //}
    }
}
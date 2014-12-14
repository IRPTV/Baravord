using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;

namespace Baravord.BLL
{
    class Provider_HistoryBll
    {
        public static List<Provider_HistoryObj>  Select_Provider_History(ProviderObj Provider)
        {
            Provider_HistoryDal Provider_Dal = new Provider_HistoryDal();
            return Provider_Dal.Select_Provider_History(Provider);
        }

        public static Provider_HistoryObj Select_Current_Provider_History(int HistoryId)
        {
            Provider_HistoryDal Provider_Dal = new Provider_HistoryDal();
            return Provider_Dal.Select_Current_Provider_History(HistoryId);
        }


        public static bool Insert_Provider_History(Provider_HistoryObj HistoryObject)
        {
            Provider_HistoryDal Provider_Dal = new Provider_HistoryDal();
            return Provider_Dal.Insert_Provider_History(HistoryObject);
        }

        public static bool Update_Provider_History(Provider_HistoryObj HistoryObject)
        {
             Provider_HistoryDal Provider_Dal = new Provider_HistoryDal();
             return Provider_Dal.Update_Provider_History(HistoryObject);
        }
        public static bool Delete_Provider_History(int Provider_Id)
        {
             Provider_HistoryDal Provider_Dal = new Provider_HistoryDal();
             return Provider_Dal.Delete_Provider_History(Provider_Id);
        }
    }
}

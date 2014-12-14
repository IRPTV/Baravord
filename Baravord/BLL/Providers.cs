using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;

namespace Baravord.BLL
{
    class ProvidersBll
    {
        public static List<ProviderObj> Select_All_Providers()
        {
            ProviderDal Prov_Dal = new ProviderDal();
            return Prov_Dal.Select_All_Providers();
        }
        public static List<ProviderObj> Search_Providers(string ConditionQuery)
        {
             ProviderDal Prov_Dal = new ProviderDal();
             return Prov_Dal.Search_Providers(ConditionQuery);
        }
        public static bool Update_Provider(ProviderObj Obj)
        {
            ProviderDal Prov_Dal = new ProviderDal();
             return Prov_Dal.Update_Provider(Obj);
        }
        public static bool Insert_Provider(ProviderObj Obj)
        {
             ProviderDal Prov_Dal = new ProviderDal();
             return Prov_Dal.Insert_Provider(Obj);
        }
        public static List<string[]> Select_ProviderById(int Provider_Id)
        {  
            ProviderDal Prov_Dal = new ProviderDal();
            return Prov_Dal.Select_ProviderById(Provider_Id);
        }
        public static bool Delete_Provider(int Provider_Id)
        {
            ProviderDal Prov_Dal = new ProviderDal();
            return Prov_Dal.Delete_Provider(Provider_Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;

namespace Baravord.BLL
{
    class LanguageBll
    {
        public static List<LanguageObj> Select_All_Languages()
        {
            LanguageDal Lang_Dal = new LanguageDal();
            return Lang_Dal.Select_All_Language();
        }
        public static LanguageObj Select_Current_Language(int LanguageId)
        {
            LanguageDal Lang_Dal = new LanguageDal();
            return Lang_Dal.Select_Current_Language(LanguageId);
        }
        public static bool INSERT_LANGUAGE(LanguageObj Lang)
        {
           LanguageDal Lang_Dal = new LanguageDal();
           return Lang_Dal.INSERT_LANGUAGE(Lang);
        }
        public static bool UPDATE_LANGUAGE(LanguageObj Lang)
        {
            LanguageDal Lang_Dal = new LanguageDal();
            return Lang_Dal.UPDATE_LANGUAGE(Lang);
        }
         public static bool Delete_LANGUAGE(string LangId)
        {
             LanguageDal Lang_Dal = new LanguageDal();
             return Lang_Dal.Delete_LANGUAGE(LangId);
         }
    }
}

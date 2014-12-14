using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;
namespace Baravord.BLL
{
    class SignBll
    {
        public static bool Insert_Sign_Base(SignObj Obj)
        {
            SignDal Sign_Bll = new SignDal();
            return Sign_Bll.Insert_Sign_Base(Obj);
        }
        public static List<SignObj> Select_All_SignByChannelId(SignObj SObj)
        {
            SignDal Sign_Bll = new SignDal();
            return Sign_Bll.Select_All_SignByChannelId(SObj);
        }
        public static bool Delete_Sign(int SignId)
        {
            SignDal Sign_Bll = new SignDal();
            return Sign_Bll.Delete_Sign(SignId);
        }
        public static bool Update_Current_Sign(SignObj Obj)
        {
            SignDal Sign_Bll = new SignDal();
            return Sign_Bll.Update_Current_Sign(Obj);
        }
        public static SignObj Select_Current_Sign(int Id)
        {
            SignDal Sign_Bll = new SignDal();
            return Sign_Bll.Select_Current_Sign(Id);
        }
    }
}

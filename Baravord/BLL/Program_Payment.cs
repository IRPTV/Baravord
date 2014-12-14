using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;

namespace Baravord.BLL
{
    class Program_PaymentBll
    {
        public static bool Insert_Program_Payment(Program_PaymentObj InObj, ProgramObj ProgObjInput)
        {
            Program_PaymentDal Payment_Dal = new Program_PaymentDal();

             return Payment_Dal.Insert_Program_Payment(InObj, ProgObjInput);
        }
        public static List<Program_PaymentObj> Select_Program_Payment(ProgramObj ProgObjInput)
        {
              Program_PaymentDal Payment_Dal = new Program_PaymentDal();

              return Payment_Dal.Select_Program_Payment(ProgObjInput);
        }
        public static bool Delete_Current_Program_Payment(int Id)
        {
             Program_PaymentDal Payment_Dal = new Program_PaymentDal();

             return Payment_Dal.Delete_Current_Program_Payment(Id);

        }
    }
}

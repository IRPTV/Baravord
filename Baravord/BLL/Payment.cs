using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;

namespace Baravord.BLL
{
    class PaymentBll
    {
        public List<PaymentObj> Select_All_Payment()
        {
            PaymentDal Py_Dal = new PaymentDal();
            List<PaymentObj> Py_Lst = Py_Dal.Select_All_Payment();
            return Py_Lst;
        }
        public static PaymentObj Select_Current_Payment(int Id)
        {
            PaymentDal Py_Dal = new PaymentDal();
            return Py_Dal.Select_Current_Payment(Id);
        }
        public static bool Update_Current_Payment(PaymentObj Pym)
        {
            PaymentDal Py_Dal = new PaymentDal();
            return Py_Dal.Update_Current_Payment(Pym);
        }
        public static bool Insert_Payment_Base(PaymentObj Pym)
        {
            PaymentDal Py_Dal = new PaymentDal();
            return Py_Dal.Insert_Payment_Base(Pym);
        }
        public static List<string[]> Select_PaymentById(int PaymentId)
        {
            PaymentDal Py_Dal = new PaymentDal();
            return Py_Dal.Select_PaymentById(PaymentId);
        }
        public static bool Delete_Payment(int PaymentId)
        {
            PaymentDal Py_Dal = new PaymentDal();
            return Py_Dal.Delete_Payment(PaymentId);
        }
    }
}

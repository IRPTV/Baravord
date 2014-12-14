using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;

namespace Baravord.BLL
{
    class PlanStepBll
    {
        public static List<PlanStepObj> Select_All_PlanStep()
        {
            PlanStepDal Plnstp_Dal = new PlanStepDal();
            return Plnstp_Dal.Select_All_PlanStep();
        }

        public static PlanStepObj Select_Current_PlanStep(int Id)
        {
             PlanStepDal Plnstp_Dal = new PlanStepDal();
             return Plnstp_Dal.Select_Current_PlanStep(Id);
        }

        public static bool Update_Current_PlanStep(PlanStepObj PlnStp)
        {
            PlanStepDal Plnstp_Dal = new PlanStepDal();
            return Plnstp_Dal.Update_Current_PlanStep(PlnStp);
        }

        public static bool Insert_Step_Base(PlanStepObj PnlStp)
        {
             PlanStepDal Plnstp_Dal = new PlanStepDal();
             return Plnstp_Dal.Insert_Step_Base(PnlStp);
        }
        public static  List<string[]> Select_PlanStepById(int PlanStep_Id)
        {
            PlanStepDal Plnstp_Dal = new PlanStepDal();
            return Plnstp_Dal.Select_PlanStepById(PlanStep_Id);
        }
        public static bool Delete_PlanStep(int PlanStep_Id)
        {
            PlanStepDal Plnstp_Dal = new PlanStepDal();
            return Plnstp_Dal.Delete_PlanStep(PlanStep_Id);
        }
    }
}

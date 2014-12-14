using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.OBJECTS;
using Baravord.DAL;

namespace Baravord.BLL
{
    class SubjectBll
    {
        public List<SubjectObj> Select_All_Subject()
        {
            SubjectDal Sub_Dal = new SubjectDal();
            List<SubjectObj> Subject_Lst = Sub_Dal.Select_All_Subject();
            return Subject_Lst;
        }
        public static bool Insert_Program_Subject(List<SubjectObj> InLstStructs, ProgramObj ProgObj)
        {
            SubjectDal Sub_Dal = new SubjectDal();
            return Sub_Dal.Insert_Program_Subjects(InLstStructs, ProgObj);
        }
        public static List<SubjectObj> Select_Program_Subject(ProgramObj ProgObj)
        {
            SubjectDal Sub_Dal = new SubjectDal();
            return Sub_Dal.Select_Program_Subjects(ProgObj);
        }



        public static SubjectObj Select_Current_Subject_Base(SubjectObj Sub)
        {
             SubjectDal Sub_Dal = new SubjectDal();
             return Sub_Dal.Select_Current_Subject_Base(Sub);
        }

        public static bool Update_Subject_Base(SubjectObj Sub)
        {
            SubjectDal Sub_Dal = new SubjectDal();
            return Sub_Dal.Update_Subject_Base(Sub);
        }



        public static bool Insert_Subject_Base(SubjectObj Sub)
        {
             SubjectDal Sub_Dal = new SubjectDal();
             return Sub_Dal.Insert_Subject_Base(Sub);
        }
        public static List<string[]> Select_SubjectById(int Subject_Id)
        {
            SubjectDal Sub_Dal = new SubjectDal();
            return Sub_Dal.Select_SubjectById(Subject_Id);
        }
        public static bool Delete_Subject(int Subject_Id)
        {
            SubjectDal Sub_Dal = new SubjectDal();
            return Sub_Dal.Delete_Subject(Subject_Id);
        }
    }
}

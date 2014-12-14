using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baravord.OBJECTS;
namespace Baravord.TOOLS
{
    class GlobalObjectTools
    {
        public static void SetGlobalProgramObject(ProgramObj InProg)
        {
            //Set Golbal Programe in Main Form
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "Form1")
                {
                    ((Form1)(f)).GetGlobalProgram(InProg.Id);
                }
            }  
     
        }
    }    
}

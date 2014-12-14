using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Baravord.TOOLS
{
    class Calculation
    {
        public static string[] RowCost(int Unit, int Number, double PriceUnit, int SessionNumber, string SessionTime)
        {
            string[] RetValue = new string[2];

            string[] Time = SessionTime.Split(':');
            double Second = int.Parse(Time[0].Trim()) * 3600 + int.Parse(Time[1].Trim()) * 60 + int.Parse(Time[2].Trim());






            switch (Unit)
            {
                    //Per : Barname
                case 1:
                    RetValue[0] = ((PriceUnit * Number ) ).ToString();
                    RetValue[1] = (((PriceUnit * Number ) )*(SessionNumber)).ToString();

                    break;




                //Per : Dar Kol
                case 2:
                     RetValue[0] = "****";
                     RetValue[1] = (((PriceUnit * Number))).ToString();

                    break;



                //Per : Minute
                case 3:
                    RetValue[0] = ((PriceUnit * Number * Second) / 60).ToString();
                    RetValue[1] = (((PriceUnit * Number * Second) / 60) * (SessionNumber)).ToString();
                    break;

                //Per : Second
                case 4:
                    RetValue[0] = ((PriceUnit * Number * Second) ).ToString();
                    RetValue[1] = (((PriceUnit * Number * Second)) * (SessionNumber)).ToString();
                    break;


                //Per : jalase
                case 5:
                    RetValue[0] = ((PriceUnit * Number ) ).ToString();
                    RetValue[1] = (((PriceUnit * Number ) )*(SessionNumber)).ToString();
                    break;


                //Per : Nafar Roooz
                case 6:
                    RetValue[0] = "****";
                    RetValue[1] = (((PriceUnit * Number))).ToString();
                    break;


                default:
                    break;
            }

            

            return RetValue;
            
        }
        public static string RowCostSupport(int Unit, float Number, double PriceUnit, float Shift, float Month)
        {
            string RetValue = "------";




            switch (Unit)
            {
                //Per : Barname
                case 1:
                    RetValue = (PriceUnit * Number * Shift * Month).ToString();

                    break;




                //Per : Dar Kol
                case 2:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();

                    break;



                //Per : Minute
                case 3:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();
                    break;

                //Per : Second
                case 4:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();
                    break;


                //Per : jalase
                case 5:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();
                    break;


                //Per : Nafar Roooz
                case 6:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();
                    break;


                    //Nafar Maaaaaaaaaaaaaah
                case 7:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();
                    break;


                //kaaaaaaaaaaar
                case 8:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();
                    break;

                    //
                case 9:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();
                    break;

                case 10:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();
                    break;

                case 11:

                    RetValue = (PriceUnit * Number * Shift * Month).ToString();
                    break;


                default:
                    break;
            }



            return RetValue;

        }
    }
}

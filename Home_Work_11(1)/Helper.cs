using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    public class Helper
    {
        public static bool CheckSurname(string surname)
        {
            if (String.IsNullOrEmpty(surname)) return true;
            return false;
        }

        public static bool CheckFName(string name)
        {
            if (String.IsNullOrEmpty(name)) return true;
            return false;
        }

        public static bool CheckLName(string lName)
        {
            if (String.IsNullOrEmpty(lName)) return true;
            return false;
        }

        public static bool CheckPSeries(string pSeries)
        {
            if (String.IsNullOrEmpty(pSeries)) return true;
            return false;
        }
        
        public static bool CheckPNumber(string pNumber)
        {
            if (String.IsNullOrEmpty(pNumber)) return true;
            return false;
        }
        
        public static bool CheckTelephoneNumber(string tNumber)
        {
            if (String.IsNullOrEmpty(tNumber)) return true;
            return false;
        }
    }
}

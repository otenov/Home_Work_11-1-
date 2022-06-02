using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    class Consultant
    {
        public void View(Client c)
        {
            string dataClient = $"{c.Surname} {c.FName} {c.LName} {c.TelephoneNumber} {c.pasport}";
        }
    }
}

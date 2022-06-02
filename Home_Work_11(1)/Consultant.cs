using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    class Consultant
    {
        public string Surname { get; }
        public string FName  { get; }
        public string LName { get; }
        public string TelephoneNumber { get; set; }
        private byte PSeries { get; set; }
        private byte PNumber { get; set; }
        public string Pasport { get; }

        public Consultant(string surname, string fname, string lname, string telephjneNumber, byte pSeries, byte pNumber)
        {
            this.Surname = surname;
            this.FName = fname;
            this.LName = lname;
            this.TelephoneNumber = telephjneNumber;
            this.PSeries = pSeries;
            this.PNumber = pNumber;
            if (PSeries == 0 && PNumber == 0)
                {
                    Pasport = "-";
                }
            else
                {
                    Pasport = "**************";
                }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    class Repository
    {
        public Repository()
        {
            this.clients = new List<Consultant>();
        }
        public List<Consultant> clients;

        public Consultant CreateClient(string surname, string name, string lname, string number, byte pseria, byte pnumber)
        {
            Consultant c = new Consultant(surname, name, lname, number, pseria, pnumber);
            return c;
        }

        public void Add(Consultant c)
        {
            if (!clients.Contains(c))
            {
                clients.Add(c);
            }
        }

        public void Fill()
        {
            for (int i = 0; i < 10; i++)
            {
                Add(CreateClient("фамилия", "имя", "отчество", "телефон", 0, 1));
            }
        }
    }
}

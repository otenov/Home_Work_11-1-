using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    public class Manager : Worker, IManager
    {

        public Manager(string name, ObservableCollection<Client> clients) : base(name, clients)
        {

        }

        public void AddClient(string surname, string name, string lName, string passport, string tNumber)
        {
            Client newClient = new Client(surname, name, lName, tNumber, passport);

            clients.Add(newClient);

        }

        public bool ChangeClient(Client client, string surname, string name, string lName, string passport, string tNumber)
        {
            HistoryRecord historyRecord = new HistoryRecord(this); 
            if (client.Surname != surname)
            {
                historyRecord.Add(new Record("Surname", client.Surname, surname));
                client.Surname = surname;
            }
            if (client.FName != name)
            {
                historyRecord.Add(new Record("FName", client.FName, name));
                client.FName = name;
            }
            if (client.LName != lName)
            {
                historyRecord.Add(new Record("LName", client.LName, lName));
                client.LName = lName;
            }
            if (client.FName != name)
            {
                historyRecord.Add(new Record("FName", client.Passport, passport));
                client.Passport = passport;
            }
            if (client.TelephoneNumber != tNumber)
            {
                historyRecord.Add(new Record("TelephoneNumber", client.TelephoneNumber, tNumber));
                client.TelephoneNumber = tNumber;
            }
            if (historyRecord.Records.Count == 0) return true;
            client.historyChanges.Add(historyRecord);
            return false;
        }
    }
}

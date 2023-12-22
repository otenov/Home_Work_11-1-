﻿using System;
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
            HistoryRecord historyRecord = new HistoryRecord(this, 1 , HistoryRecord.TypeOfHistory.Add); //Как тут более правильно
            historyRecord.Add(new Record("Client", null, "Создан клиент"));
            Client newClient = new Client(surname, name, lName, tNumber, passport);
            newClient.HistoryChanges.Add(historyRecord);
            WorkerClients.Add(newClient);
        }

        public bool EditClient(Client client, string surname, string name, string lName, string passport, string tNumber)
        {

            HistoryRecord historyRecord = new HistoryRecord(this, client.HistoryChanges.Count + 1, HistoryRecord.TypeOfHistory.Edit); //когда делать операцию приведения типа
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
            if (client.Passport != passport)
            {
                historyRecord.Add(new Record("Passport", client.Passport, passport));
                client.Passport = passport;
            }
            if (client.TelephoneNumber != tNumber)
            {
                historyRecord.Add(new Record("TelephoneNumber", client.TelephoneNumber, tNumber));
                client.TelephoneNumber = tNumber;
            }
            if (historyRecord.Records.Count == 0) return true;
            client.HistoryChanges.Add(historyRecord);
            return false;
        }
    }
}
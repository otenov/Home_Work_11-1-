using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    public class Consultant : Worker, IConsultant
    {
        /// <summary>
        /// Коллекция, с которой работает консультант
        /// </summary>
        public ObservableCollection<Client> WorkerCollection { get; set; }


        public Consultant(string name, ObservableCollection<Client> clients) :base(name, clients)
        {
            WorkerCollection = CreateConsultantCollection(clients);
        }

        /// <summary>
        /// Метод, который Консультанту подготавливает коллекцию для работы с данными клиентов
        /// </summary>
        /// <param name="clients">Исходная коллекция</param>
        /// <returns>Коллекция для консультанта</returns>
        private ObservableCollection<Client> CreateConsultantCollection(ObservableCollection<Client> clients)
        {
            return DepersonalizationCollection(CopyCollection(clients));
        }

        /// <summary>
        /// Метод по подготовки коллекции для консультанта. Обезличивание
        /// </summary>
        /// <param name="clients">Коллекция данных</param>
        /// <returns></returns>
        private ObservableCollection<Client> DepersonalizationCollection(ObservableCollection<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (!String.IsNullOrEmpty(clients[i].Passport))
                    clients[i].Passport = "**** ******";
            }
            return clients;
        }

        public bool ChangedNumber(Client client, string newTNumber)
        {
            HistoryRecord historyRecord = new HistoryRecord(this);
            if (client.TelephoneNumber != newTNumber)
            {
                historyRecord.Add(new Record("TelephoneNumber", client.TelephoneNumber, newTNumber));
                client.TelephoneNumber = newTNumber;
            }
            if (historyRecord.Records.Count == 0) return true;
            client.historyChanges.Add(historyRecord);
            return false;
        }

        public void Sync(ObservableCollection<Client> clients)
        {
            {
                for (int i = 0; i <= clients.Count - 1; i++)
                {
                    base.clients[i].TelephoneNumber = clients[i].TelephoneNumber;
                }
            }
        }

        public override void Save(ObservableCollection<Client> clients)
        {
            Sync(clients);
            base.Save(base.clients);
        }
    }
}

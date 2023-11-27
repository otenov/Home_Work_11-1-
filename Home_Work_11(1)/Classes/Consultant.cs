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


        public Consultant(string name, Bank bank) :base(name, bank)
        {
            WorkerCollection = CreateConsultantCollection(bank.clients);

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
                //for (int j = 0; j < clients[i].historyChanges.Count; j++)
                //{
                //    for (int l = 0; l < clients[i].historyChanges[j].Records.Count; l++)
                //    {
                //        if (clients[i].historyChanges[j].Records[l].Field == "Passport")
                //        {
                //            clients[i].historyChanges[j].Records[l].PreviousValue = "*********";
                //            clients[i].historyChanges[j].Records[l].NewValue = "*********";
                //        }
                //    }
                //}

            }
            return clients;
        }


        /// <summary>
        /// Изменяет номер клиента
        /// </summary>
        /// <param name="client">Клиент номер которого будет изменён</param>
        /// <param name="newTNumber">Новый телефонный номер</param>
        /// <returns></returns>
        public bool EditTNumber(Client client, string newTNumber)
        {
            HistoryRecord historyRecord = new HistoryRecord(this);
            if (client.TelephoneNumber != newTNumber)
            {
                historyRecord.Add(new Record("TelephoneNumber", client.TelephoneNumber, newTNumber));
                //bank.clients[bank.clients.IndexOf(client)].TelephoneNumber = newTNumber;
                client.TelephoneNumber = newTNumber;
            }
            if (historyRecord.Records.Count == 0) return true;
            client.historyChanges.Add(historyRecord);
            //bank.clients[bank.clients.IndexOf(client)].historyChanges.Add(historyRecord);
            return false;
        }

        public void Sync()
        {
            {
                for (int i = 0; i <= WorkerCollection.Count - 1; i++)
                {
                    bank.clients[i].TelephoneNumber = WorkerCollection[i].TelephoneNumber;
                }
            }
        }

        public override void Save()
        {
            Sync();
            base.Save();
        }
    }
}

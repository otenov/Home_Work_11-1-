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
        public Consultant(string name, ObservableCollection<Client> clients) : base(name, clients)
        {

        }


        /// <summary>
        /// Изменяет номер клиента
        /// </summary>
        /// <param name="client">Клиент номер которого будет изменён</param>
        /// <param name="newTNumber">Новый телефонный номер</param>
        /// <returns></returns>
        public bool EditTNumber(Client client, string newTNumber)
        {
            HistoryRecord historyRecord = new HistoryRecord(this, client.HistoryChanges.Count + 1, HistoryRecord.TypeOfHistory.Edit);
            if (client.TelephoneNumber != newTNumber)
            {
                historyRecord.Add(new Record("TelephoneNumber", client.TelephoneNumber, newTNumber));
                client.TelephoneNumber = newTNumber;
            }
            if (historyRecord.Records.Count == 0) return true;
            client.HistoryChanges.Add(historyRecord);
            return false;
        }
    }
}

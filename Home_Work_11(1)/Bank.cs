using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    public class Bank
    {
        public ObservableCollection<Client> clients;

        public Bank()
        {
            clients = new ObservableCollection<Client>();
        }

        /// <summary>
        /// Метод, который Консультанту подготавливает коллекцию для работы с данными клиентов
        /// </summary>
        /// <param name="clients">Исходная коллекция</param>
        /// <returns>Коллекция для консультанта</returns>
        public ObservableCollection<Client> CreateCollectionForConsultant()
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
            //Можно
            //Следующая итерация цикла не должна зависеть от предыдущей итерации цикла 
            //Parallel.For(0, clients.Count, (i) =>
            //{
            //    if (!String.IsNullOrEmpty(clients[i].Passport))
            //        clients[i].Passport = "**** ******";
            //});
            for (int i = 0; i < clients.Count; i++)
            {
                if (!String.IsNullOrEmpty(clients[i].Passport))
                    clients[i].Passport = "**** ******";
                for (int j = 0; j < clients[i].historyChanges.Count; j++)
                {
                    for (int l = 0; l < clients[i].historyChanges[j].Records.Count; l++)
                    {
                        if (clients[i].historyChanges[j].Records[l].Field == "Passport")
                        {
                            clients[i].historyChanges[j].Records[l].PreviousValue = "*********";
                            clients[i].historyChanges[j].Records[l].NewValue = "*********";
                        }
                    }
                }
            }
            return clients;
        }

        /// <summary>
        /// Метод копирует исходную коллекцию
        /// </summary>
        /// <param name="clients">Оригинал коллекции</param>
        /// <returns>Копия коллекции</returns>
        private ObservableCollection<Client> CopyCollection(ObservableCollection<Client> clients)
        {
            ObservableCollection<Client> copyClients = new ObservableCollection<Client>();
            foreach (Client item in clients)
            {
                copyClients.Add(new Client(item));
            }
            return copyClients;
        }

        private void SyncTelephoneNumber(ObservableCollection<Client> WorkerCollection)
        {
            for (int i = 0; i <= WorkerCollection.Count - 1; i++)
            {
                clients[i].TelephoneNumber = WorkerCollection[i].TelephoneNumber;
            }
        }

        private void SyncHistoryChanges(ObservableCollection<Client> WorkerCollection)
        {
            for (int i = 0; i < clients.Count - 1; i++)
            {
                if (clients[i].historyChanges.Count == WorkerCollection[i].historyChanges.Count)
                {
                    continue;
                }

                for (int j = clients[i].historyChanges.Count + 1; j < WorkerCollection[i].historyChanges.Count - 1; j++)
                {
                    clients[i].historyChanges.Add(WorkerCollection[i].historyChanges[j]);
                }
            }
        }
        private void Sync(ObservableCollection<Client> WorkerCollection)
        {
            SyncTelephoneNumber(WorkerCollection);
            SyncHistoryChanges(WorkerCollection);
        }


        /// <summary>
        /// Сохранение всех изменений в файл
        /// </summary>
        /// <param name="w">Работник, сохраняющий данные</param>
        public void Save(Worker w)
        {
            if (w is Consultant)
            {
                Sync(w.WorkerClients);
                App.repositoryClients.SerializeClientsList(clients);
                return;
            }
            if (w is Manager)
            {
                App.repositoryClients.SerializeClientsList(clients);
                return;
            }
        }
    }
}

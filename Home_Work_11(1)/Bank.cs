using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    public class Bank //Спросить как должна лежать коллекция и репозиторий
    {
        /// <summary>
        /// Индексатор по позиции
        /// </summary>
        /// <param name="index">Позиция клиента в банке</param>
        /// <returns>Клиент</returns>
        public Client this[int index]
        {
            get { return Сlients[index]; }
            set { Сlients[index] = value; }
        }

        public ObservableCollection<Client> Сlients { get; private set; }

        public Bank()
        {
            Сlients = Repository.Clients;
        }

        /// <summary>
        /// Метод, который Консультанту подготавливает коллекцию для работы с данными клиентов
        /// </summary>
        /// <param name="clients">Исходная коллекция</param>
        /// <returns>Коллекция для консультанта</returns>
        public ObservableCollection<Client> CreateCollectionForConsultant()
        {
            return DepersonalizationCollection(CopyCollection(Сlients));
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
            //Parallel.For(0, Сlients.Count, (i) =>
            //{
            //    if (!String.IsNullOrEmpty(Сlients[i].Passport))
            //        Сlients[i].Passport = "**** ******";
            //});
            for (int i = 0; i < clients.Count; i++)
            {
                if (!String.IsNullOrEmpty(clients[i].Passport))
                    clients[i].Passport = "**** ******";
                for (int j = 0; j < clients[i].HistoryChanges.Count; j++)
                {
                    for (int l = 0; l < clients[i].HistoryChanges[j].Records.Count; l++)
                    {
                        if (clients[i].HistoryChanges[j].Records[l].Field == "Passport")
                        {
                            clients[i].HistoryChanges[j].Records[l].PreviousValue = "*********";
                            clients[i].HistoryChanges[j].Records[l].NewValue = "*********";
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
                Сlients[i].TelephoneNumber = WorkerCollection[i].TelephoneNumber;
            }
        }

        private void SyncHistoryChanges(ObservableCollection<Client> WorkerCollection)
        {
            for (int i = 0; i < Сlients.Count - 1; i++)
            {
                if (Сlients[i].HistoryChanges.Count == WorkerCollection[i].HistoryChanges.Count)
                {
                    continue;
                }

                for (int j = Сlients[i].HistoryChanges.Count + 1; j < WorkerCollection[i].HistoryChanges.Count - 1; j++)
                {
                    Сlients[i].HistoryChanges.Add(WorkerCollection[i].HistoryChanges[j]);
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
                Repository.SerializeClientsList(Сlients);
                return;
            }
            if (w is Manager)
            {
                Repository.SerializeClientsList(Сlients);
                return;
            }
        }
    }
}

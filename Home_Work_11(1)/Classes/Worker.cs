using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    public abstract class Worker
    {
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        protected string Name { get; set; }

        /// <summary>
        /// Метод копирует исходную коллекцию
        /// </summary>
        /// <param name="clients">Оригинал коллекции</param>
        /// <returns>Копия коллекции</returns>
        protected ObservableCollection<Client> CopyCollection(ObservableCollection<Client> clients)
        {
            ObservableCollection<Client> copyClients = new ObservableCollection<Client>();
            foreach (Client item in clients)
            {
                copyClients.Add(new Client(item));
            }
            return copyClients;
        }

        protected Bank bank;

        public Worker(string name, Bank bank)
        {
            Name = name;
            this.bank = bank;
        }

        /// <summary>
        /// Сохранение всех изменений в файл
        /// </summary>
        public virtual void Save()
        {
            App.repositoryClients.SerializeClientsList(bank.clients);
        }

    }
}

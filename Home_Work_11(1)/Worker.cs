using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    public abstract class Worker : BaseVM
    {
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        protected string Name { get; set; }


        public ObservableCollection<Client> WorkerClients { get; set; }

        public Worker(string name, ObservableCollection<Client> clients)
        {
            Name = name;
            WorkerClients = clients;
        }

        //Вопрос: Можно ли так реализовывать сравнения?
        public List<Client> SortClient()
        {
            List<Client> sortedClient = WorkerClients.ToList();
            sortedClient.Sort();
            return sortedClient;
        }
    }
}

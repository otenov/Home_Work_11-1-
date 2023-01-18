using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CreateFile;

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

        protected ObservableCollection<Client> clients;

        public abstract void Sync(ObservableCollection<Client> clients);


        public Worker(string name, ObservableCollection<Client> clients)
        {
            Name = name;
            this.clients = clients;
        }

        /// <summary>
        /// Метод для кнопки просмотр
        /// </summary>
        /// <param name="window"></param>
        public abstract void View(Window window);

        /// <summary>
        /// Метод для кнопки Cкрыть
        /// </summary>
        /// <param name="windoww"></param>
        public abstract void Hide(Window window);

        /// <summary>
        /// Метод для подтаскивания данных в поля и отображения кнопок при выборе экземпляра списка
        /// </summary>
        /// <param name="window"></param>
        public abstract void SelectionChangedMethod(Window window);

        /// <summary>
        /// Метод для кнопки изменить
        /// </summary>
        /// <param name="window"></param>
        public abstract void Changed(Window window);


        /// <summary>
        /// Сохранение всех изменений в файл
        /// </summary>
        protected void Save(ObservableCollection<Client> clients)
        {
            Sync(clients);
            App.repositoryClients.SerializeClientsList(this.clients);
        }

        /// <summary>
        /// Метод для кнопки Назад
        /// </summary>
        /// <param name="window"></param>
        public abstract void Back(Window window);

    }
}

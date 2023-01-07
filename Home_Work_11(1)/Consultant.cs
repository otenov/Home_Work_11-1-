using CreateFile;
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
    public class Consultant
    {
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Коллекция, с которой работает консультант
        /// </summary>
        protected ObservableCollection<Client> consultantCollection;

        /// <summary>
        /// Исходная коллекция
        /// </summary>
        protected ObservableCollection<Client> clients;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Consultant()
        {

        }

        /// <summary>
        /// Конструктор. Создаёт экземпляр с коллекцией, где сразу невидно паспорт.
        /// </summary>
        /// <param name="consultantWindow">Окно в котором работает консультант</param>
        /// <param name="name">Имя работника</param>
        /// <param name="clients">Исходная коллекция клиентов</param>
        public Consultant(ConsultantWindow consultantWindow, string name, ObservableCollection<Client> clients)
        {
            consultantCollection = new ObservableCollection<Client>();
            foreach (Client item in clients)
            {
                consultantCollection.Add(new Client(item));
            }

            this.consultantCollection = ConsultantCollection(consultantCollection);

            this.Name = name;
            this.clients = clients;

            //this.consultantCollection = ConsultantCollection(new ObservableCollection<Client>(clients));

            consultantWindow.lw.ItemsSource = this.consultantCollection;
            consultantWindow.lw.Visibility = Visibility.Hidden;
            consultantWindow.btnSave.IsEnabled = false;
            consultantWindow.btnChange.IsEnabled = false;
            consultantWindow.txt.IsEnabled = false;
        }

        /// <summary>
        /// Метод для кнопки просмотр
        /// </summary>
        /// <param name="window"></param>
        public virtual void View(Window window)
        {
            if (window is ConsultantWindow)
            {
                ConsultantWindow consultantWindow = window as ConsultantWindow;
                if (consultantWindow.lw.Visibility == Visibility.Visible) return;
                consultantWindow.lw.Visibility = Visibility.Visible;
                if (!(consultantWindow.lw.SelectedItem is null))
                {
                    consultantWindow.txt.IsEnabled = true;
                    consultantWindow.btnSave.IsEnabled = true;
                    consultantWindow.btnChange.IsEnabled = true;
                }
            }
        }

        /// <summary>
        /// Метод для кнопки Cкрыть
        /// </summary>
        /// <param name="windoww"></param>
        public virtual void Hide(Window window)
        {
            if (window is ConsultantWindow)
            {
                ConsultantWindow consultantWindow = window as ConsultantWindow;
                if (consultantWindow.lw.Visibility == Visibility.Hidden) return;
                consultantWindow.lw.Visibility = Visibility.Hidden;
                consultantWindow.btnSave.IsEnabled = false;
                consultantWindow.btnChange.IsEnabled = false;
                consultantWindow.txt.IsEnabled = false;
            }
        }

        /// <summary>
        /// Метод для подтаскивания данных в поля и отображения кнопок при выборе экземпляра списка
        /// </summary>
        /// <param name="window"></param>
        public virtual void SelectionChangedMethod(Window window)
        {
            if (window is ConsultantWindow)
            {
                ConsultantWindow consultantWindow = window as ConsultantWindow;
                consultantWindow.txt.IsEnabled = true;
                consultantWindow.txt.Text = ((Client)consultantWindow.lw.SelectedItem).TelephoneNumber;
                consultantWindow.btnSave.IsEnabled = true;
                consultantWindow.btnChange.IsEnabled = true;
            }
        }

        /// <summary>
        /// Метод для кнопки изменить
        /// </summary>
        /// <param name="window"></param>
        public virtual void Changed(Window window)
        {
            if (window is ConsultantWindow)
            {
                ConsultantWindow consultantWindow = window as ConsultantWindow;
                string number = consultantWindow.txt.Text;
                if (String.IsNullOrEmpty(number) || number.Length != 11)
                {
                    MessageBox.Show("Вы ввели неверный номер телефона\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    consultantWindow.txt.Text = default;
                    consultantWindow.txt.Focus();
                    consultantWindow.txt.ToolTip = "Был введён некорректный номер";
                }
                else
                {
                    ((Client)consultantWindow.lw.SelectedItem).TelephoneNumber = consultantWindow.txt.Text;
                    MessageBox.Show("Телефонный номер сохранён", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        /// Метод для кнопки Назад
        /// </summary>
        /// <param name="window"></param>
        public void Back(Window window)
        {
            Save();
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            window.Close();
        }

        /// <summary>
        /// Метод по подготовки коллекции для консультанта. Обезличивание
        /// </summary>
        /// <param name="clients">Коллекция данных</param>
        /// <returns></returns>
        protected ObservableCollection<Client> ConsultantCollection(ObservableCollection<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (!String.IsNullOrEmpty(clients[i].Pasport))
                    clients[i].Pasport = "**** ******";
            }
            return clients;
        }

        /// <summary>
        /// Метод синхронизирующий работу Менеджера и Консультанта
        /// </summary>
        public void Sync()
        {
            for (int i = 0; i < consultantCollection.Count ; i++)
            {
                clients[i].TelephoneNumber = consultantCollection[i].TelephoneNumber;
            }
        }

        /// <summary>
        /// Сохранение всех изменений в файл
        /// </summary>
        public virtual void Save()
        {
            Sync();
            App.repositoryClients.SerializeClientsList(clients);
        }

    }
}

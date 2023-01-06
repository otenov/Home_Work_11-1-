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
        /// <param name="clients">Коллекция с обезличенным паспортом</param>
        public Consultant(ConsultantWindow consultantWindow,string name)
        {
            this.Name = name;
            this.clients = ConsultantCollection();
            consultantWindow.lw.ItemsSource = this.clients;
            consultantWindow.lw.Visibility = Visibility.Hidden;
            consultantWindow.btnSave.IsEnabled = false;
            consultantWindow.btnChange.IsEnabled = false;
            consultantWindow.txt.IsEnabled = false;
        }

        /// <summary>
        /// Метод по подготовки коллекции для консультанта. Обезличивание
        /// </summary>
        /// <param name="clients">Коллекция данных</param>
        /// <returns></returns>
        private ObservableCollection<Client> ConsultantCollection()
        {
            var clients = DeserializeClientCollection();
            for (int i = 0; i < clients.Count; i++)
            {
                if (!String.IsNullOrEmpty(clients[i].Pasport))
                    clients[i].Pasport = "**** ******";
            }
            return clients;
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
            if(window is ConsultantWindow)
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
            window.Close();
            startWindow.Show();

        }

        /// <summary>
        /// Метод сохранения данных. Записывает данные в файл
        /// </summary>
        protected virtual void Save()
        {
            App.repositoryClients.SerializeClientsList(clients);
        }

        /// <summary>
        /// Считывает коллекцию с файла
        /// </summary>
        /// <returns></returns>
        protected ObservableCollection<Client> DeserializeClientCollection()
        {
            return App.repositoryClients.DeserializeObservableClient(App.repositoryClients.path);
        }

    }
}

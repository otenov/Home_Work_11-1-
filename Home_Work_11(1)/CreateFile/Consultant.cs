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

        ///// <summary>
        ///// Конструктор без параметров
        ///// </summary>
        //public Consultant()
        //{

        //}

        /// <summary>
        /// Конструктор. Создаёт экземпляр с коллекцией, где сразу невидно паспорт.
        /// </summary>
        /// <param name="consultantWindow">Окно в котором работает консультант</param>
        /// <param name="name">Имя работника</param>
        /// <param name="clients">Исходная коллекция клиентов</param>
        public Consultant(ConsultantWindow consultantWindow, string name, ObservableCollection<Client> clients) :base(name, clients)
        {
            WorkerCollection = CreateConsultantCollection(clients);

            //this.consultantCollection = DepersonalizationCollection(new ObservableCollection<Client>(clients));

            consultantWindow.lw.ItemsSource = WorkerCollection;
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
        private ObservableCollection<Client> DepersonalizationCollection(ObservableCollection<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (!String.IsNullOrEmpty(clients[i].Pasport))
                    clients[i].Pasport = "**** ******";
            }
            return clients;
        }

        /// <summary>
        /// Метод, который Консультанту подготавливает коллекцию для работы с данными клиентов
        /// </summary>
        /// <param name="clients">Исходная коллекция</param>
        /// <returns>Коллекция для консультанта</returns>
        private  ObservableCollection<Client> CreateConsultantCollection(ObservableCollection<Client> clients)
        {
            return DepersonalizationCollection(CopyCollection(clients));
        }

        public void View(Window window)
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

        public void Hide(Window window)
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

        public void SelectionChangedMethod(Window window)
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

        public void ChangedNumber(Window window)
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

        public void Back(Window window)
        {
            Save(WorkerCollection);
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            window.Close();
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

        protected override void Save(ObservableCollection<Client> clients)
        {
            Sync(clients);
            base.Save(clients);
        }

    }
}

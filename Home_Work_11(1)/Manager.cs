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
    public class Manager : Worker, IMyCollection
    {
        public ObservableCollection<Client> WorkerCollection { get; set; }

        /// <summary>
        /// Конструктор. Создаёт менеджера. Менеджер работает с исходной коллекцией
        /// </summary>
        /// <param name="managerWindow">Окно, в котором работает менеджер</param>
        /// <param name="Name">Имя менеджера</param>
        /// <param name="clients">Исходная коллекция</param>
        public Manager(ManagerWindow managerWindow, string name, ObservableCollection<Client> clients) : base(name, clients)
        {
            WorkerCollection = CopyCollection(clients);
            managerWindow.lw.ItemsSource = WorkerCollection;
            managerWindow.lw.Visibility = Visibility.Hidden;
            managerWindow.btnSave.IsEnabled = false;
            managerWindow.btnChange.IsEnabled = false;
            managerWindow.txt.IsEnabled = false;
        }

        /// <summary>
        /// Метод для кнопки Добавить
        /// </summary>
        /// <param name="window"></param>
        public void Add(Window window)
        {
            window.Hide();

            AddNewClientWindow addWindow = new AddNewClientWindow(this);

            addWindow.ShowDialog();

            window.Show();

        }

        /// <summary>
        /// Метод для добавление нового клиента в коллекцию менеджера
        /// </summary>
        /// <param name="addNewClientwWindow"></param>
        public void AddClient(AddNewClientWindow addNewClientwWindow)
        {
            Client newClient = new Client(addNewClientwWindow.surnameBox.Text, addNewClientwWindow.fnameBox.Text, addNewClientwWindow.lnameBox.Text, addNewClientwWindow.numberBox.Text, addNewClientwWindow.passportBox.Text);

            WorkerCollection.Add(newClient);

        }


        public override void Changed(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                string number = managerWindow.txt.Text;
                if (String.IsNullOrEmpty(number) || number.Length != 11)
                {
                    MessageBox.Show("Вы ввели неверный номер телефона\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    managerWindow.txt.Text = default;
                    managerWindow.txt.Focus();
                    managerWindow.txt.ToolTip = "Был введён некорректный номер";
                }
                else
                {
                    ((Client)managerWindow.lw.SelectedItem).TelephoneNumber = managerWindow.txt.Text;
                    MessageBox.Show("Телефонный номер сохранён", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public override void SelectionChangedMethod(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                managerWindow.txt.IsEnabled = true;
                managerWindow.txt.Text = ((Client)managerWindow.lw.SelectedItem).TelephoneNumber;
                managerWindow.btnSave.IsEnabled = true;
                managerWindow.btnChange.IsEnabled = true;
            }
        }

        public override void View(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                if (managerWindow.lw.Visibility == Visibility.Visible) return;
                managerWindow.lw.Visibility = Visibility.Visible;
                if (!(managerWindow.lw.SelectedItem is null))
                {
                    managerWindow.txt.IsEnabled = true;
                    managerWindow.btnSave.IsEnabled = true;
                    managerWindow.btnChange.IsEnabled = true;
                }
            }
        }

        public override void Hide(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                if (managerWindow.lw.Visibility == Visibility.Hidden) return;
                managerWindow.lw.Visibility = Visibility.Hidden;
                managerWindow.btnSave.IsEnabled = false;
                managerWindow.btnChange.IsEnabled = false;
                managerWindow.txt.IsEnabled = false;
            }
        }

        public override void Back(Window window)
        {
            Save(WorkerCollection);
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            window.Close();
        }

        public override void Sync(ObservableCollection<Client> clients)
        {
            for (int i = 0; i <= clients.Count - 1; i++)
            {
                
                if (i > base.clients.Count-1 && i <= clients.Count-1)
                {
                    base.clients.Add(clients[i]);
                }
                else { base.clients[i] = clients[i]; }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    public class Manager : Worker, IManager
    {

        /// <summary>
        /// Конструктор. Создаёт менеджера. Менеджер работает с исходной коллекцией
        /// </summary>
        /// <param name="managerWindow">Окно, в котором работает менеджер</param>
        /// <param name="Name">Имя менеджера</param>
        /// <param name="clients">Исходная коллекция</param>
        public Manager(ManagerWindow managerWindow, string name, ObservableCollection<Client> clients) : base(name, clients)
        {
            managerWindow.lw.ItemsSource = base.clients;
            managerWindow.lw.Visibility = Visibility.Hidden;
            managerWindow.btnSave.IsEnabled = false;
            managerWindow.btnChange.IsEnabled = false;
            managerWindow.TelephoneNumber.IsEnabled = false;
        }

        public void Add(Window window)
        {
            window.Hide();

            AddNewClientWindow addWindow = new AddNewClientWindow(this);

            addWindow.ShowDialog();

            window.Show();

        }

        public void AddClient(AddNewClientWindow addNewClientwWindow)
        {
            Client newClient = new Client(addNewClientwWindow.surnameBox.Text, addNewClientwWindow.fnameBox.Text, addNewClientwWindow.lnameBox.Text, addNewClientwWindow.numberBox.Text, addNewClientwWindow.passportBox.Text);

            clients.Add(newClient);

        }

        public void ChangedNumber(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                string number = managerWindow.TelephoneNumber.Text;
                if (String.IsNullOrEmpty(number) || number.Length != 11)
                {
                    MessageBox.Show("Вы ввели неверный номер телефона\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    managerWindow.TelephoneNumber.Text = default;
                    managerWindow.TelephoneNumber.Focus();
                    managerWindow.TelephoneNumber.ToolTip = "Был введён некорректный номер";
                }
                else
                {
                    ((Client)managerWindow.lw.SelectedItem).TelephoneNumber = managerWindow.TelephoneNumber.Text;
                    MessageBox.Show("Телефонный номер сохранён", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void SelectionChangedMethod(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                Client client = (Client)managerWindow.lw.SelectedItem;
                managerWindow.Surname.IsEnabled = true;
                managerWindow.Name.IsEnabled = true;
                managerWindow.LName.IsEnabled = true;
                managerWindow.PassportSeries.IsEnabled = true;
                managerWindow.PassportNumber.IsEnabled = true;
                managerWindow.TelephoneNumber.IsEnabled = true;
                managerWindow.Surname.Text = client.Surname;
                managerWindow.Name.Text = client.FName;
                managerWindow.LName.Text = client.LName;
                managerWindow.PassportSeries.Text = client.Passport.Substring(0,4);
                managerWindow.PassportNumber.Text = client.Passport.Substring(5,4);
                managerWindow.TelephoneNumber.Text = client.TelephoneNumber;
                managerWindow.btnSave.IsEnabled = true;
                managerWindow.btnChange.IsEnabled = true;
            }
        }

        public void View(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                if (managerWindow.lw.Visibility == Visibility.Visible) return;
                managerWindow.lw.Visibility = Visibility.Visible;
                if (!(managerWindow.lw.SelectedItem is null))
                {
                    managerWindow.TelephoneNumber.IsEnabled = true;
                    managerWindow.btnSave.IsEnabled = true;
                    managerWindow.btnChange.IsEnabled = true;
                }
            }
        }

        public void Hide(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                if (managerWindow.lw.Visibility == Visibility.Hidden) return;
                managerWindow.lw.Visibility = Visibility.Hidden;
                managerWindow.btnSave.IsEnabled = false;
                managerWindow.btnChange.IsEnabled = false;
                managerWindow.TelephoneNumber.IsEnabled = false;
            }
        }

        public void Back(Window window)
        {
            Save(clients);
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            window.Close();
        }

    }
}

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
            managerWindow.Surname.IsEnabled = false;
            managerWindow.Name.IsEnabled = false;
            managerWindow.LName.IsEnabled = false;
            managerWindow.PassportSeries.IsEnabled = false;
            managerWindow.PassportNumber.IsEnabled = false;
            managerWindow.TelephoneNumber.IsEnabled = false;
        }

        public void Add(Window window)
        {
            window.Hide();

            AddNewClientWindow addWindow = new AddNewClientWindow(this);

            addWindow.ShowDialog();

            window.Show();

        }

        public void AddClient(AddNewClientWindow addNewClientWindow)
        {
            Client newClient = new Client(addNewClientWindow.surnameBox.Text, addNewClientWindow.fnameBox.Text, addNewClientWindow.lnameBox.Text, addNewClientWindow.numberBox.Text, addNewClientWindow.passportBox.Text);

            clients.Add(newClient);

        }

        private void RecordClient(Client client,
            string surname, string name, string lName, string pSeries, string pNumber, string tNumber)
        {
            client.Surname = surname;
            client.FName = name;
            client.LName = lName;
            client.Passport = pSeries + " " + pNumber;
            client.TelephoneNumber = tNumber;
        }

        public void ChangeClient(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                string surname = managerWindow.Surname.Text;
                string name = managerWindow.Name.Text;
                string lname = managerWindow.LName.Text;
                string pSeries = managerWindow.PassportSeries.Text;
                string pNumber = managerWindow.PassportNumber.Text;
                string tNumber = managerWindow.TelephoneNumber.Text;

                if (Helper.Check(managerWindow, surname, name, lname, pSeries, pNumber, tNumber))
                {
                    Client client = (Client)managerWindow.lw.SelectedItem;
                    RecordClient(client, surname, name, lname, pSeries, pNumber, tNumber);
                    MessageBox.Show("Данные клиента обновлены", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    managerWindow.btnSave.IsEnabled = true;
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
                managerWindow.PassportSeries.Text = client.Passport.Substring(0, 4);
                managerWindow.PassportNumber.Text = client.Passport.Substring(5, 6);
                managerWindow.TelephoneNumber.Text = client.TelephoneNumber;
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

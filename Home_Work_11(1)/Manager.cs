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
    public class Manager : Consultant
    {
        new ObservableCollection<Client> clients;

        public Manager(ManagerWindow managerWindow, string Name, ObservableCollection<Client> clients) : base()
        {
            this.clients = clients;
            //base.clients = ConsultantCollection(new ObservableCollection < Client > (clients)); Также относится к вопросу по том как создавать дубли коллекции?
            managerWindow.lw.ItemsSource = this.clients;
            managerWindow.lw.Visibility = Visibility.Hidden;
            managerWindow.btnSave.IsEnabled = false;
            managerWindow.btnChange.IsEnabled = false;
            managerWindow.txt.IsEnabled = false;
        }

        /// <summary>
        /// Метод для кнопки изменить. Переопределён
        /// </summary>
        /// <param name="window"></param>
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

        /// <summary>
        /// Метод для подтаскивания данных в поля и отображения кнопок при выборе экземпляра списка. Переопределён
        /// </summary>
        /// <param name="window"></param>
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

        /// <summary>
        /// Метод для кнопки просмотр. Переопределён
        /// </summary>
        /// <param name="window"></param>
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

        /// <summary>
        /// Метод для кнопки скрыть. Переопределён
        /// </summary>
        /// <param name="windoww"></param>
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

            clients.Add(newClient);
        }

    }
}

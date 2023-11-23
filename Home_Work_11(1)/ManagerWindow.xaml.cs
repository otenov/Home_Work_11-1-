using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Home_Work_11_1_
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        IManager manager;

        public ManagerWindow(ObservableCollection<Client> clients)
        {
            InitializeComponent();
            manager = new Manager(this, "Сергей", clients);
            lw.ItemsSource = clients;
            lw.Visibility = Visibility.Hidden;
            btnSave.IsEnabled = false;
            btnChange.IsEnabled = false;
            Surname.IsEnabled = false;
            Name.IsEnabled = false;
            LName.IsEnabled = false;
            PassportSeries.IsEnabled = false;
            PassportNumber.IsEnabled = false;
            TelephoneNumber.IsEnabled = false;
        }

        /// <summary>
        /// Обработчик для кнопки Добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            manager.Add(this);
        }

        /// <summary>
        /// Обработчик для кнопоки Просмотр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonViewClick(object sender, RoutedEventArgs e)
        {
            lw.Visibility = Visibility.Visible;
            if (!(lw.SelectedItem is null))
            {
                TelephoneNumber.IsEnabled = true;
                btnChange.IsEnabled = true;
            }
        }

        /// <summary>
        /// Обработчик для кнопоки Скрыть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHideClick(object sender, RoutedEventArgs e)
        {
            if (lw.Visibility == Visibility.Hidden) return;
            lw.Visibility = Visibility.Hidden;
            btnSave.IsEnabled = false;
            btnChange.IsEnabled = false;
            TelephoneNumber.IsEnabled = false;
        }

        /// <summary>
        /// Обработчик для изменения выбора элемента списка. Реализован для изменения данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionChangedMethod(object sender, SelectionChangedEventArgs e)
        {
            Client client = (Client)lw.SelectedItem;
            Surname.IsEnabled = true;
            Name.IsEnabled = true;
            LName.IsEnabled = true;
            PassportSeries.IsEnabled = true;
            PassportNumber.IsEnabled = true;
            TelephoneNumber.IsEnabled = true;
            Surname.Text = client.Surname;
            Name.Text = client.FName;
            LName.Text = client.LName;
            PassportSeries.Text = client.Passport.Substring(0, 4);
            PassportNumber.Text = client.Passport.Substring(5, 6);
            TelephoneNumber.Text = client.TelephoneNumber;
            btnChange.IsEnabled = true;
        }

        /// <summary>
        /// Обработчик для кнопки Изменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            manager.ChangeClient(this);
        }

        /// <summary>
        /// Обработчик для кнопки Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            ((Manager)manager).Save((ObservableCollection<Client>)lw.ItemsSource); //Вопрос. Если метод будет protected, то я не смогу вызвать метод, когда обратно верну
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            ((Manager)manager).Save((ObservableCollection<Client>)lw.ItemsSource); // Переделать интерфейсы
            MessageBox.Show("Данные клиента успешно сохранены", "Оповещение", MessageBoxButton.OK);
        }
    }
}

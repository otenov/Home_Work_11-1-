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

namespace Home_Work_11_1_.View
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        IManager manager;

        public ManagerWindow()
        {
            InitializeComponent();
            manager = new Manager("Сергей", App.bank.Сlients);
            lw.ItemsSource = ((Manager)manager).WorkerClients;
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
            Hide();
            AddNewClientWindow addWindow = new AddNewClientWindow((Manager)manager);
            addWindow.ShowDialog();
            Show();
        }

        /// <summary>
        /// Обработчик для кнопоки Просмотр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonViewClick(object sender, RoutedEventArgs e)
        {
            if(lw.Visibility == Visibility.Visible) return;
            lw.Visibility = Visibility.Visible;
            if (!(lw.SelectedItem is null))
            {
                Surname.IsEnabled = true;
                Name.IsEnabled = true;
                LName.IsEnabled = true;
                PassportSeries.IsEnabled = true;
                PassportNumber.IsEnabled = true;
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
            Surname.IsEnabled = false;
            Name.IsEnabled = false;
            LName.IsEnabled = false;
            PassportSeries.IsEnabled = false;
            PassportNumber.IsEnabled = false;
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
            HistoryList.ItemsSource = client.HistoryChanges;
        }

        /// <summary>
        /// Обработчик для кнопки Изменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (Helper.CheckSurname(Surname.Text))
            {
                MessageBox.Show("Фамилия введена некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                Surname.Text = default;
                Surname.Focus();
                Surname.ToolTip = "Некорректные данные";
                return;
            }
            if (Helper.CheckName(Name.Text))
            {
                MessageBox.Show("Имя введено некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                Name.Text = default;
                Name.Focus();
                Name.ToolTip = "Некорректные данные";
                return;
            }
            if (Helper.CheckLName(LName.Text))
            {
                MessageBox.Show("Отчество введено некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                LName.Text = default;
                Name.Focus();
                Name.ToolTip = "Некорректные данные";
                return;
            }
            if (Helper.CheckPSeries(PassportSeries.Text))
            {
                MessageBox.Show("Серия паспорта введена некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                PassportSeries.Text = default;
                PassportSeries.Focus();
                PassportSeries.ToolTip = "Некорректные данные";
                return;
            }
            if (Helper.CheckPNumber(PassportNumber.Text))
            {
                MessageBox.Show("Номер паспорта введён некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                PassportNumber.Text = default;
                PassportNumber.Focus();
                PassportNumber.ToolTip = "Некорректные данные";
                return;
            }
            if (Helper.CheckTelephoneNumber(TelephoneNumber.Text))
            {
                MessageBox.Show("Вы ввели неверный номер телефона\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelephoneNumber.Text = default;
                TelephoneNumber.Focus();
                TelephoneNumber.ToolTip = "Некорректные данные";
                return;
            }
            if (manager.EditClient((Client)lw.SelectedItem,
                Surname.Text,
                Name.Text,
                LName.Text,
                PassportSeries.Text + " " + PassportNumber.Text,
                TelephoneNumber.Text))
            {
                MessageBox.Show("Данные не обновлены\n" +
                    "Вы не внесли никаких изменений", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show("Данные клиента успешно обновлены.\n" +
                "Сохраните изменения перед тем как закрыть приложение", "Оповещение", MessageBoxButton.OK);
            btnSave.IsEnabled = true;
        }

        /// <summary>
        /// Обработчик для кнопки Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            App.bank.Save((Manager)manager);
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            App.bank.Save((Manager)manager); // Переделать интерфейсы
            MessageBox.Show("Данные клиента успешно сохранены", "Оповещение", MessageBoxButton.OK);
        }

        private void MouseDoubleClickMethod(object sender, MouseButtonEventArgs e)
        { 
            HistoryRecordWindow historyRecordWindow = new HistoryRecordWindow((HistoryRecord)HistoryList.SelectedItem);
            historyRecordWindow.ShowDialog();
        }
    }
}

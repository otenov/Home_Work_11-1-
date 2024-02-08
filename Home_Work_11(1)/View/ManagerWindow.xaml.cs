using Home_Work_11_1_.Helpers;
using Home_Work_11_1_.ViewModel;
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

        public ManagerWindow()
        {
            InitializeComponent();
            DataContext = new ManagerVM(new WPFMessageBoxHelper(), App.windowCreator, Close);
        }

        /// <summary>
        /// Обработчик для кнопки Добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            //Hide();
            //AddNewClientWindow addWindow = new AddNewClientWindow((Manager)manager);
            //addWindow.ShowDialog();
            //Show();
        }

        /// <summary>
        /// Обработчик для кнопки Изменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            //if (Helper.CheckSurname(Surname.Text))
            //{
            //    MessageBox.Show("Фамилия введена некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    Surname.Text = default;
            //    Surname.Focus();
            //    Surname.ToolTip = "Некорректные данные";
            //    return;
            //}
            //if (Helper.CheckFName(Name.Text))
            //{
            //    MessageBox.Show("Имя введено некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    Name.Text = default;
            //    Name.Focus();
            //    Name.ToolTip = "Некорректные данные";
            //    return;
            //}
            //if (Helper.CheckLName(LName.Text))
            //{
            //    MessageBox.Show("Отчество введено некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    LName.Text = default;
            //    Name.Focus();
            //    Name.ToolTip = "Некорректные данные";
            //    return;
            //}
            //if (Helper.CheckPSeries(PassportSeries.Text))
            //{
            //    MessageBox.Show("Серия паспорта введена некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    PassportSeries.Text = default;
            //    PassportSeries.Focus();
            //    PassportSeries.ToolTip = "Некорректные данные";
            //    return;
            //}
            //if (Helper.CheckPNumber(PassportNumber.Text))
            //{
            //    MessageBox.Show("Номер паспорта введён некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    PassportNumber.Text = default;
            //    PassportNumber.Focus();
            //    PassportNumber.ToolTip = "Некорректные данные";
            //    return;
            //}
            //if (Helper.CheckTelephoneNumber(TelephoneNumber.Text))
            //{
            //    MessageBox.Show("Вы ввели неверный номер телефона\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    TelephoneNumber.Text = default;
            //    TelephoneNumber.Focus();
            //    TelephoneNumber.ToolTip = "Некорректные данные";
            //    return;
            //}
            //if (manager.EditClient((Client)lw.SelectedItem,
            //    Surname.Text,
            //    Name.Text,
            //    LName.Text,
            //    PassportSeries.Text + " " + PassportNumber.Text,
            //    TelephoneNumber.Text))
            //{
            //    MessageBox.Show("Данные не обновлены\n" +
            //        "Вы не внесли никаких изменений", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}
            //MessageBox.Show("Данные клиента успешно обновлены.\n" +
            //    "Сохраните изменения перед тем как закрыть приложение", "Оповещение", MessageBoxButton.OK);
            //btnSave.IsEnabled = true;
        }



        private void MouseDoubleClickMethod(object sender, MouseButtonEventArgs e)
        {
            //HistoryRecordWindow historyRecordWindow = new HistoryRecordWindow((HistoryRecord)HistoryList.SelectedItem, Close());
            //historyRecordWindow.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Home_Work_11_1_
{
    /// <summary>
    /// Логика взаимодействия для ConsultantWindow.xaml
    /// </summary>
    public partial class ConsultantWindow : Window
    {
        IConsultant consultant;

        public ConsultantWindow()  
        {

            #region Получение списка директорий в папке
            //DirectoryInfo dir = new DirectoryInfo(@"C:\Users\oteno\Desktop\Skillbox\Дз\Home_Work_11\CreateFile\bin\Debug");
            //foreach (var item in dir.GetFiles())          
            // 
            //    Debug.WriteLine($"{item.Name}");
            //}
            #endregion
            #region Debug
            //Проверка парсинга и отображения данных
            //foreach (var item in clients)
            //{
            //    Debug.WriteLine(item.FName);
            //    Debug.WriteLine(item.LName);
            //    Debug.WriteLine(item.Surname);
            //    Debug.WriteLine(item.TelephoneNumber);
            //    Debug.WriteLine(item.Passport);
            //}
            #endregion
            #region Парсинг данных из файла sd как List
            //List<Client> c = DeserializeList(@"C:\Users\oteno\Desktop\Skillbox\Дз\Home_Work_11\Home_Work_11(1)\sd");
            #endregion
            #region Построение коллекции observableCollection на основе List
            //ObservableCollection<Client> clients = new ObservableCollection<Client>(c); //построение коллекции observableCollection на основе list
            #endregion

            InitializeComponent();

            consultant = new Consultant("Сергей", App.bank.CreateCollectionForConsultant());
            lw.ItemsSource = ((Consultant)consultant).WorkerClients;
            lw.Visibility = Visibility.Hidden;
            btnSave.IsEnabled = false;
            btnChange.IsEnabled = false;
            TelephoneNumber.IsEnabled = false;
        }

        /// <summary>
        /// Обработчик для кнопки Просмотр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonViewClick(object sender, RoutedEventArgs e)
        {
            if (lw.Visibility == Visibility.Visible) return;
            lw.Visibility = Visibility.Visible;
            if (!(lw.SelectedItem is null))
            {
                TelephoneNumber.IsEnabled = true;
                btnChange.IsEnabled = true;
            }
        }

        /// <summary>
        /// Обработчик для кнопки Скрыть
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
            TelephoneNumber.IsEnabled = true;
            TelephoneNumber.Text = client.TelephoneNumber;
            btnChange.IsEnabled = true;
            HistoryList.ItemsSource = client.historyChanges;


            //
            //var arr = Enumerable.Range(1, client.historyChanges.Count).ToArray();
            //var historyChangesDict = client.historyChanges.ToDictionary(y => client.historyChanges.IndexOf(y) + 1, x => x);
            //HistoryList.ItemsSource = arr;
        }

        /// <summary>
        /// Обработчик для кнопки Изменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client)lw.SelectedItem;
            if (Helper.CheckTelephoneNumber(TelephoneNumber.Text))
            {
                MessageBox.Show("Вы ввели неверный номер телефона\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelephoneNumber.Text = default;
                TelephoneNumber.Focus();
                TelephoneNumber.ToolTip = "Некорректные данные";
                return;
            }
            if (consultant.EditTNumber(client, TelephoneNumber.Text))
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
            App.bank.Save((Consultant)consultant);
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            App.bank.Save((Consultant)consultant);
            MessageBox.Show("Данные клиента успешно сохранены", "Оповещение", MessageBoxButton.OK);
        }
    }
}

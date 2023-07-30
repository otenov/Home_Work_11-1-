using CreateFile;
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
            manager.View(this);
        }

        /// <summary>
        /// Обработчик для кнопоки Скрыть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHideClick(object sender, RoutedEventArgs e)
        {
            manager.Hide(this);
        }

        /// <summary>
        /// Обработчик для изменения выбора элемента списка. Реализован для изменения данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionChangedMethod(object sender, SelectionChangedEventArgs e)
        {
            manager.SelectionChangedMethod(this);
        }

        /// <summary>
        /// Обработчик для кнопки Изменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            manager.ChangedNumber(this);
        }

        /// <summary>
        /// Обработчик для кнопки Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            manager.Back(this);
        }
    }
}

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



        private void MouseDoubleClickMethod(object sender, MouseButtonEventArgs e)
        {
            ((ManagerVM)DataContext).ShowHistoryRecord();
        }
    }
}

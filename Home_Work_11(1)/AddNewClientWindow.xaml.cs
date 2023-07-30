using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Home_Work_11_1_
{
    /// <summary>
    /// Логика взаимодействия для AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {
        IManager manager;

        public AddNewClientWindow(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        /// <summary>
        /// Обработчик для кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnOkClick(object sender, RoutedEventArgs e)
        {
            manager.AddClient(this);
            this.Close();
        }

        /// <summary>
        /// Обработчик для кнопки Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

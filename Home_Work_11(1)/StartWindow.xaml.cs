using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выбор Консультанта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedConsultant(object sender, RoutedEventArgs e)
        {
            ConsultantWindow consultantWindow = new ConsultantWindow();
            consultantWindow.Show();
            this.Close();

        }

        /// <summary>
        /// Выбор Менеджера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedManager(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            this.Close();
        }
    }
}

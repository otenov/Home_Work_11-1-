using System;
using System.Collections.Generic;
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

namespace Home_Work_11_1_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Consultant c = new Consultant("фамилия", "имя", "отчество", "телефон", 0, 1);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

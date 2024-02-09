using Home_Work_11_1_.ViewModel;
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
//Вопрос: Еще раз пройтись по зависимостям
namespace Home_Work_11_1_.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {

        public AddNewClientWindow(AddNewClientVM addNewClientVM)
        {
            InitializeComponent();
            DataContext = addNewClientVM;
        }

        /// <summary>
        /// Обработчик для кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void btnOkClick(object sender, RoutedEventArgs e)
        //{
        //    //manager.AddClient(surnameBox.Text, fnameBox.Text, lnameBox.Text, passportBox.Text, numberBox.Text);
        //    //this.Close();
        //}
    }
}

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
using Home_Work_11_1_.ViewModel;
using Home_Work_11_1_.Helpers;

namespace Home_Work_11_1_.View
{
    //Вопрос-Ответ: Как сделать одно окно и для консультанта и для менеджера правильно с помощью наследования?
    //Вынести общие компоненты в отдельные view и использовать их во view. И для них отдельные VM

    /// <summary>
    /// Логика взаимодействия для ConsultantWindow.xaml
    /// </summary>
    public partial class ConsultantWindow : Window
    {
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
            //foreach (var item in Сlients)
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
            //ObservableCollection<Client> Сlients = new ObservableCollection<Client>(c); //построение коллекции observableCollection на основе list
            #endregion

            InitializeComponent();
            DataContext = new ConsultantVM(new WPFMessageBoxHelper(), App.windowCreator, Close);
        }

        private void MouseDoubleClickMethod(object sender, RoutedEventArgs e)
        {
            ((ConsultantVM)DataContext).ShowHistoryRecord();
        }
    }
}

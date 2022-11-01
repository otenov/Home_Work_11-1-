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
using CreateFile;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Home_Work_11_1_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Парсинг данных из файла sd как observableCollection
        // ObservableCollection < Client > clients1 = DeserializeObservableClient(
        // @"C:\Users\oteno\Desktop\Skillbox\Дз\Home_Work_11\Home_Work_11(1)\sd"); 

        //Парсинг данных из файла sd как List
        static List<Client> c = DeserializeList(@"C:\Users\oteno\Desktop\Skillbox\Дз\Home_Work_11\Home_Work_11(1)\sd");

        //Построение коллекции observableCollection на основе List
        ObservableCollection<Client> clients = new ObservableCollection<Client>(c); //построение коллекции observableCollection на основе list

        Consultant d;

        public MainWindow()
        {

            InitializeComponent();
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
            //    Debug.WriteLine(item.Pasport);
            //}
            #endregion
            d = new Consultant(this, "Сергей", clients);




        }

        // Метод для парсинга файла sd как list
        static List<Client> DeserializeList(string path)
        {
            List<Client> tempclients = new List<Client>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Client>));

            FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read);

            tempclients = xmlSerializer.Deserialize(fstream) as List<Client>;

            fstream.Close();

            return tempclients;
        }

        // Метод для парсинга файла sd как observableCollection
        static ObservableCollection<Client> DeserializeObservableClient(string path)
        {
            ObservableCollection<Client> tempclients = new ObservableCollection<Client>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Client>));

            FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read);

            tempclients = xmlSerializer.Deserialize(fstream) as ObservableCollection<Client>;

            fstream.Close();

            return tempclients;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            d.View(this);
            //lw.Visibility = Visibility.Visible;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            d.View(this);
            //lw.Visibility = Visibility.Hidden;
        }
    }
}

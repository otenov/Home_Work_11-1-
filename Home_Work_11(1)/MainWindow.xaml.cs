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

namespace Home_Work_11_1_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            //DirectoryInfo dir = new DirectoryInfo(@"C:\Users\oteno\Desktop\Skillbox\Дз\Home_Work_11\CreateFile\bin\Debug");
            //foreach (var item in dir.GetFiles())          
            //{
            //    Debug.WriteLine($"{item.Name}");

            //}

            List<Client> clients = DeserializeList(@"C:\Users\oteno\Desktop\Skillbox\Дз\Home_Work_11\CreateFile\bin\Debug\sd");

            foreach (var item in clients)
            {
                Debug.WriteLine(item.FName);
                Debug.WriteLine(item.LName);
                Debug.WriteLine(item.Pasport);
                Debug.WriteLine(item.Surname);
                Debug.WriteLine(item.TelephoneNumber);
            }

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

        }

        List<Client> DeserializeList(string path)
        {
            List<Client> tempclients = new List<Client>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Client>));

            FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read);

            tempclients = xmlSerializer.Deserialize(fstream) as List<Client>;

            fstream.Close();

            return tempclients;
        }

    }
}

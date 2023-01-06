using CreateFile;
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

        ObservableCollection<Client> clients;

        /// <summary>
        /// Метод для парсинга файла sd как observableCollection
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        ObservableCollection<Client> DeserializeObservableClient(string path)
        {
            ObservableCollection<Client> tempclients = new ObservableCollection<Client>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Client>));

            FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read);

            tempclients = xmlSerializer.Deserialize(fstream) as ObservableCollection<Client>;

            fstream.Close();

            return tempclients;
        }

        public StartWindow()
        {
            InitializeComponent();

            clients = DeserializeObservableClient(App.repositoryClients.path);
        }

        private void CheckedConsultant(object sender, RoutedEventArgs e)
        {
            ConsultantWindow consultantWindow = new ConsultantWindow(clients);
            consultantWindow.Show();
            this.Close();

        }

        private void CheckedManager(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow(clients);
            managerWindow.Show();
            this.Close();
        }
    }
}

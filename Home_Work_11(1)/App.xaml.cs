using CreateFile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Home_Work_11_1_
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Репозиторий
        /// </summary>
        static public Repository repositoryClients;

        /// <summary>
        /// Исходная коллекция клиентов
        /// </summary>
        static public ObservableCollection<Client> clients;

        /// <summary>
        /// Метод для парсинга файла sd как observableCollection
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static ObservableCollection<Client> DeserializeObservableClient(string path)
        {
            ObservableCollection<Client> tempclients = new ObservableCollection<Client>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Client>));

            FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read);

            tempclients = xmlSerializer.Deserialize(fstream) as ObservableCollection<Client>;

            fstream.Close();

            return tempclients;
        }

        static App()
        {
            if (!File.Exists("CollectionClients"))
            {
                repositoryClients = new Repository();
            }
            else
            {
                repositoryClients = new Repository("CollectionClients");
                clients = DeserializeObservableClient(repositoryClients.path);
            }
        }
    }
}

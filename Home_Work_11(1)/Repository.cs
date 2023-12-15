using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Home_Work_11_1_
{
    
    public static class Repository
    {
        private static ClientGenerator clientGenerator;

        /// <summary>
        /// Коллекция клиентов
        /// </summary>
        public static ObservableCollection<Client> Clients { get; }

        /// <summary>
        /// Полный путь к файлу с данными о клиенте
        /// </summary>
        private static string Path { get; set; }

        static Repository()
        {
            //TODO: Перенести в отдельный метод
            if (File.Exists("CollectionClients"))
            {
                Stream fStream = new FileStream("CollectionClients", FileMode.OpenOrCreate, FileAccess.Read);
                Path = (fStream as FileStream).Name;
                Clients = DeserializeObservableClient();
            }
            else
            {
                clientGenerator = new ClientGenerator();
                Clients = clientGenerator.CreateClientsCollection(50);
                SerializeClientsList(Clients);
            }
        }

        /// <summary>
        /// Создает на основе коллекции, созданной выше xml файл для удобного хранения и обмена данными
        /// </summary>
        /// <param name="clients">Коллекция для сериализации</param>
        public static void SerializeClientsList(ObservableCollection<Client> clients)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(ObservableCollection<Client>));

            Stream fStream = new FileStream("CollectionClients", FileMode.Create, FileAccess.Write);

            Path = (fStream as FileStream).Name;

            xmls.Serialize(fStream, clients);

            fStream.Close();

        }

        /// <summary>
        /// Метод для парсинга файла sd как observableCollection
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Client> DeserializeObservableClient()
        {
            ObservableCollection<Client> tempclients = new ObservableCollection<Client>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Client>));

            FileStream fstream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            tempclients = xmlSerializer.Deserialize(fstream) as ObservableCollection<Client>;

            fstream.Close();

            return tempclients;
        }
    }
}

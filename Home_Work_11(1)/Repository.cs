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
        /// <summary>
        /// Генератор рандомных клиентов
        /// </summary>
        private static ClientGenerator clientGenerator;

        /// <summary>
        /// Коллекция клиентов
        /// </summary>
        public static ObservableCollection<Client> Clients { get; }

        /// <summary>
        /// Полный путь к файлу с данными о клиенте
        /// </summary>
        private static string Path { get; set;}

        static Repository()
        {
            if (File.Exists("CollectionClients"))
            {
                Stream fStream = new FileStream("CollectionClients", FileMode.OpenOrCreate, FileAccess.Read);
                Path = (fStream as FileStream).Name;
                Clients = Load();
            }
            else
            {
                Clients = CreateRepository();
                Save(Clients);
            }
        }

        /// <summary>
        /// Создает на основе коллекции xml файл для удобного хранения и обмена данными
        /// </summary>
        /// <param name="clients">Коллекция для сериализации</param>
        public static void Save(ObservableCollection<Client> clients)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(ObservableCollection<Client>));

            Stream fStream = new FileStream("CollectionClients", FileMode.Create, FileAccess.Write);

            Path = (fStream as FileStream).Name;

            xmls.Serialize(fStream, clients);

            fStream.Close();

        }

        /// <summary>
        /// Парсит файл по указанному пути Path и возвращает коллекцию клиентов
        /// </summary>
        /// <returns>Коллекцию клиентов</returns>
        public static ObservableCollection<Client> Load()
        {
            ObservableCollection<Client> tempclients = new ObservableCollection<Client>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Client>));

            FileStream fstream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            tempclients = xmlSerializer.Deserialize(fstream) as ObservableCollection<Client>;

            fstream.Close();

            return tempclients;
        }

        /// <summary>
        /// Создаёт коллекцию клиентов с рандомными значениями
        /// </summary>
        /// <returns>Новая коллекция клиентов</returns>
        private static ObservableCollection<Client> CreateRepository()
        {
            clientGenerator = new ClientGenerator();
            return clientGenerator.CreateClientsCollection(50);
        }

    }
}

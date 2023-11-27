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
    
    public class Repository
    {
        public ClientGenerator clientGenerator;

        /// <summary>
        /// Коллекция клиентов
        /// </summary>
        private ObservableCollection<Client> clients;

        /// <summary>
        /// Полный путь к файлу с данными о клиенте
        /// </summary>
        public string path;

        /// <summary>
        /// Конструктор репозитория. Генерирует 50 клиентов и записывает их в файл
        /// </summary>
        public Repository()
        {
            clientGenerator = new ClientGenerator();
            clients = clientGenerator.CreateClientsCollection(50);
            SerializeClientsList(clients);
        }

        public Repository(string path)
        {
            Stream fStream = new FileStream("CollectionClients", FileMode.OpenOrCreate, FileAccess.Read);
            this.path = (fStream as FileStream).Name;
        }

        /// <summary>
        /// Создает на основе коллекции, созданной выше xml файл для удобного хранения и обмена данными
        /// </summary>
        /// <param name="clients">Коллекция для сериализации</param>
        public void SerializeClientsList(ObservableCollection<Client> clients)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(ObservableCollection<Client>));

            Stream fStream = new FileStream("CollectionClients", FileMode.Create, FileAccess.Write);

            this.path = (fStream as FileStream).Name;

            xmls.Serialize(fStream, clients);

            fStream.Close();

        }
    }
}

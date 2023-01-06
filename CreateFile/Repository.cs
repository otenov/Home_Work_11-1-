using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreateFile
{
    
    public class Repository
    {
        //Коллекция клиентов
        private ObservableCollection<Client> clients;

        /// <summary>
        /// Путь, по которому лежит файл с клиентами
        /// </summary>
        public string path;

        /// <summary>
        /// Конструктор. Создаёт 10 клиентов и записывает их в файл
        /// </summary>
        public Repository()
        {
            //Добавление клиентов в коллекцию
            this.clients = new ObservableCollection<Client>();
            for (int i = 0; i < 10; i++)
            {
                clients.Add(new Client());
            }

            //Демонстрация созданных клиентов в отладчике
            foreach (var item in clients)
            {
                Debug.WriteLine(item.ToString());
            }
            
            //Представление клиентов в удобном формате xml
            SerializeClientsList(this.clients);
        }

        /// <summary>
        /// Создает на основе коллекции, созданной выше xml файл для удобного хранения и обмена данными
        /// </summary>
        /// <param name="clients"></param>
        public void SerializeClientsList(ObservableCollection<Client> clients)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(ObservableCollection<Client>));

            Stream fStream = new FileStream("CollectionClients", FileMode.Create, FileAccess.Write);

            this.path = (fStream as FileStream).Name;

            xmls.Serialize(fStream, clients);

            fStream.Close();

        }

        /// <summary>
        /// Метод для парсинга файла sd как observableCollection
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ObservableCollection<Client> DeserializeObservableClient(string path)
        {
            ObservableCollection<Client> tempclients = new ObservableCollection<Client>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Client>));

            FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read);

            tempclients = xmlSerializer.Deserialize(fstream) as ObservableCollection<Client>;

            fstream.Close();

            return tempclients;
        }
    }
}

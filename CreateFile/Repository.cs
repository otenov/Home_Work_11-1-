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

        //Путь к файлу с клиентами
        public string path;

        public Repository()
        {
            //Добавление клиентов в коллекцию
            this.clients = new ObservableCollection<Client>();
            for (int i = 0; i < 50; i++)
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

        //Создает на основе коллекции, созданной выше xml файл для удобного хранения и обмена данными
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

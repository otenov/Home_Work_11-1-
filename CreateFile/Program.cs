using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace CreateFile
{
    public class Program
    {

        static void Main(string[] args)
        {
            //Создание клиентов и добавление их в коллекцию
            List<Client> clients = new List<Client>();
            for (int i =0; i < 50; i++)
            {
                clients.Add(new Client(i));
            }

            //Демонстрация созданных клиентов в консоли
            foreach (var item in clients)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

            //Представление клиентов в удобном формате xml
            SerializeClientsList(clients);

        }

        //Создает на основе коллекции, созданной выше xml файл для удобного хранения и обмена данными
        static public void SerializeClientsList(List<Client> clients) 
        {
            XmlSerializer xmls = new XmlSerializer(typeof(List<Client>));

            Stream fStream = new FileStream(@"C:\Users\oteno\Desktop\Skillbox\Дз\Home_Work_11\Home_Work_11(1)\sd", FileMode.Create, FileAccess.Write);

            xmls.Serialize(fStream, clients);
            fStream.Close();
        }
    }
}

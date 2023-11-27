using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    public class ClientGenerator
    {
        private readonly Random r;

        public ClientGenerator()
        {
            r = new Random(Guid.NewGuid().ToByteArray().Sum(x => x));
        }

        public ObservableCollection<Client> CreateClientsCollection(int number)
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            for (int i = 0; i < number; i++)
            {
                Client client = CreateClient();
                clients.Add(client);
            }
            return clients;

        }

        private Client CreateClient()
        {
            string surname = CreateFIO();
            string fName = CreateFIO();
            string lName = CreateFIO();
            string passport = CreatePassport();
            string tNumber = CreateTNumber();
            Client client = new Client(surname, fName, lName, tNumber, passport);
            return client;
        }

        // Создает случайное имя длинной от 3 до 15 символов
        private string CreateFIO()
        {
            int stringLength = r.Next(2, 15);
            string str = null;
            char letter;
            for (int i = 0; i <= stringLength; i++)
            {
                letter = Convert.ToChar(r.Next(0, 26) + 65); // +65 смещение, необходимое для создания имени с валидными буквами
                str += letter;
            }
            return str;
        }

        // Создает телефонный номер из 11 знаков
        private string CreateTNumber()
        {
            const int TNumberLength = 10;
            string str = "8";
            for (int i = 0; i < TNumberLength; i++)
            {
                str += Convert.ToString(r.Next(0, 9));
            }
            return str;
        }

        // Создаёт паспорт. Сначала создаётся переменная в которой хранится серия, затем переменная, в которой хранится номер.
        // Переменная passport хранит серию и номер вместе
        private string CreatePassport()
        {
            string series = Convert.ToString(r.Next(1000, 9999));
            string pNumber = Convert.ToString(r.Next(100_000, 999_999));
            string passport = series + " " + pNumber;
            return passport;
        }
    }
}

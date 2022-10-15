using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFile
{
    public class Client
    {
        //Список неоходимых переменных
        public string Surname { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string TelephoneNumber { get; set; }
        private string PSeries { get; set; }
        private string PNumber { get; set; }
        public string Pasport { get; }
        Random r;

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

        // Создаёт паспорт. Сначала создаётся переменная в которой хранится серия, затем переменная, которой хранится номер.
        // Переменная passport хранит серию и номер вместе
        public string CreatePassport()
        {
            string series = Convert.ToString(r.Next(1000, 9999));
            string pNumber = Convert.ToString(r.Next(100_000, 999_999));
            string passport = series + " " + pNumber;
            return passport;
        }

        // Конструктор без параметров
        public Client()
        {

        }

        //Конструктор с параметром. i - номер клиента, необходим для уникальности. Каждый раз создается новый экземпляр Random, не дублируя старый
        public Client(int i)
        {
            this.r = new Random(i);
            this.Surname = CreateFIO();
            this.FName = CreateFIO();
            this.LName = CreateFIO();
            this.TelephoneNumber = CreateTNumber();
            this.Pasport = CreatePassport();
            this.PSeries = this.Pasport.Substring(0, 4);
            this.PNumber = this.Pasport.Substring(5, 6);
        }

        //Переопределённый метод ToString() для удобства, закрепления
        public override string ToString()
        {
            string s = $"{Surname,20} {LName,20} {FName,20} {TelephoneNumber,13} {Pasport,13}";
            return s;
        }

    }
}

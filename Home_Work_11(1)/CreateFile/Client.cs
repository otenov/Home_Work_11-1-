using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Home_Work_11_1_
{
    public class Client : INotifyPropertyChanged
    {
        //Список необходимых свойств
        private string surname;
        public string Surname 
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        private string fName;
        public string FName
        {
            get { return fName; }
            set { fName = value; OnPropertyChanged("FName"); }
        }
        private string lName;
        public string LName
        {
            get { return lName; }
            set {lName = value; OnPropertyChanged("LName"); }
        }
        private string telephoneNumber;
        public string TelephoneNumber
        {
            get { return telephoneNumber; }

            set
            {
                telephoneNumber = value;
                OnPropertyChanged("TelephoneNumber");
            }
        }
        private string PSeries { get; set; }
        private string PNumber { get; set; }
        private string passport;
        public string Passport
        {
            get { return passport; }
            set { passport = value; OnPropertyChanged("Passport"); }
        }

        public ObservableCollection<HistoryRecord> historyChanges;

        Random r;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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
            this.r = new Random(Guid.NewGuid().ToByteArray().Sum(x => x));
            this.Surname = CreateFIO();
            this.FName = CreateFIO();
            this.LName = CreateFIO();
            this.TelephoneNumber = CreateTNumber();
            this.Passport = CreatePassport();
            this.PSeries = this.Passport.Substring(0, 4);
            this.PNumber = this.Passport.Substring(5, 6);
            historyChanges = new ObservableCollection<HistoryRecord>();
        }

        /// <summary>
        /// Конструктор для копирования
        /// </summary>
        /// <param name="item">Оригинал</param>
        public Client(Client item)
        {
            this.r = item.r;
            this.Surname = item.Surname;
            this.FName = item.FName;
            this.LName = item.LName;
            this.TelephoneNumber = item.telephoneNumber;
            this.Passport = item.Passport;
            this.PSeries = item.PSeries;
            this.PNumber = item.PNumber;
            this.historyChanges = item.historyChanges;
        }


        public Client(string surname, string fName, string lName, string telephoneNumber, string passport, Manager manager)
        {
            this.Surname = surname;
            this.FName = fName;
            this.LName = lName;
            this.TelephoneNumber = telephoneNumber;
            this.Passport = passport;
            HistoryRecord historyRecord = new HistoryRecord(manager);
            historyRecord.Add(new Record("Client", null, "Создан клиент"));
            historyChanges = new ObservableCollection<HistoryRecord>() { historyRecord};
        }

        //Переопределённый метод ToString() для удобства, закрепления
        public override string ToString()
        {
            string s = $"{Surname,20} {LName,20} {FName,20} {TelephoneNumber,13} {Passport,13}";
            return s;
        }

    }
}

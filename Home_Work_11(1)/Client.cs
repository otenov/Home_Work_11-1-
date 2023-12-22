﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Home_Work_11_1_
{
    public class Client : BaseVM, INotifyPropertyChanged
    {
        private static int staticId;

        private static int NextId()
        {
            staticId++;
            return staticId;
        }

        static Client()
        {
            staticId = 0;
        }
        //Список необходимых свойств

        public int Id { get; set; }
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
        private string passport;
        public string Passport
            
        {
            get
            {
                return passport; 
            }
            set { passport = value; OnPropertyChanged("Passport"); }
        }

        public ObservableCollection<HistoryRecord> HistoryChanges { get; set; }

        // Конструктор без параметров
        public Client()
        {

        }

        /// <summary>
        /// Конструктор для копирования
        /// </summary>
        /// <param name="item">Оригинал</param>
        public Client(Client item)    //Этот код окей?
        {
            this.Id = item.Id;
            this.Surname = item.Surname;
            this.FName = item.FName;
            this.LName = item.LName;
            this.TelephoneNumber = item.telephoneNumber;
            this.Passport = item.Passport;
            this.HistoryChanges = item.HistoryChanges;
        }


        public Client(string surname, string fName, string lName, string tNumber, string passport)
        {
            this.Id = NextId();
            this.Surname = surname;
            this.FName = fName;
            this.LName = lName;
            this.TelephoneNumber = tNumber;
            this.Passport = passport;
            HistoryChanges = new ObservableCollection<HistoryRecord>();
        }

        //Переопределённый метод ToString() для удобства, закрепления
        public override string ToString()
        {
            string s = $"{Surname,20} {LName,20} {FName,20} {TelephoneNumber,13} {Passport,13}";
            return s;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    public class HistoryRecord
    {
        public DateTime DateOfHistory { get;  set; } //Как работать с датой и временем

        private string author;

        public string Author
        {
            get => author;
            set
            {
                author = value;
            }
        }

        public string NumberOfRecord { get; set; }

        public enum TypeOfHistory
        {
            Add,
            Edit,
            Delete
        }

        public string TypeOfHistoryString { get; }

        public HistoryRecord()
        {
                
        }

        public ObservableCollection<Record> Records { get; set; }

        public HistoryRecord(Worker worker, string numberOfRecord, TypeOfHistory typeOfHistory)
        {
            NumberOfRecord = numberOfRecord;
            Author = WhoIsAuthor(worker);
            DateOfHistory = DateTime.Now; //Как вывести минуты и часы
            if (typeOfHistory == TypeOfHistory.Add) TypeOfHistoryString = "Добавление";
            if (typeOfHistory == TypeOfHistory.Edit) TypeOfHistoryString = "Изменение";
            Records = new ObservableCollection<Record>();
        }

        public void Add(Record record)
        {
            Records.Add(record);
        }

        private string WhoIsAuthor(Worker w)
        {
            if (w is Consultant) return "Консультант";
            if (w is Manager) return "Менеджер";
            return "";
        }
    }

    public class Record
    {
        //public enum TypeOfChange
        //{
        //    Change,
        //    Add,
        //    Delete
        //}

        public string Field { get; set; }

        public string PreviousValue { get; set; }

        public string NewValue { get; set; }



        public Record(string field, string previousValue, string newValue)
        {
            this.Field = field;

            this.PreviousValue = previousValue;

            this.NewValue = newValue;
        }

        public Record()
        {

        }
    }
}



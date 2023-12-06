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
        public DateTime DateOfHistory { get; set; }

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

        public HistoryRecord()
        {
                
        }

        public ObservableCollection<Record> Records { get; private set; }

        public HistoryRecord(Worker worker, string numberOfRecord)
        {
            NumberOfRecord = numberOfRecord;
            Author = WhoIsAuthor(worker);
            DateOfHistory = DateTime.Now;
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



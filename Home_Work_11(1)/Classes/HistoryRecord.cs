using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFile
{
    public struct HistoryRecord
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

        public List<Record> Records;

    }

    public struct Record
    {
        public enum TypeOfChange
        {
            Change,
            Add,
            Delete
        }

        public string margin;

        public string previousValue;

        public string newValue;
    }
}



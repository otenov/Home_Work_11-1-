using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_.ViewModel
{
    public class HistoryRecordVM :BaseVM
    {
        public HistoryRecordVM(HistoryRecord historyRecord, Action CloseAction):
            base(CloseAction)
        {
            HistoryRecords = historyRecord.Records;
            TextBlockAuthor = historyRecord.Author;
            TextBlockDate = historyRecord.DateOfHistory.ToString();
            TextBlockTypeOfHistory = historyRecord.TypeOfHistoryString;
            WindowCreator = new WPFWindowCreator();
            WindowCreator.CreateWindow(Windows.HistoryRecordWindow, this);
        }

        public IWindowCreator WindowCreator { get; }

        public string TextBlockAuthor { get; }

        public string TextBlockDate { get; }

        public string TextBlockTypeOfHistory { get;}

        public ObservableCollection<Record> HistoryRecords { get; }
    }
}

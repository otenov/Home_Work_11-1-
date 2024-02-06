﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_.ViewModel
{
    public class HistoryRecordVM :BaseVM
    {
        public HistoryRecordVM(HistoryRecord historyRecord)
        {
            HistoryRecords = historyRecord.Records;
            TextBlockAuthor = historyRecord.Author;
            TextBlockDate = historyRecord.DateOfHistory.ToString();
            TextBlockTypeOfHistory = historyRecord.TypeOfHistoryString;
            //WindowCreator.CreateWindow(Windows.HistoryRecordWindow, this); 
            //TODO: Его надо сделать статическим в app
        }

        public IWindowCreator WindowCreator { get; } //Не нужен

        public string TextBlockAuthor { get; }

        public string TextBlockDate { get; }

        public string TextBlockTypeOfHistory { get;}

        public ObservableCollection<Record> HistoryRecords { get; }
    }
}

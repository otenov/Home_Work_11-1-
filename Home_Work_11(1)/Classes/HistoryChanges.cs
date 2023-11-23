using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    public class HistoryChanges
    {
        public ObservableCollection<HistoryRecord> historyChanges;

        public HistoryChanges()
        {
            historyChanges = new ObservableCollection<HistoryRecord>();
        }

        HistoryRecord historyR;
    }
}


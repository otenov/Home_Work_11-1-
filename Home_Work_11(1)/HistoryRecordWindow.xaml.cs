using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Home_Work_11_1_
{
    /// <summary>
    /// Логика взаимодействия для HistoryRecordWindow.xaml
    /// </summary>
    public partial class HistoryRecordWindow : Window
    {
        HistoryRecord HistoryRecord;
        public HistoryRecordWindow(ObservableCollection<Record> records)
        {
            InitializeComponent();

            HistoryRecordList.ItemsSource = records;
        }
    }
}

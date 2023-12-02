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

        public HistoryRecordWindow(HistoryRecord historyRecord)
        {
            InitializeComponent();

            Author.Text = historyRecord.Author;
            Date.Text = historyRecord.DateOfHistory.Date.ToString();

            HistoryRecordList.ItemsSource = historyRecord.Records;
        }

        private void MouseDoubleClickMethod(object sender, MouseButtonEventArgs e)
        {
            RecordWindow recordWindow = new RecordWindow((Record)HistoryRecordList.SelectedItem);
            recordWindow.ShowDialog();
        }
    }
}

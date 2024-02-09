using Home_Work_11_1_.View;
using Home_Work_11_1_.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    public class WPFWindowCreator : IWindowCreator
    {
        //Вопрос: Можно ли здесь использовать UI компоненты? Если да, то чем это выгодно?
        public void CreateWindow(Windows window, BaseVM vm)
        {
            if(window == Windows.StartWindow)
            {
                StartWindow startWindow = new StartWindow();
                startWindow.Show();
                return;
            }
            if(window == Windows.ConsultantWindow)
            {
                ConsultantWindow consultantWindow = new ConsultantWindow();
                consultantWindow.Show();
                return;
            }
            if (window == Windows.ManagerWindow)
            {
                var managerWindow = new ManagerWindow();
                managerWindow.Show();
                return;
            }
            if (window == Windows.HistoryRecordWindow)
            {
                var historyRecordWindow = new HistoryRecordWindow((HistoryRecordVM)vm);
                historyRecordWindow.Show();
                return;
            }
            if (window == Windows.AddNewClientWindow)
            {
                var addNewClientWindow = new AddNewClientWindow((AddNewClientVM)vm);
                addNewClientWindow.ShowDialog();
                return;
            }
        }
    }
}

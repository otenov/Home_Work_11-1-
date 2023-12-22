using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Home_Work_11_1_.View;

namespace Home_Work_11_1_.ViewModel
{
    class StartWindowVM : BaseVM
    {
        public ICommand ConsultantWindowLoadCommand { get; set; }

        public ICommand ManagerWindowLoadCommand { get; set; }
        

        private void ConsultantWindowLoad()
        {
            ConsultantWindow consultantWindow = new ConsultantWindow(); //Ui эллемент
            CloseAction.Invoke();
            consultantWindow.Show();
        }

        private void ManagerWindowLoad()
        {
            ManagerWindow managerWindow = new ManagerWindow(); //Ui эллемент
            CloseAction.Invoke();
            managerWindow.Show();
        }

        public StartWindowVM(Action action)
        {
            ConsultantWindowLoadCommand = new CommandBase(ConsultantWindowLoad);
            ManagerWindowLoadCommand = new CommandBase(ManagerWindowLoad);
            base.CloseAction = action;
        }

    }
}

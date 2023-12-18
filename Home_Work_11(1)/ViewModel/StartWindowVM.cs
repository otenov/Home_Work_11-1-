using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Home_Work_11_1_.View;

namespace Home_Work_11_1_.ViewModel
{
    class StartWindowVM //TODO: Убрать View из VM
    {
        public ICommand ConsultantWindowLoadCommand { get; set; }

        public ICommand ManagerWindowLoadCommand { get; set; }

        private Action Action { get; set; }

        private void ConsultantWindowLoad()
        {
            ConsultantWindow consultantWindow = new ConsultantWindow();
            Action.Invoke();
            consultantWindow.Show();
        }

        private void ManagerWindowLoad()
        {
            ManagerWindow managerWindow = new ManagerWindow();
            Action.Invoke();
            managerWindow.Show();
        }

        public StartWindowVM(Action action)
        {
            ConsultantWindowLoadCommand = new CommandBase(ConsultantWindowLoad);
            ManagerWindowLoadCommand = new CommandBase(ManagerWindowLoad);
            this.Action = action;
        }

    }
}

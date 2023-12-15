using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Home_Work_11_1_
{
    class StartWindowVM
    {
        public ICommand ConsultantWindowLoadCommand { get; set; }

        public ICommand ManagerWindowLoadCommand { get; set; }

        private void ConsultantWindowLoad()
        {
            ConsultantWindow consultantWindow = new ConsultantWindow();
            consultantWindow.Show();
            //this.Close();
        }

        private void ManagerWindowLoad()
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            //this.Close();
        }

        public StartWindowVM()
        {
            ConsultantWindowLoadCommand = new CommandBase(ConsultantWindowLoad);
            ManagerWindowLoadCommand = new CommandBase(ManagerWindowLoad);
        }

    }
}

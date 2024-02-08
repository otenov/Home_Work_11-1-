using Home_Work_11_1_.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Home_Work_11_1_.ViewModel
{
    public class ManagerVM : BaseVM, ICloseable
    {
        public ManagerVM(IMessageBoxHelper messageBoxHelper,IWindowCreator windowCreator, Action CloseAction)
        {
            this.messageBoxHelper = messageBoxHelper;
            this.windowCreator = windowCreator;
            this.CloseAction = CloseAction;
            manager = new Manager("Сергей", App.bank.Сlients);
            ListOfClientsVM = new ListOfClientsVM(manager.WorkerClients);
            ButtonViewClickCommand = new CommandBase(ButtonViewClick);
            ButtonHideClickCommand = new CommandBase(ButtonHideClick);
            ButtonBackClickCommand = new CommandBase(ButtonBackClick);
            ButtonSaveClickCommand = new CommandBase(ButtonSaveClick);
            IsEnabledEditPanel = false;
            IsEnabledButtonSave = false;
        }

        public ListOfClientsVM ListOfClientsVM { get; set; }

        private Manager manager;

        private IWindowCreator windowCreator;

        private IMessageBoxHelper messageBoxHelper;

        private bool isEnabledEditPanel;
        public bool IsEnabledEditPanel
        {
            get
            {
                return isEnabledEditPanel;
            }

            set
            {
                isEnabledEditPanel = value;
                OnPropertyChanged(nameof(IsEnabledEditPanel));
            }
        }

        private bool isEnabledButtonSave;
        public bool IsEnabledButtonSave
        {
            get
            {
                return isEnabledButtonSave;
            }

            set
            {
                isEnabledButtonSave = value;
                OnPropertyChanged(nameof(IsEnabledButtonSave));
            }
        }

        public ICommand ButtonViewClickCommand { get; set; }

        public ICommand ButtonHideClickCommand { get; set; }

        public ICommand ButtonBackClickCommand { get; set; }

        public ICommand ButtonSaveClickCommand { get; set; }

        public Action CloseAction { get ; set; }

        private void ButtonViewClick()
        {
            if (ListOfClientsVM.ListViewVisibility == Visibility.Visible) return;
            ListOfClientsVM.ListViewVisibility = Visibility.Visible;
            if (!(ListOfClientsVM.SelectedClient is null))
            {
                IsEnabledEditPanel = true;
            }
        }

        private void ButtonHideClick()
        {
            if (ListOfClientsVM.ListViewVisibility == Visibility.Hidden) return;
            ListOfClientsVM.ListViewVisibility = Visibility.Hidden;
            IsEnabledButtonSave = false;
            IsEnabledEditPanel = false;
        }

        private void ButtonBackClick()
        {
            App.bank.Save(manager);
            windowCreator.CreateWindow(Windows.StartWindow, null);
            CloseAction.Invoke();
        }

        private void ButtonSaveClick()
        {
            App.bank.Save(manager);
            messageBoxHelper.Show("Данные клиента успешно сохранены",
                "Оповещение",
                MessageBoxImage.Information);
        }


        //Вопрос: Как поступить с одинаковым функционалом? Его тоже в отдельную vm?
    }
}

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
            manager = new Manager("Сергей", App.bank.Сlients);
            ButtonViewClickCommand = new CommandBase(ButtonViewClick);
            ButtonHideClickCommand = new CommandBase(ButtonHideClick);
            ButtonBackClickCommand = new CommandBase(ButtonBackClick);
            WindowCreator = windowCreator;
            MessageBoxHelper = messageBoxHelper;
            IsEnabledEditPanel = false;
            ListViewVisibility = Visibility.Hidden;
            SelectedClient = new Client();
            this.CloseAction = CloseAction;
        }

        private Manager manager;

        private IWindowCreator WindowCreator { get; set; }

        private IMessageBoxHelper MessageBoxHelper { get; set; }

        private Visibility listViewVisibility;

        public Visibility ListViewVisibility
        {
            get => listViewVisibility;
            set
            {
                listViewVisibility = value;
                OnPropertyChanged(nameof(ListViewVisibility));
            }
        }

        private Client selectedClient;

        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

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
        public Action CloseAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void ButtonViewClick()
        {
            if (ListViewVisibility == Visibility.Visible) return;
            ListViewVisibility = Visibility.Visible;
            if (!(SelectedClient is null))
            {
                IsEnabledEditPanel = true;
            }
        }

        private void ButtonHideClick()
        {
            if (ListViewVisibility == Visibility.Hidden) return;
            ListViewVisibility = Visibility.Hidden;
            IsEnabledButtonSave = false;
            IsEnabledEditPanel = false;
        }

        private void ButtonBackClick()
        {
            App.bank.Save(manager);
            WindowCreator.CreateWindow(Windows.StartWindow, null);
            CloseAction.Invoke();
        }

    }
}

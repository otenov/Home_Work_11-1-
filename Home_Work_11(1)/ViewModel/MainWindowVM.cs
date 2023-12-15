using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Home_Work_11_1_
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private Visibility listViewVisibility;
        public Visibility ListViewVisibility
        {
            get { return listViewVisibility; }
            set
            {
                listViewVisibility = value;
                OnPropertyChanged("ListViewVisibility");
            }
        }

        public Client SelectedClient { get; set; }

        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get
            {
                return clients;
            }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private bool isEnabledButtonTNumber;
        public bool IsEnabledButtonTNumber
        {
            get
            {
                return isEnabledButtonTNumber;
            }

            set
            {
                isEnabledButtonTNumber = value;
                OnPropertyChanged("IsEnabledButtonTNumber");
            }
        }

        private bool isEnabledButtonEdit;
        public bool IsEnabledButtonEdit
        {
            get
            {
                return isEnabledButtonEdit;
            }

            set
            {
                isEnabledButtonEdit = value;
                OnPropertyChanged("IsEnabledButtonEdit");
            }
        }

        private bool isEnabledButtonSave;
        public bool IsEnabledButtonSave
        {
            get => isEnabledButtonSave;
            set
            {
                isEnabledButtonSave = value;
                OnPropertyChanged("IsEnabledButtonSave");
            }
        }

        public ICommand ButtonViewClickCommand { get; set; }

        public ICommand ButtonHideClickCommand { get; set; }

        private void ButtonViewClick()
        {
            if (ListViewVisibility == Visibility.Visible) return;
            ListViewVisibility = Visibility.Visible;
            IsEnabledButtonTNumber = true;
            IsEnabledButtonEdit = true;
            if (!(SelectedClient is null))
            {
                IsEnabledButtonTNumber = true;
                IsEnabledButtonEdit = true;
            }
        }

        private void ButtonHideClick()
        {
            if (ListViewVisibility == Visibility.Hidden) return;
            ListViewVisibility = Visibility.Hidden;
            IsEnabledButtonSave = false;
            IsEnabledButtonEdit = false;
            IsEnabledButtonTNumber = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public MainWindowVM()
        {
            ButtonViewClickCommand = new CommandBase(ButtonViewClick);
            ButtonHideClickCommand = new CommandBase(ButtonHideClick);
            IsEnabledButtonSave = false;
            IsEnabledButtonTNumber = false;
            IsEnabledButtonEdit = false;
            ListViewVisibility = Visibility.Hidden;
        }
    }
}

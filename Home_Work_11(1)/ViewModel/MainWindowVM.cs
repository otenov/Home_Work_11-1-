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


namespace Home_Work_11_1_.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        //TODO: Можно ли давать ссылку в vm на model ?
        private Consultant consultant;
        public Consultant Consultant
        {
            get => consultant;
        }

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

        private Client selectedClient; //TODO: Могу я как-то сделать привязку на основе свойства выделенного клиента его истории изменений?
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
                IsEnabledBoxTNumber = true;
                IsEnabledButtonEdit = true;
                TextTelephoneBox = selectedClient.TelephoneNumber;
                HistoryRecords = selectedClient.HistoryChanges;
            }
        }


        //TODO: Где должен быть этот код? В отдельном VM?
        private HistoryRecord selectedHistoryRecord;
        public HistoryRecord SelectedHistoryRecord
        {
            get => selectedHistoryRecord;
            set
            {
                selectedHistoryRecord = value;
                OnPropertyChanged("SelectedHistoryRecord");
            }
        }
        public ObservableCollection<HistoryRecord> HistoryRecords { get; set; }


        //TODO: Нужно ли для коллекций прописывать свойства подробно и вызывать метод OnPropertyChanged("Clients"); ?

        //private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients { get; set; }
        //{
        //    get
        //    {
        //        return clients;
        //    }
        //    set
        //    {
        //        clients = value;
        //        OnPropertyChanged("Clients");
        //    }
        //}

        //TODO: Можно ли объеинять свойства для разных компонентов?
        private bool isEnabledBoxTNumber;
        public bool IsEnabledBoxTNumber
        {
            get
            {
                return isEnabledBoxTNumber;
            }

            set
            {
                isEnabledBoxTNumber = value;
                OnPropertyChanged("isEnabledBoxTNumber");
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

        private string textTelephoneBox;
        public string TextTelephoneBox
        {
            get => textTelephoneBox;
            set
            {
                textTelephoneBox = value;
                OnPropertyChanged("TextTelephoneBox");
            }
        }

        public ICommand ButtonViewClickCommand { get; set; }

        public ICommand ButtonHideClickCommand { get; set; }

        private void ButtonViewClick()
        {
            if (ListViewVisibility == Visibility.Visible) return;
            ListViewVisibility = Visibility.Visible;
            if (!(SelectedClient is null))
            {
                IsEnabledBoxTNumber = true;
                IsEnabledButtonEdit = true;
            }
        }

        private void ButtonHideClick()
        {
            if (ListViewVisibility == Visibility.Hidden) return;
            ListViewVisibility = Visibility.Hidden;
            IsEnabledButtonSave = false;
            IsEnabledButtonEdit = false;
            IsEnabledBoxTNumber = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public MainWindowVM()
        {
            consultant = new Consultant("Сергей", App.bank.CreateCollectionForConsultant());
            Clients = consultant.WorkerClients;
            ButtonViewClickCommand = new CommandBase(ButtonViewClick);
            ButtonHideClickCommand = new CommandBase(ButtonHideClick);
            IsEnabledButtonSave = false;
            IsEnabledBoxTNumber = false;
            IsEnabledButtonEdit = false;
            ListViewVisibility = Visibility.Hidden;
        }
    }
}

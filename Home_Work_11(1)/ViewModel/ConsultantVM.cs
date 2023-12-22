using Home_Work_11_1_.Helpers;
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

//ReactiveUI 
//Prism
namespace Home_Work_11_1_.ViewModel
{
    public class ConsultantVM : BaseVM
    {
        private Consultant consultant;

        private Visibility listViewVisibility;
        public Visibility ListViewVisibility
        {
            get { return listViewVisibility; }
            set
            {
                listViewVisibility = value;
                OnPropertyChanged(nameof (ListViewVisibility));
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
                IsEnabledEditPanel = true;
                TextTelephoneNumber = selectedClient.TelephoneNumber;
                OnPropertyChanged(nameof(TextTelephoneNumber));
            }
        }

        private HistoryRecord selectedHistoryRecord;
        public HistoryRecord SelectedHistoryRecord
        {
            get => selectedHistoryRecord;
            set
            {
                selectedHistoryRecord = value;
                OnPropertyChanged(nameof(SelectedHistoryRecord));
            }
        }

        public ObservableCollection<Client> Clients { get; }

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
                OnPropertyChanged("IsEnabledEditPanel");
            }
        }

        private bool isEnabledButtonSave;
        public bool IsEnabledButtonSave
        {
            get => isEnabledButtonSave;
            set
            {
                isEnabledButtonSave = value;
                OnPropertyChanged(nameof(IsEnabledButtonSave));
            }
        }

        private string textTelephoneNumber;
        public string TextTelephoneNumber
        {
            get => textTelephoneNumber;
            set
            {
                textTelephoneNumber = value;
                OnPropertyChanged(nameof(TextTelephoneNumber));
            }
        }

        public ICommand ButtonViewClickCommand { get; set; }

        public ICommand ButtonHideClickCommand { get; set; }

        public ICommand ButtonEditClickCommand { get; set; }

        public ICommand ButtonSaveClickCommand { get; set; }

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

        //TODO: Получается, что в любом случае нужно использовать две переменные если делаешь с ONE way?
        //TODO: Как делать проверку и где, если использовать TWO way mode?
        //TODO: Подумать над тем, чтобы убрать MessageBox из vm
        private void ButtonEditClick()
        {
            if (Helper.CheckTelephoneNumber(TextTelephoneNumber))
            {
                MessageBox.Show("Вы ввели неверный номер телефона\n" +
                    "Попробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //TODO: Надо ли выносить метод сравнения номеров в банк? Это же делает какая-то система.
            if (consultant.EditTNumber(selectedClient, TextTelephoneNumber))
            {
                MessageBox.Show("Данные не обновлены\n" +
                    "Вы не внесли никаких изменений", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show("Данные клиента успешно обновлены.\n" +
                "Сохраните изменения перед тем как закрыть приложение", "Оповещение", MessageBoxButton.OK);
            IsEnabledButtonSave = true;
        }

        private void ButtonSaveClick()
        {
            App.bank.Save(consultant);
            MessageBox.Show("Данные клиента успешно сохранены", "Оповещение", MessageBoxButton.OK);
        }


        public ConsultantVM(IMessageBoxHelper messageBoxHelper)
        {
            consultant = new Consultant("Сергей", App.bank.CreateCollectionForConsultant());
            Clients = consultant.WorkerClients;
            SelectedClient = new Client();
            ButtonViewClickCommand = new CommandBase(ButtonViewClick);
            ButtonHideClickCommand = new CommandBase(ButtonHideClick);
            ButtonEditClickCommand = new CommandBase(ButtonEditClick);
            ButtonSaveClickCommand = new CommandBase(ButtonSaveClick);
            IsEnabledButtonSave = false;
            IsEnabledEditPanel = false;
            ListViewVisibility = Visibility.Hidden;
            this.messageBoxHelper = messageBoxHelper;

        }
    }
}

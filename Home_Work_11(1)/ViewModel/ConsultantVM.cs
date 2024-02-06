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

//Вопрос-Ответ: Нормально ли, что в VM я использую ссылку на View ? using System.Windows.Input; using System.Windows;
//Не страшно при необходимости меняется на кросс. плат. аналоги

//ReactiveUI 
//Prism
namespace Home_Work_11_1_.ViewModel
{
    public class ConsultantVM : BaseVM, ICloseable
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
                OnPropertyChanged(nameof(IsEnabledEditPanel));
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
                //TODO: Можем проверить равняется value textTelephoneNumber. Изменилось ли что-то
                //TODO: Можем value проверить на наличие символов
                if (value?.Length > 5)
                {
                    messageBoxHelper.Show("Error", "Error", MessageBoxImage.None);
                    return;
                }
                textTelephoneNumber = value;
                OnPropertyChanged(nameof(TextTelephoneNumber));
            }
        }

        public ICommand ButtonViewClickCommand { get; set; }

        public ICommand ButtonHideClickCommand { get; set; }

        public ICommand ButtonEditClickCommand { get; set; }

        public ICommand ButtonSaveClickCommand { get; set; }

        public ICommand ButtonBackClickCommand { get; set; }

        public IWindowCreator WindowCreator { get; set; }

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

        private void ButtonEditClick()
        {
            if (Helper.CheckTelephoneNumber(TextTelephoneNumber))
            {
                messageBoxHelper.Show("Вы ввели неверный номер телефона\n" +
                    "Попробуйте еще раз",
                    "", 
                    MessageBoxImage.Warning);
                return;
            }
            if (consultant.EditTNumber(selectedClient, TextTelephoneNumber))
            {

                messageBoxHelper.Show("Данные не обновлены\n" +
                    "Вы не внесли никаких изменений", "Оповещение", 
                    MessageBoxImage.Warning);
                return;
            }
            messageBoxHelper.Show("Данные клиента успешно обновлены.\n" +
                "Сохраните изменения перед тем как закрыть приложение", 
                "Оповещение", 
                MessageBoxImage.Information);
            IsEnabledButtonSave = true;
        }

        private void ButtonSaveClick()
        {
            App.bank.Save(consultant);
            messageBoxHelper.Show("Данные клиента успешно сохранены",
                "Оповещение",
                MessageBoxImage.Information);
        }

        private void ButtonBackClick()
        {
            App.bank.Save(consultant);
            WindowCreator.CreateWindow(Windows.StartWindow, null);
            CloseAction.Invoke();
        }

        public void ShowHistoryRecord()
        {
            //Вопрос-Ответ: Можно ли вообще отсюда создавать VM?
            //Да. Это хорошо
            HistoryRecordVM historyRecordVM = new HistoryRecordVM(SelectedHistoryRecord);
            WindowCreator.CreateWindow(Windows.HistoryRecordWindow, historyRecordVM);
            

        }

        public ConsultantVM(IMessageBoxHelper messageBoxHelper, Action CloseAction)
        {
            consultant = new Consultant("Сергей", App.bank.CreateCollectionForConsultant());
            Clients = consultant.WorkerClients;
            SelectedClient = new Client();
            ButtonViewClickCommand = new CommandBase(ButtonViewClick);
            ButtonHideClickCommand = new CommandBase(ButtonHideClick);
            ButtonEditClickCommand = new CommandBase(ButtonEditClick);
            ButtonSaveClickCommand = new CommandBase(ButtonSaveClick);
            ButtonBackClickCommand = new CommandBase(ButtonBackClick);
            WindowCreator = new WPFWindowCreator(); //TODO:  WindowCreator должен быть зависимым от параметров конструктора
            IsEnabledButtonSave = false;
            IsEnabledEditPanel = false;
            ListViewVisibility = Visibility.Hidden;
            this.messageBoxHelper = messageBoxHelper;
            this.CloseAction = CloseAction;
        }

        public ConsultantVM()
        {

        }

        //Вопрос: Как сделать привязку через datacontext в xaml? Мы можем так сделать, только если констурктор модели не принимает никаких аргументов - по умолчанию. Мирон скинет ссылку
        //Вопрос: Поговорить подроюно про реализацию ICommand
        //Вопрос: Поговорить подробно про реализацию INotifyPropertyChanged

        //На изучение: DevExpress
        //На изучение: Fody

    }
}

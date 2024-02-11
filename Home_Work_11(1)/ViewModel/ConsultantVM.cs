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

        public ConsultantVM(IMessageBoxHelper messageBoxHelper, IWindowCreator windowCreator, Action CloseAction)
        {
            this.messageBoxHelper = messageBoxHelper;
            this.windowCreator = windowCreator;
            this.CloseAction = CloseAction;
            consultant = new Consultant("Сергей", App.bank.CreateCollectionForConsultant());
            ListOfClientsVM = new ListOfClientsVM(consultant.WorkerClients);
            ButtonViewClickCommand = new CommandBase(ButtonViewClick);
            ButtonHideClickCommand = new CommandBase(ButtonHideClick);
            ButtonEditClickCommand = new CommandBase(ButtonEditClick);
            ButtonSaveClickCommand = new CommandBase(ButtonSaveClick);
            ButtonBackClickCommand = new CommandBase(ButtonBackClick);
            ButtonSortClickCommand = new CommandBase(ButtonSortClick);
            IsEnabledButtonSave = false;
            IsEnabledEditPanel = false;
            ListOfClientsVM.NotifySelectedClient += LoadSelectedClient;
        }

        private Consultant consultant;

        public ListOfClientsVM ListOfClientsVM { get; set; }

        private IMessageBoxHelper messageBoxHelper;

        private IWindowCreator windowCreator;


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
                //Вопрос-Ответ: Можем проверить равняется value textTelephoneNumber, но это логика работы программы, поэтому решено её вынести из set
                //TODO: Можем value проверить на наличие символов
                //TODO: Сделать красивый textbox с выводом ошибки при вводе для всех 

                if (Helper.CheckTelephoneNumber(value))
                {
                    messageBoxHelper.Show("Вы ввели неверный номер телефона\n" +
                        "Попробуйте еще раз",
                        "",
                        MessageBoxImage.Warning);
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

        public ICommand ButtonSortClickCommand { get; set; }

        public Action CloseAction { get; set ; }

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

        private void ButtonEditClick()
        {
            if (consultant.EditTNumber(ListOfClientsVM.SelectedClient, TextTelephoneNumber))
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
            windowCreator.CreateWindow(Windows.StartWindow, null);
            CloseAction.Invoke();
        }

        private void ButtonSortClick()
        {
            ListOfClientsVM.Clients = new ObservableCollection<Client>(consultant.SortClient());
        }

        public void ShowHistoryRecord()
        {
            //Вопрос-Ответ: Можно ли вообще отсюда создавать VM?
            //Да. Это хорошо
            HistoryRecordVM historyRecordVM = new HistoryRecordVM(SelectedHistoryRecord);
            windowCreator.CreateWindow(Windows.HistoryRecordWindow, historyRecordVM);
            

        }


        /// <summary>
        /// Метод загрузки выделенного клиента. Обработчик события ListOfClientsVM.NotifySelectedClient
        /// </summary>
        /// <param name="selectedClient">Выделенный клиент</param>
        private void LoadSelectedClient(Client selectedClient)
        {
            IsEnabledEditPanel = true;
            TextTelephoneNumber = selectedClient.TelephoneNumber;
        }


        public ConsultantVM()
        {

        }

        //Вопрос: Как сделать привязку через datacontext в xaml? Мы можем так сделать, только если конструктор модели не принимает никаких аргументов - по умолчанию. Мирон скинет ссылку
        //Вопрос: Поговорить подробно про реализацию ICommand
        //Вопрос: Поговорить подробно про реализацию INotifyPropertyChanged

        //На изучение: DevExpress
        //На изучение: Fody

    }
}

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
            ButtonEditClickCommand = new CommandBase(ButtonEditClick);
            ButtonAddClickCommand = new CommandBase(ButtonAddClick);
            ListOfClientsVM.NotifySelectedClient += LoadSelectedClient;
            IsEnabledEditPanel = false;
            IsEnabledButtonSave = false;
        }

        public ListOfClientsVM ListOfClientsVM { get; set; }

        private Manager manager;

        private IWindowCreator windowCreator;

        private IMessageBoxHelper messageBoxHelper;


        #region Cвойства

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

        private string textSurname;
        public string TextSurname
        {
            get => textSurname;
            set
            {
                if (Helper.CheckSurname(value))
                {
                    messageBoxHelper.Show("Фамилия введена некорректно\n" +
                        "Попробуйте еще раз", 
                        "", 
                        MessageBoxImage.Warning);
                    return;
                }
                textSurname = value;
                OnPropertyChanged(nameof(TextSurname));
            }
        }

        private string textFName;
        public string TextFName
        {
            get => textFName;
            set
            {
                if (Helper.CheckFName(value))
                {
                    messageBoxHelper.Show("Имя введено некорректно\n" +
                        "Попробуйте еще раз",
                        "", 
                        MessageBoxImage.Warning);
                    return;
                }
                textFName = value;
                OnPropertyChanged(nameof(TextFName));
            }
        }

        private string textLName;
        public string TextLName
        {
            get => textLName;
            set
            {
                if (Helper.CheckLName(value))
                {
                    messageBoxHelper.Show("Отчество введено некорректно\n" +
                        "Попробуйте еще раз",
                        "",
                        MessageBoxImage.Warning);
                    return;
                }
                textLName = value;
                OnPropertyChanged(nameof(TextLName));
            }
        }

        private string textPassportSeries;
        public string TextPassportSeries
        {
            get => textPassportSeries;
            set
            {
                if (Helper.CheckPSeries(value))
                {
                    messageBoxHelper.Show("Серия паспорта введена некорректно\n" +
                        "Попробуйте еще раз",
                        "",
                        MessageBoxImage.Warning);
                    return;
                }

                textPassportSeries = value;
                OnPropertyChanged(nameof(TextPassportSeries));
            }
        }

        private string textPassportNumber;
        public string TextPassportNumber
        {
            get => textPassportNumber;
            set
            {
                if (Helper.CheckPNumber(value))
                {
                    messageBoxHelper.Show("Номер паспорта введён некорректно\n" +
                        "Попробуйте еще раз",
                        "",
                        MessageBoxImage.Warning);
                    return;
                }
                textPassportNumber = value;
                OnPropertyChanged(nameof(TextPassportNumber));
            }
        }

        private string textTelephoneNumber;
        public string TextTelephoneNumber
        {
            get => textTelephoneNumber;
            set
            {
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



        #endregion


        public ICommand ButtonViewClickCommand { get; set; }

        public ICommand ButtonHideClickCommand { get; set; }

        public ICommand ButtonBackClickCommand { get; set; }

        public ICommand ButtonSaveClickCommand { get; set; }

        public ICommand ButtonEditClickCommand { get; set; }

        public ICommand ButtonAddClickCommand { get; set; }

        public Action CloseAction { get ; set; }

        private void LoadSelectedClient(Client selectedClient)
        {
            IsEnabledEditPanel = true;
            TextSurname = selectedClient.Surname;
            TextFName = selectedClient.FName;
            TextLName = selectedClient.LName;
            TextPassportSeries = selectedClient.Passport.Substring(0, 4);
            TextPassportNumber = selectedClient.Passport.Substring(5, 6);
            TextTelephoneNumber = selectedClient.TelephoneNumber;

            //Вопрос: Мне нужно ли использовать события для обновления TextBox-ов? Или я могу ссылку дать в биндинге? 
            //В XAML TextSurname = ListOfClientsVM.SelectedClient.Surname;
        }

        private void ButtonEditClick()
        {
            if (manager.EditClient(ListOfClientsVM.SelectedClient,
                TextSurname,
                TextFName,
                TextLName,
                TextPassportSeries + " " + TextPassportNumber,
                TextTelephoneNumber))
            {
                messageBoxHelper.Show("Данные не обновлены\n" +
                    "Вы не внесли никаких изменений", 
                    "Оповещение",
                    MessageBoxImage.Warning);
                return;
            }
            messageBoxHelper.Show("Данные клиента успешно обновлены.\n" +
                "Сохраните изменения перед тем как закрыть приложение", 
                "Оповещение",
                MessageBoxImage.Information);
            IsEnabledButtonSave = true;
        }

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

        private void ButtonAddClick()
        {
            AddNewClientVM addNewClientVM = new AddNewClientVM(messageBoxHelper, manager);
            windowCreator.CreateWindow(Windows.AddNewClientWindow, addNewClientVM);
        }

        public void ShowHistoryRecord()
        {
            HistoryRecordVM historyRecordVM = new HistoryRecordVM(SelectedHistoryRecord);
            windowCreator.CreateWindow(Windows.HistoryRecordWindow, historyRecordVM);
        }


        //TODO: Вынести общий функционал в отдельную какую-то абстрактную VM?
    }
}

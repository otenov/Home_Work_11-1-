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
    public class AddNewClientVM : BaseVM, ICloseable
    {
        //TODO Сделать нормальный паспорт box
        public AddNewClientVM(IMessageBoxHelper messageBoxHelper, Manager manager)
        {
            this.manager = manager;
            this.messageBoxHelper = messageBoxHelper;
            ButtonBackClickCommand = new CommandBase(ButtonBackClick);
            ButtonOkClickCommand = new CommandBase(ButtonOkClick);
        }

        private IMessageBoxHelper messageBoxHelper;

        private Manager manager;

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

        private string textPassport;
        public string TextPassport
        {
            get => textPassport;
            set
            {
                textPassport = value;
                OnPropertyChanged(nameof(TextPassport));
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

        public ICommand ButtonBackClickCommand { get; set; }

        public ICommand ButtonOkClickCommand { get; set; }

        private void ButtonBackClick()
        {
            CloseAction?.Invoke();
        }

        private void ButtonOkClick()
        {
            manager.AddClient(TextSurname, TextFName, TextLName, TextPassport, TextTelephoneNumber);
            CloseAction?.Invoke();
        }

        public Action CloseAction { get ; set ; }
    }
}

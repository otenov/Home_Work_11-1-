using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    public class Manager : Worker, IManager
    {
        /// <summary>
        /// Конструктор. Создаёт менеджера. Менеджер работает с исходной коллекцией
        /// </summary>
        /// <param name="managerWindow">Окно, в котором работает менеджер</param>
        /// <param name="Name">Имя менеджера</param>
        /// <param name="clients">Исходная коллекция</param>
        public Manager(ManagerWindow managerWindow, string name, ObservableCollection<Client> clients) : base(name, clients)
        {

        }

        public void Add(Window window)
        {
            window.Hide();

            AddNewClientWindow addWindow = new AddNewClientWindow(this);

            addWindow.ShowDialog();

            window.Show();

        }

        public void AddClient(AddNewClientWindow addNewClientWindow)
        {
            Client newClient = new Client(addNewClientWindow.surnameBox.Text, addNewClientWindow.fnameBox.Text, addNewClientWindow.lnameBox.Text, addNewClientWindow.numberBox.Text, addNewClientWindow.passportBox.Text);

            clients.Add(newClient);

        }

        private void RecordClient(Client client,
            string surname, string name, string lName, string pSeries, string pNumber, string tNumber)
        {
            client.Surname = surname;
            client.FName = name;
            client.LName = lName;
            client.Passport = pSeries + " " + pNumber;
            client.TelephoneNumber = tNumber;
        }

        public void ChangeClient(Window window)
        {
            if (window is ManagerWindow)
            {
                ManagerWindow managerWindow = window as ManagerWindow;
                string surname = managerWindow.Surname.Text;
                string name = managerWindow.Name.Text;
                string lname = managerWindow.LName.Text;
                string pSeries = managerWindow.PassportSeries.Text;
                string pNumber = managerWindow.PassportNumber.Text;
                string tNumber = managerWindow.TelephoneNumber.Text;

                if (Helper.Check(managerWindow, surname, name, lname, pSeries, pNumber, tNumber))
                {
                    Client client = (Client)managerWindow.lw.SelectedItem;
                    //проверка
                    //    и взависимости от измененных полей - какую-то коллекцию из измененных значений, дальше
                    //    я создаю набор рекодов
                    /*
                     * ObservableCollection<Record> recordList = [];
                     * if (c.surname !== f.surname) 
                     * {
                     * Record newRecord = new Record("surname", oldValue, newValue);
                     
                     * recordList.add(newRecord)
                     * if (...)
                     * 
                     * HistoryRecord newHistoryRecord = new HistoryRecord(recordList, worker)
                     * Client client.historyChanges.add(newHistoryRecord);
                     */
                    //    на основе этих рекордов создаю нову историю записи
                    //и эту историю записи кладу в коллекцию клиента хистори рекорд


                    if (client.Surname != surname)
                    {
                        Record record = new Record("surname", client.Surname, surname);
                        //historyRecord.Add(new Record("surname", client.Surname, surname));
                    }
                    if (client.FName != name)
                    {
                       // historyRecord.Add(new Record("FName", client.FName, name));
                    }
                    if (client.LName != lname)
                    {
                        //historyRecord.Add(new Record("LName", client.LName, lname));
                    }
                    //if (client.FName != name)
                    //{
                    //    Record newRecord = new Record("FName", client., pSeries);
                    //    records.Add(newRecord);
                    //}
                    if (client.TelephoneNumber != tNumber)
                    {
                        //historyRecord.Add(new Record("TelephoneNumber", client.TelephoneNumber, tNumber));
                    }

                   // HistoryRecord historyRecord = new HistoryRecord(this, records);
                    //client.history.Add(historyRecord);

                    RecordClient(client, surname, name, lname, pSeries, pNumber, tNumber);
                    MessageBox.Show("Данные клиента обновлены", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    managerWindow.btnSave.IsEnabled = true;
                }
            }
        }

    }
}

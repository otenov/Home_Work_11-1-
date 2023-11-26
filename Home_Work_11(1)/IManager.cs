using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    interface IManager
    {
        void AddClient(string surname, string name, string lName, string passport, string tNumber);

        bool EditClient(Client client, string surname, string name, string lName, string passport, string tNumber);

        ///// <summary>
        ///// Метод для сохранения данных менеджером
        ///// </summary>
        //void Save();
    }
}

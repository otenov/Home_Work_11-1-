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
        /// <summary>
        /// Метод для кнопки Добавить
        /// </summary>
        /// <param name="window"></param>
        void Add(Window window);

        /// <summary>
        /// Метод для добавление нового клиента в коллекцию менеджера
        /// </summary>
        /// <param name="addNewClientwWindow"></param>
        void AddClient(AddNewClientWindow addNewClientwWindow);

        /// <summary>
        /// Метод для возможности изменения всех данных клиента
        /// </summary>
        /// <param name="window"></param>
        void ChangeClient(Window window);
        
        ///// <summary>
        ///// Метод для сохранения данных менеджером
        ///// </summary>
        //void Save();
    }
}

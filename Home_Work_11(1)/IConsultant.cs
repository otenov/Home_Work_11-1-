using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    interface IConsultant
    {
        /// <summary>
        /// Метод для кнопки изменить (изменяем только номер телефона)
        /// </summary>
        /// <param name="window"></param>
        void ChangedNumber(Window window);

        //void SaveData();
    }
}

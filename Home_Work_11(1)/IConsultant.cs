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

        /// <summary>
        /// Метод для кнопки просмотр
        /// </summary>
        /// <param name="window"></param>
        void View(Window window);

        /// <summary>
        /// Метод для кнопки Cкрыть
        /// </summary>
        /// <param name="windoww"></param>
        void Hide(Window window);

        /// <summary>
        /// Метод для подтаскивания данных в поля и отображения кнопок при выборе экземпляра списка
        /// </summary>
        /// <param name="window"></param>
        void SelectionChangedMethod(Window window);

        /// <summary>
        /// Метод для кнопки Назад
        /// </summary>
        /// <param name="window"></param>
        void Back(Window window);
    }
}

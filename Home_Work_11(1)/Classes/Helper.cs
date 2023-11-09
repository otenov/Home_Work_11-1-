using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    public class Helper
    {
        static private bool CheckSurname(ManagerWindow managerWindow, string surname)
        {
            bool flag = false;
            if (String.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Фамилия введена некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                managerWindow.Surname.Text = default;
                managerWindow.Surname.Focus();
                managerWindow.Surname.ToolTip = "Некорректные данные";
            }
            else flag = true;

            return flag;
        }

        static private bool CheckName(ManagerWindow managerWindow, string name)
        {
            bool flag = false;
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Имя введено некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                managerWindow.Name.Text = default;
                managerWindow.Name.Focus();
                managerWindow.Name.ToolTip = "Некорректные данные";
            }
            else flag = true;

            return flag;
        }

        static private bool CheckLName(ManagerWindow managerWindow, string lName)
        {
            bool flag = false;
            if (String.IsNullOrEmpty(lName))
            {
                MessageBox.Show("Отчество введено некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                managerWindow.LName.Text = default;
                managerWindow.Name.Focus();
                managerWindow.Name.ToolTip = "Некорректные данные";
            }
            else flag = true;

            return flag;
        }

        static private bool CheckPSeries(ManagerWindow managerWindow, string pSeries)
        {
            bool flag = false;
            if (String.IsNullOrEmpty(pSeries) || pSeries.Trim().Length != 4)
            {
                MessageBox.Show("Серия паспорта введена некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                managerWindow.PassportSeries.Text = default;
                managerWindow.PassportSeries.Focus();
                managerWindow.PassportSeries.ToolTip = "Некорректные данные";
            }
            else flag = true;

            return flag;
        }
        
        static private bool CheckPNumber(ManagerWindow managerWindow, string pNumber)
        {
            bool flag = false;
            if (String.IsNullOrEmpty(pNumber) || pNumber.Trim().Length != 6)
            {
                MessageBox.Show("Номер паспорта введён некорректно\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                managerWindow.PassportNumber.Text = default;
                managerWindow.PassportNumber.Focus();
                managerWindow.PassportNumber.ToolTip = "Некорректные данные";
            }
            else flag = true;

            return flag;
        }
        
        static private bool CheckTelephoneNumber(ManagerWindow managerWindow, string tNumber)
        {
            bool flag = false;
            if (String.IsNullOrEmpty(tNumber) || tNumber.Trim().Length != 11)
            {
                MessageBox.Show("Вы ввели неверный номер телефона\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                managerWindow.TelephoneNumber.Text = default;
                managerWindow.TelephoneNumber.Focus();
                managerWindow.TelephoneNumber.ToolTip = "Некорректные данные";
            }
            else flag = true;
            return flag;
        }

        static public bool Check(ManagerWindow managerWindow, 
            string surname, 
            string name, 
            string lName,
            string pSeries, 
            string pNumber,
            string tNumber)
        {
            if (CheckSurname(managerWindow, surname)
                & CheckName (managerWindow, name)
                & CheckLName(managerWindow, lName)
                & CheckPSeries(managerWindow, pSeries)
                & CheckPNumber(managerWindow, pNumber)
                & CheckTelephoneNumber(managerWindow, tNumber)
                )
                return true;
            else 
                return false;
        }
    }
}

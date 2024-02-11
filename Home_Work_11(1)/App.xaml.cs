using Home_Work_11_1_.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Home_Work_11_1_
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Bank bank;

        public static WPFWindowCreator windowCreator;

        public static IMessageBoxHelper messageBox;

        static App()
        {
            bank = new Bank();
            windowCreator = new WPFWindowCreator();
        }
    }
}

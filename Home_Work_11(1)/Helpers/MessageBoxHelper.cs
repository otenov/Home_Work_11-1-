using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_.Helpers
{
    class WPFMessageBoxHelper : IMessageBoxHelper
    {
        public void Show(string text, string label, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage)
        {
            MessageBox.Show(text, label, messageBoxButton, messageBoxImage);
        }


    }
}

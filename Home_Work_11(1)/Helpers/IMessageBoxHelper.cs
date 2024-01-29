using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_.Helpers
{
    public interface IMessageBoxHelper
    {
        void Show(string text, string label, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage);

        //TODO: Здесь мы можем ссылку Windows использовать? UI эллементы.
    }


}

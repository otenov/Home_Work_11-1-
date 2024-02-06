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
        void Show(string text, string label, MessageBoxImage messageBoxImage);

        //TODO: Кроссплатформенно. Создать свой enum.
        //Вопрос-Ответ: Здесь мы можем ссылку Windows использовать? UI эллементы?
        //Я могу использовать и не заморачиваться. Но если, я хочу писать кроссплатформенно, то нужно переписывать и реализовывать свой enum
    }
}

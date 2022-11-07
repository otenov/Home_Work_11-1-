using CreateFile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    class Consultant
    {
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Коллекция, с которой работает консультант
        /// </summary>
        private ObservableCollection<Client> clients;

        /// <summary>
        /// Конструктор. Создаёт экземпляр с коллекцией, где сразу невидно паспорт.
        /// </summary>
        /// <param name="w">Окно в котором работает консультант</param>
        /// <param name="name">Имя работника</param>
        /// <param name="clients">Коллекция с обезличенным паспортом</param>
        public Consultant(MainWindow w,string name, ObservableCollection<Client> clients)
        {
            this.Name = name;
            //Обезличивание данных
            this.clients = ConsultantCollection(clients);
            //Стартовые настройки окна (может потом вынести в отдельный метод?)
            w.lw.ItemsSource = this.clients;
            w.lw.Visibility = Visibility.Hidden;
            w.btnSave.IsEnabled = false;
            w.btnChange.IsEnabled = false;
            w.txt.IsEnabled = false;
        }

        /// <summary>
        /// Метод по подготовки коллекции для консультанта
        /// </summary>
        /// <param name="clients">Коллекция данных</param>
        /// <returns></returns>
        private ObservableCollection<Client> ConsultantCollection(ObservableCollection<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (!String.IsNullOrEmpty(clients[i].Pasport))
                    clients[i].Pasport = "**** ******";
            }
            return clients;
        }

        /// <summary>
        /// Метод для отображения и скрытия списка, используется в обработчике событий
        /// </summary>
        /// <param name="w"></param>
        public void ButtonsLookAndHide(MainWindow w)
        {
            if (w.lw.Visibility == Visibility.Hidden)
                View(w);
            else
                Hide(w);
        }

        /// <summary>
        /// Метод для кнопки просмотр
        /// </summary>
        /// <param name="w"></param>
        private void View(MainWindow w)
        {
            w.lw.Visibility = Visibility.Visible;
            w.btnLook.IsEnabled = false;
            w.btnHide.IsEnabled = true;
            if(!(w.lw.SelectedItem is null))
            {
                w.txt.IsEnabled = true;
                w.btnSave.IsEnabled = true;
                w.btnChange.IsEnabled = true;
            }

        }

        /// <summary>
        /// Метод для кнопки скрыть
        /// </summary>
        /// <param name="w"></param>
        private void Hide(MainWindow w)
        {
            w.lw.Visibility = Visibility.Hidden;
            w.btnHide.IsEnabled = false;
            w.btnLook.IsEnabled = true;
            w.btnSave.IsEnabled = false;
            w.btnChange.IsEnabled = false;
            w.txt.IsEnabled = false;
        }

        /// <summary>
        /// Метод для подтаскивания данных в поля и отображения кнопок при выборе экземпляра списка
        /// </summary>
        /// <param name="w"></param>
        public void SelectionChangedMethod(MainWindow w)
        {
            w.txt.IsEnabled = true;
            w.txt.Text = ((Client)w.lw.SelectedItem).TelephoneNumber;
            w.btnSave.IsEnabled = true;
            w.btnChange.IsEnabled = true;
        }

        /// <summary>
        /// Метод для кнопки изменить
        /// </summary>
        /// <param name="w"></param>
        public void btnChanged(MainWindow w)
        {
            string number = w.txt.Text;
            if(String.IsNullOrEmpty(number) || number.Length != 11)
            {
                MessageBox.Show("Вы ввели неверный номер телефона\nПопробуйте еще раз", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                w.txt.Text = default;
                w.txt.Focus();
                w.txt.ToolTip = "Был введён некорректный номер";
            }
            else
            {
                ((Client)w.lw.SelectedItem).TelephoneNumber = w.txt.Text;
                MessageBox.Show("Телефонный номер сохранён","", MessageBoxButton.OK, MessageBoxImage.Information);
            }
                

        }

    }
}

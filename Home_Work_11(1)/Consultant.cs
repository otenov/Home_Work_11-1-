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
        public string Name { get; set; }

        ObservableCollection<Client> clients;


        public Consultant(MainWindow w,string name, ObservableCollection<Client> clients)
        {
            this.Name = name;

            this.clients = ConsultantCollection(clients);

            w.lw.ItemsSource = this.clients;
            w.lw.Visibility = Visibility.Hidden;

        }

        public ObservableCollection<Client> ConsultantCollection(ObservableCollection<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (!String.IsNullOrEmpty(clients[i].Pasport))
                    clients[i].Pasport = "**** ******";
            }
            return clients;
        }

        public void View(MainWindow w)
        {
            if (w.lw.Visibility == Visibility.Hidden)
                w.lw.Visibility = Visibility.Visible;
            else w.lw.Visibility = Visibility.Hidden;


        }
        public void ViewPassport(MainWindow w)
        {
            if (w.lw.ItemsSource is List<Client>)
            {
            }
                
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_.ViewModel
{
    public class ListOfClientsVM : BaseVM
    {
        public ListOfClientsVM(ObservableCollection<Client> clients)
        {
            ListViewVisibility = Visibility.Hidden;
            Clients = clients;
        }

        public event Action<Client> NotifySelectedClient;

        private Visibility listViewVisibility;
        public Visibility ListViewVisibility
        {
            get { return listViewVisibility; }
            set
            {
                listViewVisibility = value;
                OnPropertyChanged(nameof(ListViewVisibility));
            }
        }

        private Client selectedClient;
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
                NotifySelectedClient?.Invoke(selectedClient);
            }
        }

        private ObservableCollection<Client> clients;

        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    public class Bank
    {
        public ObservableCollection<Client> clients;

        public Bank()
        {
            clients = new ObservableCollection<Client>();
        }
    }
}

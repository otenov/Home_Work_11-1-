﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateFile;

namespace Home_Work_11_1_
{
    interface IMyCollection
    {
        ObservableCollection<Client> WorkerCollection { get; set; }
    }
}

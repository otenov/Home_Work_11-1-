﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_1_
{
    interface ICloseable
    {
        Action CloseAction { get; set; }
    }
}
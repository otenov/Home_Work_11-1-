﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Work_11_1_
{
    public interface IWindowCreator
    {
        void CreateWindow(Windows window, BaseVM baseVM);
    }
}

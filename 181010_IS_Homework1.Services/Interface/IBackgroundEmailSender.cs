﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _181010_IS_Homework1.Services.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IFFTService
    {
        FFTResult Run(Complex[] signal);
    }
}

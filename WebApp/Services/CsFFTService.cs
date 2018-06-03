using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using FFT;

namespace WebApp.Services
{
    public class CsFFTService : IFFTService
    {
        public Complex[] Run(Complex[] signal)
        {
            return FFT.FFT.fft(signal);
        }
    }
}

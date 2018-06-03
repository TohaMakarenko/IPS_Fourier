using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using FFT;
using WebApp.Models;

namespace WebApp.Services
{
    public class CsFFTService : IFFTService
    {
        public FFTResult Run(Complex[] signal)
        {
            var result = new FFTResult();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            result.Result = FFT.FFT.fft(signal);
            sw.Stop();
            result.Time = sw.Elapsed;
            return result;
        }
    }
}

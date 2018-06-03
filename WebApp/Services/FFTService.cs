using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class FFTService : IFFTService
    {
    //    [DllImport("IPS_Fourier.dll", CallingConvention = CallingConvention.Cdecl,
    //SetLastError = true)]
    //    static private extern void run(int n, double[] signal, double[] real, double[] imag);

        public FFTResult Run(Complex[] signal)
        {
            var size = signal.Length;
            var real = new double[size];
            var imag = new double[size];

            //pzdc
            //run(0, signal.Select(c => c.Real).ToArray(), real, imag);

            var result = new FFTResult();
            result.Result = new Complex[size];
            for (int i = 0; i < size; i++) {
                result.Result[i] = new Complex(real[i], imag[i]);
            }
            return result;
        }
    }
}

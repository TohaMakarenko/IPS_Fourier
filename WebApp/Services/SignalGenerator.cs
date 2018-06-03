using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class SignalGenerator : ISignalGeneratorService
    {
        public Complex[] Generate(int size, double step)
        {
            Complex[] result = new Complex[size];

            for (int i = 0; i < size; i++) {
                result[i] = Math.Sin(i * step) + Math.Cos(i * step * 2) - i / 10;
            }

            return result;
        }
    }
}

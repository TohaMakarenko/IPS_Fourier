using System;
using System.Runtime.InteropServices;

namespace TryCallDLL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Complex
    {
        public double real;
        public double imag;
    }

    class Program
    {
        [DllImport("IPS_Fourier.dll", CallingConvention = CallingConvention.Cdecl,
    SetLastError = true)]
        static public extern void run(int n, double[] signal, double[] real, double[] imag);

        static void Main(string[] args)
        {
            var size = 32;
            var real = new double[size];
            var imag = new double[size];
            var signal = GenerateSignal(size, 0.1);
            for (int i = 0; i < size; i++) {
                Console.Write(signal[i] + ", ");
            }
            run(0, signal, real, imag);
            Console.WriteLine();
            for (int i = 0; i < size; i++) {
                Console.WriteLine($"{real[i]} + i*{imag[i]}");
            }
            Console.ReadLine();
        }

        static double[] GenerateSignal(int n, double step)
        {
            double[] result = new double[n];

            for (int i = 0; i < n; i++) {
                result[i] = Math.Sin(i * step) + Math.Cos(i * step * 2);
            }

            return result;
        }
    }
}

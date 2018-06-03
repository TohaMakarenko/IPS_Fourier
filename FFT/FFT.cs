using System;
using System.Numerics;

namespace FFT
{
    public static class FourierTransform
    {
        public static Complex[] FFT(Complex[] a)
        {
            int n = a.Length;
            int n2 = n / 2;

            if (n == 1)
                return a;

            Complex z = new Complex(0.0, 2.0 * Math.PI / n);
            Complex omegaN = Complex.Exp(z);
            Complex omega = new Complex(1.0, 0.0);
            Complex[] a0 = new Complex[n2];
            Complex[] a1 = new Complex[n2];
            Complex[] y0 = new Complex[n2];
            Complex[] y1 = new Complex[n2];
            Complex[] y = new Complex[n];

            for (int i = 0; i < n2; i++) {
                a0[i] = new Complex(0.0, 0.0);
                a0[i] = a[2 * i];
                a1[i] = new Complex(0.0, 0.0);
                a1[i] = a[2 * i + 1];
            }

            y0 = FFT(a0);
            y1 = FFT(a1);

            for (int k = 0; k < n2; k++) {
                y[k] = new Complex(0.0, 0.0);
                y[k] = y0[k] + (y1[k] * omega);
                y[k + n2] = new Complex(0.0, 0.0);
                y[k + n2] = y0[k]-(y1[k] * (omega));
                omega = omega * (omegaN);
            }

            return y;
        }
    }
}

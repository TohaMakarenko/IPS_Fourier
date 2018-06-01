#define _USE_MATH_DEFINES
#include <complex>
using namespace std;

/// <summary>
/// Вычисление поворачивающего модуля e^(-i*2*PI*k/N)
/// </summary>
/// <param name="k"></param>
/// <param name="N"></param>
/// <returns></returns>
complex<double> w(int k, int N);

/// <summary>
/// Возвращает спектр сигнала
/// </summary>
/// <param name="x">Массив значений сигнала. Количество значений должно быть степенью 2</param>
/// <returns>Массив со значениями спектра сигнала</returns>
complex<double>* fft(complex<double>* x, int n);

/// <summary>
/// Центровка массива значений полученных в fft (спектральная составляющая при нулевой частоте будет в центре массива)
/// </summary>
/// <param name="X">Массив значений полученный в fft</param>
/// <returns></returns>
complex<double>* nfft(complex<double>* X, int n);

int main()
{
	return 0;
}

complex<double>* nfft(complex<double>* X, int n) {
	complex<double>* X_n = new complex<double>[n];
	for (int i = 0; i < n / 2; i++)
	{
		X_n[i] = X[n / 2 + i];
		X_n[n / 2 + i] = X[i];
	}
	return X_n;
}

complex<double>* fft(complex<double>* x, int n) {
	complex<double>* X;
	if (n == 2)
	{
		X = new complex<double>[2];
		X[0] = x[0] + x[1];
		X[1] = x[0] - x[1];
	}
	else {
		complex<double>* x_even = new complex<double>[n / 2];
		complex<double>* x_odd = new complex<double>[n / 2];
		for (int i = 0; i < n / 2; i++)
		{
			x_even[i] = x[2 * i];
			x_odd[i] = x[2 * i + 1];
		}
		complex<double>* X_even = fft(x_even, n);
		complex<double>* X_odd = fft(x_odd, n);
		X = new complex<double>[n];
		for (int i = 0; i < n / 2; i++)
		{
			X[i] = X_even[i] + w(i, n) * X_odd[i];
			X[i + n / 2] = X_even[i] - w(i, n) * X_odd[i];
		}
	}
	return X;
}

complex<double> w(int k, int N) {
	if (k%N == 0) return complex<double>(1, 0);
	double arg = -2 * M_PI*k / N;
	return complex<double>(cos(arg), sin(arg));
}
#define _USE_MATH_DEFINES
#include <complex>
#include <vector>
#include <algorithm>
#include <iostream>
#include <math.h>

using namespace std;
typedef complex<double> w_type;

extern "C" {
	__declspec(dllexport) void run(int n, double* signal, double* real, double* imag);
}

static vector<w_type> fft(const vector<w_type> &In);

void run(int n, double* signal, double* real, double* imag)
{
	int ln = (int)floor(log(n - 1.0) / log(2.0));
	vector<w_type> In(1 << ln);
	std::transform(signal + 1, signal + n, In.begin(), [&](const double arg) {
		return w_type(arg, 0);
	});
	vector<w_type> Out = fft(In);
	for (unsigned int i = 0; i < Out.capacity(); i++) {
		real[i] = Out[i].real();
		imag[i] = Out[i].imag();
	}
}

static vector<w_type> fft(const vector<w_type> &In)
{
	int i = 0, wi = 0;
	int n = In.size();
	vector<w_type> A(n / 2), B(n / 2), Out(n);
	if (n == 1) {
		return vector<w_type>(1, In[0]);
	}
	i = 0;
	copy_if(In.begin(), In.end(), A.begin(), [&i](w_type e) {
		return !(i++ % 2);
	});
	copy_if(In.begin(), In.end(), B.begin(), [&i](w_type e) {
		return (i++ % 2);
	});

	vector<w_type> At = fft(A);
	vector<w_type> Bt = fft(B);

	transform(At.begin(), At.end(), Bt.begin(), Out.begin(), [&wi, &n]
	(w_type& a, w_type& b) {
		return  a + b * exp(w_type(0, 2 * M_PI * wi++ / n));
	});
	transform(At.begin(), At.end(), Bt.begin(), Out.begin() + n / 2, [&wi, &n]
	(w_type& a, w_type& b) {
		return  a + b * exp(w_type(0, 2 * M_PI * wi++ / n));
	});
	return Out;
}
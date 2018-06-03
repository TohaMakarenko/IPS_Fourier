using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class FFTController : Controller
    {
        private ISignalGeneratorService _signalGenerator;
        private IFFTService _fftService;

        public FFTController(ISignalGeneratorService signalGenerator,
            IFFTService fftService)
        {
            _signalGenerator = signalGenerator;
            _fftService = fftService;
        }

        [HttpGet]
        public double[] GenerateSignal(int size, double step)
        {
            return _signalGenerator.Generate(size, step).Select(i=>i.Real).ToArray();
        }

        [HttpPost]
        [RequestSizeLimit(valueCountLimit: 214748364)]
        public FFTResult RunFFT([FromBody]double[] signal)
        {
            if (signal == null)
                return null;
            if(signal.Length != 0 && (signal.Length & (signal.Length - 1)) != 0) {
                return null;
            }
            return _fftService.Run(signal.Select(i => new Complex(i, 0)).ToArray());
        }
    }
}

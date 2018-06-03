using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class FFTController : Controller
    {
        private ISignalGeneratorService _signalGenerator;
        private ISignalStorage _signalStorage;
        private IFFTService _fftService;
        const string costyl = "1";
        public FFTController(ISignalGeneratorService signalGenerator,
            ISignalStorage signalStorage,
            IFFTService fftService)
        {
            _signalGenerator = signalGenerator;
            _signalStorage = signalStorage;
            _fftService = fftService;
        }

        [HttpGet]
        public Complex[] GenerateSignal(int size, double step)
        {
            var signal = _signalGenerator.Generate(size, step);
            _signalStorage.SetSignal(costyl, signal);
            return signal;
        }

        [HttpGet]
        public Complex[] GetSignal()
        {
            return _signalStorage.GetSignal(costyl);
        }

        [HttpGet]
        public Complex[] RunFFT()
        {
            var signal = _signalStorage.GetSignal(costyl);
            if (signal == null)
                return null;
            return _fftService.Run(signal);
        }
    }
}

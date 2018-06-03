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
        public Complex[] GenerateSignal(int size, double step)
        {
            return _signalGenerator.Generate(size, step);
        }

        [HttpPost]
        public FFTResult RunFFT([FromBody]Complex[] signal)
        {
            if (signal == null)
                return null;
            return _fftService.Run(signal);
        }
    }
}

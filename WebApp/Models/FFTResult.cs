using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class FFTResult
    {
        public TimeSpan Time { get; set; }
        public Complex[] Result { get; set; }
    }
}

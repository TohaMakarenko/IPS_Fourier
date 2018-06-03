using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface ISignalStorage
    {
        Complex[] GetSignal(string sessionId);
        void SetSignal(string sessionId, Complex[] signal);
    }
}

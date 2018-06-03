using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class SignalStorage : ISignalStorage
    {
        private Dictionary<string, Complex[]> _signals = new Dictionary<string, Complex[]>();

        public Complex[] GetSignal(string sessionId)
        {
            if (_signals.ContainsKey(sessionId)) {
                return _signals[sessionId];
            }
            return null;
        }

        public void SetSignal(string sessionId, Complex[] signal)
        {
            if (_signals.ContainsKey(sessionId)) {
                _signals[sessionId] = signal;
            }
            else {
                _signals.Add(sessionId, signal);
            }
        }
    }
}

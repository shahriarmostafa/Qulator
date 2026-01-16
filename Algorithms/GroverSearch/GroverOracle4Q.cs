using Sim1Test.Circuit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.Algorithms.GroverSearch
{
    public static class GroverOracle4Q
    {
        public static void ApplyOracle(StateVector state, int targetIndex)
        {
            int nQubits = state.NumberOfQubits;
            if (nQubits != 4)
            {
                throw new InvalidOperationException("GroverOracle4Q supports exactly 4 qubits.");
            }

            int maxIndex = (1 << nQubits) - 1;
            if (targetIndex < 0 || targetIndex > maxIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(targetIndex),
                    $"Marked index must be between 0 and {maxIndex}.");
            }

            bool[] bits = new bool[nQubits];
            for (int q = 0; q < nQubits; q++)
            {
                bits[q] = ((targetIndex >> q) & 1) == 1;
            }

            for (int q = 0; q < nQubits; q++)
            {
                if (!bits[q])
                {
                    state.ApplySingleQubitGate(GateLibrary.X(), q);
                }
            }

            state.ApplySingleQubitGate4Controls(GateLibrary.Z(), 0, 1, 2, 3, 3);

            for (int q = 0; q < nQubits; q++)
            {
                if (!bits[q])
                {
                    state.ApplySingleQubitGate(GateLibrary.X(), q);
                }
            }
        }
    }
}

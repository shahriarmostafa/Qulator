using Sim1Test.Circuit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.Algorithms.GroverSearch
{
    public static class GroverSearch4Q
    {
        public static int[] RunGrover4Qubits(int markedIndex)
        {
            int nQubits = 4;
            int iterations = 3;

            int maxIndex = (1 << nQubits) - 1;
            if (markedIndex < 0 || markedIndex > maxIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(markedIndex),
                    $"Marked index must be between 0 and {maxIndex}.");
            }

            StateVector state = new StateVector(nQubits);

            for (int q = 0; q < nQubits; q++)
            {
                state.ApplySingleQubitGate(GateLibrary.H(), q);
            }

            for (int k = 0; k < iterations; k++)
            {
                GroverOracle4Q.ApplyOracle(state, markedIndex);
                GroverDiffuser4Q.ApplyDiffuser(state);
            }

            int[] measured = state.MeasureAllQubit();
            return measured;
        }
    }

}

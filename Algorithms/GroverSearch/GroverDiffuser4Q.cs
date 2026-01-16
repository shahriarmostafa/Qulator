using Sim1Test.Circuit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.Algorithms.GroverSearch
{
    public static class GroverDiffuser4Q
    {
        public static void ApplyDiffuser(StateVector state)
        {
            int nQubits = state.NumberOfQubits;
            if (nQubits != 4)
            {
                throw new InvalidOperationException("GroverDiffuser4Q supports exactly 4 qubits.");
            }

            for (int q = 0; q < nQubits; q++)
            {
                state.ApplySingleQubitGate(GateLibrary.H(), q);
            }

            for (int q = 0; q < nQubits; q++)
            {
                state.ApplySingleQubitGate(GateLibrary.X(), q);
            }


            state.ApplySingleQubitGate4Controls(GateLibrary.Z(), 0, 1, 2, 3, 3);


            for (int q = 0; q < nQubits; q++)
            {
                state.ApplySingleQubitGate(GateLibrary.X(), q);
            }


            for (int q = 0; q < nQubits; q++)
            {
                state.ApplySingleQubitGate(GateLibrary.H(), q);
            }
        }
    }
}

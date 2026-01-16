using Sim1Test.Circuit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.Algorithms
{
    public class BellState
    {
        public static StateVector CreatePhiPlus()
        {
            StateVector entangledState = new StateVector(2);
            entangledState.ApplySingleQubitGate(GateLibrary.H(), 0);
            entangledState.ApplySingleQubitGate(GateLibrary.X(), 0, 1);
            return entangledState;
        }
        public static StateVector CreatePhiMinus()
        {
            StateVector entangledState = new StateVector(2);
            entangledState.ApplySingleQubitGate(GateLibrary.H(), 0);
            entangledState.ApplySingleQubitGate(GateLibrary.X(), 0, 1);
            entangledState.ApplySingleQubitGate(GateLibrary.Z(), 0);
            return entangledState;
        }
        public static StateVector CreatePsiPlus()
        {
            StateVector entangledState = new StateVector(2);
            entangledState.ApplySingleQubitGate(GateLibrary.X(), 1);
            entangledState.ApplySingleQubitGate(GateLibrary.H(), 0);
            entangledState.ApplySingleQubitGate(GateLibrary.X(), 0, 1);
            return entangledState;
        }
        public static StateVector CreatePsiMinus()
        {
            StateVector entangledState = new StateVector(2);
            entangledState.ApplySingleQubitGate(GateLibrary.X(), 1);
            entangledState.ApplySingleQubitGate(GateLibrary.H(), 0);
            entangledState.ApplySingleQubitGate(GateLibrary.X(), 0, 1);
            entangledState.ApplySingleQubitGate(GateLibrary.Z(), 0);
            return entangledState;
        }
    }
}

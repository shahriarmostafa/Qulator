using Sim1Test.Circuit;
using Sim1Test.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.Algorithms
{
    public static class Teleportation
    {
        public static StateVector Teleport(StateVector unknown, StateVector bellState)
        {
            Matrix unknownMatrix = new Matrix(unknown.Amplitudes.Length, 1);
            for (int i = 0; i < unknown.Amplitudes.Length; i++)
            {
                unknownMatrix.Set(i, 0, unknown.Amplitudes[i]);
            }

            Matrix bellMatrix = new Matrix(bellState.Amplitudes.Length, 1);
            for (int i = 0; i < bellState.Amplitudes.Length; i++)
            {
                bellMatrix.Set(i, 0, bellState.Amplitudes[i]);
            }
            Matrix combinedMatrix = unknownMatrix.KroneckerProduct(bellMatrix);
            ComplexNumber[] combinedAmplitudes = new ComplexNumber[combinedMatrix.Rows];
            for (int i = 0; i < combinedMatrix.Rows; i++)
            {
                combinedAmplitudes[i] = combinedMatrix.Get(i, 0);
            }
            StateVector teleportedState = new StateVector(combinedAmplitudes);
            teleportedState.ApplySingleQubitGate(GateLibrary.X(), 0, 1);
            teleportedState.ApplySingleQubitGate(GateLibrary.H(), 0);
            int m0 = teleportedState.MeasureSingleQubit(0);
            int m1 = teleportedState.MeasureSingleQubit(1);
            if (m1 == 1)
            {
                teleportedState.ApplySingleQubitGate(GateLibrary.X(), 2);
            }
            if (m0 == 1)
            {
                teleportedState.ApplySingleQubitGate(GateLibrary.Z(), 2);
            }
            return teleportedState;
        }
    }
}

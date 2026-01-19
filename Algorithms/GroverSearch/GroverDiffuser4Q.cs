using Sim1Test.Circuit;
using Sim1Test.Maths;
using System;

public static class GroverDiffuser4Q
{
    public static void ApplyDiffuser(StateVector state)
    {
        if (state.NumberOfQubits != 4)
            throw new InvalidOperationException("GroverDiffuser4Q supports exactly 4 qubits.");

        for (int q = 0; q < 4; q++)
        {
            state.ApplySingleQubitGate(GateLibrary.H(), q);
        }

        for (int q = 0; q < 4; q++)
        {
            state.ApplySingleQubitGate(GateLibrary.X(), q);
        }

        int allOnesIndex = 15;
        state.Amplitudes[allOnesIndex] = state.Amplitudes[allOnesIndex].Multiply(new ComplexNumber(-1, 0));

        for (int q = 0; q < 4; q++)
        {
            state.ApplySingleQubitGate(GateLibrary.X(), q);
        }

        for (int q = 0; q < 4; q++)
        {
            state.ApplySingleQubitGate(GateLibrary.H(), q);
        }
    }
}

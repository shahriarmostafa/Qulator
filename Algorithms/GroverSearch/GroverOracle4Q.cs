using Sim1Test.Circuit;
using Sim1Test.Maths;
using System;

public static class GroverOracle4Q
{
    public static void ApplyOracle(StateVector state, int targetIndex)
    {
        if (state.NumberOfQubits != 4)
            throw new InvalidOperationException("GroverOracle4Q supports exactly 4 qubits.");

        if (targetIndex < 0 || targetIndex > 15)
            throw new ArgumentOutOfRangeException(nameof(targetIndex));

        bool[] bits = new bool[4];
        for (int q = 0; q < 4; q++)
            bits[q] = ((targetIndex >> q) & 1) == 1;

        for (int q = 0; q < 4; q++)
            if (!bits[q])
                state.ApplySingleQubitGate(GateLibrary.X(), q);


        int allOnesIndex = 15; 
        state.Amplitudes[allOnesIndex] = state.Amplitudes[allOnesIndex].Multiply(new ComplexNumber(-1, 0));

        for (int q = 0; q < 4; q++)
            if (!bits[q])
                state.ApplySingleQubitGate(GateLibrary.X(), q);
    }
}



public static class GroverOracle
{
    public static void ApplyOracle(StateVector state, int targetIndex)
    {
        int nQubits = state.NumberOfQubits;

        bool[] bits = new bool[nQubits];
        for (int q = 0; q < nQubits; q++)
        {
            bits[q] = ((targetIndex >> q) & 1) == 1; //copied expression, bujhte hobe pore
        }

        for (int q = 0; q < nQubits; q++)
        {
            if (!bits[q])
            {
                state.ApplySingleQubitGate(GateLibrary.X(), q);
            }
        }
        state.ApplySingleQubitGate3Controls(GateLibrary.Z(), 0, 1, 2, 2);

        for (int q = 0; q < nQubits; q++)
        {
            if (!bits[q])
            {
                state.ApplySingleQubitGate(GateLibrary.X(), q);
            }
        }
    }
}


public static class GroverDiffuser
{
    public static void ApplyDiffuser(StateVector state)
    {
        int nQubits = state.NumberOfQubits;

        for (int q = 0; q < nQubits; q++)
        {
            state.ApplySingleQubitGate(GateLibrary.H(), q);
        }

        for (int q = 0; q < nQubits; q++)
        {
            state.ApplySingleQubitGate(GateLibrary.X(), q);
        }

        state.ApplySingleQubitGate3Controls(GateLibrary.Z(), 0, 1, 2, 2);

        for (int q = 0; q < nQubits; q++)
            state.ApplySingleQubitGate(GateLibrary.X(), q);

        for (int q = 0; q < nQubits; q++)
            state.ApplySingleQubitGate(GateLibrary.H(), q);
    }
}

public static class GroverSearch
{
    public static int[] RunGrover3Qubits(int markedIndex)
    {
        int nQubits = 3;
        int iterations = 2;

        StateVector state = new StateVector(nQubits);

        for (int q = 0; q < nQubits; q++)
            state.ApplySingleQubitGate(GateLibrary.H(), q);

        for (int k = 0; k < iterations; k++)
        {
            GroverOracle.ApplyOracle(state, markedIndex);
            GroverDiffuser.ApplyDiffuser(state);
        }

        int[] measured = state.MeasureAllQubit();

        return measured;
    }
}


public class Program
{
    public static void Main()
    {
        int markedIndex = 5; 
        int shots = 100;
        int nQubits = 3;

        int[] counts = new int[8];

        for (int s = 0; s < shots; s++)
        {
            int[] bits = GroverSearch.RunGrover3Qubits(markedIndex);
            int value = bits[2] * 1 + bits[1] * 2 + bits[0] * 4;
            counts[value]++;
        }

        Console.WriteLine("Grover 3-qubit histogram:");
        for (int i = 0; i < 8; i++)
        {
            string bitstring = Convert.ToString(i, 2).PadLeft(3, '0');
            Console.WriteLine($"{bitstring}: {counts[i]}");
        }
    }
}



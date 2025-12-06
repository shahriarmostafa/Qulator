using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace simpleClasses
{
    public class ComplexNumber
    {
        public double Real { get; }
        public double Imaginary { get; }
        public ComplexNumber(double Real, double Imaginary)
        {
            this.Real = Real;
            this.Imaginary = Imaginary;
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber(Real + other.Real, Imaginary + other.Imaginary);
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber(Real - other.Real, Imaginary - other.Imaginary);
        }
        public ComplexNumber Multiply(ComplexNumber other)
        {
            return new ComplexNumber(Real * other.Real - Imaginary * other.Imaginary,
                Real * other.Imaginary + Imaginary * other.Real);
        }
        public double SquireValue()
        {
            return Real * Real + Imaginary * Imaginary;
        }
        public void PrintComplexNumber()
        {
            Console.Write($"{Real}+i{Imaginary} \t");
        }
    }

    public class Matrix {
        public int Rows { get; }
        public int Cols { get; }
        private ComplexNumber[,] data;
        public Matrix(int Rows, int Cols)
        {
            this.Rows = Rows;
            this.Cols = Cols;
            data = new ComplexNumber[Rows, Cols];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    data[i, j] = new ComplexNumber(0, 0);
                }
            }
                
        }

        public Matrix(ComplexNumber[,] x)
        {
            Rows = x.GetLength(0);
            Cols = x.GetLength(1);
            data = new ComplexNumber[Rows, Cols];
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    data[i, j] = new ComplexNumber(x[i, j].Real, x[i, j].Imaginary);
                }
            }
        }

        public ComplexNumber Get(int r, int c)
        {
            return data[r, c];
        }
        public void Set(int r, int c, ComplexNumber value) {
            data[r, c] = value;
        }

        public Matrix Multiply(Matrix other)
        {
            if (Cols != other.Rows)
            {
                Console.WriteLine("Error! col != row. Multi not possible");
                return new Matrix(Cols, other.Rows);
            }
            Matrix result = new Matrix(Rows, other.Cols);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < other.Cols; j++)
                {
                    ComplexNumber sum = new ComplexNumber(0, 0);
                    for (int k = 0; k < Cols; k++)
                    {
                        sum = sum.Add(data[i, k].Multiply(other.data[k, j]));
                    }
                    result.Set(i, j, sum);
                }
            return result;
        }
        public Matrix KroneckerProduct(Matrix other)
        {
            Matrix result = new Matrix(Rows * other.Rows, Cols * other.Cols);
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Cols; j++)
                {
                    for (int k = 0; k < other.Rows; k++)
                    {
                        for (int l = 0; l < other.Cols; l++)
                        {
                            result.Set(other.Rows * i + k, other.Cols * j + l, data[i, j].Multiply(other.Get(k, l)));

                        }
                    }
                }
            }
            return result;
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    data[i, j].PrintComplexNumber();
                }
            }
        }
    }

    public class StateVector
    {
        public int NumberOfQubits { get; }
        public ComplexNumber[] Amplitudes { get; }
        Random rnd = new Random();

        public StateVector(int numberOQB)
        {
            NumberOfQubits = numberOQB;
            Amplitudes = new ComplexNumber[(int) Math.Pow(2, numberOQB)];
            Amplitudes[0] = new ComplexNumber(1, 0);
            for (int i = 1; i < Amplitudes.Length; i++)
            {
                Amplitudes[i] = new ComplexNumber(0, 0);
            }
        }
        public StateVector(ComplexNumber[] amplitudes)
        {
            Amplitudes = new ComplexNumber[amplitudes.Length];
            NumberOfQubits = (int)Math.Log2(Amplitudes.Length);
            for (int i = 0; i < Amplitudes.Length; i++)
            {
                Amplitudes[i] = amplitudes[i];
            }
        }

        public StateVector(StateVector other)
        {
            NumberOfQubits = other.NumberOfQubits;
            Amplitudes = new ComplexNumber[other.Amplitudes.Length];
            for (int i = 0; i < Amplitudes.Length; i++)
            {
                Amplitudes[i] = new ComplexNumber(other.Amplitudes[i].Real, other.Amplitudes[i].Imaginary);
            }
        }

        public void Normalize()
        {
            double sum = 0;
            for(int i = 0; i < Amplitudes.Length; i++)
            {
                sum = sum + Amplitudes[i].SquireValue();
            }
            double normalConstant = 1 / Math.Sqrt(sum == 0? 1: sum);
            for (int i = 0; i < Amplitudes.Length; i++)
            {
                Amplitudes[i] = Amplitudes[i].Multiply(new ComplexNumber(normalConstant, 0));
            }
        }

        public double[] GetProbability(int target)
        {
            double probability0 = 0;
            double probability1 = 0;

            for (int i = 0; i <Amplitudes.Length; i++)
            {
                if((int)(i/Math.Pow(2, target))%2 == 0){
                    probability0 = probability0 + Amplitudes[i].SquireValue();
                }
                else
                {
                    probability1 = probability1 + Amplitudes[i].SquireValue();
                }
            }
            double[] probabilities = new double[2];
            probabilities[0] = probability0;
            probabilities[1] = probability1;

            return probabilities;
        }

        public int MeasureSingleQubit(int target)
        {
            double randomNumber = rnd.NextDouble();

            double[] p = GetProbability(target);
            double p0 = p[0];
            double p1 = p[1];

            int measuredValue = randomNumber < p0 ? 0 : 1;

            int mask = 1 << target;

            for (int i = 0; i < Amplitudes.Length; i++)
            {
                int bit = (i & mask) != 0 ? 1 : 0;

                if (bit != measuredValue)
                {
                    Amplitudes[i] = new ComplexNumber(0, 0);
                }
            }

            Normalize();
            return measuredValue;
        }

        public int[] MeasureAllQubit()
        {
            double randomNumber = rnd.NextDouble();
            double probabilityRange = 0;
            int[] qubitArray = new int[NumberOfQubits];
            int k = 0;
            for(int i = 0; i < Amplitudes.Length; i++)
            {
                probabilityRange += Amplitudes[i].SquireValue();
                if(randomNumber < probabilityRange)
                {
                    k = i;
                    break;
                }
            }
            for (int i = 0; i < Amplitudes.Length; i++)
            {
                if (i!=k)
                {
                    Amplitudes[i] = new ComplexNumber(0, 0);
                }
            }
            Normalize();
            for (int i = NumberOfQubits - 1; i >=0; i--)
            {
                qubitArray[i] = k % 2;
                k = k / 2;
            }
            return qubitArray;
        }
        
        public void ApplySingleQubitGate(Matrix gate, int target)
        {
            if (target >= NumberOfQubits || gate.Rows != 2 || gate.Cols != 2) return;

            int steps = (int)Math.Pow(2, target);

            for (int i = 0; i < Amplitudes.Length; i += steps * 2)
            {
                for (int j = i; j < i + steps; j++)
                {
                    int i0 = j;
                    int i1 = i0 ^ (1 << target);
                    ComplexNumber a0 = gate.Get(0, 0).Multiply(Amplitudes[i0]).Add(gate.Get(0, 1).Multiply(Amplitudes[i1]));
                    ComplexNumber a1 = gate.Get(1, 0).Multiply(Amplitudes[i0]).Add(gate.Get(1, 1).Multiply(Amplitudes[i1]));
                    Amplitudes[i0] = a0;
                    Amplitudes[i1] = a1;
                }
            }
        }

        public void ApplySingleQubitGate(Matrix gate, int control, int target)
        {
            if (target >= NumberOfQubits || gate.Rows != 2 || gate.Cols != 2)
            {
                                return;

            }
            int maskTarget = 1 << target;    
            int maskControl = 1 << control;  
            int length = Amplitudes.Length;
            for (int j = 0; j < length; j++)
            {
                if ((j & maskControl) == 0)
                {
                    continue;
                }
                int i0 = j;
                int i1 = j ^ maskTarget;  
                if (i0 > i1)
                {
                    continue;
                }
                ComplexNumber a0 = Amplitudes[i0];
                ComplexNumber a1 = Amplitudes[i1];
                ComplexNumber new0 = gate.Get(0, 0).Multiply(a0).Add(gate.Get(0, 1).Multiply(a1));
                ComplexNumber new1 = gate.Get(1, 0).Multiply(a0).Add(gate.Get(1, 1).Multiply(a1));
                Amplitudes[i0] = new0;
                Amplitudes[i1] = new1;
            }
        }
    }

    public static class GateLibrary
    {
        public static Matrix X()
        {
            return new Matrix(new ComplexNumber[,]
            {
            { new ComplexNumber(0, 0), new ComplexNumber(1, 0) },
            { new ComplexNumber(1, 0), new ComplexNumber(0, 0) }
            });
        }

        public static Matrix Z()
        {
            return new Matrix(new ComplexNumber[,]
            {
            { new ComplexNumber(1, 0),  new ComplexNumber(0, 0) },
            { new ComplexNumber(0, 0), new ComplexNumber(-1, 0) }
            });
        }

        public static Matrix H()
        {
            double s = 1.0 / Math.Sqrt(2);
            return new Matrix(new ComplexNumber[,]
            {
            { new ComplexNumber(s, 0),  new ComplexNumber(s, 0) },
            { new ComplexNumber(s, 0),  new ComplexNumber(-s, 0) }
            });
        }

        public static Matrix Y()
        {
            return new Matrix(new ComplexNumber[,]
            {
            { new ComplexNumber(0, 0),  new ComplexNumber(0, -1) },
            { new ComplexNumber(0, 1),  new ComplexNumber(0, 0) }
            });
        }
    }


    public class BellState
    {
        public static StateVector CreatePhiPlus()
        {
            StateVector entangledState = new StateVector(2);
            entangledState.ApplySingleQubitGate(GateLibrary.H(), 0);
            entangledState.ApplySingleQubitGate(GateLibrary.X(), 0, 1);
            return entangledState;
        }
    }

    public static class Teleportation
    {
        public static StateVector Teleport(StateVector unknown, StateVector bellState)
        {
            Matrix unknownMatrix = new Matrix(unknown.Amplitudes.Length, 1);
            for(int i = 0; i < unknown.Amplitudes.Length; i++)
            {
                unknownMatrix.Set(i, 0, unknown.Amplitudes[i]);
            }

            Matrix bellMatrix = new Matrix(bellState.Amplitudes.Length, 1);
            for(int i = 0; i < bellState.Amplitudes.Length; i++)
            {
                bellMatrix.Set(i, 0, bellState.Amplitudes[i]);
            }
            Matrix combinedMatrix = unknownMatrix.KroneckerProduct(bellMatrix);
            ComplexNumber[] combinedAmplitudes = new ComplexNumber[combinedMatrix.Rows];
            for(int i = 0; i < combinedMatrix.Rows; i++)
            {
                combinedAmplitudes[i] = combinedMatrix.Get(i, 0);
            }
            StateVector teleportedState = new StateVector(combinedAmplitudes);
            teleportedState.ApplySingleQubitGate(GateLibrary.X(), 0, 1);
            teleportedState.ApplySingleQubitGate(GateLibrary.H(), 0);
            int m0 = teleportedState.MeasureSingleQubit(0);
            int m1 = teleportedState.MeasureSingleQubit(1);
            if(m1 == 1)
            {
                teleportedState.ApplySingleQubitGate(GateLibrary.X(), 2);
            }
            if(m0 == 1)
            {
                teleportedState.ApplySingleQubitGate(GateLibrary.Z(), 2);
            }
            return teleportedState;
        }
    }

public class Program
    {
        static void PrintState(string label, StateVector sv)
        {
            Console.WriteLine(label);
            for (int i = 0; i < sv.Amplitudes.Length; i++)
            {
                Console.Write($"|{Convert.ToString(i, 2).PadLeft(sv.NumberOfQubits, '0')}>: ");
                sv.Amplitudes[i].PrintComplexNumber();
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Step 1: Create a Bell state (|Φ+> = (|00> + |11>) / √2)
            StateVector bellState = BellState.CreatePhiPlus();
            Console.WriteLine("=== BELL STATE |Φ+> BEFORE MEASUREMENT ===");
            PrintState("Bell State |Φ+>:", bellState);

            // Step 2: Create an unknown state (for example, |0> state)
            StateVector unknownState = new StateVector(1); // Creating a state with 1 qubit, which is initialized to |0>
            Console.WriteLine("=== UNKNOWN STATE ===");
            unknownState.ApplySingleQubitGate(GateLibrary.H(), 0);
            unknownState.ApplySingleQubitGate(GateLibrary.Y(), 0);
            PrintState("Unknown State:", unknownState);

            // Step 3: Teleport the unknown state using the Bell state
            Console.WriteLine("\n=== TELEPORTING STATE ===");
            StateVector teleportedState = Teleportation.Teleport(unknownState, bellState);

            // Step 4: Print the final state after teleportation
            Console.WriteLine("\n=== TELEPORTED STATE ===");
            PrintState("Teleported State:", teleportedState);

            // Step 5: Measure the teleported state
            int[] result = teleportedState.MeasureAllQubit();
            Console.WriteLine("=== MEASUREMENT RESULT ===");
            Console.WriteLine($"Measured: {string.Join("", result)}");

            // Step 6: Print the final collapsed state after measurement
            Console.WriteLine("\n=== FINAL STATE AFTER MEASUREMENT ===");
            PrintState("Collapsed State:", teleportedState);

            Console.ReadKey();
        }
    }
}











    //Important followups (make your project feel pro)






    //Save/Load circuits as JSON (circuit = list of gates with targets and time steps).

    //Circuit runner(time-step execution) — support stepping through columns of gates and visualizing collapse after measurements.

    //Stretch / CV-boosters

    //Teleportation demo — uses H, CNOT and measurements; visually impressive and shows understanding.

    //Parameterised rotation gates(Rx, Ry, Rz) and Rx(theta) as Matrix factory.

    //Performance small wins — use 1<<target everywhere, reuse temporaries, and consider Parallel.For for larger registers.

    //If you want a single next action to show the team right now:

    //Implement CNOT + a Bell state demo (H on qubit 0, CNOT control = 0 target= 1, then MeasureAllQubit and show correlated results).

    //Tell me which of the above you want me to produce next(I can give you the exact code for CNOT, ApplyControlledGate, Bell demo, or tests). Which one?


//    QuantumSim/
//│
//├── Math/
//│   ├── ComplexNumber.cs
//│   ├── Matrix.cs
//│
//├── Core/
//│   ├── QubitRegister.cs
//│   ├── QuantumGate.cs
//│   ├── GateLibrary.cs
//│   ├── QuantumCircuit.cs
//│   ├── MeasurementEngine.cs
//│
//├── Algorithms/
//│   ├── BellState.cs
//│   ├── Teleportation.cs
//│
//├── Tests/
//│   ├── GateTests.cs
//│   ├── BellStateTests.cs
//│
//└── Program.cs(Console sandbox for now)


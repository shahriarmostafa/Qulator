
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sim1Test.Maths;
namespace Sim1Test.Circuit
{
    public class StateVector
    {
        public int NumberOfQubits { get; }
        public ComplexNumber[] Amplitudes { get; }
        Random rnd = new Random();

        public StateVector(int numberOQB)
        {
            NumberOfQubits = numberOQB;
            Amplitudes = new ComplexNumber[1<< numberOQB];
            Amplitudes[0] = new ComplexNumber(1, 0);
            for (int i = 1; i < Amplitudes.Length; i++)
            {
                Amplitudes[i] = new ComplexNumber(0, 0);
            }
        }
        public StateVector(ComplexNumber[] amplitudes)
        {
            Amplitudes = new ComplexNumber[amplitudes.Length];
            NumberOfQubits = (int)Math.Log(Amplitudes.Length, 2);
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
            for (int i = 0; i < Amplitudes.Length; i++)
            {
                sum = sum + Amplitudes[i].SquireValue();
            }
            double normalConstant = 1 / Math.Sqrt(sum == 0 ? 1 : sum);
            for (int i = 0; i < Amplitudes.Length; i++)
            {
                Amplitudes[i] = Amplitudes[i].Multiply(new ComplexNumber(normalConstant, 0));
            }
        }

        public double[] GetProbability(int target)
        {
            double probability0 = 0;
            double probability1 = 0;

            for (int i = 0; i < Amplitudes.Length; i++)
            {
                if ((int)(i / Math.Pow(2, target)) % 2 == 0)
                {
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
            for (int i = 0; i < Amplitudes.Length; i++)
            {
                probabilityRange += Amplitudes[i].SquireValue();
                if (randomNumber < probabilityRange)
                {
                    k = i;
                    break;
                }
            }
            for (int i = 0; i < Amplitudes.Length; i++)
            {
                if (i != k)
                {
                    Amplitudes[i] = new ComplexNumber(0, 0);
                }
            }
            Normalize();
            for (int i = 0; i< NumberOfQubits; i++)
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
        public void ApplySingleQubitGate(Matrix gate, int control, int control2, int target)
        {
            if (target >= NumberOfQubits || gate.Rows != 2 || gate.Cols != 2)
                return;

            int maskTarget = 1 << target;
            int maskControl = 1 << control;
            int maskControl2 = 1 << control2;

            int length = Amplitudes.Length;

            for (int j = 0; j < length; j++)
            {
                if ((j & maskControl) == 0 || (j & maskControl2) == 0)
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
        public void ApplySingleQubitGate4Controls(Matrix gate,
                                          int control1,
                                          int control2,
                                          int control3,
                                          int control4,
                                          int target)
        {
            if (target >= NumberOfQubits || gate.Rows != 2 || gate.Cols != 2)
                return;

            int maskT = 1 << target;
            int mask1 = 1 << control1;
            int mask2 = 1 << control2;
            int mask3 = 1 << control3;
            int mask4 = 1 << control4;

            int length = Amplitudes.Length;

            for (int j = 0; j < length; j++)
            {
                if ((j & mask1) == 0 || (j & mask2) == 0 ||
                    (j & mask3) == 0 || (j & mask4) == 0)
                {
                    continue;
                }

                int i0 = j;
                int i1 = j ^ maskT;

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

}

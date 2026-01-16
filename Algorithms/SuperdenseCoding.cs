using Sim1Test.Circuit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.Algorithms
{
    public class SuperdenseCoding
    {
        StateVector state;
        int message1, message2;
        int[] decodedBits;
        public SuperdenseCoding()
        {
            Console.WriteLine("Default one");
        }
        public SuperdenseCoding(int bit0, int bit1)
        {
            message1 = bit0;
            message2 = bit1;
        }
        public void PrepareBell()
        {
            state = BellState.CreatePhiPlus();
        }

        public int[] RunOnce()
        {
            PrepareBell();
            Encode(message1, message2);
            DecodeAndMeasure();
            return GetDecodedBits(); // return the measured result, not the original message
        }

        public int[,] RunShots(int count)
        {
            int[,] results = new int[count, 2];
            for (int i = 0; i < count; i++)
            {
                int[] res = RunOnce();
                results[i, 0] = res[0];
                results[i, 1] = res[1];
            }
            return results;
        }


        public void SetMessage(int b0, int b1)
        {
            message1 = b0;
            message2 = b1;
        }



        public void Encode(int bit0, int bit1)
        {
            if (bit0 == 1)
            {
                state.ApplySingleQubitGate(GateLibrary.Z(), 0);
            }
            if (bit1 == 1)
            {
                state.ApplySingleQubitGate(GateLibrary.X(), 0);
            }
        }
        public void DecodeAndMeasure()
        {
            state.ApplySingleQubitGate(GateLibrary.X(), 0, 1);
            state.ApplySingleQubitGate(GateLibrary.H(), 0);
            decodedBits = state.MeasureAllQubit();
        }
        public int[] GetDecodedBits()
        {
            return decodedBits;
        }
        public StateVector GetState()
        {
            return state;
        }
    }
}

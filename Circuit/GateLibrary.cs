using Sim1Test.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.Circuit
{
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
            double s = 1 / Math.Sqrt(2);
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
        public static Matrix S()
        {
            return new Matrix(new ComplexNumber[,]
            {
                { new ComplexNumber(1, 0), new ComplexNumber(0, 0) },
                { new ComplexNumber(0, 0), new ComplexNumber(0, 1) }
            });
        }
        public static Matrix T()
        {
            double onebyroute2 = 1 / Math.Sqrt(2);
            return new Matrix(new ComplexNumber[,]
            {
                { new ComplexNumber(1, 0), new ComplexNumber(0, 0) },
                { new ComplexNumber(0, 0), new ComplexNumber(onebyroute2, onebyroute2) }
            });
        }

    }

}

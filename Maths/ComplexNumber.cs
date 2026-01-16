using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.Maths
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
}

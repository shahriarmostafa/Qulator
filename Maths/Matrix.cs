using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim1Test.Maths
{
    public class Matrix
    {
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
        public void Set(int r, int c, ComplexNumber value)
        {
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
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
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
}

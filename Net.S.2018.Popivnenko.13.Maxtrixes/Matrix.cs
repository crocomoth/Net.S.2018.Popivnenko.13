using System;

namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    public class Matrix<T> where T : ISummarable<T>
    {
        protected T[,] Elements;

        public Matrix(T[,] elements)
        {
            Elements = elements ?? throw new ArgumentNullException(nameof(elements));
        }

        public Matrix(int dimension1, int dimension2)
        {
            Elements = new T[dimension1, dimension2];
        }

        public virtual T this[int index1, int index2]
        {
            get => Elements[index1, index2];
            set => Elements[index1, index2] = value;
        }

        public static Matrix<T> SumMatrix(Matrix<T> first, Matrix<T> second)
        {
            if ((first.Elements.GetLength(0) != second.Elements.GetLength(0)) &&
                (first.Elements.GetLength(1) != second.Elements.GetLength(1)))
            {
                throw new InvalidOperationException("matrixes have different sizes");
            }

            var resultMatrix = new Matrix<T>(first.Elements.GetLength(0), first.Elements.GetLength(1));
            for (int i = 0; i < first.Elements.GetLength(0); i++)
            {
                for (int j = 0; j  < first.Elements.GetLength(1); j++)
                {
                    resultMatrix.Elements[i, j] = first.Elements[i, j].SumWith(second.Elements[i, j]);
                }
            }

            return resultMatrix;
        }       
    }
}

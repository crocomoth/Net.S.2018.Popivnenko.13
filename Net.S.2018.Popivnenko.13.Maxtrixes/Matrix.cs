using System;

namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    /// <summary>
    /// Basic matrix class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Matrix<T> where T : ISummarable<T>
    {
        protected T[,] Elements;

        /// <summary>
        /// Constructor which uses array to initialize object.
        /// throws <see cref="ArgumentNullException"/> if array is <see langword="null"/>
        /// </summary>
        /// <param name="elements">Array to be use in initializing.</param>
        public Matrix(T[,] elements)
        {
            Elements = elements ?? throw new ArgumentNullException(nameof(elements));
        }

        /// <summary>
        /// Constuctor which uses dimensions to create an object.
        /// </summary>
        /// <param name="dimension1">First dimension capacity.</param>
        /// <param name="dimension2">Second dimension capacity.</param>
        public Matrix(int dimension1, int dimension2)
        {
            Elements = new T[dimension1, dimension2];
        }

        public virtual T this[int index1, int index2]
        {
            get => Elements[index1, index2];
            set => Elements[index1, index2] = value;
        }

        /// <summary>
        /// Static method to implement summing of matrixes.
        /// </summary>
        /// <param name="first">First matrix.</param>
        /// <param name="second">Second matrix.</param>
        /// <returns>Result of operation.</returns>
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

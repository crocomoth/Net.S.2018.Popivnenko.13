using System;

namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    /// <summary>
    /// Square matrix.
    /// Two dimension's are even.
    /// </summary>
    /// <typeparam name="T">Type of a concrete object.</typeparam>
    public class SquareMatrix<T> : Matrix<T> where T : ISummarable<T>
    {
        /// <summary>
        /// Constructor same to base <see cref="Matrix{T}"/>
        /// throws <exception cref="ArgumentException"></exception> if dimension's aren't even.
        /// </summary>
        /// <param name="elements">Array to used to initialize object.</param>
        public SquareMatrix(T[,] elements) : base(elements)
        {
            if (elements.GetLength(0) != elements.GetLength(1))
            {
                throw new ArgumentException(nameof(elements));
            }
        }

        /// <summary>
        /// Constructor same to bas <see cref="Matrix{T}"/>.
        /// throws <exception cref="ArgumentException"></exception> if dimension's aren't even.
        /// </summary>
        /// <param name="dimension1">First dimension.</param>
        /// <param name="dimension2">Second dimension.</param>
        public SquareMatrix(int dimension1, int dimension2) : base(dimension1, dimension2)
        {
            if (dimension1 != dimension2)
            {
                throw new ArgumentException(nameof(dimension2));
            }
        }
    }
}

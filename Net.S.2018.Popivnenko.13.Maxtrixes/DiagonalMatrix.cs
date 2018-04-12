using System;

namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    /// <summary>
    /// Diagonal matrix implementation.
    /// </summary>
    /// <typeparam name="T">Type of object to be used in matrix.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T> where T : ISummarable<T>
    {
        /// <summary>
        /// Constructor which uses same rules as base <see cref="Matrix{T}"/>
        /// throws <exception cref="ArgumentException"></exception> if matrix is not diagonal.
        /// </summary>
        /// <param name="elements">Array to be used in initialization.</param>
        public DiagonalMatrix(T[,] elements) : base(elements)
        {
            if (!this.CheckConstructor(elements))
            {
                throw new ArgumentException(nameof(elements));
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Same to base <see cref="T:Net.S._2018.Popivnenko._13.Maxtrixes.Matrix`1" />.
        /// throws <exception cref="T:System.ArgumentException"></exception> if dimensions aren't even.
        /// </summary>
        /// <param name="dimension1">First dimension.</param>
        /// <param name="dimension2">Second dimension.</param>
        public DiagonalMatrix(int dimension1, int dimension2) : base(dimension1, dimension2)
        {
            if (dimension1 != dimension2)
            {
                throw new ArgumentException(nameof(dimension2));
            }
        }

        /// <summary>
        /// Overriden indexer.
        /// </summary>
        /// <param name="index1">First index.</param>
        /// <param name="index2">Second index.</param>
        /// <returns>Element from matrix specified by indexes.</returns>
        public override T this[int index1, int index2]
        {
            get => base[index1, index2];
            set => this.ChangeElem(index1, index2, value);
        }

        private bool CheckConstructor(T[,] values)
        {
            var baseValue = default(T);
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        if (!values[i, j].Equals(baseValue))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void ChangeElem(int index1, int index2, T value)
        {
            if (index1 == index2)
            {
                this.Elements[index1, index2] = value;
            }
        }
    }
}

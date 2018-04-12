namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    /// <summary>
    /// Implements mirrored matrix.
    /// </summary>
    /// <typeparam name="T">Type of concrete object to be used in matrix.</typeparam>
    public class MirrorMatrix<T> : SquareMatrix<T> where T : ISummarable<T>
    {
        /// <summary>
        /// Basic constructor same to base <see cref="Matrix{T}"/>
        /// </summary>
        /// <param name="elements"></param>
        public MirrorMatrix(T[,] elements) : base(elements)
        {
        }

        /// <summary>
        /// Constructor with dimensions same to base <see cref="Matrix{T}"/>
        /// </summary>
        /// <param name="dimension1">First dimension capacity.</param>
        /// <param name="dimension2">Second dimension capacity.</param>
        public MirrorMatrix(int dimension1, int dimension2) : base(dimension1, dimension2)
        {
        }

        /// <summary>
        /// Overriden indexer.
        /// </summary>
        /// <param name="index1">First index.</param>
        /// <param name="index2">Second index.</param>
        /// <returns>Values from matrix by secified index.</returns>
        public override T this[int index1, int index2]
        {
            get => base[index1, index2];
            set => this.ChangeAtIndex(index1, index2, value); 
        }

        private void ChangeAtIndex(int index1, int index2, T value)
        {
            this.Elements[index1, index2] = value;
            this.Elements[index2, index1] = value;
        }
    }
}

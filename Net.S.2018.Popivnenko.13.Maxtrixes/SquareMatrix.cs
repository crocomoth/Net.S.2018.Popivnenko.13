using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    public class SquareMatrix<T> : Matrix<T> where T : ISummarable<T>
    {
        public SquareMatrix(T[,] elements) : base(elements)
        {
            if (elements.GetLength(0) != elements.GetLength(1))
            {
                throw new ArgumentException(nameof(elements));
            }
        }

        public SquareMatrix(int dimension1, int dimension2) : base(dimension1, dimension2)
        {
            if (dimension1 != dimension2)
            {
                throw new ArgumentException(nameof(dimension2));
            }
        }
    }
}

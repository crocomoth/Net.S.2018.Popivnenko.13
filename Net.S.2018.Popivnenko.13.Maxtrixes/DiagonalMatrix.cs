using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    public class DiagonalMatrix<T> : SquareMatrix<T> where T : ISummarable<T>
    {
        public DiagonalMatrix(T[,] elements) : base(elements)
        {
            if (!this.CheckConstructor(elements))
            {
                throw new ArgumentException(nameof(elements));
            }
        }

        public DiagonalMatrix(int dimension1, int dimension2) : base(dimension1, dimension2)
        {
        }

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

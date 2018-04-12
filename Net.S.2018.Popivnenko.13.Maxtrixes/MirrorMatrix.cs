using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    public class MirrorMatrix<T> : SquareMatrix<T> where T : ISummarable<T>
    {
        public MirrorMatrix(T[,] elements) : base(elements)
        {
        }

        public MirrorMatrix(int dimension1, int dimension2) : base(dimension1, dimension2)
        {
        }

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

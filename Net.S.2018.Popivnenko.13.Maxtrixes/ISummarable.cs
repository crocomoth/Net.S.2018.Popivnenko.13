using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    public interface ISummarable<T>
    {
        T SumWith(ISummarable<T> second);
    }
}

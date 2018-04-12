using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Popivnenko._13.Queue
{
    public class QueueClass<T> : IEnumerator<T>
    {
        private T[] _elements;
        private int _size;
        private int _tail;
        private int _head;
        private T _current;

        public QueueClass(T[] elements)
        {
            _elements = elements ?? throw new ArgumentNullException(nameof(elements));
            this._size = 0;
            this._head = 0;
            this._tail = 0;
        }

        public QueueClass()
        {
            _elements = new T[16];
            this._size = 0;
            this._head = 0;
            this._tail = 0;
        }

        public T Current
        {
            get => _current = _size > 0 ? _elements[_head] : throw new IndexOutOfRangeException(nameof(Current));
            private set => _current = value;
        }

        object IEnumerator.Current => Current;

        public void Enqueue(T elem)
        {
            if (_size == _elements.Length)
            {
                DoubleArray();
            }

            _elements[_tail] = elem;
            _tail++;
            _size++;
        }

        public T Dequeue()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException("queue is empty");
            }

            T result = _elements[_head];
            _head++;
            _size--;
            return result;
        }

        public void Dispose()
        {
            this._elements = new T[16];
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        public bool MoveNext()
        {
            this.Current = this.Dequeue();
            return _head <= _tail;
        }

        public void Reset()
        {
            this.Dispose();
        }

        private void DoubleArray()
        {
            var newArray = new T[_size * 2];
            if (this._size > 0)
            {
                Array.Copy(this._elements, this._head, newArray, 0, this._size);
            }

            this._elements = newArray;
            _head = 0;
            _tail = _size;
        }
    }
}

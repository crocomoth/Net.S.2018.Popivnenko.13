using System;
using System.Collections;
using System.Collections.Generic;

namespace Net.S._2018.Popivnenko._13.Queue
{
    /// <summary>
    /// Implements basic work with queues.
    /// </summary>
    /// <typeparam name="T">Type of queued elements.</typeparam>
    public class QueueClass<T> : IEnumerator<T>
    {
        private T[] _elements;
        private int _size;
        private int _tail;
        private int _head;
        private T _current;

        /// <summary>
        /// Constructor.
        /// throws <see cref="ArgumentNullException"/> case <paramref name="elements"/> is null.
        /// </summary>
        /// <param name="elements">Elements which will be used for queue.</param>
        public QueueClass(T[] elements)
        {
            _elements = elements ?? throw new ArgumentNullException(nameof(elements));
            this._size = 0;
            this._head = 0;
            this._tail = 0;
        }

        /// <summary>
        /// Basic constructor for a class.
        /// </summary>
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

        /// <summary>
        /// Enqueues <paramref name="elem"/> to the queue.
        /// </summary>
        /// <param name="elem">Object to be enqueued.</param>
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

        /// <summary>
        /// Gets first object from queue.
        /// throws <exception cref="InvalidOperationException"></exception> if queue is empty.
        /// </summary>
        /// <returns>Dequed object.</returns>
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

        /// <summary>
        /// Basically resets the collection.
        /// </summary>
        public void Dispose()
        {
            this._elements = new T[16];
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        /// <summary>
        /// Moves queue head to next position.
        /// </summary>
        /// <returns>True if next elem is dequed.</returns>
        public bool MoveNext()
        {
            this.Current = this.Dequeue();
            return _head <= _tail;
        }

        /// <summary>
        /// Resets the collection.
        /// </summary>
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

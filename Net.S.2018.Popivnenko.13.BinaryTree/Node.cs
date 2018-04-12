using System;

namespace Net.S._2018.Popivnenko._13.BinaryTree
{
    public class Node<T>
    {
        private T value;
        private Node<T> _leftNode;
        private Node<T> _rightNode;

        public Node(T value)
        {
            this.value = value;
            RightNode = null;
            LeftNode = null;
        }

        public Node<T> LeftNode { get => _leftNode; set => _leftNode = value; }

        public Node<T> RightNode { get => _rightNode; set => _rightNode = value; }

        public T GetValue() => this.value;
    }
}

namespace Net.S._2018.Popivnenko._13.BinaryTree
{
    /// <summary>
    /// Implements basic node funtionality.
    /// </summary>
    /// <typeparam name="T">Type of object to stored.</typeparam>
    public class Node<T>
    {
        private T value;
        private Node<T> _leftNode;
        private Node<T> _rightNode;

        /// <summary>
        /// Constructor which uses <paramref name="value"/> to initialize object.
        /// </summary>
        /// <param name="value">Value to be stored in node.</param>
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

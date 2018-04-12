using System;
using System.Collections.Generic;

namespace Net.S._2018.Popivnenko._13.BinaryTree
{
    /// <summary>
    /// Implements basic binary tree functionality.
    /// </summary>
    /// <typeparam name="T">Type of objects to be stored.</typeparam>
    public class Tree<T>
    {
        private Node<T> _headNode;
        private IComparer<T> comparer;

        /// <summary>
        /// Basic tree constructor which uses <see cref="Node{T}"/> to initialize object.
        /// throws <exception cref="ArgumentNullException"></exception>
        /// if <paramref name="headNode"/> is null.
        /// </summary>
        /// <param name="headNode">Node to be used to initialize tree.</param>
        public Tree(Node<T> headNode)
        {
            HeadNode = headNode ?? throw new ArgumentNullException(nameof(headNode));
            comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Badic constructor.
        /// </summary>
        /// <param name="elem">Elem to be put in head node.</param>
        public Tree(T elem)
        {
            HeadNode = new Node<T>(elem);
            comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Constructor which allows to pass custom <see cref="IComparer{T}"/>.
        /// throws <exception cref="ArgumentNullException"></exception> if any of arguments is null.
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/> to be used.</param>
        /// <param name="headNode">Head node of a tree.</param>
        public Tree(IComparer<T> comparer, Node<T> headNode)
        {
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            HeadNode = headNode ?? throw new ArgumentNullException(nameof(headNode));
        }

        /// <summary>
        /// Same to previous constructor.
        /// </summary>
        /// <param name="headNode">Head node to be used.</param>
        /// <param name="comparer">Comparer to be used.</param>
        public Tree(Node<T> headNode, IComparer<T> comparer) : this(headNode)
        {
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        public Node<T> HeadNode { get => _headNode; set => _headNode = value; }

        /// <summary>
        /// Allows to add new node to a tree.
        /// </summary>
        /// <param name="elem">Elem to be stored in a new node.</param>
        public void AddNode(T elem)
        {
            var currentElem = HeadNode;
            while (currentElem != null)
            {
                if (comparer.Compare(elem, currentElem.GetValue()) < 0)
                {
                    if (currentElem.LeftNode == null)
                    {
                        currentElem.LeftNode = new Node<T>(elem);
                        return;
                    }

                    currentElem = currentElem.LeftNode;
                }
                else
                {
                    if (currentElem.RightNode == null)
                    {
                        currentElem.RightNode = new Node<T>(elem);
                        return;
                    }

                    currentElem = currentElem.RightNode;
                }
            }
        }

        /// <summary>
        /// One of a tree enumarators.
        /// </summary>
        /// <returns>Sequence of tree node's elements.</returns>
        public IEnumerable<T> PreOrder()
        {
            if (HeadNode == null)
            {
                yield break;
            }

            var stack = new Stack<Node<T>>();
            stack.Push(HeadNode);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                yield return node.GetValue();

                if (node.RightNode != null)
                {
                    stack.Push(node.RightNode);
                }

                if (node.LeftNode != null)
                {
                    stack.Push(node.LeftNode);
                }
            }
        }

        /// <summary>
        /// One of a tree enumerators.
        /// </summary>
        /// <returns>Sequence of tree node's elements.</returns>
        public IEnumerable<T> Postorder()
        {
            if (HeadNode == null)
            {
                yield break;
            }

            var stack = new Stack<Node<T>>();
            var node = HeadNode;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && node.RightNode == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(node);
                        node = node.RightNode;
                    }
                    else
                    {
                        yield return node.GetValue();
                        node = null;
                    }
                }
                else
                {
                    if (node.RightNode != null)
                    {
                        stack.Push(node.RightNode);
                    }

                    stack.Push(node);
                    node = node.LeftNode;
                }
            }
        }

        /// <summary>
        /// One of a tree enumerators.
        /// </summary>
        /// <returns>Sequence of tree node's elements.</returns>
        public IEnumerable<T> Inorder()
        {
            if (HeadNode == null)
            {
                yield break;
            }

            var stack = new Stack<Node<T>>();
            var node = HeadNode;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.GetValue();

                    if (node.RightNode != null)
                    {
                        node = stack.Pop();
                    }
                    else
                    {
                        node = null;
                    }
                }
                else
                {
                    if (node.RightNode != null)
                    {
                        stack.Push(node.RightNode);
                    }

                    stack.Push(node);
                    node = node.LeftNode;
                }
            }
        }
    }
}

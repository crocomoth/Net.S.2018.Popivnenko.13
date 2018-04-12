using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Popivnenko._13.BinaryTree
{
    public class Tree<T>
    {
        private Node<T> _headNode;
        private IComparer<T> comparer;

        public Tree(Node<T> headNode)
        {
            HeadNode = headNode ?? throw new ArgumentNullException(nameof(headNode));
            comparer = Comparer<T>.Default;
        }

        public Tree(T elem)
        {
            HeadNode = new Node<T>(elem);
            comparer = Comparer<T>.Default;
        }

        public Tree(IComparer<T> comparer, Node<T> headNode)
        {
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            HeadNode = headNode ?? throw new ArgumentNullException(nameof(headNode));
        }

        public Tree(Node<T> headNode, IComparer<T> comparer) : this(headNode)
        {
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        public Node<T> HeadNode { get => _headNode; set => _headNode = value; }

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

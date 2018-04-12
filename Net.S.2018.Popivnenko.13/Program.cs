using System;
using Net.S._2018.Popivnenko._13.BinaryTree;

namespace Net.S._2018.Popivnenko._13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(10);
            tree.AddNode(8);
            tree.AddNode(12);
            tree.AddNode(7);
            tree.AddNode(9);
            tree.AddNode(11);
            tree.AddNode(13);
            foreach (var elem in tree.PreOrder())
            {
                Console.WriteLine(elem.ToString());
            }

            foreach (var elem in tree.Postorder())
            {
                Console.WriteLine(elem.ToString());
            }

            Console.ReadLine();
        }
    }
}

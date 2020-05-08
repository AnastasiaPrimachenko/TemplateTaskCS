using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            BT<int> root = new BT<int>(15);
            for (int i = 1; i <= 150; ++i)
            {
                root.add_node(rnd.Next(1, 31));
            }
            Console.WriteLine("Print full tree: ");
            root.full_print(); //full tree
            root.delete_node(20);
            Console.WriteLine();
            Console.WriteLine("Print full tree after deleting one element: ");
            root.full_print(); //tree after deleting one node
            Console.WriteLine();
            Console.Write("Traverse: ");
            root.traverse();
            Console.WriteLine();
            BT<int> node = root.search(15);
            Console.WriteLine("Parent: " + node.get_parent().ToString());
            Console.WriteLine("Left Child: " + node.get_left().ToString());
            Console.WriteLine("Right Child: " + node.get_right().ToString());
            Console.Write("Print leaves: ");
            root.leaves_print();
            Console.Read();
        }
    }
}

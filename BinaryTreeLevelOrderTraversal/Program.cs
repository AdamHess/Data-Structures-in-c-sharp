using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLevelOrderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree();

            tree.InsertValue(5);
            tree.InsertValue(6);
            tree.InsertValue(2);
            tree.InsertValue(4);
            tree.InsertValue(7);
            tree.InsertValue(1);
            tree.InsertValue(3);
            tree.InsertValue(8);
            tree.InsertValue(9);
            tree.InsertValue(10);

            tree.InOrderTraversal();

            tree.LevelOrderTraversal();
            Console.ReadKey();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLevelOrderTraversal
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode LeftChild { get; set; } = null;
        public BinaryTreeNode RightChild { get; set; } = null; 
        public int Data { get; set; }


        public bool NoChildren => RightChild == null && LeftChild == null;
        public BinaryTreeNode()
        {
        }
    }
}

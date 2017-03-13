using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLevelOrderTraversal
{
    public class BinaryTree
    {
        public BinaryTreeNode RootNode { get; set; } = null;

        public void InOrderTraversal()
        {
            InOrderTraversalRecursive(RootNode);
        }

        private static void InOrderTraversalRecursive(BinaryTreeNode node)
        {
            if (node != null)
            {
                InOrderTraversalRecursive(node.LeftChild);
                Console.WriteLine(node.Data);
                InOrderTraversalRecursive(node.RightChild);
            }

        }

        public void InsertValue(int value)
        {
            var node = new BinaryTreeNode
            {
                Data = value
            };
            InsertNode(node);            
        }
        public void InsertNode(BinaryTreeNode node)
        {
            if (RootNode == null)
            {
                RootNode = node;
            }
            else if (node != null)
            {
                InsertNodeRecursive(RootNode, node);
            }
        }

        private static void InsertNodeRecursive(BinaryTreeNode currentNode, BinaryTreeNode insertionNode)
        {
            if (currentNode == null) return;

            if (insertionNode.Data > currentNode.Data)
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = insertionNode;
                }
                else
                {
                    InsertNodeRecursive(currentNode.LeftChild, insertionNode);
                }
            }
            else
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = insertionNode;
                }
                else
                {
                    InsertNodeRecursive(currentNode.RightChild, insertionNode);
                }
            }                            
        }


        public void LevelOrderTraversal()
        {
            Console.WriteLine("-----Level Order Traversal-----");
            var currentLevelQueue = new Queue<BinaryTreeNode>();
            var processedCurrentLevelQueue = new Queue<BinaryTreeNode>();
            var NextLevelQueue = new Queue<BinaryTreeNode>();

            currentLevelQueue.Enqueue(RootNode);
            while(currentLevelQueue.Any())
            {
                var currentNode = currentLevelQueue.Dequeue();
                if (currentNode.LeftChild != null)
                {
                    NextLevelQueue.Enqueue(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    NextLevelQueue.Enqueue(currentNode.RightChild);
                }
                processedCurrentLevelQueue.Enqueue(currentNode);
                if (!currentLevelQueue.Any())
                {
                    foreach(var node in processedCurrentLevelQueue)
                    {
                        Console.Write($"{node.Data} ");
                    }
                    Console.Write("\n");
                    currentLevelQueue = NextLevelQueue;
                    processedCurrentLevelQueue = new Queue<BinaryTreeNode>();
                    NextLevelQueue = new Queue<BinaryTreeNode>();                 
                }
            }


        }

    }
}

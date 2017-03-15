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
                Console.WriteLine(node.Key);
                InOrderTraversalRecursive(node.RightChild);
            }

        }

        public void InsertValue(int value)
        {
            var node = new BinaryTreeNode
            {
                Key = value
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

            if (insertionNode.Key > currentNode.Key)
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
            if (RootNode == null) return;
            var currentLevelQueue = new Queue<BinaryTreeNode>();
            var processedCurrentLevelQueue = new Queue<BinaryTreeNode>();
            var NextLevelQueue = new Queue<BinaryTreeNode>();

            currentLevelQueue.Enqueue(RootNode);
            while (currentLevelQueue.Any())
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
                    foreach (var node in processedCurrentLevelQueue)
                    {
                        Console.Write($"{node.Key} ");
                    }
                    Console.Write("\n");
                    currentLevelQueue = NextLevelQueue;
                    processedCurrentLevelQueue = new Queue<BinaryTreeNode>();
                    NextLevelQueue = new Queue<BinaryTreeNode>();
                }
            }
        }

        public void PrettyPrint()
        {
            PrettyPrint("", RootNode);
        }

        private static void PrettyPrint(string indent, BinaryTreeNode currentNode)
        {
            if (currentNode == null) return;
            Console.WriteLine($"{indent}-{currentNode.Key}");
            if (!currentNode.NoChildren)
            {
                PrettyPrint(indent + "    |", currentNode.LeftChild);
                PrettyPrint(indent + "    |", currentNode.RightChild);
            }
        }

        public BinaryTreeNode Find(int key)
        {
            return RecursiveFind(key, RootNode);

        }

        private BinaryTreeNode RecursiveFind(int key, BinaryTreeNode currentNode)
        {

            if (currentNode.Key == key)
            {
                return currentNode;
            }
            else if (currentNode.Key < key && currentNode.LeftChild != null)
            {
                return RecursiveFind(key, currentNode.LeftChild);
            }
            else if (currentNode.RightChild != null)
            {
                return RecursiveFind(key, currentNode.RightChild);
            }
            else
            {
                return null;
            }

        }

    }
}

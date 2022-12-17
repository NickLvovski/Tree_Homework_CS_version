using System;

namespace Algo_for_Anton.SLAYYYTER
{
    internal class Traversal
    {
        private static Traversal instance;

        private Traversal()
        { }

        public static Traversal getInstance()
        {
            if (instance == null)
                instance = new Traversal();
            return instance;
        }

        public void preOrder(Node node)
        {
            // прямой обход
            node.Print();

            if (node.LeftChild != null)
            {
                preOrder(node.LeftChild);
            }
            if (node.RightChild != null)
            {
                preOrder(node.RightChild);
            }
        }

        public void postOrder(Node node)
        {
            // обратный обход
            if (node.LeftChild != null)
            {
                postOrder(node.LeftChild);
            }
            if (node.RightChild != null)
            {
                postOrder(node.RightChild);
            }

            node.Print();
        }

        public void inOrder(Node node)
        {
            // симметричный обход
            if (node.LeftChild != null)
            {
                inOrder(node.LeftChild);
            }

            node.Print();

            if (node.RightChild != null)
            {
                inOrder(node.RightChild);
            }
        }

        public void fillTreeA(Node node, BinaryTree newTree)
        {
            // инициализация дерева A в обратном порядке.
            if (node.LeftChild != null)
            {
                fillTreeA(node.LeftChild, newTree);
            }
            if (node.RightChild != null)
            {
                fillTreeA(node.RightChild, newTree);
            }

            newTree.InsertNode(node.Value);
        }
    }
}

using System;

namespace Algo_for_Anton.SLAYYYTER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Traversal traversal = Traversal.getInstance();
            int[] values = { 51, 43, 12, 45, 1, 52, 53, 3, 4, 212, 90, 34 };
            BinaryTree treeB = new BinaryTree();
            BinaryTree treeA = new BinaryTree();

            foreach (int value in values)
                treeB.InsertNode(value);
            traversal.fillTreeA(treeB.RootNode, treeA); // заполнение дерева A
            Console.WriteLine("Прямой обход дерева A:");
            traversal.preOrder(treeA.RootNode);
            Console.WriteLine("\nСимметричный обход дерева B:");
            traversal.inOrder(treeB.RootNode);

            Console.WriteLine("Print any key to exit.");
            Console.ReadKey();
        }
    }
}

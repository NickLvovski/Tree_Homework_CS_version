using System;

namespace Algo_for_Anton.SLAYYYTER
{
    internal class Node
    {
        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node Parent { get; set; }

        public Node(int value, Node parent=null)
        {
            Value = value;
            Parent = parent;
        }

        public void Print()
        {
            string right = RightChild == null ? "null" : RightChild.Value.ToString();
            string left = LeftChild == null ? "null" : LeftChild.Value.ToString();
            string parentValue = Parent == null ? "null" : Parent.Value.ToString();
            string info = String.Format("Node(value={0}, leftValue={1}, rightValue={2} parent={3})",
                Value, left, right, parentValue);
            Console.WriteLine(info);
        }
    }
}

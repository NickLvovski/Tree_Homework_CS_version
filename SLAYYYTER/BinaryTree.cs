using System;

namespace Algo_for_Anton.SLAYYYTER
{
    internal class BinaryTree
    {
        public Node RootNode {get; set;}

        public Node FindNode(int value)
        {
            Node currentNode = RootNode;

            while (currentNode.Value != value)
            {
                if (value < currentNode.Value)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }
                if (currentNode == null)
                {
                    return null;
                }
            }
            return currentNode;
        }

        public void InsertNode(int value)
        {
            // добавление узла в дерево
            // логика аналогична поиску.
            Node newNode = new Node(value);

            if (RootNode == null)
            {
                RootNode = newNode;
            }
            else
            {
                Node currentNode = RootNode;
                Node parentNode;

                while (true)
                {
                    parentNode = currentNode;
                    if (value == currentNode.Value)
                    {
                        return;
                    }
                    else if (value < currentNode.Value)
                    {
                        currentNode = currentNode.LeftChild;
                        if (currentNode == null)
                        {
                            parentNode.LeftChild = newNode;
                            newNode.Parent = parentNode;
                            return;
                        }
                    }
                    else
                    {
                        currentNode = currentNode.RightChild;
                        if (currentNode == null)
                        {
                            parentNode.RightChild = newNode;
                            newNode.Parent = parentNode;
                            return;
                        }
                    }
                }
            }
        }

        public void DeleteNode(int value)
        {
            Node currentNode = RootNode;
            Node parentNode = RootNode;
            Boolean isLeft = true;

            while (currentNode.Value != value)
            {
                // поиск элемента осуществляется по алгоритму, описанному выше.
                parentNode = currentNode;
                if (value < currentNode.Value)
                {
                    isLeft = true;
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    isLeft = false;
                    currentNode = currentNode.RightChild;
                }
                if (currentNode == null)
                {
                    return;
                }
            }

            if (currentNode.LeftChild == null && currentNode.RightChild == null)
            {
                // если у узла нет потомков, то спокойно удаляем его.
                if (currentNode == RootNode)
                {
                    RootNode = null;
                }
                else if (isLeft)
                {
                    parentNode.LeftChild = null;
                }
                else
                {
                    parentNode.RightChild = null;
                }
            }
            else if (currentNode.RightChild == null)
            {
                // если у узла есть левый потомок, то в случае,
                // если узел левый, то левый потомок становится левым узлом родителя,
                // если узел правый, то левый потомок становится правым узлом родителя.
                if (currentNode == RootNode)
                {
                    RootNode = currentNode.LeftChild;
                    RootNode.Parent = null;
                }
                else if (isLeft)
                {
                    parentNode.LeftChild = currentNode.LeftChild;
                    currentNode.LeftChild.Parent = parentNode;
                }
                else
                {
                    parentNode.RightChild = currentNode.LeftChild;
                    currentNode.LeftChild.Parent = parentNode;
                }
            }
            else if (currentNode.LeftChild== null)
            {
                // если у узла есть правый потомок, то в случае,
                // если узел левый, то правый потомок становится левым узлом родителя,
                // если узел правый, то его правый потомк становится правым узлом родителя.
                if (currentNode == RootNode)
                {
                    RootNode = currentNode.RightChild;
                    RootNode.Parent = null;
                }
                else if (isLeft)
                {
                    parentNode.LeftChild = currentNode.RightChild;
                    currentNode.RightChild.Parent = parentNode;
                }
                else
                {
                    parentNode.RightChild = currentNode.RightChild;
                    currentNode.RightChild.Parent = parentNode;
                }
            }
            else
            {
                // если у узла есть и левый, и правый потомок,
                // то эти потомки передаются узлу-наследнику.
                Node heir = RecieveHeir(currentNode);
                if (currentNode == RootNode)
                {
                    RootNode = heir;
                    RootNode.Parent = null;
                }
                else if (isLeft)
                {
                    heir.Parent = parentNode;
                    parentNode.LeftChild = heir;
                }
                else
                {
                    heir.Parent = parentNode;
                    parentNode.RightChild = heir;
                }
            }
            currentNode.Parent = null;
        }

        private Node RecieveHeir(Node node)
        {
            // метод для получения наследника узла
            Node parentNode = node;
            Node heirNode = node;
            Node currentNode = node.RightChild;

            while (currentNode != null)
            {
                parentNode = heirNode;
                heirNode = currentNode;
                currentNode = currentNode.LeftChild;
            }
            if (heirNode != node.RightChild)
            {
                parentNode.LeftChild = heirNode.RightChild;
                heirNode.RightChild = node.RightChild;
            }

            return heirNode;
        }
    }
}

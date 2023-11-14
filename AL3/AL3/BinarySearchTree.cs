namespace TreeExample
{
    public partial class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(T value)
        {
            root = Insert(root, value);
        }

        private Node<T> Insert(Node<T> node, T value)
        {
            if (node == null)
            {
                node = new Node<T>(value);
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        public void Delete(T value)
        {
            root = Delete(root, value);
        }

        private Node<T> Delete(Node<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Delete(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = Delete(node.Right, value);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                Node<T> minNode = FindMin(node.Right);
                node.Value = minNode.Value;
                node.Right = Delete(node.Right, minNode.Value);
            }

            return node;
        }

        private Node<T> FindMin(Node<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public IEnumerable<T> TraverseBreadthFirst()
        {
            if (root == null)
            {
                yield break;
            }

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                yield return node.Value;

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        public IEnumerable<T> TraverseDepthFirstPreorder()
        {
            return TraverseDepthFirstPreorder(root);
        }

        private IEnumerable<T> TraverseDepthFirstPreorder(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            yield return node.Value;

            foreach (T value in TraverseDepthFirstPreorder(node.Left))
            {
                yield return value;
            }

            foreach (T value in TraverseDepthFirstPreorder(node.Right))
            {
                yield return value;
            }
        }

        public IEnumerable<T> TraverseDepthFirstInorder()
        {
            return TraverseDepthFirstInorder(root);
        }

        private IEnumerable<T> TraverseDepthFirstInorder(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            foreach (T value in TraverseDepthFirstInorder(node.Left))
            {
                yield return value;
            }

            yield return node.Value;

            foreach (T value in TraverseDepthFirstInorder(node.Right))
            {
                yield return value;
            }
        }

        public IEnumerable<T> TraverseDepthFirstPostorder()
        {
            return TraverseDepthFirstPostorder(root);
        }

        private IEnumerable<T> TraverseDepthFirstPostorder(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            foreach (T value in TraverseDepthFirstPostorder(node.Left))
            {
                yield return value;
            }

            foreach (T value in TraverseDepthFirstPostorder(node.Right))
            {
                yield return value;
            }

            yield return node.Value;
        }

        public void Print()
        {
            Print(root, "", true);
        }

        private void Print(Node<T> node, string prefix, bool isTail)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + node.Value);

            if (node.Left != null)
            {
                Print(node.Left, prefix + (isTail ? "    " : "│   "), false);
            }

            if (node.Right != null)
            {
                Print(node.Right, prefix + (isTail ? "    " : "│   "), true);
            }
        }
    }
}
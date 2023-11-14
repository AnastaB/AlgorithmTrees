namespace TreeExample
{
    public partial class RedBlackTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public void Insert(T value)
        {
            root = Insert(root, value);
            root.IsRed = false; 
        }

        private Node<T> Insert(Node<T> node, T value)
        {
            if (node == null)
            {
                return new Node<T>(value);
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(node.Right, value);
            }
            else
            {
                // Value already exists
                return node;
            }

            // Additional procedures to balance the tree after insertion
            if (IsRed(node.Right) && !IsRed(node.Left))
            {
                node = RotateLeft(node);
            }
            if (IsRed(node.Left) && IsRed(node.Left?.Left))
            {
                node = RotateRight(node);
            }
            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
            }

            return node;
        }

        public void Delete(T value)
        {
            root = Delete(root, value);
            root.IsRed = false; 
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
                else
                {
                    Node<T> temp = node;
                    node = MinValueNode(temp.Right);
                    node.Right = DeleteMin(temp.Right);
                    node.Left = temp.Left;
                }
            }

            // Additional procedures to balance the tree after deletion
            if (IsRed(node.Right) && !IsRed(node.Left))
            {
                node = RotateLeft(node);
            }
            if (IsRed(node.Left) && IsRed(node.Left?.Left))
            {
                node = RotateRight(node);
            }
            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
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

            Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + node.Value + (node.IsRed ? " (Red)" : " (Black)"));

            if (node.Left != null || node.Right != null)
            {
                Print(node.Left, prefix + (isTail ? "    " : "│   "), false);
                Print(node.Right, prefix + (isTail ? "    " : "│   "), true);
            }
        }

        private bool IsRed(Node<T> node)
        {
            return node != null && node.IsRed;
        }

        private Node<T> RotateLeft(Node<T> h)
        {
            Node<T> x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.IsRed = h.IsRed;
            h.IsRed = true;
            return x;
        }

        private Node<T> RotateRight(Node<T> h)
        {
            Node<T> x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.IsRed = h.IsRed;
            h.IsRed = true;
            return x;
        }

        private void FlipColors(Node<T> h)
        {
            h.IsRed = true;
            h.Left.IsRed = false;
            h.Right.IsRed = false;
        }

        private Node<T> MinValueNode(Node<T> node)
        {
            Node<T> current = node;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        private Node<T> DeleteMin(Node<T> node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            node.Left = DeleteMin(node.Left);
            return node;
        }
    }

}

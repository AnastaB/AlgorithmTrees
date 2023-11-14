public partial class AVLTree<T> where T : IComparable<T>
{
    private Node<T> root;

    public void Insert(T value)
    {
        root = Insert(root, value);
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

        // Update height of this ancestor node
        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

        int balance = GetBalance(node);

        // Left Left Case
        if (balance > 1 && value.CompareTo(node.Left.Value) < 0)
        {
            return RightRotate(node);
        }

        // Right Right Case
        if (balance < -1 && value.CompareTo(node.Right.Value) > 0)
        {
            return LeftRotate(node);
        }

        // Left Right Case
        if (balance > 1 && value.CompareTo(node.Left.Value) > 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Right Left Case
        if (balance < -1 && value.CompareTo(node.Right.Value) < 0)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
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
            return node;
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
            if (node.Left == null || node.Right == null)
            {
                Node<T> temp = node.Left ?? node.Right;

                if (temp == null)
                {
                    temp = node;
                    node = null;
                }
                else
                {
                    node = temp;
                }
            }
            else
            {
                Node<T> temp = MinValueNode(node.Right);
                node.Value = temp.Value;
                node.Right = Delete(node.Right, temp.Value);
            }
        }

        if (node == null)
        {
            return node;
        }

        // Update height of this ancestor node
        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

        int balance = GetBalance(node);

        // Left Left Case
        if (balance > 1 && GetBalance(node.Left) >= 0)
        {
            return RightRotate(node);
        }

        // Right Right Case
        if (balance < -1 && GetBalance(node.Right) <= 0)
        {
            return LeftRotate(node);
        }

        // Left Right Case
        if (balance > 1 && GetBalance(node.Left) < 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Right Left Case
        if (balance < -1 && GetBalance(node.Right) > 0)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
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

    private int Height(Node<T> node)
    {
        return node?.Height ?? 0;
    }

    private int GetBalance(Node<T> node)
    {
        return node == null ? 0 : Height(node.Left) - Height(node.Right);
    }

    private Node<T> RightRotate(Node<T> y)
    {
        Node<T> x = y.Left;
        Node<T> T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = 1 + Math.Max(Height(y.Left), Height(y.Right));
        x.Height = 1 + Math.Max(Height(x.Left), Height(x.Right));

        return x;
    }

    private Node<T> LeftRotate(Node<T> x)
    {
        Node<T> y = x.Right;
        Node<T> T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = 1 + Math.Max(Height(x.Left), Height(x.Right));
        y.Height = 1 + Math.Max(Height(y.Left), Height(y.Right));

        return y;
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
}
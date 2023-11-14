namespace TreeExample
{
    public partial class BinarySearchTree<T> where T : IComparable<T>
    {
        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }

            public Node(T value)
            {
                Value = value;
            }

        }
    }
}
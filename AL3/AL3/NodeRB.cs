namespace TreeExample
{
    public partial class RedBlackTree<T> where T : IComparable<T>
    {
        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public bool IsRed { get; set; }

            public Node(T value)
            {
                Value = value;
                IsRed = true; 
            }
        }
    }

}

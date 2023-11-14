using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TreeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            AVLTree<int> avl = new AVLTree<int>();

            Console.WriteLine("1. Red-Black tree");
            Console.WriteLine("2. AVL-tree");
            Console.WriteLine("3. BinarySearch Tree");
            Console.Write("Enter a number to select a kind of tree: ");
            int tree = int.Parse(Console.ReadLine());

            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Print");
            Console.WriteLine("4. Traverse the tree in breadth-first order");
            Console.WriteLine("5. Traverse the tree in depth-first order: preorder");
            Console.WriteLine("6. Traverse the tree in depth-first order: inorder");
            Console.WriteLine("7. Traverse the tree in depth-first order: postorder");
            Console.WriteLine("8. Exit");

            while (true)
            { 
                Console.Write("Enter a number to select a method: ");

                int option = int.Parse(Console.ReadLine());

                switch (tree)
                {
                    case 1:
                        switch (option)
                        {
                            case 1:
                                Console.Write("Enter a number to Insert: ");
                                rbt.Insert(Convert.ToInt16(Console.ReadLine()));
                                break;
                            case 2:
                                Console.Write("Enter a number to Delete: ");
                                rbt.Delete(Convert.ToInt16(Console.ReadLine()));
                                break;
                            case 3:
                                rbt.Print();
                                break;
                            case 4:
                                Console.WriteLine("Breadth-first traversal:");
                                foreach (int value in rbt.TraverseBreadthFirst())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 5:
                                Console.WriteLine("Depth-first preorder traversal:");
                                foreach (int value in rbt.TraverseDepthFirstPreorder())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 6:
                                Console.WriteLine("Depth-first inorder traversal:");
                                foreach (int value in rbt.TraverseDepthFirstInorder())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 7:
                                Console.WriteLine("Depth-first postorder traversal:");
                                foreach (int value in rbt.TraverseDepthFirstPostorder())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 8:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    case 2:
                        switch (option)
                        {
                            case 1:
                                //var runningTime = MeasureRunningTime(() => SelectionSort(arr));
                                Console.Write("Enter a number to Insert: ");
                                avl.Insert(Convert.ToInt16(Console.ReadLine()));
                                break;
                            case 2:
                                Console.Write("Enter a number to Delete: ");
                                avl.Delete(Convert.ToInt16(Console.ReadLine()));
                                break;
                            case 3:
                                avl.Print();
                                break;
                            case 4:
                                Console.WriteLine("Breadth-first traversal:");
                                foreach (int value in avl.TraverseBreadthFirst())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 5:
                                Console.WriteLine("Depth-first preorder traversal:");
                                foreach (int value in avl.TraverseDepthFirstPreorder())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 6:
                                Console.WriteLine("Depth-first inorder traversal:");
                                foreach (int value in avl.TraverseDepthFirstInorder())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 7:
                                Console.WriteLine("Depth-first postorder traversal:");
                                foreach (int value in avl.TraverseDepthFirstPostorder())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 8:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    case 3:
                        switch (option)
                        {
                            case 1:
                                //var runningTime = MeasureRunningTime(() => SelectionSort(arr));
                                Console.Write("Enter a number to Insert: ");
                                bst.Insert(Convert.ToInt16(Console.ReadLine()));
                                break;
                            case 2:
                                Console.Write("Enter a number to Delete: ");
                                bst.Delete(Convert.ToInt16(Console.ReadLine()));
                                break;
                            case 3:
                                bst.Print();
                                break;
                            case 4:
                                Console.WriteLine("Breadth-first traversal:");
                                foreach (int value in bst.TraverseBreadthFirst())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 5:
                                Console.WriteLine("Depth-first preorder traversal:");
                                foreach (int value in bst.TraverseDepthFirstPreorder())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 6:
                                Console.WriteLine("Depth-first inorder traversal:");
                                foreach (int value in bst.TraverseDepthFirstInorder())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 7:
                                Console.WriteLine("Depth-first postorder traversal:");
                                foreach (int value in bst.TraverseDepthFirstPostorder())
                                {
                                    Console.Write(value + " ");
                                }
                                Console.WriteLine();
                                break;
                            case 8:
                                Environment.Exit(0);
                                break;

                        }
                        break;
                    default:
                        break;

                }
            }
        }
        public static double MeasureRunningTime(Action method)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            method();
            stopwatch.Stop();
            return (double)stopwatch.ElapsedTicks / Stopwatch.Frequency;
        }
    }

}

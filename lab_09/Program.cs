using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo K;
        MyTree<int> Tree = new MyTree<int>();

        do
        {
            Console.Clear();
            Console.WriteLine("1. Add a tree node");
            Console.WriteLine("2. Right-Root-Left traversal");
            Console.WriteLine("3. Breadth-first traversal");
            Console.WriteLine("4. Delete a tree node");
            Console.WriteLine("5. Sum of all nodes");
            Console.WriteLine("6. Maximum values at each level");
            Console.WriteLine("7. Clear tree");
            Console.WriteLine("Esc. Exit");
            K = Console.ReadKey();
            Console.WriteLine();

            try
            {
                switch (K.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Enter value:");
                        if (int.TryParse(Console.ReadLine(), out int N))
                        {
                            Tree.Add(N);
                            Console.WriteLine($"Node {N} added");
                            Console.WriteLine("Current tree (RRL): " + Tree.RRL());
                        }
                        else
                        {
                            Console.WriteLine("Invalid value");
                        }
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Right-Root-Left traversal:");
                        Console.WriteLine(Tree.RRL());
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("Breadth-first traversal:");
                        Console.WriteLine(Tree.Weight());
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.WriteLine("Current tree (RRL): " + Tree.RRL());
                        Console.WriteLine("Enter node to delete:");
                        if (int.TryParse(Console.ReadLine(), out int delN))
                        {
                            try
                            {
                                Tree.Delete(delN);
                                Console.WriteLine($"Node {delN} deleted");
                                Console.WriteLine("Current tree (RRL): " + Tree.RRL());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid value");
                        }
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.WriteLine($"Sum of all tree elements: {Tree.Sum()}");
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Console.WriteLine("Maximum values at each level:");
                        var maxValues = Tree.MaxAtEachLevel();
                        foreach (var level in maxValues)
                        {
                            Console.WriteLine($"Level {level.Key}: {level.Value}");
                        }
                        break;

                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        Tree.Clear();
                        Console.WriteLine("Tree cleared successfully");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            if (K.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        } while (K.Key != ConsoleKey.Escape);
    }
}

public class MyTree<T> where T : IComparable<T>
{
    private class TreeNode
    {
        public T Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    private TreeNode root;
    private int count;

    public MyTree()
    {
        root = null;
        count = 0;
    }

    public void Add(T value)
    {
        root = AddRecursive(root, value);
        count++;
    }

    private TreeNode AddRecursive(TreeNode node, T value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = AddRecursive(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = AddRecursive(node.Right, value);
        }
        // If value is equal, we don't add duplicates

        return node;
    }

    public string RRL()
    {
        return RRLTraversal(root).Trim();
    }

    private string RRLTraversal(TreeNode node)
    {
        if (node == null)
        {
            return "";
        }

        string result = "";
        result += RRLTraversal(node.Right);
        result += node.Value + " ";
        result += RRLTraversal(node.Left);

        return result;
    }

    public string Weight()
    {
        if (root == null)
        {
            return "";
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        string result = "";

        while (queue.Count > 0)
        {
            TreeNode currentNode = queue.Dequeue();
            result += currentNode.Value + " ";

            if (currentNode.Left != null)
            {
                queue.Enqueue(currentNode.Left);
            }

            if (currentNode.Right != null)
            {
                queue.Enqueue(currentNode.Right);
            }
        }

        return result.Trim();
    }

    public void Delete(T value)
    {
        root = DeleteRecursive(root, value);
        count--;
    }

    private TreeNode DeleteRecursive(TreeNode node, T value)
    {
        if (node == null)
        {
            throw new InvalidOperationException("Value not found in tree");
        }

        int comparison = value.CompareTo(node.Value);

        if (comparison < 0)
        {
            node.Left = DeleteRecursive(node.Left, value);
        }
        else if (comparison > 0)
        {
            node.Right = DeleteRecursive(node.Right, value);
        }
        else
        {
            // Node with only one child or no child
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            // Node with two children: Get the inorder successor (smallest in the right subtree)
            node.Value = MinValue(node.Right);

            // Delete the inorder successor
            node.Right = DeleteRecursive(node.Right, node.Value);
        }

        return node;
    }

    private T MinValue(TreeNode node)
    {
        T minValue = node.Value;
        while (node.Left != null)
        {
            minValue = node.Left.Value;
            node = node.Left;
        }
        return minValue;
    }

    public T Sum()
    {
        if (typeof(T) == typeof(int) || typeof(T) == typeof(double) || typeof(T) == typeof(decimal) ||
            typeof(T) == typeof(float) || typeof(T) == typeof(long))
        {
            dynamic sum = default(T);
            SumRecursive(root, ref sum);
            return sum;
        }
        else
        {
            throw new InvalidOperationException("Sum operation is not supported for this type");
        }
    }

    private void SumRecursive(TreeNode node, ref dynamic sum)
    {
        if (node != null)
        {
            sum += node.Value;
            SumRecursive(node.Left, ref sum);
            SumRecursive(node.Right, ref sum);
        }
    }

    public Dictionary<int, T> MaxAtEachLevel()
    {
        var maxValues = new Dictionary<int, T>();
        if (root == null)
        {
            return maxValues;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int level = 0;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            T max = default(T);
            bool firstInLevel = true;

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode currentNode = queue.Dequeue();

                if (firstInLevel)
                {
                    max = currentNode.Value;
                    firstInLevel = false;
                }
                else if (currentNode.Value.CompareTo(max) > 0)
                {
                    max = currentNode.Value;
                }

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }

            maxValues.Add(level, max);
            level++;
        }

        return maxValues;
    }

    public void Clear()
    {
        root = null;
        count = 0;
    }

    public int Count => count;
}

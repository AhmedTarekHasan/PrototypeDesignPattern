using System;
using System.Text;

namespace NestedObjectsWithICloneableExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var node1 =
                new Node(
                    "Node 1",
                    new Node(
                        "Node 2",
                        new Node(
                            "Node 3",
                            new Node(
                                "Node 4",
                                null
                            ))));

            Console.WriteLine("Original Series:");
            Console.WriteLine(node1.ToString());
            /*
            Node 1   --->   Node 2   --->   Node 3   --->   Node 4
            */

            Console.WriteLine("");

            Console.WriteLine("Copied Series:");
            var copy = node1.Clone() as Node;
            Console.WriteLine(copy.ToString());


            Console.ReadLine();
        }
    }

    public class Node : ICloneable
    {
        public string Name { get; }
        public Node Next { get; }

        public Node(string name, Node next)
        {
            Name = name;
            Next = next;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            var current = this;

            while (current != null)
            {
                builder.Append(current.Name + (current.Next != null ? "   --->   " : ""));
                current = current.Next;
            }

            return builder.ToString();
        }

        public object Clone()
        {
            return new Node($"Copy Of {Name}", Next?.Clone() as Node);
        }
    }
}
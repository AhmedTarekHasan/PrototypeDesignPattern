using System;
using System.Text;

namespace NestedObjectsEnhancedExample
{
    public class Program
    {
        static void Main(string[] args)
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


            Console.WriteLine("\n\nCopy1:");
            var copy1 = node1.Clone();
            Console.WriteLine(copy1.ToString());


            Console.WriteLine("\n\nCopy2:");
            var copy2 = node1.Clone(name => $"CLONE OF {name}");
            Console.WriteLine(copy2.ToString());


            Console.ReadLine();
        }
    }

    public class Node
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

        public Node Clone()
        {
            return Clone(null);
        }

        public Node Clone(Func<string, string> copyNameResolver)
        {
            return Clone(copyNameResolver, null);
        }

        public Node Clone(
            Func<string, string> copyNameResolver,
            Node nextOverride)
        {
            return new Node(
                copyNameResolver != null ? copyNameResolver(Name) : $"Copy Of {Name}",
                nextOverride ?? Next?.Clone(copyNameResolver));
        }
    }
}
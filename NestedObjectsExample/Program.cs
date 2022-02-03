using System;
using System.Collections.Generic;
using System.Text;

namespace NestedObjectsExample
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


            Console.WriteLine("\n\nWrong way of copying:");
            WrongWayOfCopying(node1);


            Console.WriteLine("\n\nComplex way of copying:");
            ComplexWayOfCopying(node1);


            Console.ReadLine();
        }

        private static void WrongWayOfCopying(Node source)
        {
            var CopyOfNode1 = new Node($"Copy Of {source.Name}", source.Next);

            Console.WriteLine(CopyOfNode1.ToString());
            /*
            Copy Of Node 1   --->   Node 2   --->   Node 3   --->   Node 4
            */
        }

        private static void ComplexWayOfCopying(Node source)
        {
            if (source != null)
            {
                var reversedNodes = new Stack<Node>();

                var current = source;

                while (current != null)
                {
                    reversedNodes.Push(current);
                    current = current.Next;
                }

                Node previous = null;

                while (reversedNodes.Count > 0)
                {
                    var currentNode = reversedNodes.Pop();
                    previous = new Node($"Copy Of {currentNode.Name}", previous);
                }

                Console.WriteLine(previous.ToString());
                /*
                Copy Of Node 1   --->   Copy Of Node 2   --->   Copy Of Node 3   --->   Copy Of Node 4
                */
            }
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
    }
}
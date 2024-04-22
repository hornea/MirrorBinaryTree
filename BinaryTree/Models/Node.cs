using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace BinaryTree.Models
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
            left.Parent = right.Parent = this;
        }

        public void Print(Node<T> node)
        {
            if (node is null)
            {
                return;
            }

            Print(node.Left);
            Console.Write(node.Value + " ");

            Print(node.Right);
        }

        public void Print()
        {
            if (this == null)
            {
                return;
            }

            Print(this.Left);
            Console.Write(this.Value + " ");

            Print(this.Right);
        }

        public bool areMirror(Node<T> a, Node<T> b)
        {
            /* Base case : Both empty */
            if (a == null && b == null)
            {
                return true;
            }

            // If only one is empty 
            if (a == null || b == null)
            {
                return false;
            }

            return a.Value.Equals(b.Value) && areMirror(a.Left, b.Right)
                                && areMirror(a.Right, b.Left);
        }
    }
}

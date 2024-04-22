using BinaryTree.Models;

namespace BinaryTree.Extensions
{
    public static class NodeExtension
    {
        static int helperPosition;

        public static string Serialize(this Node<int> root)
        {
            if (root == null)
            {
                return null;
            }
            Stack<Node<int>> stack = new Stack<Node<int>>();
            stack.Push(root);

            List<string> result = new List<string>();

            while (stack.Count > 0)
            {
                Node<int> t = stack.Pop();

                // If current node is NULL, store marker
                if (t == null)
                {
                    result.Add("#");
                }
                else
                {
                    result.Add(t.Value.ToString());
                    stack.Push(t.Right);
                    stack.Push(t.Left);
                }
            }
            return string.Join(",", result);
        }

        public static Node<int> Deserialize(this string data)
            {
                if (data == null)
                    return null;

                helperPosition = 0;

                string[] arr = data.Split(',');

                return Helper(arr);
            }

            public static Node<int> Helper(string[] arr)
            {
                if (arr[helperPosition].Equals("#"))
                    return null;

                // Create node with this item
                // and recur for children
                Node<int> root = new Node<int>((int)Convert.ChangeType(arr[helperPosition], typeof(int)));
                helperPosition++;
                root.Left = Helper(arr);
                helperPosition++;
                root.Right = Helper(arr);
                return root;
            }
        }
    }


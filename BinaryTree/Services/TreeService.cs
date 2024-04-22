using BinaryTree.Models;
using System.Xml.Linq;

namespace BinaryTree.Services
{
    public interface ITreeService
    {
        Node<T> MirrorTree<T>(Node<T> node);
    }

    public class TreeService : ITreeService
    {
        public Node<T> MirrorTree<T>(Node<T> node)
        {
            if (node == null)
                return null;

            Node<T> result = new Node<T>(node.Value);

            result.Right = MirrorTree(node.Left);
            result.Left = MirrorTree(node.Right);


            return result;
        }
    }
}

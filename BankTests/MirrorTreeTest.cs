using BinaryTree;
using BinaryTree.Extensions;
using BinaryTree.Models;
using BinaryTree.Services;
using System.Text.Json;

namespace BankTests
{
    [TestClass]
    public class MirrorTreeTest
    {
        private readonly ITreeService _treeService;

        public MirrorTreeTest()
        {
            _treeService = new TreeService();
        }

        [TestMethod]
        public void MirrorTreeHeap()
        {
            ///         0
            ///       1     2
            ///     3   4  5  6

            var root = new Node<int>(0,
                    new Node<int>(1,
                         new Node<int>(3), new Node<int>(4)),
                    new Node<int>(2,
                         new Node<int>(5), new Node<int>(6)));

            var mirror = _treeService.MirrorTree(root);

            var tess = mirror.areMirror(mirror, root);


            Assert.IsTrue(mirror.areMirror(mirror, root));
        }

        [TestMethod]
        public void MirrorTreeLine()
        {
            ///         0
            ///       1     
            ///     2
            ///    3
            ///   4 

            var root = new Node<int>(0);
            root.Left = new Node<int>(1);
            root.Left.Left = new Node<int>(2);
            root.Left.Left.Left = new Node<int>(3);
            root.Left.Left.Left.Left = new Node<int>(4);

            var mirror = _treeService.MirrorTree(root);

            Assert.IsTrue(mirror.areMirror(mirror, root));
        }

        [TestMethod]
        public void MirrorTreeOnlyroot()
        {
            ///         0
    

            var root = new Node<int>(0);

            var mirror = _treeService.MirrorTree(root);


            Assert.IsTrue(mirror.areMirror(mirror, root));
        }

        [TestMethod]
        public void MirrorTreeString()
        {
            ///         a
            ///       b     c
            ///     d  e   f g


            var root = new Node<string>("a",
                    new Node<string>("b",
                         new Node<string>("d"), new Node<string>("e")),
                    new Node<string>("c",
                         new Node<string>("f"), new Node<string>("g")));

            var mirror = _treeService.MirrorTree(root);


            Assert.IsTrue(mirror.areMirror(mirror, root));
        }
    }
}
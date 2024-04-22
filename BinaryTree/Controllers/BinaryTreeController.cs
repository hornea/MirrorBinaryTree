using BinaryTree.Extensions;
using BinaryTree.Models;
using BinaryTree.Services;
using Microsoft.AspNetCore.Mvc;

namespace BinaryTree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BinaryTreeController : ControllerBase
    {
        private readonly ITreeService _treeService;

        public BinaryTreeController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        //Example tree: 0,2,6,#,#,5,#,#,1,4,#,#,3,#,#
        [HttpPost(Name = "Mirror")]
        public async Task<IActionResult> MirrorTree([FromBody] string treeString)
        {
            Node<int> tree = treeString.Deserialize();

            var test = _treeService.MirrorTree(tree);

            return Ok(test.Serialize());
        }
    }
}

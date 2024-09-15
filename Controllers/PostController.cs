using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;
using go_funding_server.Data.DTO;
using go_funding_server.Services;
using System.ComponentModel;

namespace go_funding_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService) {
           this._postService = postService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> getPosts() {
            var post = await _postService.getAllPostsAsync();
            return Ok(post);

        }

        [HttpPost("save")]
        public async Task<IActionResult> addPost(PostDTO postDTO) {
            var post = await _postService.addPost(postDTO);
            return Ok(post);
        }

        [HttpPatch("edit")]
        public async Task<IActionResult> editPost(PostDTO postDTO) {
            var post = await _postService.editPost(postDTO);
            return Ok(post);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> deletePostById(int id) {
            var post = await _postService.deletePostById(id);
            return Ok(post);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getPost(int id)
        {
            var post = await _postService.getAllPostByIdAsync(id);
            return Ok(post);

        }
    }
}
 
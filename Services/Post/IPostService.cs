using Org.BouncyCastle.Utilities;
using go_funding_server.Data.DTO;
using go_funding_server.Data.Entities;

namespace go_funding_server.Services
{
    public interface IPostService
    {
        Task<List<Post>> getAllPostsAsync();

        Task<Post> addPost(PostDTO postDTO);
        Task<Post> editPost(PostDTO postDTO);

        Task<Post> getAllPostByIdAsync(int id);

        Task<Post> deletePostById(int id);
    }
}

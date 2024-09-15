using AutoMapper;
using Microsoft.EntityFrameworkCore;
using go_funding_server.Data;
using go_funding_server.Data.DTO;
using go_funding_server.Data.Entities;

namespace go_funding_server.Services
{
    public class PostService : IPostService
    {
        private readonly GoFundingPortalDbContext _goFundingPortalDbContext;
        private readonly IMapper _mapper;
        public PostService(GoFundingPortalDbContext goFundingPortalDbContext, IMapper mapper)
        {
            this._goFundingPortalDbContext = goFundingPortalDbContext;
            this._mapper = mapper;
        }

        public async Task<Post> addPost(PostDTO postDTO)
        {
            Post post = _mapper.Map<Post>(postDTO); //MapStudentObject(studentDTO);
            _goFundingPortalDbContext.Post.Add(post);
            await _goFundingPortalDbContext.SaveChangesAsync();
            return post;
        }

         public async Task<Post> editPost(PostDTO postDTO)
        {
            Post post = _mapper.Map<Post>(postDTO);
            await _goFundingPortalDbContext.Post.Where(item => item.id == post.id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(item=> item.content, post.content)
                           .SetProperty(item=> item.userId, post.userId));
            return post;
        }

        public async Task<Post> deletePostById(int id)
        {
            var deletedPost = await _goFundingPortalDbContext.Post.FindAsync(id);
            _goFundingPortalDbContext.Post.Remove(deletedPost);
            await _goFundingPortalDbContext.SaveChangesAsync();
            return deletedPost;
        }

        public async Task<Post> getAllPostByIdAsync(int id)
        {
            var posts = await _goFundingPortalDbContext.Post.Where(_ => _.id == id).FirstOrDefaultAsync();
            return posts;
        }

        public async Task<List<Post>> getAllPostsAsync()
        {

            var post = await _goFundingPortalDbContext.Post.Select(x=>new Post { 
            content = x.content
            }).ToListAsync();

// var arrayPost = (
//      from ps in _goFundingPortalDbContext.Post
//      join us in _goFundingPortalDbContext.User on ps.userId equals us.id 
//      select new Post 
//      {
//           id = ps.id,
//           content = ps.content,
//           userId = ps.userId,
//           user = new User() {
//             id = us.id,
//             username = us.username
//           }
//      }).ToArray();
//      foreach (Post i in arrayPost) 
// {
//   Console.WriteLine(i.content);
// }

            // var posts = await _goFundingPortalDbContext.Post.FromSql($"SELECT p.id as postId, us.id as userPostId,p.content,us.username FROM Post p join User us on p.userId = us.id").ToListAsync();
            // posts.ForEach(item => Console.WriteLine(item));
            return post;
        }

        /*private Student MapStudentObject(StudentDTO studentDTO) {
            Student student = new Student();
            student.StudentName = studentDTO.StudentName;
            student.Age = studentDTO.Age;
            student.Address = new List<Address>();
            studentDTO.Address.ForEach(_ =>
            {
                Address address = new Address();
                address.HouseName = _.HouseName;
                address.City = _.City;
                address.Pincode = _.Pincode;
                student.Address.Add(address);
            });
            return student;
        }*/
    }
}

namespace go_funding_server.Data.Entities
{
    public class Post
    {
        public int id { get; set; }

        public string? content { get; set; }
         
        public int userId { get; set; }

        public User? user { get; set; }
    }
}

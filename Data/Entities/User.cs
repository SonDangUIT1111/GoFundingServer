namespace go_funding_server.Data.Entities
{
    public class User
    {
        public int id { get; set; }

        public string? username { get; set; }

        public List<Post>? posts { get; set; }
    }
}

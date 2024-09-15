using go_funding_server.Data.Entities;

namespace go_funding_server.Data.DTO
{
    public class UserDTO
    {
        public int id { get; set; }

        public string? username { get; set; }

        public List<PostDTO>? posts { get; set; }
    }
}

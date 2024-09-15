using Org.BouncyCastle.Utilities;
using go_funding_server.Data.DTO;
using go_funding_server.Data.Entities;

namespace go_funding_server.Services
{
    public interface IUserService
    {
        Task<List<User>> getAllUsersAsync();

        Task<User> addUser(UserDTO userDTO);

        Task<User> getAllUserByIdAsync(int id);
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using go_funding_server.Data;
using go_funding_server.Data.DTO;
using go_funding_server.Data.Entities;

namespace go_funding_server.Services
{
    public class UserService : IUserService
    {
        private readonly GoFundingPortalDbContext _goFundingPortalDbContext;
        private readonly IMapper _mapper;
        public UserService(GoFundingPortalDbContext goFundingPortalDbContext, IMapper mapper)
        {
            this._goFundingPortalDbContext = goFundingPortalDbContext;
            this._mapper = mapper;
        }

        public async Task<User> addUser(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO); //MapStudentObject(studentDTO);
            _goFundingPortalDbContext.User.Add(user);
            await _goFundingPortalDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> getAllUserByIdAsync(int id)
        {
            var users = await _goFundingPortalDbContext.User.Where(_ => _.id == id).FirstOrDefaultAsync();
            return users;
        }

        public async Task<List<User>> getAllUsersAsync()
        {

            // var user = await _goFundingPortalDbContext.User.Select(x=>new User { 
            // username = x.username
            // }).ToListAsync();
            var users = await _goFundingPortalDbContext.User.FromSql($"SELECT * FROM User st").ToListAsync();
            return users;
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

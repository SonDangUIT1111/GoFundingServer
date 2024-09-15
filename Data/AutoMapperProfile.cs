using AutoMapper;
using go_funding_server.Data.DTO;
using go_funding_server.Data.Entities;

namespace go_funding_server.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            // CreateMap here
            CreateMap<UserDTO, User>();
            CreateMap<PostDTO, Post>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using trelloApi.Command;
using trelloApi.Domains;
using trelloApi.DTO;

namespace trelloApi.Automapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            var map = CreateMap<User, UserDTO>();


            CreateMap<UserDTO, User>();
            CreateMap<RegisterCommand, UserDTO>();
            CreateMap<UserDTO, RegisterCommand>();
            CreateMap<RegisterCommand, User>();
            CreateMap<User, RegisterCommand>();
            CreateMap<CreateBoardCommand, Board>();
            CreateMap<CreateBoardCommand, BoardDTO>();







        }
    }
}
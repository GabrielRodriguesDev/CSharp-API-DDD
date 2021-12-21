using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>() //Criando o mapeamendo de Model para Dto
            .ReverseMap(); // Revertendo o mapeamento de Dto para Model

            CreateMap<UserModel, UserDtoCreate>()
            .ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>()
            .ReverseMap();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            #region  User
            CreateMap<UserEntity, UserModel>()
            .ReverseMap();
            #endregion

            #region Uf
            CreateMap<UfEntity, UfModel>()
            .ReverseMap();
            #endregion

            #region  Municipio
            CreateMap<MunicipioEntity, MunicipioModel>()
            .ReverseMap();
            #endregion

            #region  Cep
            CreateMap<CepEntity, CepModel>()
            .ReverseMap();
            #endregion
        }
    }
}

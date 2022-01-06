using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Municipio
{
    public class MunicipioTestes
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string NomeAlterado { get; set; }

        public int CodIBGE { get; set; }

        public int CodIBGEAlterado { get; set; }

        public Guid UfId { get; set; }

        public List<MunicipioDto> listaDto = new List<MunicipioDto>();

        public MunicipioDto municipioDto;

        public MunicipioDtoCompleto municipioDtoCompleto;

        public MunicipioDtoCreate municipioDtoCreate;

        public MunicipioDtoCreateResult municipioDtoCreateResult;

        public MunicipioDtoUpdate municipioDtoUpdate;

        public MunicipioDtoUpdateResult municipioDtoUpdateResult;

        public MunicipioTestes()
        {
            Id = Guid.NewGuid();
            Nome = Faker.Address.StreetName();
            CodIBGE = Faker.RandomNumber.Next(1, 10000);
            NomeAlterado = Faker.Address.StreetName();
            CodIBGEAlterado = Faker.RandomNumber.Next(1, 10000);
            UfId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.StreetName(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid()
                };
                listaDto.Add(dto);
            }

            municipioDto = new MunicipioDto
            {
                Id = this.Id,
                Nome = this.Nome,
                CodIBGE = this.CodIBGE,
                UfId = this.UfId
            };

            municipioDtoCompleto = new MunicipioDtoCompleto
            {
                Id = this.Id,
                Nome = this.Nome,
                CodIBGE = this.CodIBGE,
                UfId = this.Id,
                Uf = new UfDto
                {
                    Id = this.Id,
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3)
                }
            };

            municipioDtoCreate = new MunicipioDtoCreate
            {
                Nome = this.Nome,
                CodIBGE = this.CodIBGE,
                UfId = this.UfId
            };

            municipioDtoCreateResult = new MunicipioDtoCreateResult
            {
                Id = this.Id,
                Nome = this.Nome,
                CodIBGE = this.CodIBGE,
                UfId = this.UfId,
                CreateAt = DateTime.UtcNow
            };

            municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = this.Id,
                Nome = this.NomeAlterado,
                CodIBGE = this.CodIBGEAlterado,
                UfId = this.UfId
            };

            municipioDtoUpdateResult = new MunicipioDtoUpdateResult
            {
                Id = this.Id,
                Nome = this.NomeAlterado,
                CodIBGE = this.CodIBGEAlterado,
                UfId = this.UfId,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}

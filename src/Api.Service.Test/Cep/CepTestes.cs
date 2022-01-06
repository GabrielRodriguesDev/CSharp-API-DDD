using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Cep
{
    public class CepTestes
    {
        public Guid Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }


        public string Numero { get; set; }


        public Guid MunicipioId { get; set; }

        public MunicipioDtoCompleto Municipio { get; set; }

        public CepDto cepDto;

        public CepDtoCreate cepDtoCreate;

        public CepDtoCreateResult cepDtoCreateResult;

        public CepDtoUpdate cepDtoUpdate;

        public CepDtoUpdateResult CepDtoUpdateResult;

        public CepTestes()
        {
            Id = Guid.NewGuid();
            Cep = Faker.RandomNumber.Next(1, 10000).ToString();
            Logradouro = Faker.Address.StreetAddress();
            Numero = "";
            MunicipioId = Guid.NewGuid();
            Municipio = new MunicipioDtoCompleto
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                UfId = Guid.NewGuid(),
                Uf = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3)
                }
            };

            cepDto = new CepDto
            {
                Id = this.Id,
                Cep = this.Cep,
                Logradouro = this.Logradouro,
                Numero = this.Numero,
                MunicipioId = this.MunicipioId,
                Municipio = this.Municipio
            };

            cepDtoCreate = new CepDtoCreate
            {
                Cep = this.Cep,
                Logradouro = this.Logradouro,
                Numero = this.Numero,
                MunicipioId = this.MunicipioId
            };

            cepDtoCreateResult = new CepDtoCreateResult
            {
                Id = this.Id,
                Cep = this.Cep,
                Logradouro = this.Logradouro,
                Numero = this.Numero,
                MunicipioId = this.MunicipioId,
                CreateAt = DateTime.UtcNow
            };

            cepDtoUpdate = new CepDtoUpdate
            {
                Id = this.Id,
                Cep = this.Cep,
                Logradouro = this.Logradouro,
                Numero = this.Numero,
                MunicipioId = this.MunicipioId,
            };

            CepDtoUpdateResult = new CepDtoUpdateResult
            {
                Id = this.Id,
                Cep = this.Cep,
                Logradouro = this.Logradouro,
                Numero = this.Numero,
                MunicipioId = this.MunicipioId,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}

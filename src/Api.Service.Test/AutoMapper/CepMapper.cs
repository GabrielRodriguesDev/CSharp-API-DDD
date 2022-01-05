using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelo de Cep")]
        public void E_Possivel_Mapear_Os_Modelos_Cep()
        {
            var model = new CepModel
            {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                Logradouro = Faker.Address.StreetAddress(),
                Numero = "",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                MunicipioId = Guid.NewGuid()
            };

            var listaEntity = new List<CepEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                    Logradouro = Faker.Address.StreetAddress(),
                    Numero = "",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfEntity
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };

                listaEntity.Add(item);
            }

            //Model => Entity
            var modelForEntity = Mapper.Map<CepEntity>(model);
            Assert.Equal(modelForEntity.Id, model.Id);
            Assert.Equal(modelForEntity.Cep, model.Cep);
            Assert.Equal(modelForEntity.Logradouro, model.Logradouro);
            Assert.Equal(modelForEntity.Numero, model.Numero);
            Assert.Equal(modelForEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelForEntity.UpdateAt, model.UpdateAt);
            Assert.Equal(modelForEntity.MunicipioId, model.MunicipioId);

            //Entity => Dto
            var entityForDto = Mapper.Map<CepDto>(modelForEntity);
            Assert.Equal(entityForDto.Id, modelForEntity.Id);
            Assert.Equal(entityForDto.Cep, modelForEntity.Cep);
            Assert.Equal(entityForDto.Logradouro, modelForEntity.Logradouro);
            Assert.Equal(entityForDto.Numero, modelForEntity.Numero);
            Assert.Equal(entityForDto.MunicipioId, modelForEntity.MunicipioId);

            var entityFroDtoCompleto = Mapper.Map<CepDto>(listaEntity.FirstOrDefault());
            Assert.Equal(entityFroDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(entityFroDtoCompleto.Cep, listaEntity.FirstOrDefault().Cep);
            Assert.Equal(entityFroDtoCompleto.Logradouro, listaEntity.FirstOrDefault().Logradouro);
            Assert.Equal(entityFroDtoCompleto.Numero, listaEntity.FirstOrDefault().Numero);
            Assert.Equal(entityFroDtoCompleto.MunicipioId, listaEntity.FirstOrDefault().MunicipioId);
            Assert.NotNull(entityFroDtoCompleto.Municipio);
            Assert.NotNull(entityFroDtoCompleto.Municipio.Uf);

            var listaDto = Mapper.Map<List<CepDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Cep, listaEntity[i].Cep);
                Assert.Equal(listaDto[i].Logradouro, listaEntity[i].Logradouro);
                Assert.Equal(listaDto[i].Numero, listaEntity[i].Numero);
                Assert.Equal(listaDto[i].MunicipioId, listaEntity[i].MunicipioId);
                Assert.NotNull(listaDto[i].Municipio);
                Assert.NotNull(listaDto[i].Municipio.Uf);
            }

            var entityForDtoCreateResult = Mapper.Map<CepDtoCreateResult>(modelForEntity);
            Assert.Equal(entityForDtoCreateResult.Id, modelForEntity.Id);
            Assert.Equal(entityForDtoCreateResult.Cep, modelForEntity.Cep);
            Assert.Equal(entityForDtoCreateResult.Logradouro, modelForEntity.Logradouro);
            Assert.Equal(entityForDtoCreateResult.Numero, modelForEntity.Numero);
            Assert.Equal(entityForDtoCreateResult.MunicipioId, modelForEntity.MunicipioId);
            Assert.Equal(entityForDtoCreateResult.CreateAt, modelForEntity.CreateAt);

            var entityForDtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(modelForEntity);
            Assert.Equal(entityForDtoUpdateResult.Id, modelForEntity.Id);
            Assert.Equal(entityForDtoUpdateResult.Cep, modelForEntity.Cep);
            Assert.Equal(entityForDtoUpdateResult.Logradouro, modelForEntity.Logradouro);
            Assert.Equal(entityForDtoUpdateResult.Numero, modelForEntity.Numero);
            Assert.Equal(entityForDtoUpdateResult.MunicipioId, modelForEntity.MunicipioId);
            Assert.Equal(entityForDtoUpdateResult.UpdateAt, modelForEntity.UpdateAt);

            // Dto => Model
            entityForDto.Numero = "";
            var dtoForModel = Mapper.Map<CepModel>(entityForDto);
            Assert.Equal(dtoForModel.Id, entityForDto.Id);
            Assert.Equal(dtoForModel.Cep, entityForDto.Cep);
            Assert.Equal(dtoForModel.Logradouro, entityForDto.Logradouro);
            Assert.Equal(dtoForModel.Numero, "S/N");
            Assert.Equal(dtoForModel.MunicipioId, entityForDto.MunicipioId);

            var modelForDtoCreate = Mapper.Map<CepDtoCreate>(dtoForModel);
            Assert.Equal(modelForDtoCreate.Cep, dtoForModel.Cep);
            Assert.Equal(modelForDtoCreate.Logradouro, dtoForModel.Logradouro);
            Assert.Equal(modelForDtoCreate.Numero, "S/N");
            Assert.Equal(modelForDtoCreate.MunicipioId, dtoForModel.MunicipioId);

            var modelForDtoUpdate = Mapper.Map<CepDtoUpdate>(dtoForModel);
            Assert.Equal(modelForDtoUpdate.Id, dtoForModel.Id);
            Assert.Equal(modelForDtoUpdate.Cep, dtoForModel.Cep);
            Assert.Equal(modelForDtoUpdate.Logradouro, dtoForModel.Logradouro);
            Assert.Equal(modelForDtoUpdate.Numero, "S/N");
            Assert.Equal(modelForDtoUpdate.MunicipioId, dtoForModel.MunicipioId);
        }
    }
}

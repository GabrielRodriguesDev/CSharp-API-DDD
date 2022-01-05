using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelo de um Municipio")]
        public void E_Possivel_Mapear_Os_Modelos_Municipio()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<MunicipioEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UfEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }
                };

                listaEntity.Add(item);
            }

            // Model => Entity
            var modelForEntity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(modelForEntity.Id, model.Id);
            Assert.Equal(modelForEntity.Nome, model.Nome);
            Assert.Equal(modelForEntity.CodIBGE, model.CodIBGE);
            Assert.Equal(modelForEntity.UfId, model.UfId);
            Assert.Equal(modelForEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelForEntity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var entityForDto = Mapper.Map<MunicipioDto>(modelForEntity);
            Assert.Equal(entityForDto.Id, modelForEntity.Id);
            Assert.Equal(entityForDto.Nome, modelForEntity.Nome);
            Assert.Equal(entityForDto.CodIBGE, modelForEntity.CodIBGE);
            Assert.Equal(entityForDto.UfId, modelForEntity.UfId);

            var entityForDtoCompleto = Mapper.Map<MunicipioDtoCompleto>(listaEntity.FirstOrDefault());
            Assert.Equal(entityForDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(entityForDtoCompleto.Nome, listaEntity.FirstOrDefault().Nome);
            Assert.Equal(entityForDtoCompleto.CodIBGE, listaEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(entityForDtoCompleto.UfId, listaEntity.FirstOrDefault().UfId);
            Assert.NotNull(entityForDtoCompleto.Uf);

            var listaDto = Mapper.Map<List<MunicipioDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
                Assert.Equal(listaDto[i].UfId, listaEntity[i].UfId);
            }

            var entityForDtoCreateResult = Mapper.Map<MunicipioDtoCreateResult>(modelForEntity);
            Assert.Equal(entityForDtoCreateResult.Id, modelForEntity.Id);
            Assert.Equal(entityForDtoCreateResult.Nome, modelForEntity.Nome);
            Assert.Equal(entityForDtoCreateResult.CodIBGE, modelForEntity.CodIBGE);
            Assert.Equal(entityForDtoCreateResult.UfId, modelForEntity.UfId);
            Assert.Equal(entityForDtoCreateResult.CreateAt, modelForEntity.CreateAt);

            var entityForDtoUpdateResult = Mapper.Map<MunicipioDtoUpdateResult>(modelForEntity);
            Assert.Equal(entityForDtoUpdateResult.Id, modelForEntity.Id);
            Assert.Equal(entityForDtoUpdateResult.Nome, modelForEntity.Nome);
            Assert.Equal(entityForDtoUpdateResult.CodIBGE, modelForEntity.CodIBGE);
            Assert.Equal(entityForDtoUpdateResult.UfId, modelForEntity.UfId);
            Assert.Equal(entityForDtoUpdateResult.UpdateAt, modelForEntity.UpdateAt);

            // Dto => Model
            var dtoForModel = Mapper.Map<MunicipioModel>(entityForDto);
            Assert.Equal(dtoForModel.Id, entityForDto.Id);
            Assert.Equal(dtoForModel.Nome, entityForDto.Nome);
            Assert.Equal(dtoForModel.CodIBGE, entityForDto.CodIBGE);
            Assert.Equal(dtoForModel.UfId, entityForDto.UfId);

            //Model => Dto
            var modelForDtoCreate = Mapper.Map<MunicipioDtoCreate>(dtoForModel);
            Assert.Equal(modelForDtoCreate.Nome, dtoForModel.Nome);
            Assert.Equal(modelForDtoCreate.CodIBGE, dtoForModel.CodIBGE);
            Assert.Equal(modelForDtoCreate.UfId, dtoForModel.UfId);

            var modelForDtoUpdate = Mapper.Map<MunicipioDtoUpdate>(dtoForModel);
            Assert.Equal(modelForDtoUpdate.Id, dtoForModel.Id);
            Assert.Equal(modelForDtoUpdate.Nome, dtoForModel.Nome);
            Assert.Equal(modelForDtoUpdate.CodIBGE, dtoForModel.CodIBGE);
            Assert.Equal(modelForDtoUpdate.UfId, dtoForModel.UfId);

        }
    }
}

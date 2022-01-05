using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Api.Domain.Dtos.Uf;
using Api.Domain.Models;
using Api.Domain.Entities;

namespace Api.Service.Test.AutoMapper
{
    public class UfMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelos de Uf")]
        public void E_Possivel_Mapear_Os_Modelos_Uf()
        {
            var model = new UfModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1, 3),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<UfEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(item);
            }

            //Model => Entity
            var modelForEntity = Mapper.Map<UfEntity>(model);
            Assert.Equal(modelForEntity.Id, model.Id);
            Assert.Equal(modelForEntity.Nome, model.Nome);
            Assert.Equal(modelForEntity.Sigla, model.Sigla);
            Assert.Equal(modelForEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelForEntity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var entityForDto = Mapper.Map<UfDto>(modelForEntity);
            Assert.Equal(entityForDto.Id, modelForEntity.Id);
            Assert.Equal(entityForDto.Nome, modelForEntity.Nome);
            Assert.Equal(entityForDto.Sigla, modelForEntity.Sigla);

            var lisEntityForListDto = Mapper.Map<List<UfDto>>(listEntity);
            Assert.True(lisEntityForListDto.Count() == listEntity.Count());

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(lisEntityForListDto[i].Id, listEntity[i].Id);
                Assert.Equal(lisEntityForListDto[i].Nome, listEntity[i].Nome);
                Assert.Equal(lisEntityForListDto[i].Sigla, listEntity[i].Sigla);
            }

            var dtoForModel = Mapper.Map<UfModel>(entityForDto);
            Assert.Equal(dtoForModel.Id, entityForDto.Id);
            Assert.Equal(dtoForModel.Nome, entityForDto.Nome);
            Assert.Equal(dtoForModel.Sigla, entityForDto.Sigla);
        }
    }
}

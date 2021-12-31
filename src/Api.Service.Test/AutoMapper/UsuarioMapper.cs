using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possivel mapear os modelos")]
        public void E_Possivel_Mapear_Os_Modelos()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listaEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                var entity = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };

                listaEntity.Add(entity);
            }

            //Model => Entity
            var modelForEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(modelForEntity.Id, model.Id);
            Assert.Equal(modelForEntity.Name, model.Name);
            Assert.Equal(modelForEntity.Email, model.Email);
            Assert.Equal(modelForEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelForEntity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var entityForDto = Mapper.Map<UserDto>(modelForEntity);
            Assert.Equal(entityForDto.Id, modelForEntity.Id);
            Assert.Equal(entityForDto.Name, modelForEntity.Name);
            Assert.Equal(entityForDto.Email, modelForEntity.Email);

            //ListEntity => ListDto
            var listaDto = Mapper.Map<List<UserDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDto[i].Email, listaEntity[i].Email);
            }

            //Entity => DtoCreteResult
            var entityForDtoCreateResult = Mapper.Map<UserDtoCreateResult>(modelForEntity);
            Assert.Equal(entityForDtoCreateResult.Id, modelForEntity.Id);
            Assert.Equal(entityForDtoCreateResult.Name, modelForEntity.Name);
            Assert.Equal(entityForDtoCreateResult.Email, modelForEntity.Email);
            Assert.Equal(entityForDtoCreateResult.CreateAt, modelForEntity.CreateAt);

            //Entity => DtoUpdateResult
            var entityForDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(modelForEntity);
            Assert.Equal(entityForDtoUpdateResult.Id, modelForEntity.Id);
            Assert.Equal(entityForDtoUpdateResult.Name, modelForEntity.Name);
            Assert.Equal(entityForDtoUpdateResult.Email, modelForEntity.Email);
            Assert.Equal(entityForDtoUpdateResult.UpdateAt, modelForEntity.UpdateAt);

            //Dto => Model
            var dtoForModel = Mapper.Map<UserModel>(entityForDto);
            Assert.Equal(dtoForModel.Id, entityForDto.Id);
            Assert.Equal(dtoForModel.Name, entityForDto.Name);
            Assert.Equal(dtoForModel.Email, entityForDto.Email);

            //DtoCreate => Model (Realizando o reverse nesse caso, pois se funcionar para um jeito funciona para o reverso)
            var modelforDtoCreate = Mapper.Map<UserDtoCreate>(model);
            Assert.Equal(modelforDtoCreate.Name, model.Name);
            Assert.Equal(modelforDtoCreate.Email, model.Email);


            //Modelo => DtoUpdate Model (Realizando o reverse nesse caso, pois se funcionar para um jeito funciona para o reverso)
            var modeloForDtoUpdate = Mapper.Map<UserDtoUpdate>(model);
            Assert.Equal(modeloForDtoUpdate.Id, model.Id);
            Assert.Equal(modeloForDtoUpdate.Name, model.Name);
            Assert.Equal(modeloForDtoUpdate.Email, model.Email);

        }


    }
}

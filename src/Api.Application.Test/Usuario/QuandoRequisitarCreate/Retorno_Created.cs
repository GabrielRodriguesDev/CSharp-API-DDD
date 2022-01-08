using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar o Created.")]
        public async Task E_Possivel_Invocar_Controller_Create()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            var userDtoCreate = new UserDtoCreate
            {
                Name = name,
                Email = email
            };

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.Now
                }
            );

            _controller = new UsersController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("https://github.com/GabrielRodriguesDev");

            _controller.Url = url.Object;

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as UserDtoCreateResult; //Pegando o valor do Objeto CreateResult (result) e convertendo o valor em UserDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, userDtoCreate.Name);
            Assert.Equal(resultValue.Email, userDtoCreate.Email);

        }
    }
}

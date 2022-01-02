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

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
    public class Retorno_BadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated.")]
        public async Task E_Possivel_Invocar_Controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();


            var userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                    new UserDtoUpdateResult
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Email = email,
                        UpdateAt = DateTime.Now
                    }
            );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "É um campo obrigatorio");

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is BadRequestResult);
        }
    }
}

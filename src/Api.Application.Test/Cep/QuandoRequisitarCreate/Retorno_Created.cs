using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
                new CepDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de Rua",
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(_serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("https://github.com/GabrielRodriguesDev");

            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreate
            {
                Logradouro = "Teste de Rua",
                Numero = ""
            };

            var result = await _controller.Post(cepDtoCreate);

            Assert.True(result is CreatedResult);
        }
    }
}

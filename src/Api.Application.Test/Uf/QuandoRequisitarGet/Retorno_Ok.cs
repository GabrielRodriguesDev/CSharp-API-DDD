using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Uf.QuandoRequisitarGet
{
    public class Retorno_Ok
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possivel realizar o Get.")]
        public async Task E_Possivel_Invocar_Controller_Get()
        {
            var serviceMock = new Mock<IUfService>();
            var Id = Guid.NewGuid();
            var Nome = "São Paulo";
            var Sigla = "SP";

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    Sigla = "SP"
                }
            );

            _controller = new UfsController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());

            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as UfDto;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Nome, Nome);
            Assert.Equal(resultValue.Sigla, Sigla);
        }
    }
}

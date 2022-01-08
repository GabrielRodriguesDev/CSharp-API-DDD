using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Test.Cep.QuandoRequisitarDelete
{
    public class Retorno_NotFound
    {
        private CepsController _controller;
        [Fact(DisplayName = "É possível Realizar o Deleted.")]
        public async Task E_Possivel_Invocar_a_Controller_Delete()
        {
            var _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new CepsController(_serviceMock.Object);
            var result = await _controller.Delete(Guid.NewGuid());

            Assert.True(result is NotFoundObjectResult);
        }
    }

}

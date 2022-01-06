using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class QuandoForExecutadoGet : UfTestes
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;


        [Fact(DisplayName = "É Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Get()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(ufDto.Id)).ReturnsAsync(ufDto);

            var result = await _serviceMock.Object.Get(ufDto.Id);
            Assert.NotNull(result);
            Assert.Equal(result.Id, ufDto.Id);
            Assert.Equal(result.Nome, ufDto.Nome);
        }
    }
}

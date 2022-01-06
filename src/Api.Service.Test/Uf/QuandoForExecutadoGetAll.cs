using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class QuandoForExecutadoGetAll : UfTestes
    {
        private IUfService _service;

        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GetAll ")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUfDto);

            var result = await _serviceMock.Object.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
        }
    }
}

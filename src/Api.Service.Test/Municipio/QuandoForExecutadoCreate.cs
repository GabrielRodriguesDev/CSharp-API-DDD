using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Service.Test.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoCreate : MunicipioTestes
    {

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Create")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Post(municipioDtoCreate)).ReturnsAsync(municipioDtoCreateResult);

            var result = await _serviceMock.Object.Post(municipioDtoCreate);
            Assert.NotNull(result);
            Assert.False(result.Id == Guid.Empty);
            Assert.Equal(result.Nome, municipioDtoCreate.Nome);
            Assert.Equal(result.CodIBGE, municipioDtoCreate.CodIBGE);
        }
    }
}

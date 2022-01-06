using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoDelete : MunicipioTestes
    {
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Delete")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(municipioDto.Id)).ReturnsAsync(true);

            var result = await _serviceMock.Object.Delete(municipioDto.Id);
            Assert.NotNull(result);
            Assert.True(result);
        }
    }
}

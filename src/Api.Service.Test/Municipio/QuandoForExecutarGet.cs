using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutarGet : MunicipioTestes
    {
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Get")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Get(this.Id)).ReturnsAsync(municipioDto);

            var result = await _serviceMock.Object.Get(this.Id);
            Assert.NotNull(result);
            Assert.Equal(result.Id, this.Id);
            Assert.Equal(result.Nome, this.Nome);
            Assert.Equal(result.CodIBGE, this.CodIBGE);

        }
    }
}

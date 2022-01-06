using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoDelete : CepTestes
    {
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Delete")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(this.Id)).ReturnsAsync(true);

            var result = await _serviceMock.Object.Delete(this.Id);
            Assert.NotNull(result);
            Assert.True(result);
        }
    }
}

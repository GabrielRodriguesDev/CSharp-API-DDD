using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoUpdate : CepTestes
    {
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Update")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Put(cepDtoUpdate)).ReturnsAsync(CepDtoUpdateResult);

            var result = await _serviceMock.Object.Put(cepDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(result.Id, cepDto.Id);
            Assert.Equal(result.Cep, cepDto.Cep);
            Assert.Equal(result.Logradouro, cepDto.Logradouro);
            Assert.Equal(result.Numero, cepDto.Numero);
            Assert.Equal(result.MunicipioId, cepDto.MunicipioId);
            Assert.NotNull(result.UpdateAt);
        }
    }
}

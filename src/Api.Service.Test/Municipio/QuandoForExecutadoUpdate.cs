using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoUpdate : MunicipioTestes
    {
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Update")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Put(municipioDtoUpdate)).ReturnsAsync(municipioDtoUpdateResult);

            var result = await _serviceMock.Object.Put(municipioDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(result.Nome, NomeAlterado);
            Assert.Equal(result.CodIBGE, CodIBGEAlterado);
            Assert.Equal(result.UfId, municipioDtoUpdate.UfId);


        }
    }
}

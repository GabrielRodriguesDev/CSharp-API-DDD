using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandorForExecutadoGetCompleteById : MunicipioTestes
    {
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Get Complete By Id")]
        public async Task E_Possivel_Executar_Metodo_Get_Complete_By_Id()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetCompleteById(this.Id)).ReturnsAsync(municipioDtoCompleto);

            var result = await _serviceMock.Object.GetCompleteById(this.Id);
            Assert.NotNull(result);
            Assert.True(result.Id == this.Id);
            Assert.Equal(result.Nome, this.Nome);
            Assert.Equal(result.CodIBGE, this.CodIBGE);
            Assert.NotNull(result.Uf);
        }
    }
}

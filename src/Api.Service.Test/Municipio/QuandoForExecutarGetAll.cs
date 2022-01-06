using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutarGetAll : MunicipioTestes
    {
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GetAll")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaDto);

            var result = await _serviceMock.Object.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
        }
    }
}

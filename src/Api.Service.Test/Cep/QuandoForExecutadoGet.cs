using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoGet : CepTestes
    {
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Get")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(this.Id)).ReturnsAsync(cepDto);

            var resultGetId = await _serviceMock.Object.Get(this.Id);
            Assert.NotNull(resultGetId);
            Assert.Equal(resultGetId.Id, cepDto.Id);
            Assert.Equal(resultGetId.Cep, cepDto.Cep);
            Assert.Equal(resultGetId.Logradouro, cepDto.Logradouro);
            Assert.NotNull(resultGetId.Municipio);
            Assert.NotNull(resultGetId.Municipio.Uf);

            _serviceMock.Setup(m => m.Get(this.Cep)).ReturnsAsync(cepDto);

            var resultGetCep = await _serviceMock.Object.Get(this.Cep);
            Assert.NotNull(resultGetCep);
            Assert.Equal(resultGetCep.Id, cepDto.Id);
            Assert.Equal(resultGetCep.Cep, cepDto.Cep);
            Assert.Equal(resultGetCep.Logradouro, cepDto.Logradouro);
            Assert.NotNull(resultGetCep.Municipio);
            Assert.NotNull(resultGetCep.Municipio.Uf);
        }
    }
}

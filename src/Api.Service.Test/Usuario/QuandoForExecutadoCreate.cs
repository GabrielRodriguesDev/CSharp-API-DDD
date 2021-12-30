using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoCreate : UsuarioTestes
    {
        private IUserService _service;  //Criação da variavel que vai receber o serviço para comparação posterior;

        private Mock<IUserService> _serviceMock; //Criação da variavel que vai receber o objeto mock fortemente tipado;

        [Fact(DisplayName = "É possivel executar o método Create")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IUserService>(); //Crição do Objeto fortemente tipado que utiliza a interface IUserService, sendo então fortemente tipado. 
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(result, userDtoCreateResult);
        }
    }
}

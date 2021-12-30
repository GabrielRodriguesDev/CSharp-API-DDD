using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoDelete : UsuarioTestes
    {
        private IUserService _service;  //Criação da variavel que vai receber o serviço para comparação posterior;

        private Mock<IUserService> _serviceMock; //Criação da variavel que vai receber o objeto mock fortemente tipado;

        [Fact(DisplayName = "É possivel executar o método Delete")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IUserService>(); //Crição do Objeto fortemente tipado que utiliza a interface IUserService, sendo então fortemente tipado.
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())) //Realizando o delete com qualquer valor
                .ReturnsAsync(true);    // E o valor esperado vai ser true;
            _service = _serviceMock.Object;

            var result = await _service.Delete(IdUsuario);
            Assert.True(result);
        }
    }
}

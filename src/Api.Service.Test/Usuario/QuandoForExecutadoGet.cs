using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUserService _service; // Criando variavel com a interface de implementacao IUserService

        private Mock<IUserService> _serviceMock; // Criando variavel para mockar os dados com base na interface IUserSerive

        [Fact(DisplayName = "É possivel executar o método GET")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUserService>(); //Criando uma instancia de Mock.
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);//Realizando a inicialização para uso do mock (setup) (Estamos dizendo que quando o usuario for realizar o get() o parametro a ser passado deve ser IdUsuario e que o retono é um UserDto)
            _service = _serviceMock.Object; //Passando o Objeto mock configurado para a _service

            var result = await _service.Get(IdUsuario); //Realizando o Get passando como parametro o IdUsuario (O parametro a ser passado deve ser o mesmo que configuramos no mock, o mesmo vale para o retorno tem que ser o mesmo que pré determinamos no mock)
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);
        }
    }
}

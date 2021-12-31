using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUserService _service;  //Criação da variavel que vai receber o serviço para comparação posterior;

        private Mock<IUserService> _serviceMock; //Criação da variavel que vai receber o objeto mock fortemente tipado;

        [Fact(DisplayName = "É possivel executar o método GET")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUserService>(); //Crição do Objeto fortemente tipado que utiliza a interface IUserService, sendo então fortemente tipado. 
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto); //Realizando o Setup do objeto Mock, que foi definido para esperar um retorno de UserDto. Note que idependente do IdUsuario passado, o valor de retorno do objeto Mock será sempre UserDto, pois assim está definido.
            _service = _serviceMock.Object; //Passando o Objeto mock configurado para a _service (Consigo passar o Objeto mock configurado para a classe _service, pois ela é apenas uma classe fortemente tipada ela não tem a implementação dos métodos pois é uma interface, após eu passar o objeto Mock com a implementação dos métodos já que ambos implementam e são tipados com a mesma interface, a classe _service tem acesso aos métodos do mock) (O meu Setup imita o método real)

            var result = await _service.Get(IdUsuario); //Realizando o Get passando como parametro o IdUsuario (O parametro a ser passado deve ser o mesmo que configuramos no mock, o mesmo vale para o retorno tem que ser o mesmo que pré determinamos no mock)
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;
using Api.Domain.Dtos;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método FindByLogin")]
        public async Task E_Possivel_Executar_Metodo_FindByLogin()
        {
            var email = Faker.Internet.Email();

            var loginDto = new LoginDto
            {
                Email = email
            };

            var objetoRetorno = new
            {
                authenticated = true,
                created = DateTime.Now,
                expiration = DateTime.Now.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = email,
                message = "Usuario Logado com sucesso"
            };

            _serviceMock = new Mock<ILoginService>(); //Crição do Objeto fortemente tipado que utiliza a interface ILoginService, sendo então fortemente tipado. 
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoRetorno); //Realizando o Setup do mock, dizendo que quando chamar o método FindByLogin passando um "loginDto" como parametro, o retorno será um "objetoRetorno"


            var result = await _serviceMock.Object.FindByLogin(loginDto); //Realizando o teste de uma forma diferente, usando o objeto do mock que fizemos o setup para fazer a execução do método
            Assert.NotNull(result);
        }
    }
}

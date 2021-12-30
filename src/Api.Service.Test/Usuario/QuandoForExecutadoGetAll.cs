using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGetAll : UsuarioTestes
    {
        private IUserService _service;

        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método GETAll")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IUserService>(); //Crição do Objeto fortemente tipado que utiliza a interface IUserService, sendo então fortemente tipado. 
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto); //Realizando o Setup do objeto Mock, que foi definido para esperar um retorno de listaUserDto
            _service = _serviceMock.Object; //Passando o Objeto mock configurado para a _service

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
        }
    }
}

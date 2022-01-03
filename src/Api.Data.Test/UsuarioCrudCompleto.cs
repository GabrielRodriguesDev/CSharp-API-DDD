using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste> //IClassFixture<> É uma interface que permite acessar instancias de outra classe (Basicamente libera uma injeção de dependencia para nós);
    {
        private ServiceProvider _serviceProvider { get; set; }
        public UsuarioCrudCompleto(DbTeste dbTeste) //Recebendo a classe que que foi tagueada com IClassFixture<>
        {
            this._serviceProvider = dbTeste.ServiceProvider; //Recebendo o container de serviços
        }

        [Fact(DisplayName = "Crud de Usúario")]
        [Trait("Crud", "UserEntity")]
        public async Task RealizandoCrudUsuario()
        {
            using (var context = this._serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context); // Criando o objeto BaseRepository e passando o contexto de conexão com BD
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                //Test Insert
                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                //Test Update
                _entity.Name = Faker.Name.First();
                var _regitroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_regitroAtualizado);
                Assert.Equal(_entity.Email, _regitroAtualizado.Email);
                Assert.Equal(_entity.Name, _regitroAtualizado.Name);

                //Test Exist
                var _registroExiste = await _repositorio.ExistAsync(_regitroAtualizado.Id);
                Assert.True(_registroExiste);

                //Test Select
                var _registroSelecionado = await _repositorio.SelectAsync(_regitroAtualizado.Id);
                Assert.NotNull(_regitroAtualizado);
                Assert.Equal(_regitroAtualizado.Email, _registroSelecionado.Email);
                Assert.Equal(_regitroAtualizado.Name, _registroSelecionado.Name);

                //Test SelectAll
                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 1);

                //Test Remove
                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                //Test Login
                var _usuarioPadrao = await _repositorio.FindByLogin("gabriel@gabriel.com");
                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("Administrador", _usuarioPadrao.Name);
                Assert.Equal("gabriel@gabriel.com", _usuarioPadrao.Email);
            }
        }
    }
}

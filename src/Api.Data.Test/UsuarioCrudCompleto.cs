using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider { get; set; }

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            this._serviceProvider = dbTeste.ServiceProvider; //Recebendo o container de serviços
        }


        [Fact(DisplayName = "Crud de Usúario")]
        [Trait("Crud", "UserEntity")]
        public async Task RealizandoCrudUsuario()
        {
            using (var context = this._serviceProvider.GetService<MyContext>())
            {
                BaseRepository<UserEntity> _repositorio = new BaseRepository<UserEntity>(context); // Criando o objeto BaseRepository e passando o contexto de conexão com BD
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };
                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
            }
        }

    }
}

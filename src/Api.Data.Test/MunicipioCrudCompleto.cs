using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class MunicipioCrudCompleto : IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public MunicipioCrudCompleto(DbTeste dbTeste)
        {
            this._serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Crud de Municipio")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task E_Possivel_Realizar_CRUD_Municipio()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repositorio = new MunicipioImplementation(context);
                MunicipioEntity _entity = new MunicipioEntity
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_registroCriado.Nome, _entity.Nome);
                Assert.Equal(_registroCriado.CodIBGE, _entity.CodIBGE);
                Assert.Equal(_registroCriado.UfId, _entity.UfId);
                Assert.False(_registroCriado.Id == Guid.Empty);


                _entity.Nome = Faker.Address.City();
                var _regitroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_regitroAtualizado);
                Assert.Equal(_regitroAtualizado.Nome, _entity.Nome);
                Assert.Equal(_regitroAtualizado.CodIBGE, _entity.CodIBGE);
                Assert.Equal(_regitroAtualizado.UfId, _entity.UfId);


                var _registroSelecionado = await _repositorio.SelectAsync(_entity.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroSelecionado.Id, _entity.Id);
                Assert.Equal(_registroSelecionado.Nome, _entity.Nome);
                Assert.Equal(_registroSelecionado.UfId, _entity.UfId);
                Assert.Null(_registroSelecionado.Uf);

                _registroSelecionado = await _repositorio.GetCompleteByIBGE(_regitroAtualizado.CodIBGE);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_regitroAtualizado.Id, _registroSelecionado.Id);
                Assert.Equal(_regitroAtualizado.Nome, _registroSelecionado.Nome);
                Assert.NotNull(_registroSelecionado.Uf);

                _registroSelecionado = await _repositorio.GetCompleteById(_regitroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_regitroAtualizado.Id, _registroSelecionado.Id);
                Assert.Equal(_regitroAtualizado.Nome, _registroSelecionado.Nome);
                Assert.NotNull(_registroSelecionado.Uf);


                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);


                var _registroDeletado = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_registroDeletado);

                _todosRegistros = await _repositorio.SelectAsync();
                Assert.True(_todosRegistros.Count() == 0);
            }
        }
    }
}

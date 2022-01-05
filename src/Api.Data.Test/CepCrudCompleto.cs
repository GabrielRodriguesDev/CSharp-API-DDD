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
    public class CepCrudCompleto : IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public CepCrudCompleto(DbTeste dbTeste)
        {
            this._serviceProvider = dbTeste.ServiceProvider;
        }


        [Fact(DisplayName = "Crud de Cep")]
        [Trait("CRUD", "CepEntity")]
        public async Task E_Possivel_Realizar_CRUD_Cep()
        {
            using (var context = this._serviceProvider.GetService<MyContext>())
            {

                MunicipioImplementation _repositorioMunicipio = new MunicipioImplementation(context);
                MunicipioEntity _entityMunicipio = new MunicipioEntity
                {
                    Nome = Faker.Address.City(),
                    CodIbge = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _municipioRegistroCriado = await _repositorioMunicipio.InsertAsync(_entityMunicipio);
                Assert.NotNull(_municipioRegistroCriado);
                Assert.Equal(_municipioRegistroCriado.Nome, _entityMunicipio.Nome);
                Assert.False(_municipioRegistroCriado.Id == Guid.Empty);

                CepImplementation _repositorioCep = new CepImplementation(context);
                CepEntity _entityCep = new CepEntity
                {
                    Cep = "13.481.001",
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "0 até 2000",
                    MunicipioId = _municipioRegistroCriado.Id
                };

                var _registroCriado = await _repositorioCep.InsertAsync(_entityCep);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_registroCriado.Cep, _entityCep.Cep);
                Assert.Equal(_registroCriado.Logradouro, _entityCep.Logradouro);
                Assert.Equal(_registroCriado.Numero, _entityCep.Numero);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entityCep.Logradouro = Faker.Address.StreetAddress();
                var _regitroAtualizado = await _repositorioCep.UpdateAsync(_entityCep);
                Assert.NotNull(_regitroAtualizado);
                Assert.Equal(_regitroAtualizado.Cep, _entityCep.Cep);
                Assert.Equal(_regitroAtualizado.Logradouro, _entityCep.Logradouro);
                Assert.Equal(_regitroAtualizado.Numero, _entityCep.Numero);
                Assert.Equal(_regitroAtualizado.MunicipioId, _entityCep.MunicipioId);
                Assert.True(_regitroAtualizado.Id == _registroCriado.Id);

                var _registroSelecionado = await _repositorioCep.SelectAsync(_regitroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroSelecionado.Cep, _regitroAtualizado.Cep);
                Assert.Equal(_registroSelecionado.Logradouro, _regitroAtualizado.Logradouro);
                Assert.Equal(_registroSelecionado.MunicipioId, _regitroAtualizado.MunicipioId);

                _registroSelecionado = await _repositorioCep.SelectAsync(_regitroAtualizado.Cep);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroSelecionado.Cep, _regitroAtualizado.Cep);
                Assert.Equal(_registroSelecionado.Logradouro, _regitroAtualizado.Logradouro);
                Assert.Equal(_registroSelecionado.MunicipioId, _regitroAtualizado.MunicipioId);
                Assert.NotNull(_registroSelecionado.Municipio);
                Assert.NotNull(_registroSelecionado.Municipio.Uf);


                var _todosRegistros = await _repositorioCep.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _registroDeletado = await _repositorioCep.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_registroDeletado);

                _todosRegistros = await _repositorioCep.SelectAsync();
                Assert.True(_todosRegistros.Count() == 0);
            }
        }
    }
}

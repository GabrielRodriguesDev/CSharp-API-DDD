using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }

    }
    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace(" - ", string.Empty)}"; //Criando um nome de um BD sempre diferente usando o NewGuid()
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var connectionString = $"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=root;Password=fx870";
            var serviceColletion = new ServiceCollection();// Criando uma coleção de Serviços
            /*Adicionando o contexto de conexão com o BD a coleção de serviços*/
            serviceColletion.AddDbContext<MyContext>(o =>
                o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                    ServiceLifetime.Transient
            );

            ServiceProvider = serviceColletion.BuildServiceProvider(); //Criando o container de Serviços
            using (var context = ServiceProvider.GetService<MyContext>()) // Usando o bloco using pois após a execução do bloco terminar ele vai usar o Dispose para elimitar as variaveis da memoria
            {
                context.Database.EnsureCreated(); //Criando o Bd de teste e rodando as migrações
            }
        }

        public void Dispose() //Método da interface IDispose que descarta algo da classe após sua execução
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted(); //Deletando o BD após os testes.
            }
        }
    }
}

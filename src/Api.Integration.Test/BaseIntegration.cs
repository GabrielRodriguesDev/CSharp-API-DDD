using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Dtos;
using application;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; private set; }

        public HttpClient client { get; private set; }

        public IMapper mapper { get; set; }

        public string hostApi { get; set; }



        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            var mapper = new AutoMapperFixture().GetMapper();

            client = server.CreateClient(); //Simulando um servidor (Postman)
        }


        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(url,
            new StringContent(JsonConvert.SerializeObject(dataclass),
            System.Text.Encoding.UTF8, "application/json")); // Post Generico
        }


        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto()
            {
                Email = "gabriel@gabriel.com"
            };

            var resultLogin = await PostJsonAsync(loginDto, $"{hostApi}login", client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResposeDto>(jsonLogin);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                                                                        loginObject.acessToken);
        }

        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
    }

    public class AutoMapperFixture
    {

        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => // Instanciando classe de configuração de mapeamento
            {
                cfg.AddProfile(new ModelToEntityProfile()); //Passando as classes de mapeamento que já existem na camada de CrossCutting
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });

            return config.CreateMapper(); //Criando o mapeamento
        }
    }
}

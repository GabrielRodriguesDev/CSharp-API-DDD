using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        //Camada de configuração de injecção de dependecia, estamos enfatizando que quando charmarmos uma
        //interface, vamos instanciar uma classe.
        public static void ConfigureDependeciesService(IServiceCollection serviceCollection)
        {
            //Existe diferenças entre os métodos, aqui vamos usar o addTrasient mas por questões
            // de facilitação didática.
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}

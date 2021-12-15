using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependeciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            var connectionString = "server=localhost;port=3306;database=dbAPI;uid=root;password=fx870";
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }
    }
}

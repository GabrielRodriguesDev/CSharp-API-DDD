using System;
using Api.CrossCutting.Mappings;
using AutoMapper;
using Xunit;

namespace Api.Service.Test
{
    public abstract class BaseTesteService
    {

        public IMapper Mapper { get; set; }
        public BaseTesteService()
        {
            Mapper = new AutoMapperFixture().GetMapper(); // Criando a instancia de configuração de automapper
        }

        public class AutoMapperFixture : IDisposable
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
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}

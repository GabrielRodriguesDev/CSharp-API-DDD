using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Uf
{
    public class UfTestes
    {

        public Guid Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public List<UfDto> listaUfDto = new List<UfDto>();

        public UfDto ufDto;

        public UfTestes()
        {
            Id = Guid.NewGuid();
            Nome = Faker.Address.UsState();
            Sigla = Faker.Address.UsState().Substring(1, 3);

            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                };
                listaUfDto.Add(dto);
            };

            ufDto = new UfDto
            {
                Id = this.Id,
                Nome = this.Nome,
                Sigla = this.Sigla
            };
        }
    }
}

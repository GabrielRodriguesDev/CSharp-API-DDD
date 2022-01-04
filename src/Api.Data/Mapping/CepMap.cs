using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("Cep");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Cep); //Criando um Index para otimizar

            builder.HasOne(c => c.Municipio).WithMany(m => m.Ceps); // 1 Cep só pode ter 1 Municipio // 1 Municipio pode ter N Ceps


        }
    }
}

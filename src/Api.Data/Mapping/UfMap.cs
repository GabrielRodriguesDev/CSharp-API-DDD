using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UfMap : IEntityTypeConfiguration<UfEntity>
    {
        public void Configure(EntityTypeBuilder<UfEntity> builder)
        {
            builder.ToTable("Uf");  //Definindo o nome da tabela

            builder.HasKey(u => u.Id);  //Determinando a PK

            builder.HasIndex(u => u.Sigla).IsUnique(); //Marcando a Sigal como UNIQUE

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CepImplementation : BaseRepository<CepEntity>, ICepRepository
    {

        private DbSet<CepEntity> _dataset;
        public CepImplementation(MyContext context) : base(context)
        {
            this._dataset = context.Set<CepEntity>();
        }
        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await this._dataset.Include(c => c.Municipio)
                        .ThenInclude(m => m.Uf)
                        .FirstOrDefaultAsync(c => c.Cep.Equals(cep));
        }
    }
}

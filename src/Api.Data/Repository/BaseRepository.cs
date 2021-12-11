using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain;
using Api.Domain.Entities;

namespace Api.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        protected readonly MyContext _context;

        private DbSet<TEntity> _dataset;

        public BaseRepository(MyContext context)
        {
            this._context = context;
            //this._dataset = _context.Set<TEntity>();
        }
        public Task<bool> DeleteAync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> InsertAsync(TEntity item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = DateTime.UtcNow;
                this._context.Add(item);

                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return item;
        }

        public Task<TEntity> SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}

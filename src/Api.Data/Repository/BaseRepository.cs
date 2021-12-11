using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        protected readonly MyContext _context;

        private DbSet<TEntity> _dataset;


        public BaseRepository(MyContext context)
        {
            this._context = context;
            this._dataset = this._context.Set<TEntity>();
        }
        public async Task<bool> DeleteAync(Guid id)
        {
            try
            {
                var result = await this._dataset.SingleOrDefaultAsync(t => t.Id.Equals(id));
                if (result == null)
                    return false;

                this._dataset.Remove(result);

                await this._context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                this._dataset.Add(item);

                await this._context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Task<TEntity> SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            try
            {
                var result = await this._dataset.SingleOrDefaultAsync(t => t.Id.Equals(item.Id));
                if (result == null)
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                this._context.Entry(result).CurrentValues.SetValues(item);
                await this._context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

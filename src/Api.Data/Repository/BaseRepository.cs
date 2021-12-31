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
        public async Task<bool> DeleteAsync(Guid id)
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

        public async Task<bool> ExistAsync(Guid id)
        {
            return await this._dataset.AnyAsync(t => t.Id.Equals(id));
        }

        public async Task<TEntity> InsertAsync(TEntity item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = DateTime.Now;
                this._dataset.Add(item);

                await this._context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<TEntity> SelectAsync(Guid id)
        {
            try
            {

                return await this._dataset.SingleOrDefaultAsync(t => t.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> SelectAsync()
        {
            try
            {
                return await this._dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            try
            {
                var result = await this._dataset.SingleOrDefaultAsync(t => t.Id.Equals(item.Id));
                if (result == null)
                    return null;

                item.UpdateAt = DateTime.Now;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> InsertAsync(TEntity item);

        Task<TEntity> UpdateAsync(TEntity item);

        Task<bool> DeleteAync(Guid id);

        Task<TEntity> SelectAsync(Guid id);

        Task<IEnumerable<TEntity>> SelectAsync();
    }
}

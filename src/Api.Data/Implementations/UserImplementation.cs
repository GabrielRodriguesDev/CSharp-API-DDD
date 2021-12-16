
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation : IUserRepository
    {

        private DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context)
        {
            this._dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await this._dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
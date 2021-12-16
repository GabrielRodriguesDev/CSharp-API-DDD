using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Repository
{
    public interface IUserRepository
    {
        Task<UserEntity> FindByLogin(string email);

    }
}

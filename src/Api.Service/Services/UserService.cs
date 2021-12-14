using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;

namespace Api.Service.Services
{


    public class UserService : IUserService
    {

        private IRepository<UserEntity> _repository;
        public UserService(IRepository<UserEntity> repository)
        {
            this._repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this._repository.DeleteAync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await this._repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await this._repository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await this._repository.UpdateAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await this._repository.UpdateAsync(user);
        }
    }
}

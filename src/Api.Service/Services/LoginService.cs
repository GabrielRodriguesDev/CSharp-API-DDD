using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;
using Api.Domain.Repository;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {

        private IUserRepository _repository;
        public LoginService(IUserRepository repository)
        {
            this._repository = repository;
        }
        public async Task<object> FindByLogin(UserEntity user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                return await this._repository.FindByLogin(user.Email);
            }
            else
            {
                return null;
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
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
        public async Task<object> FindByLogin(LoginDto logindata)
        {
            if (logindata != null && !string.IsNullOrWhiteSpace(logindata.Email))
            {
                return await this._repository.FindByLogin(logindata.Email);
            }
            else
            {
                return null;
            }

        }
    }
}

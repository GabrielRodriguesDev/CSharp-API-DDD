using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{


    public class UserService : IUserService
    {

        private IRepository<UserEntity> _repository;

        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this._repository.DeleteAync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await this._repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await this._repository.SelectAsync();
            return this._mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = this._mapper.Map<UserModel>(user);
            var entity = this._mapper.Map<UserEntity>(model);
            var result = await this._repository.InsertAsync(entity);
            return this._mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = this._mapper.Map<UserModel>(user);
            var entity = this._mapper.Map<UserEntity>(model);
            var result = await this._repository.UpdateAsync(entity);

            return this._mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}

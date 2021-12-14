using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Users
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);

        Task<IEnumerable<UserEntity>> GetAll();

        Task<UserEntity> Post(UserEntity user);

        Task<UserEntity> Put(UserEntity user);

        Task<bool> Delete(Guid id);

        /* Caso eu tenha um método "Calular alguma coisa", eu criaria a o método aqui na interface
        e geraria a implementação do método na camada de serviço*/
    }
}

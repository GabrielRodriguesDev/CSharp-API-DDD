
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.Users;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {

        private IUserRepository _repository;

        private SigningConfigurations _signingConfigurations;
        private TokenConfiguration _tokenConfiguration;

        private IConfiguration _configuration { get; }
        public LoginService(IUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            TokenConfiguration tokenConfiguration,
                            IConfiguration configuration)
        {
            this._repository = repository;
            this._signingConfigurations = signingConfigurations;
            this._tokenConfiguration = tokenConfiguration;
            this._configuration = configuration;
        }
        public async Task<object> FindByLogin(LoginDto logindata)
        {

            if (logindata != null && !string.IsNullOrWhiteSpace(logindata.Email))
            {
                var user = await this._repository.FindByLogin(logindata.Email);
                if (user == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(user.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JTI = Id do token (Criando o Id do token)
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                    );
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler); // Criando o token com as claims

                    return SuccessObject(createDate, expirationDate, token, logindata); //Criando objeto de retorno (Sucesso); 
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDto user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = "Usuario Logado com sucesso"
            };
        }
    }
}

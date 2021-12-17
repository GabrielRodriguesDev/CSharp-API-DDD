using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurations()
        {
            //Com o uso do using nesse caso serve para criarmos uma váriavel utilizarmos ela em nosso contexto
            //Ao final do uso a váriavel é excluida da memória 
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true)); // Gerando a key e atribuindo a propriedade key do objeto
            }//Após essa execução a váriavel morre, pois já realizou sua e

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature); //Gerando o token com base em uma chave e criptogrando em Sha256
        }
    }
}

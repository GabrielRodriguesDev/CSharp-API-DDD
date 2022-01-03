using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Usuario
{
    public class QuandoRequisitarUsuario : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }

        [Fact]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            await AdicionarToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var userDto = new UserDtoCreate()
            {
                Name = _name,
                Email = _email
            };

            #region Post
            var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var resgistroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(resgistroPost.Name, _name);
            Assert.Equal(resgistroPost.Email, _email);
            #endregion

            #region GetAll
            response = await client.GetAsync($"{hostApi}users"); //Realizando o GetAll (Usando a rota como guia)
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); //Validando se o retorno da requisição é igual a 200

            var jsonResult = await response.Content.ReadAsStringAsync(); //Recuperando o conteudo da requisição
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult); //Deserializando o conteudo e convertendo um json de um IEnumerable<UserDto>
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0); //Validando se existe mais de 0 registros
            Assert.True(listaFromJson.Where(u => u.Id == resgistroPost.Id).Count() == 1); //Validando se dentro da lista existe o id que coorresponde ao id que realizamos o post no teste acima
            #endregion

            #region  Put
            var updateUserDto = new UserDtoUpdate //Criando objeto  UserDtoUpdate
            {
                Id = resgistroPost.Id, //Recuperando o Id do registro que inserimos no teste de post linhas acima
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserDto),
                                        Encoding.UTF8, "application/json"); //Transformando o objeto criando em um json

            response = await client.PutAsync($"{hostApi}users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<UserDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroAtualizado.Name, resgistroPost.Name);
            Assert.NotEqual(registroAtualizado.Email, resgistroPost.Email);
            #endregion

            #region  Get
            response = await client.GetAsync($"{hostApi}users/{registroAtualizado.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<UserDto>(jsonResult);

            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Name, registroAtualizado.Name);
            Assert.Equal(registroSelecionado.Email, registroAtualizado.Email);

            #endregion
        }
    }
}

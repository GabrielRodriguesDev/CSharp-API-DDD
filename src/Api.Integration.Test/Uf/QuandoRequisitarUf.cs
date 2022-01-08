using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Uf
{
    public class QuandoRequisitarUf : BaseIntegration
    {
        [Fact]
        public async Task TestName()
        {
            await AdicionarToken();

            #region  GetAll
            var response = await client.GetAsync($"{hostApi}ufs");
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UfDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() == 27);
            #endregion

            #region  Get{Id}
            var id = listaFromJson.Where(x => x.Sigla == "SP").FirstOrDefault().Id; //Retornando o ID, caso ele consiga entrar algo qe apareça no BD
            response = await client.GetAsync($"{hostApi}ufs/{id}");
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<UfDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Nome, "São Paulo");
            #endregion
        }
    }
}

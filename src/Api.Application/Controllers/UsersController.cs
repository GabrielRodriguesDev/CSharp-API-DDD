using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            //ActionResult é uma classe que lida com vários tipos de arquivos. Json XML.... Então estou
            //dizendo vai retonar um JSON ou XML... entre outros.
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                return Ok(await this._service.GetAll());
            }
            catch (ArgumentException e) //ArgumentException -> Para tratar erros de Controller
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}

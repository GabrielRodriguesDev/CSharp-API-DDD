using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {

        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            this._service = service;
        }


        [HttpPost]
        public async Task<object> Login([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (user == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await this._service.FindByLogin(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}


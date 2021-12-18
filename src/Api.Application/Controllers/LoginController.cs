using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto logindata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (logindata == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await this._service.FindByLogin(logindata);
                if (result != null)
                {
                    return NotFound(result);
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


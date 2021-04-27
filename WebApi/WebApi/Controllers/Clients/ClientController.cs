using Application.Clients.Commands.Create;
using Application.Clients.Commands.Delete;
using Application.Common.Exceptions;
using Application.Repositories.Interfaces;
using Domain.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly CreateClient create;
        private readonly DeleteClient delete;
        private readonly ReadClient read;

        public ClientController(Startup.DeleteByNameResolver deleteAccesor, IClientReadOnlyRepository readClient, ICreate<Client> createClient)
        {
            delete = new DeleteClient(deleteAccesor(DeletesEmail.Client), readClient);
            create = new CreateClient(createClient, readClient);
            read = new ReadClient(readClient);
        }

        // GET: api/Client
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Client>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            return Ok(new ApiResponse<IEnumerable<Client>>(read.All));
        }

        // POST api/<ClientController>
        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(Client value)
        {
            if (value.Email == null)
            {
                return BadRequest();
            }
            try
            {
                create.Create(value);
                return Ok();
            }
            catch (ClientAlreadyExistsException)
            {
                return NotFound();
            }
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{email}")]
        [Route(nameof(Delete))]
        public IActionResult Delete(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            try
            {
                delete.Delete(email);
                return Ok();
            }
            catch (NotFoundClientException)
            {
                return NotFound();
            }
        }
    }
}

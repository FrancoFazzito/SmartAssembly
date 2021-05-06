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
    [Produces("application/json")]
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
            try
            {
                return Ok(new ApiResponse<IEnumerable<Client>>(read.All));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/client/create
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
                return NoContent();
            }
            catch (ClientAlreadyExistsException)
            {
                return BadRequest();
            }
        }

        // DELETE api/client/delete?email="juan"
        [HttpDelete]
        [Route(nameof(Delete))]
        public IActionResult Delete([FromBody] string email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            try
            {
                delete.Delete(email);
                return NoContent();
            }
            catch (NotFoundClientException)
            {
                return NotFound();
            }
        }
    }
}
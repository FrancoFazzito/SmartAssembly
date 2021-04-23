using Application.Clients.Commands.Create;
using Application.Clients.Commands.Delete;
using Application.Common.Exceptions;
using Application.Repositories.Interfaces;
using Domain.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace WebApi.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly CreateClient create;
        private readonly DeleteClient delete;
        private readonly ReadClient read;

        public ClientController(Startup.DeleteByEmailResolver deleteAccesor, IClientReadOnlyRepository readClient, ICreate<Client> createClient, IUpdate<Client> updateClient)
        {
            delete = new DeleteClient(deleteAccesor(DeletesEmail.Client), readClient);
            create = new CreateClient(createClient, readClient);
            read = new ReadClient(readClient);
        }

        // GET: api/Client
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new ApiResponse<IEnumerable<Client>>(read.All));
        }

        // POST api/<ClientController>
        [HttpPost]
        public IActionResult Post(Client value)
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
        [HttpDelete("{id}")]
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

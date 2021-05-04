using Application.Common.Exceptions;
using Application.Orders.Commands.RegisterError;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers.Errors.ErrorOrderBuild
{
    [Route("api/error/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BuildController : ControllerBase
    {
        private readonly IRegisterBuildError registerError;

        public BuildController(IRegisterBuildError registerError)
        {
            this.registerError = registerError;
        }

        // POST api/error/build/register
        [HttpPost]
        [Route(nameof(Register))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IErrorResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Register(ErrorBuildParam errorParam)
        {
            if (!errorParam.IdComputer.HasValue)
            {
                return BadRequest();
            }
            if (!errorParam.IdComponent.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var result = registerError.Register(errorParam.IdComputer, errorParam.IdComponent, errorParam.Commentary, errorParam.DeleteComponent);
                return Ok(new ApiResponse<IErrorResult>(result));
            }
            catch (NotFoundComponentException)
            {
                return NotFound();
            }
            catch (NotFoundComputerException)
            {
                return NotFound();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Orders.Commands.RegisterError;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.Error.ErrorOrderBuild
{
    [Route("api/error/[controller]")]
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

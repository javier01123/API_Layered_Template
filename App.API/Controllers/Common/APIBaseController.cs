using App.API.Extensions;
using App.Application.Services._Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics.Eventing.Reader;

namespace App.API.Controllers.Common
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class APIBaseController : ControllerBase
    {
        
        protected IActionResult ServiceResultToResponse(ServiceResult serviceResult)
        {
            if (serviceResult.IsSuccesful)
                return Ok();            
            return ValidationProblem(serviceResult.ErrorsToModelState());
        }

        protected IActionResult ServiceResultToResponse<T>(ServiceResult<T> serviceResult)
        {
            if (serviceResult.IsSuccesful)
                return Ok(serviceResult.ReturnValue);
            return ValidationProblem(serviceResult.ErrorsToModelState());
        }

    }
}

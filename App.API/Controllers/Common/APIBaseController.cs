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
        //TODO:create generic method to format service response

        protected IActionResult ServiceResultToResponse(ServiceResult serviceResult)
        {
            if (serviceResult.IsSuccesful)
                return Ok();

            //TODO: simplify create extension
            var ms = new ModelStateDictionary();
            foreach (var e in serviceResult.Errors)
                if (string.IsNullOrWhiteSpace(e.Property))
                    ms.AddModelError(string.Empty, e.Message);
                else
                    ms.AddModelError(e.Property, e.Message);

            return ValidationProblem(ms);
        }

    }
}

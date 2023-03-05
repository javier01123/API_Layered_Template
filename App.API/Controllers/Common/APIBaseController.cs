using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers.Common
{

    [ApiController]
    [Route("api/[controller]")]
    internal abstract class APIBaseController : ControllerBase
    {
    }
}

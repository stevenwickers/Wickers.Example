using Microsoft.AspNetCore.Mvc;
using System;

namespace Wickers.DOTNET.Example.API.Controllers
{
    [Route("Wickers")]
    public class BaseController : Controller
    {
        
        protected IActionResult PayloadError()
        {
            return StatusCode(400, $"Error with Payload.");
        }

        protected IActionResult SqlError(string ErrorMessage)
        {
            return StatusCode(400, $"SQL Error: {ErrorMessage}");
        }

        protected IActionResult InteralServer(Exception Exp)
        {
            return StatusCode(500, Exp.Message);
        }
    }
}


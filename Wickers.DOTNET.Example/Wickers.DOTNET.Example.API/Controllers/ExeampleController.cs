using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Wickers.DOTNET.Example.Business.Exceptions;
using Wickers.DOTNET.Example.Business.Services.Interfaces;

namespace Wickers.DOTNET.Example.API.Controllers
{
    public class ExeampleController : BaseController
    {
        private IExampleServices _services;
        private ILogger _logger;
        public ExeampleController(IExampleServices ExpServices)
        {
            _services = ExpServices;
            //_logger = Logger;
        }

        [HttpGet]
        [Route("GetData")]
        public async Task<IActionResult> GetData()
        {
            try
            {
                //_logger.LogInformation($"Get Data: {System.DateTime.Now.ToString("MM/dd/yyyy h:mm tt")}");

                var results = await _services.Select();
                
                if (!results.Any())
                {
                    return NoContent();
                }

                return Ok(results);

            }
            catch (BusinessExceptions be)
            {
                return BadRequest(be.Message);
            }
            catch (System.Exception e)
            {
                //Email and Return Proper Error
                return base.InteralServer(e);
            }

        }

        [HttpGet]
        [Route("GetDataByKey")]
        public async Task<IActionResult> GetDataByID(string Key)
        {
            try
            {
                var results = await _services.SelectByKey(Key);

                if (results == null)
                {
                    return NoContent();
                }
                
                return Ok(results);

            }
            catch (BusinessExceptions be)
            {
                return BadRequest(be.Message);
            }
            catch (System.Exception e)
            {
                //Email and Return Proper Error
                return base.InteralServer(e);
            }

        }
    }
}
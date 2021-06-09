using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STP.Business.Interfaces;
using STP.Interface.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STP.Interface.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("[controller]")]
    public class CalculaJurosController : BaseController
    {
        private readonly ILogger<CalculaJurosController> _logger;

        public CalculaJurosController(INotificador notificador,
                                      ILogger<CalculaJurosController> logger)
            : base(notificador)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return CustomResponse("ok");
        }
    }
}

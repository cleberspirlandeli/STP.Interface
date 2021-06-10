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
        private readonly ICalcularJurosApplicationService _calcularJurosAppService;

        public CalculaJurosController(
                INotificador notificador,
                ICalcularJurosApplicationService calcularJurosAppService,
                ILogger<CalculaJurosController> logger)
            : base(notificador)
        {
            _logger = logger;
            _calcularJurosAppService = calcularJurosAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _calcularJurosAppService.CalcularJuros();
            return CustomResponse(result);
        }
    }
}

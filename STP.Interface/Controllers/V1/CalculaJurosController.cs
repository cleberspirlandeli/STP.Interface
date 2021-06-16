using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using STP.Business.Interfaces;
using STP.Interface.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            Int32.TryParse(HttpContext.Request?.Query["valorInicial"].ToString(), out int valorInicial);
            Int32.TryParse(HttpContext.Request?.Query["meses"].ToString(), out int meses);


            var result = await _calcularJurosAppService.CalcularJuros(valorInicial, meses, cancellationToken);
            _logger.LogInformation($"Nova consulta de crédito realizada ${DateTime.Now}");
            return CustomResponse(result);
        }
    }
}

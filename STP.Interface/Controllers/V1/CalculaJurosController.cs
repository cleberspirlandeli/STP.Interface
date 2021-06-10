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


        /* 
            public class Dto
            {
                [FromRoute(Name = "")]
                public Test Test { get; set; }

                [FromBody]
                public Sample Sample { get; set; }
                public ApiVersion ApiVersion { get; set; }
            }

            [HttpGet("col1/{col1}/col2/{col2}/col3/{col3}")]
            public async Task<IActionResult> Get([FromQuery]Dto dto)
            {           
                return Ok(dto);
            }
         */
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            int? valorInicial = Int32.Parse(HttpContext.Request?.Query["valorInicial"]);
            int? meses = Int32.Parse(HttpContext.Request?.Query["meses"]);
            dynamic obj = 0;

            var result = await _calcularJurosAppService.CalcularJuros(obj, cancellationToken);
            return CustomResponse(result);
        }
    }
}

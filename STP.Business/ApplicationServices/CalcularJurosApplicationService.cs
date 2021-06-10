using Newtonsoft.Json;
using STP.Business.Interfaces;
using STP.Business.Interfaces.Services;
using STP.Business.Models;
using STP.Common.Helpers.RestClientHelper.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace STP.Business.ApplicationServices
{
    public class CalcularJurosApplicationService : BaseApplicationService, ICalcularJurosApplicationService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalcularJurosApplicationService(
                INotificador notificador,
                ITaxaJurosService taxaJurosService
            ) : base(notificador) 
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<CalcularJuros> CalcularJuros(dynamic obj, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            //int? valorInicial = (int?)obj?.valorInicial;
            //int? meses = (int?)obj?.meses;

            //var taxaJuros = await _taxaJurosService.GetTaxaJuros();

            var calcularJuros = new CalcularJuros(100, 5, 0.01);
            calcularJuros.CalcularTotalizador();

            return calcularJuros;
        }
    }
}

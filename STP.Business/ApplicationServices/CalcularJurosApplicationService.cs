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

        public async Task<CalcularJuros> CalcularJuros(int? valorInicial, int? meses, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!ValidarRegras(valorInicial, meses)) return new CalcularJuros();

            var taxaJuros = await _taxaJurosService.GetTaxaJuros();

            var calcularJuros = new CalcularJuros((int)valorInicial, (int)meses, taxaJuros.Taxa);
            calcularJuros.CalcularTotalizador();

            return calcularJuros;
        }

        private bool ValidarRegras(int? valorInicial, int? meses)
        {
            var result = true;
            if (!valorInicial.HasValue || valorInicial <= 0)
            {
                Notificar("Valor Inicial não corresponde ao formato desejado."); // _commonMessage
                result = false;
            }
            if (!meses.HasValue || meses <= 0)
            {
                Notificar("Mês não corresponde ao formato desejado."); // _commonMessage
                result = false;
            }

            return result;
        }
    }
}

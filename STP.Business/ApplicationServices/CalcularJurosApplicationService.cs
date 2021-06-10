using Newtonsoft.Json;
using STP.Business.Interfaces;
using STP.Business.Models;
using STP.Common.Helpers.RestClientHelper.Interfaces;
using System.Threading.Tasks;

namespace STP.Business.ApplicationServices
{
    public class CalcularJurosApplicationService : BaseApplicationService, ICalcularJurosApplicationService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly string _requestUri = "https://viacep.com.br/ws/14406012/json/";

        public CalcularJurosApplicationService(
                INotificador notificador,
                IRestClientHelper restClientHelper
            ) : base(notificador) 
        {
            _restClientHelper = restClientHelper;
        }

        public async Task<CalcularJuros> CalcularJuros()
        {
            
            var result = await _restClientHelper.GetAsync(_requestUri);
            var TaxaJuros = JsonConvert.DeserializeObject<TaxaJuros>(result);

            return new CalcularJuros
            {
                Taxa = 0.50
            };
        }
    }
}

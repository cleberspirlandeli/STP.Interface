using Newtonsoft.Json;
using STP.Business.Interfaces.Services;
using STP.Business.Models;
using STP.Common.Helpers.RestClientHelper.Interfaces;
using System.Threading.Tasks;

namespace STP.Business.ApplicationServices.Services
{
    public class TaxaJurosService: ITaxaJurosService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly string _requestUri = "https://localhost:5001/api/taxajuros";

        public TaxaJurosService(IRestClientHelper restClientHelper)
        {
            _restClientHelper = restClientHelper;
        }

        public async Task<TaxaJuros> GetTaxaJuros()
        {
            var result = await _restClientHelper.GetAsync(_requestUri);
            var convertTaxaJuros = JsonConvert.DeserializeObject<ResultadoTaxaJuros>(result);

            var taxaJuros = convertTaxaJuros.Data;

            return taxaJuros;
        }
    }
}

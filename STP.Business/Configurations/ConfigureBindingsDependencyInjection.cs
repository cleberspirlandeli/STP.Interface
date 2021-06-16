using Microsoft.Extensions.DependencyInjection;
using STP.Business.ApplicationServices;
using STP.Business.ApplicationServices.Services;
using STP.Business.Interfaces;
using STP.Business.Interfaces.Services;
using STP.Business.Notificacoes;
using STP.Common.Helpers.RestClientHelper;
using STP.Common.Helpers.RestClientHelper.Interfaces;

namespace STP.Business.Configurations
{
    public static class ConfigureBindingsDependencyInjection
    {
        public static void RegisterBindings(this IServiceCollection services)
        {
            #region Others
            services.AddScoped<INotificador, Notificador>();
            services.AddHttpClient<IRestClientHelper, RestClientHelper>();
            services.AddTransient<IRestClientHelper, RestClientHelper>();
            #endregion

            #region Application Services
            services.AddScoped<ICalcularJurosApplicationService, CalcularJurosApplicationService>();
            #endregion

            #region Services
            services.AddScoped<ITaxaJurosService, TaxaJurosService>();
            #endregion
        }
    }
}

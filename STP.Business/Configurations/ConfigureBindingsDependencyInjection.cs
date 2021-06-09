using Microsoft.Extensions.DependencyInjection;
using STP.Business.ApplicationServices;
using STP.Business.Interfaces;
using STP.Business.Notificacoes;

namespace STP.Business.Configurations
{
    public static class ConfigureBindingsDependencyInjection
    {
        public static void RegisterBindings(this IServiceCollection services)
        {
            #region Others
            services.AddScoped<INotificador, Notificador>();
            #endregion

            #region Application Services
            services.AddScoped<ICalcularJurosApplicationService, CalcularJurosApplicationService>();
            #endregion
        }
    }
}

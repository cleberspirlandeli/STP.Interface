using Microsoft.Extensions.DependencyInjection;
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

        }
    }
}

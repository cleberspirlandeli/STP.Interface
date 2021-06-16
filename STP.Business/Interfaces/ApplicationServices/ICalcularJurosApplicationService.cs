using STP.Business.Models;
using System.Threading;
using System.Threading.Tasks;

namespace STP.Business.Interfaces
{
    public interface ICalcularJurosApplicationService
    {
        Task<CalcularJuros> CalcularJuros(int? valorInicial, int? meses, CancellationToken cancellationToken);
    }
}

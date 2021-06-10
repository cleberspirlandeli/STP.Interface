using STP.Business.Models;
using System.Threading;
using System.Threading.Tasks;

namespace STP.Business.Interfaces
{
    public interface ICalcularJurosApplicationService
    {
        Task<CalcularJuros> CalcularJuros(dynamic obj, CancellationToken cancellationToken);
    }
}

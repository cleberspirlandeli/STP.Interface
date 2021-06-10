using STP.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP.Business.Interfaces.Services
{
    public interface ITaxaJurosService
    {
        Task<TaxaJuros> GetTaxaJuros();
    }
}

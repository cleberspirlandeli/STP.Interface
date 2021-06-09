using STP.Business.Interfaces;
using STP.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP.Business.ApplicationServices
{
    public class CalcularJurosApplicationService : BaseApplicationService, ICalcularJurosApplicationService
    {
        //private readonly IFornecedorRepository _fornecedorRepository;

        public CalcularJurosApplicationService(INotificador notificador) : base(notificador) { }

        public async Task<CalcularJuros> CalcularJuros()
        {


            return new CalcularJuros
            {
                Taxa = 0.50
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP.Business.Models
{
    public class TaxaJuros
    {
        public double Taxa { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Tipo { get; set; }
    }
}

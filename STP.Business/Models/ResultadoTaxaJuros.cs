using System;
using System.Collections.Generic;

namespace STP.Business.Models
{
    public class ResultadoTaxaJuros
    {
        public bool Success { get; set; }
        public TaxaJuros Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

using System;

namespace STP.Business.Models
{
    public class CalcularJuros
    {
        public double ValorTotal { get; set; }
        public double Taxa { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Tipo { get; set; }
    }
}

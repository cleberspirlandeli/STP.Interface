using System;
using System.Globalization;

namespace STP.Business.Models
{
    public class CalcularJuros
    {
        public string ValorTotal { get; private set; }
        public double ValorInicial { get; private set; }
        public double TaxaJuros { get; private set; }
        public int Tempo { get; private set; }
        public double Montante { get; private set; }
        public double Juros { get; private set; }
        public DateTime DataCadastro { get; set; }
        public int Tipo { get; set; }
        public string Descricao { get; set; }

        public CalcularJuros(double valorInicial, int tempo, double juros)
        {
            this.ValorInicial = valorInicial;
            this.Tempo = tempo;
            this.TaxaJuros = juros;
            this.DataCadastro = DateTime.Now;
        }

        public void CalcularTotalizador()
        {
            CalcularValorMontante();
            CalcularValorJuros();
            CalcularValorTotal();
        }

        private void CalcularValorMontante() =>
            this.Montante = this.ValorInicial * Math.Pow((1 + this.TaxaJuros), this.Tempo);

        private void CalcularValorJuros() =>
            this.Juros = this.Montante - this.ValorInicial;

        private void CalcularValorTotal()
        {
            decimal montanteBr = Convert.ToDecimal(this.Montante, new CultureInfo("pt-BR"));
            this.ValorTotal = montanteBr.ToString("N2", new CultureInfo("pt-BR"));
        }
    }
}

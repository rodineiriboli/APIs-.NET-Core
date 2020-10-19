using System;
using System.ComponentModel.DataAnnotations;

namespace Calculo.Dominio
{
    public class Calculo
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um valor inicial.")]
        public decimal ValorInicial { get; set; }


        public double Juros { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o mês.")]
        [Range(1, 12, ErrorMessage = "Valores válidos são 1 a 12.")]
        public int Tempo { get; set; }

        public decimal CalculaJuros(decimal valorInicial, double juros, int tempo)
        {
            var resultadoOp = Math.Pow((1 + juros), Convert.ToDouble(tempo));
            var valorFinal = decimal.Multiply(valorInicial, (Convert.ToDecimal(resultadoOp)));
            return Math.Truncate(100 * valorFinal) / 100;
        }

    }
}

namespace Calculo.Servicos
{
    public class CalculoServicos : ICalculoServicos
    {
        public decimal CalculaJuros(decimal valorInicial, double juros, int tempo)
        {
            return new Calculo.Dominio.Calculo().CalculaJuros(valorInicial, juros, tempo);
        }
    }
}

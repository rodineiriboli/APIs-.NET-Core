namespace BaseJuros.Dominio
{
    public class Juros
    {
        public double ValorJuros { get; set; }

        /// <summary>
        /// Retorna taxa de juros fixada.
        /// </summary>
        /// <returns></returns>
        public double RetornaBaseJuros()
        {
            ValorJuros = 0.01;
            return ValorJuros;
        }
    }
}

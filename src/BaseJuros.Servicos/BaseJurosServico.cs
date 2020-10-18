using BaseJuros.Dominio;

namespace BaseJuros.Servicos
{
    public class BaseJurosServico : IBaseJurosServico
    {
        public double RetornaBaseJuros()
        {
            return new Juros().RetornaBaseJuros();
        }
    }
}
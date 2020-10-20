using BaseJuros.Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Calculo.Servicos
{
    public class CalculoServicos : ICalculoServicos
    {
        HttpClient httpClient = new HttpClient();
        public decimal CalculaJuros(decimal valorInicial, double juros, int tempo)
        {
            return new Dominio.Calculo().CalculaJuros(valorInicial, juros, tempo);
        }

        public async Task<List<Juros>> ConsultaApiBaseJuros()
        {
            HttpResponseMessage resposta;
            try
            {
                httpClient.BaseAddress = new Uri("http://localhost:5005");
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                resposta = await httpClient.GetAsync("/taxaJuros");
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (resposta.IsSuccessStatusCode)
            {
                var valorBaseJuro = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Juros>>(valorBaseJuro);
            }
            return new List<Juros>();
        }

        public double ObtemJurosApiBaseJuros()
        {
            double j = 0;
            var consulta = ConsultaApiBaseJuros();
            consulta.ContinueWith(task =>
            {
                List<Juros> juros = task.Result;
                foreach (var item in juros)
                {
                    j = item.ValorJuros;
                    break;
                }
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );

            return j;
        }
    }
}

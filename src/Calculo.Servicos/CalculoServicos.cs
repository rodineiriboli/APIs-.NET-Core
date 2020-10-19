using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Calculo.Servicos
{
    public class CalculoServicos : ICalculoServicos
    {
        HttpClient httpClient = new HttpClient();
        public CalculoServicos()
        {
            httpClient.BaseAddress = new Uri("http:localhost:32779");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public decimal CalculaJuros(decimal valorInicial, double juros, int tempo)
        {
            return new Dominio.Calculo().CalculaJuros(valorInicial, juros, tempo);
        }

        public async Task<List<Dominio.Calculo>> ConsultaApiBaseJuros()
        {
            var resposta = await httpClient.GetAsync("/taxaJuros");
            if (resposta.IsSuccessStatusCode)
            {
                var valorBaseJuro = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Dominio.Calculo>>(valorBaseJuro);
            }
            return new List<Dominio.Calculo>();
        }

        public double ObtemJurosApiBaseJuros()
        {
            double j = 0;
            var consulta = ConsultaApiBaseJuros();
            consulta.ContinueWith(task =>
            {
                var juros = task.Result;
                foreach (var item in juros)
                {
                    j = item.Juros;
                    break;
                }
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );

            return j;
        }
    }
}

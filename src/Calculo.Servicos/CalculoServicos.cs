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
        public decimal CalculaJuros(decimal valorInicial, double juros, int tempo)
        {
            return new Dominio.Calculo().CalculaJuros(valorInicial, juros, tempo);
        }

        public async Task<List<Dominio.Calculo>> ConsultaApiBaseJuros()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5005");
            //httpClient.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

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
            double j = 5;
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

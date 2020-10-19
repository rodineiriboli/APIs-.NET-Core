using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculo.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCalculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CalculoController : ControllerBase
    {
        /// <summary>
        /// Retorna o cálculo de juros.
        /// </summary>
        /// <param name="calculoServicos"></param>
        /// <param name="valorInicial"></param>
        /// <param name="tempo"></param>
        /// <returns></returns>
        /// <response code="200">Valor do juros calculado obtido com sucesso.</response>
        /// <response code="404">Pagina não encontrada, verique os tipo de dados dos parâmetros.</response>
        [ProducesResponseType(typeof(List<Calculo.Dominio.Calculo>), 200)]
        [HttpGet]
        [Route("/calculajuros")]
        public IActionResult CalculaJuros([FromServices] ICalculoServicos calculoServicos, decimal valorInicial, int tempo)
        {
            var juros = calculoServicos.ObtemJurosApiBaseJuros();
            return Ok(new {calculoJuros = calculoServicos.CalculaJuros(valorInicial, juros, tempo) });
        }

        /// <summary>
        /// Retorna endereço Git onde se encontra a aplicação.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/showmethecode")]
        public IActionResult ShowmeTheCode()
        {
            return Ok(new { showmethecode = "https://github.com/rodineiriboli/APIs-.NET-Core" });
        }
    }
}

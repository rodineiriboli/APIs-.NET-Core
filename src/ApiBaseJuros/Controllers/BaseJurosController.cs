using BaseJuros.Dominio;
using BaseJuros.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace ApiBaseJuros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseJurosController : ControllerBase
    {
        /// <summary>
        /// Retorna o juros fixado.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Valor do juros obtido com sucesso.</response>
        [ProducesResponseType(typeof(List<Juros>), 200)]
        [HttpGet]
        [Route("/taxaJuros")]
        public IActionResult ObterTaxaJuros([FromServices] IBaseJurosServico baseJuros)
        {
            try
            {
                return Ok(new { valorJuros = baseJuros.RetornaBaseJuros() });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}




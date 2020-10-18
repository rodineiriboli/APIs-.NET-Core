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
        public IActionResult CalculaJuros([FromServices] ICalculoServicos calculoServicos)
        {
            return Ok();
        }
    }
}

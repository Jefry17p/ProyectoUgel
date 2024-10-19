using AppP1.Class;
using AppP1.ServicesApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppP1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquiposController:ControllerBase
    {
        private readonly ApiEquipos _apiEquipos;
        public EquiposController(ApiEquipos apiEquipos)
        {
            _apiEquipos = apiEquipos;
        }

        [HttpGet("/ObtenerEquipos")]
        public async Task<ActionResult<List<EquiposCLS>>> ObtenerEquipos()
        {
            var equipos = await _apiEquipos.ObtenerEquiposAsync();
            return Ok(equipos);

        }
    }
}

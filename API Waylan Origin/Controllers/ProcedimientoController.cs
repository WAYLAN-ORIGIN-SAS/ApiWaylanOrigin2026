using API_Waylan_Origin.DTOs.Productores;
using API_Waylan_Origin.Interfaces.Productores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Waylan_Origin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimientoController : ControllerBase
    {
        private readonly IProcedimientoService _IProcedimientoService;

        public ProcedimientoController(IProcedimientoService service)
        {
            _IProcedimientoService = service;
        }


        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<ProcedimientoReadDto>> CrearProcedimiento([FromForm] ProcedimientoCreateDto procedimiento)
        {
            var nuevoProcedimiento = await _IProcedimientoService.CrearProcedimiento(procedimiento);
            return Ok(nuevoProcedimiento);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcedimientoReadDto>>> ListrarProcedimientos()
        {
            var procedimientos = await _IProcedimientoService.ListarProcedimientos();
            return Ok(procedimientos);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<ProcedimientoReadDto>> ActualizarProcedimiento(int id, [FromForm] ProcedimientoUpdateDto procedimiento)
        {
            var procedimientoActualizado = await _IProcedimientoService.ActualizarProcedimiento(id, procedimiento);
            return Ok(procedimientoActualizado);
        }

    }
}

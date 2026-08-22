using API_Waylan_Origin.DTOs.CitaSemanal;
using API_Waylan_Origin.Interfaces.CitasSemanales;
using API_Waylan_Origin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace API_Waylan_Origin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaSemanalController : ControllerBase
    {
        private readonly ICitasService _citasService;

        public CitaSemanalController(ICitasService citaService)
        {
            _citasService = citaService;
        }

        [HttpGet]
        public async Task<ActionResult<CitaSemanal>> GetCitaSemanal()
        {
            var cita = await _citasService.GetCita();
            return Ok(cita);
        }

        [HttpPut]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<bool>> UpdateCitaSemanal(CitaSemanalUpdateDto dto)
        {
            var resultado = await _citasService.UpdateCita(dto);
            return Ok(resultado);
        }
       
    }
}

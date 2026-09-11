using API_Waylan_Origin.DTOs.Productores;
using API_Waylan_Origin.Interfaces.Productores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Waylan_Origin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrganizacionController : ControllerBase
    {
       private readonly IOrganizacionesService _organizacionesService;

        public OrganizacionController(IOrganizacionesService organizacionesService)
        {
            _organizacionesService = organizacionesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizacionReadDto>>> ListarOrganizaciones()
        {
            var organizaciones = await _organizacionesService.ListrarOrganizaciones();
            return Ok(organizaciones);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<OrganizacionReadDto>> ActualizarOrganizacion(int id, [FromForm] OrganizacionUpdateDto updateDto)
        {
            var organizacionActualizada = await _organizacionesService.ActualizarOrganizacion(id,updateDto);
            return Ok(organizacionActualizada);
        }
    }
}

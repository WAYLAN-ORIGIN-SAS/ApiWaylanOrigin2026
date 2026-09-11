using API_Waylan_Origin.DTOs.Productores;
using API_Waylan_Origin.Interfaces.Productores;
using API_Waylan_Origin.Services.Productores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Waylan_Origin.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductorController : ControllerBase
    {
        private readonly IProductoresServices _productoresServices;

        public ProductorController(IProductoresServices productoresServices)
        {
            _productoresServices = productoresServices;
        }


        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<ProductorReadDto>> CrearProductor([FromForm] ProductorCreateDto productorCreateDto)
        {
            var NuevoProductor = await _productoresServices.CrearProductor(productorCreateDto);
            return Ok(NuevoProductor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductorReadDto>>> ListarProductores()
        {
            var productores = await _productoresServices.ListarProductores();
            return Ok(productores);
        }


        [HttpGet("Destacados")]
        public async Task<ActionResult<IEnumerable<ProductorReadDto>>> ListarProductoresDestacados()
        {
            var productores = await _productoresServices.ListarProductoresDestacados();
            return Ok(productores);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<ProductorReadDto>> ActualizarProductor(int id, [FromForm] ProductorUpdateDto updateDto)
        {
            var organizacionActualizada = await _productoresServices.ActualizarProductor(id, updateDto);
            return Ok(organizacionActualizada);
        }
    }
}

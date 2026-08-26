using API_Waylan_Origin.Data;
using API_Waylan_Origin.DTOs.Wompi;
using API_Waylan_Origin.Interfaces.Wompi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Waylan_Origin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPagosService _pagosService;

        public PagosController(AppDbContext context, IPagosService pagosService)
        {
            _context = context;
            _pagosService = pagosService;
        }

        /*[HttpPost("webhook")]
        public async Task<IActionResult> RecibirNotificacionWompi( WompiWebHookDto notificacion)
        {
           
            await _pagosService.ProcesarNotificacionAsync(notificacion);

            // Siempre respondemos 200 OK rápido para que Wompi sepa que el servidor está vivo
            return Ok();
        }*/

        [HttpPost("webhook")]
        [AllowAnonymous]
        public async Task<IActionResult> RecibirNotificacionWompi()
        {
            using var reader = new StreamReader(Request.Body);
            string rawJson = await reader.ReadToEndAsync();

            // 👇 Nuevo: log del JSON crudo, tal cual lo mandó Wompi
            Console.WriteLine($"RAW WOMPI JSON: {rawJson}");

            var opciones = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                var notificacion = System.Text.Json.JsonSerializer.Deserialize<WompiWebHookDto>(rawJson, opciones);

                if (notificacion != null)
                {
                    await _pagosService.ProcesarNotificacionAsync(notificacion);
                }
                else
                {
                    Console.WriteLine("ADVERTENCIA: la deserialización devolvió null.");
                }
            }
            catch (Exception ex)
            {
                // 👇 Nuevo: si algo truena deserializando o procesando, queda registrado
                Console.WriteLine($"ERROR procesando webhook Wompi: {ex.Message}");
            }

            // Siempre respondemos 2xx para que Wompi no reintente innecesariamente
            return Ok();
        }
    }
}

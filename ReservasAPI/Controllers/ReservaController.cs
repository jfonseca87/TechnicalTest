using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservasBusiness.Interfaces;
using ReservasDTOs.Dtos;
using System.Threading.Tasks;

namespace ReservasAPI.Controllers
{
    [ApiController]
    [Route("api/reservas")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaBusiness _reservaBusiness;
        private readonly ILogger<ReservaController> _logger;

        public ReservaController(IReservaBusiness reservaBusiness, ILogger<ReservaController> logger)
        {
            _reservaBusiness = reservaBusiness;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerReservasActivasPorHotel(ReservaDto reservaInfo)
        {
            try
            {
                if (reservaInfo is null)
                {
                    return BadRequest("El párametro no puede ser nulo");
                }

                return Ok(await _reservaBusiness.ObtenerReservasActivasPorHotel(reservaInfo));
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Ocurrio un error interno en el api");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearReserva(ReservaDto reserva)
        {
            try
            {
                if (reserva is null)
                {
                    return BadRequest("El párametro no puede ser nulo");
                }

                return Created(string.Empty, await _reservaBusiness.CrearReserva(reserva));
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Ocurrio un error interno en el api");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> CancelarReserva(int reservaId)
        {
            try
            {
                return Ok(await _reservaBusiness.CancelarReserva(reservaId));
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Ocurrio un error interno en el api");
            }
        }
    }
}

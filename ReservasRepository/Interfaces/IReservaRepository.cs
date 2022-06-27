using ReservasDTOs.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservasRepository.Interfaces
{
    public interface IReservaRepository
    {
        Task<ReservaDto> ObtenerReservaPorId(int reservaId);
        Task<ReservaDto> ObtenerReservaPorFechaInicialEstado(ReservaDto reserva);
        Task<IEnumerable<ReservaDto>> ObtenerReservasActivasPorHotel(ReservaDto reservaInfo);
        Task<int> ReservasActivasPorHotel(int hotelId);
        Task<bool> CancelarReserva(int reservaId);
        Task<ReservaDto> CrearReserva(ReservaDto reserva);
    }
}
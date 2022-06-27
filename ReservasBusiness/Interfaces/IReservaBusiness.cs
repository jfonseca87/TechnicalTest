using ReservasDTOs.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservasBusiness.Interfaces
{
    public interface IReservaBusiness
    {
        Task<bool> CancelarReserva(int reservaId);
        Task<ReservaDto> CrearReserva(ReservaDto reserva);
        Task<IEnumerable<ReservaDto>> ObtenerReservasActivasPorHotel(ReservaDto reservaInfo);
    }
}
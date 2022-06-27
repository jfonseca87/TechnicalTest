using ReservasDTOs.Dtos;
using System.Threading.Tasks;

namespace ReservasRepository.Interfaces
{
    public interface IHotelRepository
    {
        Task<HotelDto> ObtenerHotelPorId(int hotelId);
    }
}

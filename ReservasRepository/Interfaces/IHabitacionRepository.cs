using ReservasDTOs.Dtos;
using System.Threading.Tasks;

namespace ReservasRepository.Interfaces
{
    public interface IHabitacionRepository
    {
        Task<HabitacionDto> ObtenerHabitacionPorId(int habitacionId);
    }
}

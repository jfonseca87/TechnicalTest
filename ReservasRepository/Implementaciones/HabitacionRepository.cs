using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservasDTOs.Dtos;
using ReservasRepository.Interfaces;
using System.Threading.Tasks;

namespace ReservasRepository.Implementaciones
{
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly ReservashotelContext _db;
        private readonly IMapper _mapper;

        public HabitacionRepository(ReservashotelContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<HabitacionDto> ObtenerHabitacionPorId(int habitacionId)
        {
            return _mapper.Map<HabitacionDto>(await _db.Habitacion.FirstOrDefaultAsync(x => x.Idhabitacion == habitacionId));
        }
    }
}

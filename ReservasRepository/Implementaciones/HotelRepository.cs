using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservasDTOs.Dtos;
using ReservasRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasRepository.Implementaciones
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ReservashotelContext _db;
        private readonly IMapper _mapper;

        public HotelRepository(ReservashotelContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<HotelDto> ObtenerHotelPorId(int hotelId)
        {
            return _mapper.Map<HotelDto>(await _db.Hotel.FirstOrDefaultAsync(x => x.Idhotel == hotelId));
        }
    }
}

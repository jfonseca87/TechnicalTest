using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservasDTOs.Dtos;
using ReservasRepository.Interfaces;
using ReservasRepository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservasRepository.Implementaciones
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ReservashotelContext _db;
        private readonly IMapper _mapper;

        public ReservaRepository(ReservashotelContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ReservaDto> ObtenerReservaPorId(int reservaId)
        {
            var reserva = await _db.Reserva.AsNoTracking().FirstOrDefaultAsync(x => x.Idreserva == reservaId);
            return _mapper.Map<ReservaDto>(reserva);
        }

        public async Task<IEnumerable<ReservaDto>> ObtenerReservasActivasPorHotel(ReservaDto reservaInfo)
        {
            return await (_db.Reserva.Include(x => x.IdusuarioNavigation).Include(x => x.IdhotelNavigation)
                            .Select(x => new ReservaDto
                            {
                                IdReserva = x.Idreserva,
                                IdUsuario = x.Idusuario.Value,
                                EmailUsuario = x.IdusuarioNavigation.Mail,
                                IdHotel = x.Idhotel.Value,
                                NombreHotel = x.IdhotelNavigation.Nombre,
                                IdHabitacion = x.Idhabitacion.Value,
                                FechaEntrada = x.Fechaentrada.Value,
                                FechaSalida = x.Fechasalida.Value,
                                FechaReserva = x.Fechareserva.Value,
                                Estado = x.Estado.Value,
                            })
                            .Where(x => x.IdHotel == reservaInfo.IdHotel &&
                                        x.Estado.Value &&
                                        (x.FechaEntrada >= reservaInfo.FechaEntrada && x.FechaEntrada <= reservaInfo.FechaSalida)))
                            .ToListAsync();

        }

        public async Task<ReservaDto> ObtenerReservaPorFechaInicialEstado(ReservaDto reserva)
        {
            var reservaExistente = await _db.Reserva.AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.Idhabitacion == reserva.IdHabitacion &&
                    x.Fechaentrada == reserva.FechaEntrada &&
                    reserva.Estado.Value);
            return _mapper.Map<ReservaDto>(reservaExistente);
        }

        public async Task<int> ReservasActivasPorHotel(int hotelId)
        {
            return (await _db.Reserva.Where(x => x.Idhotel == hotelId && x.Estado.Value).ToListAsync()).Count;
        }

        public async Task<ReservaDto> CrearReserva(ReservaDto reserva)
        {
            var nuevaReserva = _mapper.Map<Reserva>(reserva);
            _db.Reserva.Add(nuevaReserva);
            await _db.SaveChangesAsync();
            reserva.IdReserva = nuevaReserva.Idreserva;

            return reserva;
        }

        public async Task<bool> CancelarReserva(int reservaId)
        {
            var reservaEliminar = await _db.Reserva.FirstOrDefaultAsync(x => x.Idreserva == reservaId);
            reservaEliminar.Estado = false;

            return await _db.SaveChangesAsync() > 0;
        }
    }
}

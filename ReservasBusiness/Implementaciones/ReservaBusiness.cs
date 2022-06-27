using ReservasBusiness.Interfaces;
using ReservasDTOs.Dtos;
using ReservasRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservasBusiness.Implementaciones
{
    public class ReservaBusiness : IReservaBusiness
    {
        private readonly IHabitacionRepository _habitacionRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IReservaRepository _reservaRepository;

        public ReservaBusiness(
            IHabitacionRepository habitacionRepository,
            IHotelRepository hotelRepository,
            IUsuarioRepository usuarioRepository,
            IReservaRepository reservaRepository)
        {
            _habitacionRepository = habitacionRepository;
            _hotelRepository = hotelRepository;
            _usuarioRepository = usuarioRepository;
            _reservaRepository = reservaRepository;
        }

        public async Task<IEnumerable<ReservaDto>> ObtenerReservasActivasPorHotel(ReservaDto reservaInfo)
        {
            return await _reservaRepository.ObtenerReservasActivasPorHotel(reservaInfo);
        }

        public async Task<ReservaDto> CrearReserva(ReservaDto reserva)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioPorId(reserva.IdUsuario);
            if (usuario is null)
            {
                throw new Exception("El usuario no existe");
            }

            var hotel = await _hotelRepository.ObtenerHotelPorId(reserva.IdHotel);
            if (hotel is null)
            {
                throw new Exception("El hotel no existe");
            }

            var habitacion = await _habitacionRepository.ObtenerHabitacionPorId(reserva.IdHabitacion);
            if (habitacion is null)
            {
                throw new Exception("La habitación no existe");
            }

            var reservaExistente = await _reservaRepository.ObtenerReservaPorFechaInicialEstado(reserva);
            if (reservaExistente != null)
            {
                throw new Exception("Ya existe una reserva con los datos suministrados");
            }

            int reservasActivas = await _reservaRepository.ReservasActivasPorHotel(reserva.IdHotel);
            if (reservasActivas >= hotel.NumeroHabitaciones)
            {
                throw new Exception("El hotel no tiene habitaciones disponibles");
            }

            return await _reservaRepository.CrearReserva(reserva);
        }

        public async Task<bool> CancelarReserva(int reservaId)
        {
            var reservaExistente = _reservaRepository.ObtenerReservaPorId(reservaId);
            if (reservaExistente is null)
            {
                throw new Exception("La reserva no existe");
            }

            return await _reservaRepository.CancelarReserva(reservaId);
        }
    }
}

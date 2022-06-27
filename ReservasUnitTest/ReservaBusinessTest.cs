using Moq;
using ReservasBusiness.Implementaciones;
using ReservasDTOs.Dtos;
using ReservasRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ReservasUnitTest
{
    public class ReservaBusinessTest
    {
        private readonly Mock<IUsuarioRepository> _usuariorepositoryMock;
        private readonly Mock<IHotelRepository> _hotelRepositoryMock;
        private readonly Mock<IHabitacionRepository> _habitacionRepositoryMock;
        private readonly Mock<IReservaRepository> _reservaRepositoryMock;
        private readonly ReservaBusiness _reservaBusiness;

        public ReservaBusinessTest()
        {
            _usuariorepositoryMock = new Mock<IUsuarioRepository>();
            _hotelRepositoryMock = new Mock<IHotelRepository>();
            _habitacionRepositoryMock = new Mock<IHabitacionRepository>();
            _reservaRepositoryMock = new Mock<IReservaRepository>();

            _reservaBusiness = new ReservaBusiness(_habitacionRepositoryMock.Object,
                                                   _hotelRepositoryMock.Object,
                                                   _usuariorepositoryMock.Object,
                                                   _reservaRepositoryMock.Object);
        }

        [Fact]
        public async Task ObtenerReservasActivasPorHoteExitosol()
        {
            _reservaRepositoryMock.Setup(x => x.ObtenerReservasActivasPorHotel(It.IsAny<ReservaDto>()))
                .ReturnsAsync(new List<ReservaDto> { new ReservaDto(), new ReservaDto() });

            var result = await _reservaBusiness.ObtenerReservasActivasPorHotel(new ReservaDto());

            Assert.NotNull(result);
            Assert.Equal(2, result.ToList().Count);
        }

        [Fact]
        public async Task CancelarReservaExitoso()
        {
            _reservaRepositoryMock.Setup(x => x.CancelarReserva(It.IsAny<int>()))
                .ReturnsAsync(true);

            var result = await _reservaBusiness.CancelarReserva(1);

            Assert.True(result);
        }

        [Fact]
        public async Task CancelarReservaGeneraExcepcion()
        {
            _reservaRepositoryMock.Setup(x => x.CancelarReserva(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            await Assert.ThrowsAsync<Exception>(async () => await _reservaBusiness.CancelarReserva(1));
        }

        [Fact]
        public async Task CrearReservaExitoso()
        {
            _usuariorepositoryMock.Setup(x => x.ObtenerUsuarioPorId(It.IsAny<int>()))
                .ReturnsAsync(new UsuarioDto());

            _hotelRepositoryMock.Setup(x => x.ObtenerHotelPorId(It.IsAny<int>()))
                .ReturnsAsync(new HotelDto());

            _habitacionRepositoryMock.Setup(x => x.ObtenerHabitacionPorId(It.IsAny<int>()))
                .ReturnsAsync(new HabitacionDto());

            _reservaRepositoryMock.Setup(x => x.ObtenerReservaPorFechaInicialEstado(It.IsAny<ReservaDto>()))
                .ReturnsAsync((ReservaDto)null);

            _reservaRepositoryMock.Setup(x => x.ReservasActivasPorHotel(It.IsAny<int>()))
                .ReturnsAsync(0);

            _reservaRepositoryMock.Setup(x => x.CrearReserva(It.IsAny<ReservaDto>()))
                .ReturnsAsync(new ReservaDto());

            var result = await _reservaBusiness.CrearReserva(new ReservaDto());

            Assert.NotNull(result);
        }

        [Fact]
        public async Task CrearReservaUsuarioNoExiste()
        {
            _usuariorepositoryMock.Setup(x => x.ObtenerUsuarioPorId(It.IsAny<int>()))
                .ReturnsAsync((UsuarioDto)null);

            await Assert.ThrowsAsync<Exception>(async () => await _reservaBusiness.CrearReserva(new ReservaDto()));
        }

        [Fact]
        public async Task CrearReservaHotelNoExiste()
        {
            _usuariorepositoryMock.Setup(x => x.ObtenerUsuarioPorId(It.IsAny<int>()))
                .ReturnsAsync(new UsuarioDto());

            _hotelRepositoryMock.Setup(x => x.ObtenerHotelPorId(It.IsAny<int>()))
                .ReturnsAsync((HotelDto)null);

            await Assert.ThrowsAsync<Exception>(async () => await _reservaBusiness.CrearReserva(new ReservaDto()));
        }

        [Fact]
        public async Task CrearReservHabitacionNoExiste()
        {
            _usuariorepositoryMock.Setup(x => x.ObtenerUsuarioPorId(It.IsAny<int>()))
                .ReturnsAsync(new UsuarioDto());

            _hotelRepositoryMock.Setup(x => x.ObtenerHotelPorId(It.IsAny<int>()))
                .ReturnsAsync(new HotelDto());

            _habitacionRepositoryMock.Setup(x => x.ObtenerHabitacionPorId(It.IsAny<int>()))
                .ReturnsAsync((HabitacionDto)null);

            await Assert.ThrowsAsync<Exception>(async () => await _reservaBusiness.CrearReserva(new ReservaDto()));
        }

        [Fact]
        public async Task CrearReservaReservaExiste()
        {
            _usuariorepositoryMock.Setup(x => x.ObtenerUsuarioPorId(It.IsAny<int>()))
                .ReturnsAsync(new UsuarioDto());

            _hotelRepositoryMock.Setup(x => x.ObtenerHotelPorId(It.IsAny<int>()))
                .ReturnsAsync(new HotelDto());

            _habitacionRepositoryMock.Setup(x => x.ObtenerHabitacionPorId(It.IsAny<int>()))
                .ReturnsAsync(new HabitacionDto());

            _reservaRepositoryMock.Setup(x => x.ObtenerReservaPorFechaInicialEstado(It.IsAny<ReservaDto>()))
                .ReturnsAsync(new ReservaDto());

            await Assert.ThrowsAsync<Exception>(async () => await _reservaBusiness.CrearReserva(new ReservaDto()));
        }

        [Fact]
        public async Task CrearReservaNoHayHabitaciones()
        {
            _usuariorepositoryMock.Setup(x => x.ObtenerUsuarioPorId(It.IsAny<int>()))
                .ReturnsAsync(new UsuarioDto());

            _hotelRepositoryMock.Setup(x => x.ObtenerHotelPorId(It.IsAny<int>()))
                .ReturnsAsync(new HotelDto() { NumeroHabitaciones = 3});

            _habitacionRepositoryMock.Setup(x => x.ObtenerHabitacionPorId(It.IsAny<int>()))
                .ReturnsAsync(new HabitacionDto());

            _reservaRepositoryMock.Setup(x => x.ObtenerReservaPorFechaInicialEstado(It.IsAny<ReservaDto>()))
                .ReturnsAsync((ReservaDto)null);

            _reservaRepositoryMock.Setup(x => x.ReservasActivasPorHotel(It.IsAny<int>()))
                .ReturnsAsync(3);

            await Assert.ThrowsAsync<Exception>(async () => await _reservaBusiness.CrearReserva(new ReservaDto()));
        }
    }
}

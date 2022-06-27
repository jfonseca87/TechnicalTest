using AutoMapper;
using ReservasDTOs.Dtos;
using ReservasRepository.Models;

namespace ReservasRepository.Mappers
{
    public class ReservasMapper : Profile
    {
        public ReservasMapper()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.IdUsuario, source => source.MapFrom(p => p.Idusuario))
                .ReverseMap();

            CreateMap<Hotel, HotelDto>()
                .ForMember(dest => dest.IdHotel, source => source.MapFrom(p => p.Idhotel))
                .ForMember(dest => dest.NumeroHabitaciones, source => source.MapFrom(p => p.Numerohabitaciones))
                .ReverseMap();

            CreateMap<Habitacion, HabitacionDto>()
                .ForMember(dest => dest.IdHabitacion, source => source.MapFrom(p => p.Idhabitacion))
                .ForMember(dest => dest.IdHotel, source => source.MapFrom(p => p.Idhotel))
                .ReverseMap();

            CreateMap<Reserva, ReservaDto>()
                .ForMember(dest => dest.IdReserva, source => source.MapFrom(p => p.Idreserva))
                .ForMember(dest => dest.IdUsuario, source => source.MapFrom(p => p.Idusuario))
                .ForMember(dest => dest.IdHotel, source => source.MapFrom(p => p.Idhotel))
                .ForMember(dest => dest.IdHabitacion, source => source.MapFrom(p => p.Idhabitacion))
                .ForMember(dest => dest.FechaEntrada, source => source.MapFrom(p => p.Fechaentrada))
                .ForMember(dest => dest.FechaSalida, source => source.MapFrom(p => p.Fechasalida))
                .ForMember(dest => dest.FechaReserva, source => source.MapFrom(p => p.Fechareserva))
                .ForMember(dest => dest.Estado, source => source.MapFrom(p => p.Estado))
                .ReverseMap();

        }
    }
}

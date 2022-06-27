using Microsoft.Extensions.DependencyInjection;
using ReservasBusiness.Implementaciones;
using ReservasBusiness.Interfaces;
using ReservasRepository.Implementaciones;
using ReservasRepository.Interfaces;

namespace ReservasAPI.MetodosExtension
{
    public static class StartupExtensions
    {
        public static IServiceCollection RepositoryDIContenedor(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<IHabitacionRepository, HabitacionRepository>();
            services.AddTransient<IReservaRepository, ReservaRepository>();
            return services;
        }

        public static IServiceCollection BusinessDIContenedor(this IServiceCollection services)
        {
            services.AddTransient<IReservaBusiness, ReservaBusiness>();
            return services;
        }
    }
}

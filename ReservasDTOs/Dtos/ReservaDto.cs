using System;

namespace ReservasDTOs.Dtos
{
    public class ReservaDto
    {
        public int IdReserva { get; set; }
        public int IdUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public int IdHotel { get; set; }
        public string NombreHotel { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaReserva { get; set; }
        public bool? Estado { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ReservasRepository.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Habitacion = new HashSet<Habitacion>();
            Reserva = new HashSet<Reserva>();
        }

        public int Idhotel { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public int? Numerohabitaciones { get; set; }

        public virtual ICollection<Habitacion> Habitacion { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
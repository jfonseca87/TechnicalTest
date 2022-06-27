using System;
using System.Collections.Generic;

namespace ReservasRepository.Models
{
    public partial class Habitacion
    {
        public Habitacion()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int Idhabitacion { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int? Idhotel { get; set; }

        public virtual Hotel IdhotelNavigation { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
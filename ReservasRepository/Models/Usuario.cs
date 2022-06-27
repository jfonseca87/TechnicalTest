using System;
using System.Collections.Generic;

namespace ReservasRepository.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
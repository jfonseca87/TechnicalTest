using System;
using System.Collections.Generic;

namespace ReservasRepository.Models
{
    public partial class Reserva
    {
        public int Idreserva { get; set; }
        public int? Idusuario { get; set; }
        public int? Idhotel { get; set; }
        public int? Idhabitacion { get; set; }
        public DateTime? Fechaentrada { get; set; }
        public DateTime? Fechasalida { get; set; }
        public DateTime? Fechareserva { get; set; }
        public bool? Estado { get; set; }

        public virtual Habitacion IdhabitacionNavigation { get; set; }
        public virtual Hotel IdhotelNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
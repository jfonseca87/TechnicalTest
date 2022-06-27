namespace ReservasDTOs.Dtos
{
    public class HotelDto
    {
        public int IdHotel { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public int? NumeroHabitaciones { get; set; }
    }
}

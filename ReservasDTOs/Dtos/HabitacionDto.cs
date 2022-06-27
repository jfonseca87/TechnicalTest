namespace ReservasDTOs.Dtos
{
    public class HabitacionDto
    {
        public int IdHabitacion { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int? IdHotel { get; set; }
    }
}

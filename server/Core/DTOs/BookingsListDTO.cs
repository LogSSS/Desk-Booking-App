namespace Core.DTOs
{
    public class BookingsListDTO
    {
        public BookingsListDTO()
        {
            Name = string.Empty;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}

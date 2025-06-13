namespace Core.DTOs
{
    public class MyImageDTO
    {
        public MyImageDTO()
        {
            Link = string.Empty;
        }

        public int Id { get; set; }

        public string Link { get; set; }

        public int WorkspaceId { get; set; }
    }
}

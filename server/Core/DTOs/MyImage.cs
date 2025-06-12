namespace Core.DTOs
{
    public class MyImage
    {
        public MyImage()
        {
            Link = string.Empty;
        }

        public int Id { get; set; }

        public string Link { get; set; }

        public int WorkspaceId { get; set; }
    }
}

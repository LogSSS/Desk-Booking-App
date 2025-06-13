namespace DAL.Entities
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

        public Workspace? Workspace { get; set; }
    }
}

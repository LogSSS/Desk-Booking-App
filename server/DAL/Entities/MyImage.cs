namespace DAL.Entities
{
    public class MyImage
    {
        public int Id { get; set; }

        public int Link { get; set; }

        public int WorkspaceId { get; set; }

        public Workspace? Workspace { get; set; }
    }
}

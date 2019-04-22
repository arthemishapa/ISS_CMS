namespace CMS.CMS.DAL.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public int SessionId { get; set; }

        public string Name { get; set; }

        public Session Session { get; set; }
    }
}
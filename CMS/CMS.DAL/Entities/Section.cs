namespace CMS.CMS.DAL.Entities
{
    public class Section
    {
        public int Id { get; set; }

        public int getId() { return Id; }

        public void setId(int newId) { this.Id = newId; }
        public int SessionId { get; set; }
        public int getSessionId() { return SessionId; }
        public void setSessionId(int newId) { this.SessionId = newId; }
        public string Name { get; set; }
        public string getName() { return Name; }
        public void setName(string newName) { this.Name = newName; }
        public Session Session { get; set; }
    }
}
namespace CMS.CMS.DAL.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string ChairId { get; set; }

        public string Name { get; set; }

        public Conference Conference { get; set; }
        public User Chair { get; set; }
    }
}
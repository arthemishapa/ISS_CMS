using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.CMS.DAL.Entities
{
    public class UserRoles
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int RoleId { get; set; }

        [Key]
        [Column(Order = 3)]
        public int ConferenceId { get; set; }

        [Key]
        [Column(Order = 4)]
        public int? SectionId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
        public Section Section { get; set; }
        public Conference Conference { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.CMS.DAL.Entities
{
    public class UserRole
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int RoleId { get; set; }

        [Key]
        [Column(Order = 3)]
        public int? LocationId { get; set; }
       

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
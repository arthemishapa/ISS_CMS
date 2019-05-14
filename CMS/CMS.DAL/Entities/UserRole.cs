using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.CMS.DAL.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int RoleId { get; set; }

        [Key]
        [Column(Order = 3)]
        public int? LocationId { get; set; }
    }
}
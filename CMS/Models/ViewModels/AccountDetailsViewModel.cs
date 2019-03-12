using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Models.ViewModels
{
    public class AccountDetailsViewModel
    {
        public string MemberID { get; set; }

        [Required]
        [Display(Name = "Affilation")]
        public string SelectedAffilationType { get; set; }
        public IEnumerable<SelectListItem> AffilationTypes { get; set; }

        [Display(Name = "Personal webpage")]
        public string Webpage { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CMS.CMS.Common.ViewModels
{
    public class AccountDetailsViewModel
    {
        public string MemberID { get; set; }

        [Display(Name = "Personal webpage")]
        public string Webpage { get; set; }
    }
}
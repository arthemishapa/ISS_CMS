using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.CMS.Common.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public string RequestMessage { get; set; }
        public bool Approved { get; set; }
    }
}
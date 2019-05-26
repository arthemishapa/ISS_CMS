using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.CMS.Common.ViewModels
{
    public class EmailNotificationViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string User { get; set; }
        public string UserID { get; set; }
        public string CallBack { get; set; }
    }
}
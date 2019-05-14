using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.CMS.Common.Enums
{
    public enum Role
    {
        Chair = 1,
        CoChair,
        PCMember,
        Author,
        ChairForSession,
        None = -1
    }
}
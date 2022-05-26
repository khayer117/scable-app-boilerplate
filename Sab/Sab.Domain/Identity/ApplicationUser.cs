using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sab.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedDate { get; set; }
    }
}

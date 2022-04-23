using System;
using System.Collections.Generic;
using System.Text;

namespace Sab.Authentication.Features
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
    }
}

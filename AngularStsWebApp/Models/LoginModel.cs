using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularStsWebApp.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public bool AllowRememberLogin { get; set; }
        public bool EnableLocalLogin { get; set; }
        public string RedirectToUrl { get; set; }
        public bool CancelLogin { get; set; }
    }
}

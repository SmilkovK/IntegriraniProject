using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppDomain.Identity
{
    public class ManageRoles : IdentityUser
    {
        public string? Email1 { get; set; }
        public List<string>? Roles { get; set;}
        public string? SelectedRole { get; set; }
    }
}

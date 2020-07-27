using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    // just going to use 3 roles for this system
    public enum AppAdminRole {AppAdministrator, Administrator, Manager, User }
    public enum AppRole { ApplicationAdministrator,  Administrator, Manager, User }
                      
    public class ApplicationRole : IdentityRole<Guid>
    {
    }
}

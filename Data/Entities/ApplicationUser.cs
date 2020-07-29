
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    // customise the Identity user accounts here 
    // note user accounts are identifided by Guids not integer ID's

    public class ApplicationUser:IdentityUser<Guid>
    {
        public string PersonName { get; set; }

        // add other info about a person here 
    }
}

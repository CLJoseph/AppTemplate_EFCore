using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    // reason for creating this class is so that role is a Guid and not an int.
    // Gives a little more flexability when creating roles in that guids can be created 
    // on the web server saving a trip to the database to have one generated and collected.
    public class ApplicationRole : IdentityRole<Guid>
    {
    }
}

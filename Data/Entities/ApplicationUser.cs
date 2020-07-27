
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string PersonName { get; set; }
        public Guid OrganisationID  { get; set; }
        public List<Instruction> Instructions { get; set; }
    }
}

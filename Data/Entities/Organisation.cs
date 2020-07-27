using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Organisation:LineId
    {
        public string Name { get; set; }
        public string About { get; set; }
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
        public List<OrgBranch> Branches { get; set; }
        public  virtual List<ApplicationUser> ApplicationUsers { get; set; }
    }
}

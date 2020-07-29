using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Initialise
{
    // class contains the application initialisation logic if the is any
    // ie checks if the Identity system has been populated with roles etc etc
    public class Initialise
    {
        public bool Complete { get; set; }

        public Initialise()
        {
            // write app initialise code here
            Complete = true;
        }
    }
}

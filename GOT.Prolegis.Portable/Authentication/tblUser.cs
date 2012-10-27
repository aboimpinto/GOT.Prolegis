using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOT.Prolegis.Portable.Authentication
{
    public class tblUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExternalKey { get; set; }
    }
}

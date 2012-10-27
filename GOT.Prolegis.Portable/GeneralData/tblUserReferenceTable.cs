using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOT.Prolegis.Portable.GeneralData
{
    public class tblUserReferenceTable
    {
        public int Id { get; set; }
        public string ReferenceTable { get; set; }
        public int ReferenceId { get; set; }
        public string ReferenceValue { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}

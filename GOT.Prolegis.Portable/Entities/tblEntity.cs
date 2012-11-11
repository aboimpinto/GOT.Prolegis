using GOT.Prolegis.Portable.GeneralData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GOT.Prolegis.Portable.Entities
{
    public class tblEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsClient { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsDeleted { get; set; }
    }
}

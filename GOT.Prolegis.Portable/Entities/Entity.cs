using GOT.Prolegis.Portable.GeneralData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOT.Prolegis.Portable.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public int EntityTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsDeleted { get; set; }

        public EntityType EntityType { get; set; }
    }
}

using GOT.Prolegis.Portable.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOT.Prolegis.Portable.GeneralData
{
    public class EntityType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Entity> Entities { get; set; }
    }
}

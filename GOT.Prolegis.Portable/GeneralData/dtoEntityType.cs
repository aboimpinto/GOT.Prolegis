﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GOT.Prolegis.Portable.GeneralData
{
    public class dtoEntityType
    {
        public int EntityTypeId { get; set; }
        public string EntityType { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}

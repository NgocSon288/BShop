﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Entities
{
    public interface IAuditable
    {
        DateTime? CreatedAt { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedAt { get; set; }

        string UpdateBy { get; set; }

        bool? IsDeleted { get; set; }
    }
}

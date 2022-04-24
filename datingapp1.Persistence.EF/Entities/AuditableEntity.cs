using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp1.Persistence.EF.Entities;

public class AuditableEntity
{
    public string CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }
}

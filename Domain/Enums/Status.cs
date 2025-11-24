using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Status
    {
        Pending = 0,
        Rejected = 1,
        ApprovedByAnalyst = 2,
        ApprovedByAdmin = 3,
        Completed = 4
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateSupplierDTO
    {
        public string Name { get; set; } = null!;
        public string ContactInfo { get; set; } = null!;
        public Guid CategoryId { get; set; }
    }
}

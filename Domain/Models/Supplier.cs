using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class Supplier
    {
        public Supplier(string name, string contactInfo, Guid categoryId)
        {
            Name = name;
            ContactInfo = contactInfo;
            CategoryId = categoryId;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public string ContactInfo { get; set; } = null!;

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class Category
    {
        public Category(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

        public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}

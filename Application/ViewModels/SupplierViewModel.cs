using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SupplierViewModel
    {
        public SupplierViewModel(Guid id, string name, string contactInfo, Guid categoryId)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
            CategoryId = categoryId;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string ContactInfo { get; set; } = null!;
        public Guid CategoryId { get; set; }
    }
}

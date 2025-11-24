using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers
{
    public static class SupplierMapper
    {
        public static SupplierViewModel ToResponse(this Supplier supplier)
        {
            return new SupplierViewModel(supplier.Id, supplier.Name, supplier.ContactInfo, supplier.CategoryId);
        }
    }
}

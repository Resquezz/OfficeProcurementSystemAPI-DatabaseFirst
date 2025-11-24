using Application.DTOs;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISupplierService
    {
        Task<SupplierViewModel> CreateSupplierAsync(CreateSupplierDTO dto);
        Task<SupplierViewModel> UpdateSupplierAsync(UpdateSupplierDTO dto);
        Task DeleteSupplierAsync(DeleteSupplierDTO dto);
        Task<ICollection<SupplierViewModel>?> GetAllSuppliersAsync();
        Task<SupplierViewModel> GetSupplierByIdAsync(Guid id);
    }
}

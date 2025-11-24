using Application.DTOs;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPurchaseService
    {
        Task<PurchaseViewModel> CreatePurchaseAsync(CreatePurchaseDTO dto);
        Task<PurchaseViewModel> UpdatePurchaseAsync(UpdatePurchaseDTO dto);
        Task DeletePurchaseAsync(DeletePurchaseDTO dto);
        Task<ICollection<PurchaseViewModel>?> GetAllPurchasesAsync();
        Task<PurchaseViewModel> GetPurchaseByIdAsync(Guid id);
    }
}

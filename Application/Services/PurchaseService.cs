using Application.DTOs;
using Application.Mappers;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        public PurchaseService(ICategoryRepository categoryRepository, IUserRepository userRepository, IPurchaseRepository purchaseRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
        }
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        public async Task<PurchaseViewModel> CreatePurchaseAsync(CreatePurchaseDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(CreateUserDTO));
            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new ArgumentNullException(nameof(dto.Description));
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ArgumentNullException(nameof(dto.Title));
            if (dto.CategoryId == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.CategoryId));
            if(dto.RequestedAmount <= 0)
                throw new ArgumentException("RequestedAmount can not be 0!");
            if(dto.UserId == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.UserId));

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
            if (category == null)
                throw new KeyNotFoundException($"Can not find category with id {dto.CategoryId}!");
            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
                throw new KeyNotFoundException($"Can not find user with id {dto.UserId}!");

            var purchase = new Purchase(dto.UserId, dto.CategoryId, dto.Title, dto.Description, dto.RequestedAmount);
            await _purchaseRepository.AddAsync(purchase);
            return purchase.ToResponse();
        }

        public async Task DeletePurchaseAsync(DeletePurchaseDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(DeleteSupplierDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));
            var purchase = await _purchaseRepository.GetByIdAsync(dto.Id);
            if (purchase is null)
                throw new KeyNotFoundException($"Can not find purchase with id {dto.Id}!");
            await _purchaseRepository.DeleteAsync(dto.Id);
        }

        public async Task<ICollection<PurchaseViewModel>?> GetAllPurchasesAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            if (purchases == null)
                return null;
            return purchases.Select(purchase => purchase.ToResponse()).ToList();
        }

        public async Task<PurchaseViewModel> GetPurchaseByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                throw new KeyNotFoundException($"Can not find purchase with id {id}!");
            return purchase.ToResponse();
        }
        public async Task<PurchaseViewModel> UpdatePurchaseAsync(UpdatePurchaseDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(UpdatePurchaseDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));

            var purchase = await _purchaseRepository.GetByIdAsync(dto.Id);
            if (purchase == null)
                throw new KeyNotFoundException($"Can not find purchase with id {dto.Id}!");

            if (dto.CategoryId != null)
            {
                var category = await _categoryRepository.GetByIdAsync(dto.CategoryId.Value);
                if (category is null)
                    throw new KeyNotFoundException($"Can not find category with id {dto.CategoryId}!");
                purchase.CategoryId = dto.CategoryId.Value;
            }
            if (dto.UserId != null)
            {
                var user = await _userRepository.GetByIdAsync(dto.UserId.Value);
                if (user is null)
                    throw new KeyNotFoundException($"Can not find user with id {dto.UserId}!");
                purchase.UserId = dto.UserId.Value;
            }
            if (!string.IsNullOrWhiteSpace(dto.Description))
                purchase.Description = dto.Description;
            if (!string.IsNullOrWhiteSpace(dto.Title))
                purchase.Title = dto.Title;
            if (dto.Status != null)
                purchase.Status = dto.Status.Value.ToString();
            if (dto.RequestedAmount != null)
                purchase.RequestedAmount = dto.RequestedAmount.Value;

            await _purchaseRepository.UpdateAsync(purchase);
            return purchase.ToResponse();
        }
    }
}

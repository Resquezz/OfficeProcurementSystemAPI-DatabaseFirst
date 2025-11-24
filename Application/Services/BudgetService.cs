using Application.DTOs;
using Application.Mappers;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class BudgetService : IBudgetService
    {
        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }
        private readonly IBudgetRepository _budgetRepository;
        public async Task<BudgetViewModel> CreateBudgetAsync(CreateBudgetDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(CreateReportDTO));
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentNullException(nameof(dto.Name));
            if (dto.GeneralAmount <= 0)
                throw new ArgumentException(nameof(dto.GeneralAmount));

            var budget = new Budget(dto.GeneralAmount, dto.Name);
            await _budgetRepository.AddAsync(budget);
            return budget.ToResponse();
        }

        public async Task DeleteBudgetAsync(DeleteBudgetDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(DeleteCategoryDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));
            var budget = await _budgetRepository.GetByIdAsync(dto.Id);
            if (budget is null)
                throw new KeyNotFoundException($"Can not find budget with id {dto.Id}!");
            await _budgetRepository.DeleteAsync(dto.Id);
        }

        public async Task<ICollection<BudgetViewModel>?> GetAllBudgetsAsync()
        {
            var budgets = await _budgetRepository.GetAllAsync();
            if (budgets == null)
                return null;
            return budgets.Select(budget => budget.ToResponse()).ToList();
        }

        public async Task<BudgetViewModel> GetBudgetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var budget = await _budgetRepository.GetByIdAsync(id);
            if (budget == null)
                throw new KeyNotFoundException($"Can not find budget with id {id}!");
            return budget.ToResponse();
        }
        public async Task<BudgetViewModel> UpdateBudgetAsync(UpdateBudgetDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(UpdatePurchaseDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));

            var budget = await _budgetRepository.GetByIdAsync(dto.Id);
            if (budget == null)
                throw new KeyNotFoundException($"Can not find budget with id {dto.Id}!");

            if (!string.IsNullOrWhiteSpace(dto.Name))
                budget.Name = dto.Name;
            if (dto.GeneralAmount != null)
                budget.GeneralAmount = dto.GeneralAmount.Value;
            if (dto.AvailableAmount != null)
                budget.AvailableAmount = dto.AvailableAmount.Value;

            await _budgetRepository.UpdateAsync(budget);
            return budget.ToResponse();
        }
    }
}

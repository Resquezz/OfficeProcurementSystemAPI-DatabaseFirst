using Application.DTOs;
using Application.Mappers;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using OfficeProcurementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AnomalyExpenseService : IAnomalyExpenseService
    {
        public AnomalyExpenseService(IAnomalyExpenseRepository anomalyExpenseRepository, IPurchaseRepository purchaseRepository)
        {
            _anomalyExpenseRepository = anomalyExpenseRepository;
            _purchaseRepository = purchaseRepository;
        }
        private readonly IAnomalyExpenseRepository _anomalyExpenseRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        public async Task<AnomalyExpenseViewModel> CreateAnomalyExpenseAsync(CreateAnomalyExpenseDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(CreateReportDTO));
            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new ArgumentNullException(nameof(dto.Description));
            if (dto.PurchaseId == Guid.Empty)
                throw new ArgumentException(nameof(dto.PurchaseId));

            var purchase = await _purchaseRepository.GetByIdAsync(dto.PurchaseId);
            if (purchase == null)
                throw new KeyNotFoundException($"Can not find purchase with id {dto.PurchaseId}!");

            var anomalyExpense = new AnomalyExpense(dto.PurchaseId, dto.Description);
            await _anomalyExpenseRepository.AddAsync(anomalyExpense);
            return anomalyExpense.ToResponse();
        }

        public async Task DeleteAnomalyExpenseAsync(DeleteAnomalyExpenseDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(DeleteAnomalyExpenseDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));
            var anomalyExpense = await _anomalyExpenseRepository.GetByIdAsync(dto.Id);
            if (anomalyExpense is null)
                throw new KeyNotFoundException($"Can not find anomaly expense with id {dto.Id}!");
            await _anomalyExpenseRepository.DeleteAsync(dto.Id);
        }

        public async Task<ICollection<AnomalyExpenseViewModel>?> GetAllAnomalyExpensesAsync()
        {
            var expenses = await _anomalyExpenseRepository.GetAllAsync();
            if (expenses == null)
                return null;
            return expenses.Select(expense => expense.ToResponse()).ToList();
        }

        public async Task<AnomalyExpenseViewModel> GetAnomalyExpenseByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var expense = await _anomalyExpenseRepository.GetByIdAsync(id);
            if (expense == null)
                throw new KeyNotFoundException($"Can not find anomaly expense with id {id}!");
            return expense.ToResponse();
        }
        public async Task<AnomalyExpenseViewModel> UpdateAnomalyExpenseAsync(UpdateAnomalyExpenseDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(UpdatePurchaseDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));

            var expense = await _anomalyExpenseRepository.GetByIdAsync(dto.Id);
            if (expense == null)
                throw new KeyNotFoundException($"Can not find anomaly expense with id {dto.Id}!");

            if (dto.PurchaseId != null)
            {
                var purchase = await _purchaseRepository.GetByIdAsync(dto.PurchaseId.Value);
                if (purchase == null)
                    throw new KeyNotFoundException($"Can not find purchase with id {dto.PurchaseId}!");
                expense.PurchaseId = dto.PurchaseId.Value;
            }
            if (!string.IsNullOrWhiteSpace(dto.Description))
                expense.Description = dto.Description;

            await _anomalyExpenseRepository.UpdateAsync(expense);
            return expense.ToResponse();
        }
    }
}

using Application.DTOs;
using Application.Mappers;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExpenseReportService : IExpenseReportService
    {
        public ExpenseReportService(IBudgetRepository budgetRepository, IUserRepository userRepository, IExpenseReportRepository expenseReportRepository)
        {
            _budgetRepository = budgetRepository;
            _userRepository = userRepository;
            _expenseReportRepository = expenseReportRepository;
        }
        private readonly IBudgetRepository _budgetRepository;
        private readonly IUserRepository _userRepository;
        private readonly IExpenseReportRepository _expenseReportRepository;
        public async Task<ExpenseReportViewModel> CreateReportAsync(CreateReportDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(CreateReportDTO));
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentNullException(nameof(dto.Name));
            if (dto.BudgetId == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.BudgetId));
            if (dto.TotalExpenses <= 0)
                throw new ArgumentException("TotalExpenses can not be 0!");
            if (dto.UserId == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.UserId));

            var budget = await _budgetRepository.GetByIdAsync(dto.BudgetId);
            if (budget == null)
                throw new KeyNotFoundException($"Can not find budget with id {dto.BudgetId}!");
            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
                throw new KeyNotFoundException($"Can not find user with id {dto.UserId}!");

            var report = new ExpenseReport(dto.Name, dto.BudgetId, dto.UserId, dto.TotalExpenses);
            await _expenseReportRepository.AddAsync(report);
            return report.ToResponse();
        }

        public async Task DeleteReportAsync(DeleteReportDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(DeleteReportDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));
            var report = await _expenseReportRepository.GetByIdAsync(dto.Id);
            if (report is null)
                throw new KeyNotFoundException($"Can not find expense report with id {dto.Id}!");
            await _expenseReportRepository.DeleteAsync(dto.Id);
        }

        public async Task<ICollection<ExpenseReportViewModel>?> GetAllReportsAsync()
        {
            var reports = await _expenseReportRepository.GetAllAsync();
            if (reports == null)
                return null;
            return reports.Select(report => report.ToResponse()).ToList();
        }

        public async Task<ExpenseReportViewModel> GetReportByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var report = await _expenseReportRepository.GetByIdAsync(id);
            if (report == null)
                throw new KeyNotFoundException($"Can not find expense report with id {id}!");
            return report.ToResponse();
        }
        public async Task<ExpenseReportViewModel> UpdateReportAsync(UpdateReportDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(UpdatePurchaseDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));

            var report = await _expenseReportRepository.GetByIdAsync(dto.Id);
            if (report == null)
                throw new KeyNotFoundException($"Can not find expense report with id {dto.Id}!");

            if (dto.BudgetId != null)
            {
                var budget = await _budgetRepository.GetByIdAsync(dto.BudgetId.Value);
                if (budget is null)
                    throw new KeyNotFoundException($"Can not find budget with id {dto.BudgetId.Value}!");
                report.BudgetId = dto.BudgetId.Value;
            }
            if (dto.UserId != null)
            {
                var user = await _userRepository.GetByIdAsync(dto.UserId.Value);
                if (user is null)
                    throw new KeyNotFoundException($"Can not find user with id {dto.UserId}!");
                report.UserId = dto.UserId.Value;
            }
            if (dto.TotalExpenses != null)
                report.TotalExpenses = dto.TotalExpenses.Value;
            if (!string.IsNullOrWhiteSpace(dto.Name))
                report.Name = dto.Name;

            await _expenseReportRepository.UpdateAsync(report);
            return report.ToResponse();
        }
    }
}

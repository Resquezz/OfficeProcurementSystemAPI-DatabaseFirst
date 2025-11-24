using Application.DTOs;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IExpenseReportService
    {
        Task<ExpenseReportViewModel> CreateReportAsync(CreateReportDTO dto);
        Task<ExpenseReportViewModel> UpdateReportAsync(UpdateReportDTO dto);
        Task DeleteReportAsync(DeleteReportDTO dto);
        Task<ICollection<ExpenseReportViewModel>?> GetAllReportsAsync();
        Task<ExpenseReportViewModel> GetReportByIdAsync(Guid id);
    }
}

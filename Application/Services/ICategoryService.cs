using Application.DTOs;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICategoryService
    {
        Task<CategoryViewModel> CreateCategoryAsync(CreateCategoryDTO dto);
        Task<CategoryViewModel> UpdateCategoryAsync(UpdateCategoryDTO dto);
        Task DeleteCategoryAsync(DeleteCategoryDTO dto);
        Task<ICollection<CategoryViewModel>?> GetAllCategoriesAsync();
        Task<CategoryViewModel> GetCategoryByIdAsync(Guid id);
    }
}

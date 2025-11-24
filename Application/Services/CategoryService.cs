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
    public class CategoryService : ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        private readonly ICategoryRepository _categoryRepository;
        public async Task<CategoryViewModel> CreateCategoryAsync(CreateCategoryDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(CreateReportDTO));
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentNullException(nameof(dto.Name));

            var category = new Category(dto.Name);
            await _categoryRepository.AddAsync(category);
            return category.ToResponse();
        }

        public async Task DeleteCategoryAsync(DeleteCategoryDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(DeleteCategoryDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));
            var category = await _categoryRepository.GetByIdAsync(dto.Id);
            if (category is null)
                throw new KeyNotFoundException($"Can not find category with id {dto.Id}!");
            await _categoryRepository.DeleteAsync(dto.Id);
        }

        public async Task<ICollection<CategoryViewModel>?> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
                return null;
            return categories.Select(category => category.ToResponse()).ToList();
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException($"Can not find category with id {id}!");
            return category.ToResponse();
        }
        public async Task<CategoryViewModel> UpdateCategoryAsync(UpdateCategoryDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(UpdatePurchaseDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));

            var category = await _categoryRepository.GetByIdAsync(dto.Id);
            if (category == null)
                throw new KeyNotFoundException($"Can not find category with id {dto.Id}!");

            if (!string.IsNullOrWhiteSpace(dto.Name))
                category.Name = dto.Name;

            await _categoryRepository.UpdateAsync(category);
            return category.ToResponse();
        }
    }
}

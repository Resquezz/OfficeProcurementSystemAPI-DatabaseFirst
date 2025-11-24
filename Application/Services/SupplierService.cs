using Application.DTOs;
using Application.Mappers;
using Application.ViewModels;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SupplierService : ISupplierService
    {
        public SupplierService(ISupplierRepository supplierRepository, ICategoryRepository categoryRepository)
        {
            _supplierRepository = supplierRepository;
            _categoryRepository = categoryRepository;
        }
        private readonly ISupplierRepository _supplierRepository;
        private readonly ICategoryRepository _categoryRepository;
        public async Task<SupplierViewModel> CreateSupplierAsync(CreateSupplierDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(CreateUserDTO));
            if (string.IsNullOrWhiteSpace(dto.ContactInfo))
                throw new ArgumentNullException(nameof(dto.ContactInfo));
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentNullException(nameof(dto.Name));
            if (dto.CategoryId == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.CategoryId));

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
            if (category == null)
                throw new KeyNotFoundException($"Can not find category with id {dto.CategoryId}!");

            var supplier = new Supplier(dto.Name, dto.ContactInfo, dto.CategoryId);
            await _supplierRepository.AddAsync(supplier);
            return supplier.ToResponse();
        }

        public async Task DeleteSupplierAsync(DeleteSupplierDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(DeleteSupplierDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));
            var supplier = await _supplierRepository.GetByIdAsync(dto.Id);
            if (supplier is null)
                throw new KeyNotFoundException($"Can not find supplier with id {dto.Id}!");
            await _supplierRepository.DeleteAsync(dto.Id);
        }

        public async Task<ICollection<SupplierViewModel>?> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            if (suppliers == null)
                return null;
            return suppliers.Select(supplier => supplier.ToResponse()).ToList();
        }

        public async Task<SupplierViewModel> GetSupplierByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier == null)
                throw new KeyNotFoundException($"Can not find supplier with id {id}!");
            return supplier.ToResponse();
        }
        public async Task<SupplierViewModel> UpdateSupplierAsync(UpdateSupplierDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(UpdateSupplierDTO));
            if (dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));

            var supplier = await _supplierRepository.GetByIdAsync(dto.Id);
            if (supplier == null)
                throw new KeyNotFoundException($"Can not find supplier with id {dto.Id}!");

            if (dto.CategoryId != null)
            {
                var category = await _categoryRepository.GetByIdAsync(dto.CategoryId.Value);
                if(category is null)
                    throw new KeyNotFoundException($"Can not find category with id {dto.CategoryId}!");
                supplier.CategoryId = dto.CategoryId.Value;
            }
            if (!string.IsNullOrWhiteSpace(dto.ContactInfo))
                supplier.ContactInfo = dto.ContactInfo;
            if (!string.IsNullOrWhiteSpace(dto.Name))
                supplier.Name = dto.Name;
            await _supplierRepository.UpdateAsync(supplier);
            return supplier.ToResponse();
        }
    }
}

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
    public class UserService : IUserService
    {
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        private readonly IUserRepository _repository;
        public async Task<UserViewModel> CreateUserAsync(CreateUserDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(CreateUserDTO));
            if (string.IsNullOrWhiteSpace(dto.Surname))
                throw new ArgumentNullException(nameof(dto.Surname));
            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentNullException(nameof(dto.Password));
            if(string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentNullException(nameof(dto.Name));
            if(string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentNullException(nameof(dto.Email));
            if (!Enum.IsDefined(typeof(Role), dto.Role))
                throw new ArgumentNullException(nameof(dto.Role));

            var user = new User(dto.Name, dto.Surname, (int)dto.Role, dto.Email, BCrypt.Net.BCrypt.HashPassword(dto.Password));
            await _repository.AddAsync(user);
            return user.ToResponse();
        }

        public async Task DeleteUserAsync(DeleteUserDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(DeleteUserDTO));
            if(dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));
            var user = await _repository.GetByIdAsync(dto.Id);
            if (user is null)
                throw new KeyNotFoundException($"Can not find user with id {dto.Id}!");
            await _repository.DeleteAsync(dto.Id);
        }

        public async Task<ICollection<UserViewModel>?> GetAllUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            if (users == null)
                return null;
            return users.Select(user => user.ToResponse()).ToList();
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid id)
        {
            if(id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var user = await _repository.GetByIdAsync(id);
            if(user == null)
                throw new KeyNotFoundException($"Can not find user with id {id}!");
            return user.ToResponse();
        }
        public async Task<UserViewModel> UpdateUserAsync(UpdateUserDTO dto)
        {
            if(dto is null)
                throw new ArgumentNullException(nameof(CreateUserDTO));
            if(dto.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(dto.Id));
            var user = await _repository.GetByIdAsync(dto.Id);
            if(user == null)
                throw new KeyNotFoundException($"Can not find user with id {dto.Id}!");
            if(!string.IsNullOrWhiteSpace(dto.Surname))
                user.Surname = dto.Surname;
            if(!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;
            if(!string.IsNullOrWhiteSpace(dto.Name))
                user.Name = dto.Name;
            if (dto.Role != null)
                user.Role = (int)dto.Role.Value;
            await _repository.UpdateAsync(user);
            return user.ToResponse();
        }
    }
}

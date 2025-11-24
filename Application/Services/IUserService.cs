using Application.DTOs;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<UserViewModel> CreateUserAsync(CreateUserDTO dto);
        Task<UserViewModel> UpdateUserAsync(UpdateUserDTO dto);
        Task DeleteUserAsync(DeleteUserDTO dto);
        Task<ICollection<UserViewModel>?> GetAllUsersAsync();
        Task<UserViewModel> GetUserByIdAsync(Guid id);
    }
}

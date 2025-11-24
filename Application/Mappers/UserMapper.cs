using Application.ViewModels;
using Domain.Enums;
using Domain.Models;

namespace Application.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToResponse(this User user)
        {
            return new UserViewModel(user.Id, user.Name, (Role)user.Role, user.Surname, user.Email);
        }
    }
}

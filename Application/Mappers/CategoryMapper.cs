using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryViewModel ToResponse(this Category category)
        {
            return new CategoryViewModel(category.Id, category.Name);
        }
    }
}

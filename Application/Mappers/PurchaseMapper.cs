using Application.ViewModels;
using Domain.Enums;
using Domain.Models;

namespace Application.Mappers
{
    public static class PurchaseMapper
    {
        public static PurchaseViewModel ToResponse(this Purchase purchase)
        {
            return new PurchaseViewModel(purchase.Id, purchase.UserId, purchase.CreatedAt, purchase.CategoryId,
                purchase.Title, purchase.Description, Enum.Parse<Status>(purchase.Status), purchase.RequestedAmount);
        }
    }
}

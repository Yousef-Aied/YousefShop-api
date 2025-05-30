using eCommerceApp.Application.DTOs.Cart;

namespace eCommerceApp.Application.Services.interfaces.Cart
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<GetPaymentMethod>> GetPaymentMethods();
    }
}

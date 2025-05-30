using eCommerceApp.Application.DTOs.Cart;
using eCommerceApp.Application.Services.interfaces.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(ICartService cartService) : ControllerBase
    {
        [HttpPost("checkout")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Checkout(Checkout checkout)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await cartService.Checkout(checkout);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("save-checkout")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> SaveCheckout(IEnumerable<CreateAchieve> achieves)
        {
            var result = await cartService.SaveCheckoutHistory(achieves);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get-achieves")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllCheckoutHistory()
        {
            var achieves = await cartService.GetAchieves();
            return achieves.Any() ? Ok(achieves) : NotFound();
        }
    }
}

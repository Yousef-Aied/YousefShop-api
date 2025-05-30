using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Categoty;
using eCommerceApp.Application.DTOs.Product;

namespace eCommerceApp.Application.Services.interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteAsync(Guid entity);
        Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId); 
    }
}

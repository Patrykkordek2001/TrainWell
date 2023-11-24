using TrainWell___BACKEND.Dtos.Diet;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IProductService
    {
        Task<int> AddProductAsync(ProductDto productDto);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task UpdateProductAsync(Product product);
    }
}
using CapicuaAPI.Model;
using System.Threading.Tasks;

namespace CapicuaAPI.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> AddNewProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
    }
}

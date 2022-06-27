using CapicuaAPI.Model;
using CapicuaAPI.Repositories;
using System.Threading.Tasks;

namespace CapicuaAPI.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }

        public async Task<Product> AddNewProduct(Product product)
        {
            return await _productRepository.AddNewProductAsync(product);
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            Product oldProduct = await _productRepository.GetProductByIdAsync(id);
            if (oldProduct == null)
            {
                return false;
            }

            product.ID = oldProduct.ID;
            await _productRepository.UpdateProductAsync(product);
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            Product productToDelete = await _productRepository.GetProductByIdAsync(id);
            if (productToDelete == null)
            {
                return false;
            }

            await _productRepository.DeleteProductAsync(productToDelete);
            return true;
        }
    }
}

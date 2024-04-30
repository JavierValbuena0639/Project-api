using System.Collections.Generic;
using System.Threading.Tasks;
using Project_api.Model;

namespace Project_api.Services
{
    public interface IProductsService
    {
        Task<List<Products>> GetAllProducts();
        Task<Products?> GetProductById(int productId);
        Task<Products> CreateProduct(Products product);
        Task<Products> UpdateProduct(Products product);
        Task<bool> DeleteProduct(int productId);
    }

    public class ProductService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _productsRepository.GetAllProducts();
        }

        public async Task<Products?> GetProductById(int productId)
        {
            return await _productsRepository.GetProductById(productId);
        }

        public async Task<Products> CreateProduct(Products product)
        {
            return await _productsRepository.CreateProduct(product);
        }

        public async Task<Products> UpdateProduct(Products product)
        {
            return await _productsRepository.UpdateProduct(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            return await _productsRepository.DeleteProduct(productId);
        }
    }
}

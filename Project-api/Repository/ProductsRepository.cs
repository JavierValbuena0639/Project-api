using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Project_api.Context;

namespace Project_api.Model
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetAllProducts();
        Task<Products?> GetProductById(int productId);
        Task<Products> CreateProduct(Products product);
        Task<Products> UpdateProduct(Products product);
        Task<bool> DeleteProduct(int productId);
    }

    public class ProductsRepository : IProductsRepository
    {
        private readonly DbProject _context;

        public ProductsRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Products?> GetProductById(int productId)
        {
            return await _context.products.FindAsync(productId);
        }

        public async Task<Products> CreateProduct(Products product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> UpdateProduct(Products product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _context.products.FindAsync(productId);
            if (product == null)
            {
                return false;
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
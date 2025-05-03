using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.ProductRepo
{
    public class ProductRepository : GenericRepository<Products>,IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task DeleteAsync(int id)
		{
			var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
		}
        public async Task<Products?> GetProductById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateProductt(Products product)
        {
            var currentProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (currentProduct != null)
            {
                currentProduct.Price = product.Price;
                currentProduct.Name = product.Name;
                //currentProduct.Image = product.Image;
                currentProduct.Description = product.Description;
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Products>> GetProductsByIdsAsync(List<int> productIds)
        {
            return await _dbContext.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
        }

    }
}

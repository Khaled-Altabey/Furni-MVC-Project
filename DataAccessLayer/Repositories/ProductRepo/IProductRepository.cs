using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.ProductRepo
{
	public interface IProductRepository : IGenericRepository<Products>
	{
		// Here to add Methods specified to the product entity in addition to those in the Generic Repo

		Task DeleteAsync(int id);
		Task<Products?> GetProductById(int id);
		Task UpdateProductt(Products product);
		Task<List<Products>> GetProductsByIdsAsync(List<int> productIds);

    }
}

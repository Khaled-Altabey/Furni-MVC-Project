using BussinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Contracts
{
    public interface IProductManager
    {
        Task<List<GetAllProductsDto>> GetAllAsync();
        Task<GetProductByIdDto> GetProductById(int Id);
        Task<List<GetProductByIdDto>> GetProductsByIdsAsync(List<int> productIds);
        Task AddProduct(AddProductDto NewProductDto);
        Task UpdateProduct(UpdateProductDto UpdatedProduct);
        Task Delete(int id);


	}
}

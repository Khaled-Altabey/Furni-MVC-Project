using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Contracts;
using BussinessLayer.DTOs;
using BussinessLayer.Mapping;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Generic;
using DataAccessLayer.Repositories.ProductRepo;

namespace BussinessLayer.Manager
{
	public class ProductManager : IProductManager
	{
        private readonly IProductRepository _productRepo;

        public ProductManager(IProductRepository ProductRepo)
		{
            _productRepo = ProductRepo;
        }

        //// Get All Products //// 
        public async Task<List<GetAllProductsDto>> GetAllAsync()
        {
			var Products = await _productRepo.GetAllAsync();
			var ListOfProducts = Products.ToList();

			////// Mapping ////// 
			var ProductsDto = ProductsExtensions.ToProductsDto(ListOfProducts);
			return ProductsDto;
		}

		//// Get Product by Id ////
			public async Task<GetProductByIdDto> GetProductById(int Id)
			{
				var product = await _productRepo.GetProductById(Id);
			if (product == null)
			{
				return null;
			}
				var ProductByIdDto = ProductsExtensions.ToProductByIdDto(product);
				return ProductByIdDto;
			}
		
		//////////// ADD NEW PRODUCT ///////////////
		
		public async Task AddProduct(AddProductDto NewProductDto)
		{
			if (NewProductDto != null)
			{ 
			var ProductAddToEntity = ProductsExtensions.ToProductEntity(NewProductDto);
			await _productRepo.Add(ProductAddToEntity);
			
			}
			await _productRepo.SaveChangesAsync();
		}

		////////// UPDATE PRODUCT /////////////////
		
		public async Task UpdateProduct(UpdateProductDto UpdatedProduct)
		{

			if (UpdatedProduct != null)
			{
				var UpdatedProductEntity = ProductsExtensions.ToUpdatedProductEntity(UpdatedProduct);
				await _productRepo.UpdateProductt(UpdatedProductEntity);
			}
			await _productRepo.SaveChangesAsync();
		}

		/////////// DELETE PRODUCT ///////////
		
		public async Task Delete(int id)
		{
			await _productRepo.DeleteAsync(id);
		}

        /////////// GET BY IDS //////
        public async Task<List<GetProductByIdDto>> GetProductsByIdsAsync(List<int> productIds)
        {
            var products = await _productRepo.GetProductsByIdsAsync(productIds);
            return products.Select(p => new GetProductByIdDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Image = p.Image
            }).ToList();
        }

    }
}

using BussinessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Mapping
{
    public static class ProductsExtensions
    {
        public static List<GetAllProductsDto> ToProductsDto(this List<Products> product)
        {
            var productDtos = product.Select( 
                p => new GetAllProductsDto
                { 
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image,
                }).ToList();
            return productDtos;
        }

        public static GetProductByIdDto ToProductByIdDto (this Products product)
        {
           return new GetProductByIdDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image,
            };

        }
        public static Products ToProductEntity(this AddProductDto ProductDto)
        {
            return new Products
            { 
                Name = ProductDto.Name,
                Description = ProductDto.Description,
                Price = ProductDto.Price,
                Image = ProductDto.Image,
            };
        }
        public static Products ToUpdatedProductEntity(this UpdateProductDto updateProductDto)
        {
            return new Products
            {
                Id = updateProductDto.Id,
                Name = updateProductDto.Name,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                Image = updateProductDto.Image,
            };
        }
    }
}

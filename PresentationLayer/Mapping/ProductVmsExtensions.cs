using BussinessLayer.DTOs;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Mapping
{
    public static class ProductVmsExtensions
    {
        public static List<GetAllProductsVm> ToProductsVms(this List<GetAllProductsDto> productDtos)
        { 
            var ListOfProductsVMs = productDtos.Select(
                P => new GetAllProductsVm
                {
                    Id = P.Id,
                    Name = P.Name,
                    Description = P.Description,
                    Price = P.Price,
                    Image = P.Image,
                }).ToList();
        return ListOfProductsVMs;
        }

        public static GetProductByIdVm ToProductIdVm( this GetProductByIdDto Product)
        {
            return new GetProductByIdVm
            { Id = Product.Id,
            Name = Product.Name,
            Description = Product.Description,
            Price = Product.Price,
            Image = Product.Image,
            };
        }

    }
}

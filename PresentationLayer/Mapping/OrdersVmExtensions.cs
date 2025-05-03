using BussinessLayer.DTOs;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Mapping
{
    public static class OrdersVmExtensions
    {
        public static List<GetAllOrdersVm> ToAllOrdersVm(List<GetAllOrdersDto> OrdersDto)
        {
            var OrdersVm = OrdersDto.Select
                (O => new GetAllOrdersVm
                {
                    Id = O.Id,
                    Name = O.Name,
                    OrderDate = O.OrderDate,
                    Review = O.Review,
                }).ToList();
            return OrdersVm;
        }

        
    }
}

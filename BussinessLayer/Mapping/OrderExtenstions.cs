using BussinessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Mapping
{
    public static class OrderExtenstions
    {
        public static List<GetAllOrdersDto> ToAllOrdersDto (List<Orders> Orders)
        {
            var OrdersDto = Orders.Select
                (O => new GetAllOrdersDto
            {
                Id = O.Id,
                Name = O.Name,
                OrderDate = O.OrderDate,
                            }).ToList();
               return OrdersDto;
        }
        public static Orders  ToOrderEntity(CreateOrderDto OrderDto)
        {
            var OrderEntity = new Orders
            { 
                Id = OrderDto.Id,
                Name = OrderDto.Name,
                OrderDate = OrderDto.OrderDate,
            };
            return OrderEntity;
        }
    }
}

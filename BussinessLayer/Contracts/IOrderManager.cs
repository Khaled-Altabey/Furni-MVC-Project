using BussinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Contracts
{
    public interface IOrderManager
    {
        Task<List<GetAllOrdersDto>> GetAllOrders();
        Task CreateAndPayOrder(CreateOrderDto OrderDto);
    }
}

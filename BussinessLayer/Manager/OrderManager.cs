using BussinessLayer.Contracts;
using BussinessLayer.DTOs;
using BussinessLayer.Mapping;
using DataAccessLayer.Repositories.OrderRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Manager
{
	public class OrderManager : IOrderManager
	{
        private readonly IOrderRepository _orderRepository;
        private readonly ICartManager _cartManager;

        public OrderManager(IOrderRepository orderRepository , ICartManager cartManager)
        {
            _orderRepository = orderRepository;
            _cartManager = cartManager;
        }
        
        ////////////// GET ALL ORDERS ////////////

        public async Task<List<GetAllOrdersDto>> GetAllOrders()
        {
            var Orders = await _orderRepository.GetAllAsync();
            var ListOfOrders = Orders.ToList();

            var ListOfOrdersDto = OrderExtenstions.ToAllOrdersDto(ListOfOrders);
            return ListOfOrdersDto;

        }
        //////////// Create Order //////////////
        
        public async Task CreateAndPayOrder(CreateOrderDto OrderDto)
        {
            var OrderEntity = OrderExtenstions.ToOrderEntity(OrderDto);
            await _orderRepository.Add(OrderEntity);
            await _orderRepository.SaveChangesAsync();
        }

    }
}

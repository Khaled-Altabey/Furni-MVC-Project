using BussinessLayer.Contracts;
using BussinessLayer.DTOs;
using BussinessLayer.Manager;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ActionRequests;
using PresentationLayer.Mapping;

namespace PresentationLayer.Controllers
{
	public class OrderController : Controller
	{
        private readonly IOrderManager _orderManager;
        private readonly ICartManager _cartManager;
        private readonly IProductManager _productManager;

        public OrderController(IOrderManager orderManager , ICartManager cartManager ,IProductManager productManager)
        {
            _orderManager = orderManager;
            _cartManager = cartManager;
            _productManager = productManager;
        }

        ////////////////// GET ALL ORDERS ////////////////
        [HttpGet]
        public async Task<IActionResult> GetAll()
		{
            var AllOrders = await _orderManager.GetAllOrders();
            var GetAllOrdersVm = OrdersVmExtensions.ToAllOrdersVm(AllOrders);
			return View("viewAllOrders" , GetAllOrdersVm);
		}

        /////////////// ADD TO CART /////////////////////
        [HttpGet]
        public async Task<IActionResult> AddTOCart(int id)
        {
            var productDto = await _productManager.GetProductById(id);
            var AddActionRequest = new AddToCartActionRequest
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Amount = productDto.Amount,
                Image = productDto.Image,
                Description = productDto.Description,
                Price = productDto.Price
            };
            
            return View("AddTOCart", AddActionRequest);
        }
        [HttpPost]
        public IActionResult AddTOCart(AddToCartActionRequest AddActionRequest)
        {
            var ProductDTo = new GetProductByIdDto
            {
                Id = AddActionRequest.Id,
                Name = AddActionRequest.Name,
                Image = AddActionRequest.Image,
                Description = AddActionRequest.Description,
                Amount = AddActionRequest.Amount,
                Price = AddActionRequest.Price

            };
            
            _cartManager.AddToCart(ProductDTo);
            return RedirectToAction("CreateOrder","Order");
        }

        ////////////// Remove from Cart///////////////////
        [HttpGet]
        public async Task<IActionResult>ConfirmRemoveFromList(int id)
        { 
            var productDto = await _productManager.GetProductById(id);
            return View("ConfirmRemoveFromList", productDto);

        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
             _cartManager.RemoveFromCart(id);
            var updatedCart = _cartManager.GetCartItems();
            return View("CreateOrder", updatedCart );

        }

        //////////////// View ORDER ///////////////////
        [HttpGet]
        public IActionResult CreateOrder()
        {
            var ListOfProducts =  _cartManager.GetCartItems();
            return View("CreateOrder", ListOfProducts);
        }



    }
}

using BussinessLayer.Contracts;
using BussinessLayer.DTOs;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PresentationLayer.ActionRequests;
using PresentationLayer.Mapping;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
		private readonly IFileServices _fileServices;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserServices _userServices;

        public ProductController(IProductManager ProductManager, 
                                    IFileServices fileServices, 
                                    UserManager<IdentityUser>userManager,
                                    IUserServices userServices) 
        {
            _productManager = ProductManager;
			_fileServices = fileServices;
            _userManager = userManager;
            _userServices = userServices;
        }

        ///////////////// GET ALL PRODUCTS (Shop) /////////////////
        [HttpGet]
        public async Task<IActionResult> Shop()
        {
            var ProductsDtos = await _productManager.GetAllAsync();
            var ProductsVms = ProductVmsExtensions.ToProductsVms(ProductsDtos);
            return View("Shop",ProductsVms);
        }

        ///////////////// GET ALL PRODUCTS (Admin) /////////////////
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> AdminGetAll()
        {
            var ProductsDtos = await _productManager.GetAllAsync();
            var ProductsVms = ProductVmsExtensions.ToProductsVms(ProductsDtos);
            return View("AdminGetAll", ProductsVms);
        }


        ///////////////// GET PRODUCT DETAILS BY ID //////////////
       
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
         var productByIdDto = await _productManager.GetProductById(id);
        if (productByIdDto == null)
            { return NotFound(); }
            var ProductByIdVm = ProductVmsExtensions.ToProductIdVm(productByIdDto);
    
            return View("Details", ProductByIdVm);
		}
        ////////////////// ADMIN FEATURE TO ADD A PRODUCT //////////////////////
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult AddProduct()
        { 
            return View(); 
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
		public async Task<IActionResult> AddProduct(AddProductActionRequest NewProductRequest)
		{
            var fileName = _fileServices.UploadFile(NewProductRequest.Image, "images");
            //// mapping ////
            var AddProductDto = new AddProductDto
            { 
                Name = NewProductRequest.Name,
                Price = NewProductRequest.Price,
                Description = NewProductRequest.Description,
                Image = fileName
			};
           await _productManager.AddProduct(AddProductDto);
            return RedirectToAction("Shop");   // After Adding redirect the admin to the control dashboard
		}

        ///////////////// ADMIN FEATURE TO UPDATE PRODUCT /////////////////
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var productDto = await _productManager.GetProductById(id);
            //// mapping ////
            var ProductToUpdate = new UpdateProductActionRequest
            { 
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                ImagePath = productDto.Image
            };
            return View("UpdateProduct", ProductToUpdate);
		}
        [Authorize(Roles ="Admin")]
        [HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductActionRequest UpdatedProduct)
		{
			var fileName = _fileServices.UploadFile(UpdatedProduct.Image, "Image");

            //// mapping ////

            var UpdatedProductedDto = new UpdateProductDto
            {
                Id = UpdatedProduct.Id,
                Name = UpdatedProduct.Name,
                Description = UpdatedProduct.Description,
                Price = UpdatedProduct.Price,
                Image = fileName
            };
            await _productManager.UpdateProduct(UpdatedProductedDto);
            return RedirectToAction(nameof(Details), new { id = UpdatedProduct.Id });
		    }

        ///////////////// DELETE PRODUCT ////////////////
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        { 
            var productDto = await _productManager.GetProductById(id);
            if (productDto == null) { return NotFound(); }
            return View("ConfirmDelete",productDto);

        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
		public async Task<IActionResult>Delete(int id)
		{
            await _productManager.Delete(id);
            return RedirectToAction("AdminGetAll");

		}

	}
}

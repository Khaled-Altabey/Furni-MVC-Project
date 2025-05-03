using BussinessLayer.Contracts;

namespace PresentationLayer.ActionRequests
{
	public class UpdateProductActionRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public IFormFile Image { get; set; }
		public string ImagePath { get; set; }
		public decimal Price { get; set; }
	}
}

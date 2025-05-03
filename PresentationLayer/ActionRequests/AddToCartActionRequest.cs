using DataAccessLayer.Entities;

namespace PresentationLayer.ActionRequests
{
    public class AddToCartActionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}

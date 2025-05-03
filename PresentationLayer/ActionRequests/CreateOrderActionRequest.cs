using Microsoft.AspNetCore.Identity;

namespace PresentationLayer.ActionRequests
{
    public class CreateOrderActionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public DateTime OrderDate { get; set; }

    }
}

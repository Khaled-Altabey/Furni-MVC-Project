using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ActionRequests
{
    public class LoginUserActionRequest
    {
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

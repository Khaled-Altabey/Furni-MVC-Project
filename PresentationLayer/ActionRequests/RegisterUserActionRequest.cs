using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ActionRequests
{
    public class RegisterUserActionRequest
    {
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }   
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}

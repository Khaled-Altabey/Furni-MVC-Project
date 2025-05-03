using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ActionRequests
{
	public class CreateRoleActionRequest
	{
		[Required]
		public string RoleName { get; set; }

	}
}

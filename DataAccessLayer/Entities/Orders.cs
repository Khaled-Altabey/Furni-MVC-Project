using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	public class Orders
	{
		public int Id { get; set; }	
		public string Name { get; set; }
		public DateTime OrderDate { get; set; }
		

		// Navigation Properties

		public ICollection<OrderProducts> OrderProducts = new List<OrderProducts>();
	}
}

	using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	public class Products
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image {  get; set; }
		public decimal Price { get; set; }


        // Navigation Properties

        public ICollection<OrderProducts> OrderProducts = new List<OrderProducts>();
    }
}

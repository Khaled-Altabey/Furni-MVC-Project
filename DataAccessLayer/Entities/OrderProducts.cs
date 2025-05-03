using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	public class OrderProducts
	{
		public int Amount { get; set; }

		[ForeignKey(nameof(Products))]
		public int ProductId { get; set; }
		public Products Products { get; set; }

        [ForeignKey(nameof(Orders))]
        public int OrderId { get; set; }
		public Orders Orders { get; set; }

	}
}

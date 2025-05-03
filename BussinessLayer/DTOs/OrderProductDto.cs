using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs
{
    public class OrderProductDto
    {
        public Products Products { get; set; }
        public int Amount { get; set; }
    }
}

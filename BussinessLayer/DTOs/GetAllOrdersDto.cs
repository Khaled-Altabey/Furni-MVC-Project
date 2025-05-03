using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs
{
    public class GetAllOrdersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

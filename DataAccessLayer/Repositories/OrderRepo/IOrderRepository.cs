using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.OrderRepo
{
    public interface IOrderRepository : IGenericRepository<Orders>
    {
        // Here to add any custome method for the Order entity in addition to those un the Generic repository
    }
}

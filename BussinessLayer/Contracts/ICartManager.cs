using BussinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Contracts
{
    public interface ICartManager
    {
        void ClearCart();
        void RemoveFromCart(int productId);
        void AddToCart(GetProductByIdDto OrderProduct);
    List<GetProductByIdDto> GetCartItems();
    }
}

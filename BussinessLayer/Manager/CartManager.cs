using BussinessLayer.Contracts;
using BussinessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Manager
{
    public class CartManager : ICartManager
    {
        public static List<GetProductByIdDto> Items = new List<GetProductByIdDto>();

        public void AddToCart(GetProductByIdDto OrderProduct)
        { 
            var ItemExistinList = Items.FirstOrDefault(P => P.Id == OrderProduct.Id);
            if (ItemExistinList != null)
            {
                ItemExistinList.Amount++;
            }
            else
            {
                Items.Add(OrderProduct);
                OrderProduct.Amount = 1;
            }
        }
        public List<GetProductByIdDto> GetCartItems()
        {
            return Items;
        }

        public void RemoveFromCart(int productId)
        {
            var item = Items.FirstOrDefault(p => p.Id == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public void ClearCart()
        {
            Items.Clear();
        }
    }
}

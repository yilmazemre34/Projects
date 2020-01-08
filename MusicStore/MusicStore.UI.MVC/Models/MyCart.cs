using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.UI.MVC.Models
{
    public class MyCart
    {
        private Dictionary<int, CartItemViewModel> _sepet = new Dictionary<int, CartItemViewModel>();

        public List<CartItemViewModel> GetAllCartItem
        {
            get
            {
                return _sepet.Values.ToList();
            }
        }

        public void AddCart(CartItemViewModel cartItem)
        {
            if (_sepet.ContainsKey(cartItem.ID))
            {
                _sepet[cartItem.ID].Amount += cartItem.Amount;
                return;
            }

            _sepet.Add(cartItem.ID, cartItem);
        }

        public void Update(int id, short amount)
        {
            if (_sepet.ContainsKey(id))
            {
                _sepet[id].Amount = amount;
            }
        }

        public void Delete(int id)
        {
            if (_sepet.ContainsKey(id))
            {
                _sepet.Remove(id);
            }
        }

        public int TotalAmount
        {
            get
            {
                return _sepet.Values.Sum(a => a.Amount);
            }
        }
    }
}
using MusicStore.BLL.Abstract;
using MusicStore.MODEL.Entities;
using MusicStore.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.UI.MVC.Controllers
{
    public class OrderController : Controller
    {
        IUserService _userService;
        IOrderService _orderService;

        public OrderController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        public ActionResult OrderCheck()
        {
            var sepet = Session["cart"] as MyCart;
            User currentUser = _userService.GetUserByName(User.Identity.Name);

            Order yeniSiparis = new Order();
            yeniSiparis.UserID = currentUser.ID;
            yeniSiparis.ShipAddress = currentUser.Address;
            yeniSiparis.OrderDate = DateTime.Now;

            OrderDetail yeniSiparisDetayi;
            foreach (CartItemViewModel item in sepet.GetAllCartItem)
            {
                yeniSiparisDetayi = new OrderDetail();
                yeniSiparisDetayi.Discount = 0;
                yeniSiparisDetayi.AlbumID = item.ID;
                yeniSiparisDetayi.Price = item.Price;
                yeniSiparisDetayi.Quantity = item.Amount;

                yeniSiparis.OrderDetails.Add(yeniSiparisDetayi);
            }
            _orderService.Insert(yeniSiparis);
            Session["cart"] = new MyCart();
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Web.Models;
using SEDC.Lamazon.WebModels.Enum;
using SEDC.Lamazon.WebModels.ViewModels;

namespace SEDC.Lamazon.Web.Controllers
{
    //TODO: Change all hardcoded userId in the controller
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService,
                               IUserService userService,
                               IProductService productService)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
        }

        public IActionResult ListOrders()
        {
            //string userId = "3";
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            List<OrderViewModel> userOrders = _orderService.GetAllOrders()
                                                            .Where(x => x.User.Id == user.Id)
                                                            .ToList();
            return View(userOrders);
        }

        public IActionResult ListAllOrders()
        {
            List<OrderViewModel> orders = _orderService.GetAllOrders().ToList();
            return View(orders);
        }

        public IActionResult OrderDetails(int orderId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            OrderViewModel order = _orderService.GetOrderById(orderId, user.Id);

            if(order.Id > 0)
            {
                return View("order", order);
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public IActionResult Order()
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            OrderViewModel order = _orderService.GetCurrentOrder(user.Id);
            return View(order);
        }

        public IActionResult ApproveOrder(int orderId)
        {
            OrderViewModel order = _orderService.GetOrderById(orderId);
            _orderService.ChangeStatus(order.Id, order.User.Id, StatusTypeViewModel.Confirmed);
            return RedirectToAction("listallorders");
        }

        public IActionResult DeclineOrder(int orderId)
        {
            OrderViewModel order = _orderService.GetOrderById(orderId);
            _orderService.ChangeStatus(order.Id, order.User.Id, StatusTypeViewModel.Declined);
            return RedirectToAction("listallorders");
        }

        public IActionResult ChangeStatus(int orderId, int statusId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            _orderService.ChangeStatus(orderId, user.Id, (StatusTypeViewModel)statusId);
            return RedirectToAction("ListOrders");
        }

        public int AddProduct(int productId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            OrderViewModel order = _orderService.GetCurrentOrder(user.Id);

            int result = _orderService.AddProduct(order.Id, productId, user.Id);

            if(result >= 0)
            {
                return result;
            }
            else
            {
                string message = "Something bad happened! Please contact support!";
                return result;
            }
        }
    }
}

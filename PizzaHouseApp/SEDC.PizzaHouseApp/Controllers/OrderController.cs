using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaHouseApp.Models;
using SEDC.PizzaHouseApp.Models.Domain;
using SEDC.PizzaHouseApp.Models.ViewModels;

namespace SEDC.PizzaHouseApp.Controllers
{
    public class OrderController : Controller
    {
       [Route("Orders")]
        public IActionResult Index()
        {
            ViewBag.Title = "Welcome to the Orders page!";
            Order firstOrder = StaticDb.Orders.FirstOrDefault();
            OrderListViewModel ordersViewModel = new OrderListViewModel()
            {
                FirstPizza = firstOrder.Pizza.Name,
                NumberOfOrders = StaticDb.Orders.Count,
                FirstCustomerName = $"{firstOrder.User.FirstName} {firstOrder.User.LastName}",
                Orders = StaticDb.Orders
            };
            return View(ordersViewModel);
        }

     
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                return View();
            }
            return new EmptyResult();
        }
  
        [HttpGet]
        public IActionResult Create(string error)
        {
            ViewBag.Error = error == null ? "" : error;
            OrderViewModel model = new OrderViewModel();
            return View(model);

        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            Pizza pizza = StaticDb.Menu.FirstOrDefault(x => x.Name == model.PizzaName && x.Size == model.Size);

            if (pizza == null)
                return RedirectToAction("Create", new { error = "There is no such pizza in the menu!" });


            StaticDb.UserId++;
            User user = new User()
            {
                Id = StaticDb.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Phone = model.Phone,
            };
            StaticDb.OrderId++;
            Order order = new Order()
            {
                Id = StaticDb.OrderId,
                Delivered = false,
                Pizza = pizza,
                Price = pizza.Price + 2,
                User = user
            };
            StaticDb.Users.Add(user);
            StaticDb.Orders.Add(order);
            return View("_ThankYou");
        }

    }
}

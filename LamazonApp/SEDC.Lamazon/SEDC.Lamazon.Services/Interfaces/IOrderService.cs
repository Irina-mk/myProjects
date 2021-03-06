using SEDC.Lamazon.Domain.Enum;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.WebModels.Enum;
using SEDC.Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id, string userId);
        OrderViewModel GetOrderById(int id);
        int CreateOrder(OrderViewModel order, string userId);
        int AddProduct(int orderId, int productId, string userId);
        OrderViewModel GetCurrentOrder(string userId);
        int ChangeStatus(int orderId, string userId, StatusTypeViewModel status);
    }
}

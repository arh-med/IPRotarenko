using IPRotarenko.DAL.Context;
using IPRotarenko.Domain.Entities.Orders;
using IPRotarenko.Infastructure.Interfaces;
using IPRotarenko.ViewModels;
using IPRotarenko.ViewModels.Orders;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Services.InDataBase
{
    public class MySqlOrderService : IOrderService
    {
        private readonly ApplicationContext applicationContext;
        public MySqlOrderService()
        {
            ApplicationContext applicationContext = new ApplicationContext();
            this.applicationContext = applicationContext;
        }

        public Order CreateOrder(CartViewModel Cart, OrderViewModel OrderModel)
        {
            var order = new Order
            {
               
                Name = OrderModel.Name,
                Adress = OrderModel.Adress,
                Email = OrderModel.Email,
                Phone = OrderModel.Phone,
                Date = DateTime.Now
            };
            applicationContext.Orders.Add(order);
            foreach (var (product_model, quantity) in Cart.Items)
            {
                var product = applicationContext.Products.FirstOrDefault(p => p.Id == product_model.Id);
                if (product is null)
                {
                    throw new InvalidOperationException($"Товар с Id:{product_model.Id} в базе данных не найден");
                }
                var order_item = new OrderItem
                {
                    
                    Order = order,
                    Price = product.Price,
                    Quantity = quantity,
                    Product = product
                };
                applicationContext.OrderItems.Add(order_item);
            }
            applicationContext.SaveChanges();
            return order;
        }

        public Order GetOrderById(int Id)
        {
            return applicationContext.Orders.Include(order => order.OrderItems).FirstOrDefault(order => order.Id == Id);
        }
    }
}

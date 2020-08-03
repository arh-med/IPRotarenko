using IPRotarenko.Domain.Entities.Orders;
using IPRotarenko.ViewModels;
using IPRotarenko.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Interfaces
{
    public interface IOrderService
    {
        Order GetOrderById(int Id);
        Order CreateOrder(CartViewModel Cart,OrderViewModel OrderModel);
    }
}

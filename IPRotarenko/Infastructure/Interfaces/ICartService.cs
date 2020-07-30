using IPRotarenko.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Interfaces
{
    public interface ICartService
    {
        void AddToCart(int id);


        void DecrementFromCart(int id, decimal count);

        void AddFromCart(int id, decimal count);

        void RemoveFromCart(int id);

        void RemoveAll();

        CartViewModel TransformFromCart();

    }
}

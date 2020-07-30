using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal ItemsCount => Items?.Sum(item => item.Quantity) ?? 0;
       
    }
}

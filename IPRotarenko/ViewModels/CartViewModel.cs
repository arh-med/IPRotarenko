using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.ViewModels
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, decimal> Items { get; set; } = new Dictionary<ProductViewModel, decimal>();
        public decimal ItemsCount => Items?.Sum(item => item.Value) ?? 0;
    }
}

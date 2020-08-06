using IPRotarenko.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IPRotarenko.Domain.Entities.Orders
{
    public class OrderItem : BaseEntity
    {
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}

using IPRotarenko.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IPRotarenko.Domain.Entities.Orders
{
    public class Order : NamedEntity  
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Adress { get; set; }
        public string  Email { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

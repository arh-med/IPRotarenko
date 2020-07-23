using IPRotarenko.Domain.Entities.Base;
using IPRotarenko.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPRotarenko.Domain.Entities
{
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int SectionId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}

using IPRotarenko.Domain.Entities.Base;
using IPRotarenko.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IPRotarenko.Domain.Entities
{
    public class Recipe : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual Section ParentSection { get; set; }


    }
}

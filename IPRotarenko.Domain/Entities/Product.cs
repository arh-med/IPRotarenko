using IPRotarenko.Domain.Entities.Base;
using IPRotarenko.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IPRotarenko.Domain.Entities
{
    //[Table("Product")] - можно указать имя создаваемой таблицы в базе данных
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int SectionId { get; set; }

        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; }

        public string ImageUrl { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        //public virtual ICollection<Section> Sections {get;set; }
    }
}

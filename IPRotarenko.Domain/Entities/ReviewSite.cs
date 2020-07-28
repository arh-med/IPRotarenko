using IPRotarenko.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IPRotarenko.Domain.Entities
{
    public class ReviewSite : NamedEntity
    {
        [Required]
        public string Deliveri { get; set; }
        public string Email { get; set; }
        [Required]
        public string Review { get; set; }
        public int Stars { get; set; }
    }
}

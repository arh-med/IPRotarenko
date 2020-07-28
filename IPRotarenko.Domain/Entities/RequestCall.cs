using IPRotarenko.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IPRotarenko.Domain.Entities
{
    public  class RequestCall : NamedEntity
    {
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Headline { get; set; }
        [Required]
        public string Message { get; set; }
    }
}

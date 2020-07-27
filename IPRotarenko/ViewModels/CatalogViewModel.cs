using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.ViewModels
{
    public class CatalogViewModel
    {
        public int? SectionId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}

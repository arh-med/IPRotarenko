using IPRotarenko.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.ViewModels
{
    public class SectionViewModel : INamedEntity ,IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public SectionViewModel ParentSection { get; set; }

        public List<SectionViewModel> ChildSections { get; set; } = new List<SectionViewModel>();
        
    }
}

using IPRotarenko.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.ViewModels
{
    public class RecipeViewModel : INamedEntity, IOrderedEntity
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string ImageUrl { get; set; }
        public RecipeViewModel ParentRecipe { get; set; }

        public List<RecipeViewModel> ChildRecipe { get; set; } = new List<RecipeViewModel>();
    }
}

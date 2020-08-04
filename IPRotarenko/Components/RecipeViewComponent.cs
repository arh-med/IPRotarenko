using IPRotarenko.Infastructure.Interfaces;
using IPRotarenko.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Components
{
    public class RecipeViewComponent : ViewComponent
    {
        private readonly IRecipeData _RecipeData;
        public RecipeViewComponent(IRecipeData RecipeData)
        {
            _RecipeData = RecipeData;
        }
        public IViewComponentResult Invoke()
        {
            return View(GetRecipe());
        }
        private IEnumerable<RecipeViewModel> GetRecipe()
        {
            var recipes = _RecipeData.GetRecipe().ToArray();
            var parent_recipes = recipes.Where(s => s.ParentId is null);
            var parent_recipes_views = parent_recipes.Select(s => new RecipeViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Order = s.Order,
                ImageUrl=s.ImageUrl
                
            }).ToList();
            foreach (var parent_recipe in parent_recipes_views)
            {
                var childs = recipes.Where(s => s.ParentId == parent_recipe.Id);
                foreach (var child_recipe in childs)
                {
                    parent_recipe.ChildRecipe.Add(new RecipeViewModel
                    {
                        Id = child_recipe.Id,
                        Name = child_recipe.Name,
                        Order = child_recipe.Order,
                        ParentRecipe = parent_recipe
                    });
                }

                parent_recipe.ChildRecipe.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            }
            parent_recipes_views.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            return parent_recipes_views;
        }
    }
}

using IPRotarenko.DAL.Context;
using IPRotarenko.Domain.Entities;
using IPRotarenko.Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Services.InDataBase
{
    public class MySqlRecipeData : IRecipeData
    {
        private readonly ApplicationContext applicationContext;
        public MySqlRecipeData()
        {
            ApplicationContext applicationContext = new ApplicationContext();
            this.applicationContext = applicationContext;
        }

        public IEnumerable<Recipe> GetRecipe()
        {
            return applicationContext.Recipes.AsEnumerable();
        }
    }
}

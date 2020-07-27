﻿using IPRotarenko.Domain.Entities;
using IPRotarenko.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Mapping
{
    public static class ProductMapping
    {
        public static ProductViewModel ToView(this Product p )
        {
            return new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            };
        }
    }
}

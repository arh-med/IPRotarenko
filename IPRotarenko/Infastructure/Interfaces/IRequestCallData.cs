﻿using IPRotarenko.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Interfaces
{
   public interface IRequestCallData
    {
        void Add(RequestCall RequestCall);
    }
}

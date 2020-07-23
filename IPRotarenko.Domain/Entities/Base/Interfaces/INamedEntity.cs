using System;
using System.Collections.Generic;
using System.Text;

namespace IPRotarenko.Domain.Entities.Base.Interfaces
{
    public interface INamedEntity : IBaseEntity
    {
        string Name { get; set; }
    }
}

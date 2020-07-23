using IPRotarenko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int Id);
        void Add(Employee Employee);
        void Edit(int Id, Employee Employee);
        bool Delete(int Id);
        void SaveChanges();
    }
}

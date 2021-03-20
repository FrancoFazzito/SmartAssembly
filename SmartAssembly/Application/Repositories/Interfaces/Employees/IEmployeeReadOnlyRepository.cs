using Domain.Employees;
using System.Collections.Generic;

namespace Application.Repositories.Employees.Interfaces
{
    public interface IEmployeeReadOnlyRepository
    {
        IEnumerable<Employee> All { get; }
        Employee MostInactiveEmployee { get; }
        Employee EmployeeWithoutOrder { get; }
        Employee GetByName(string email);
    }
}

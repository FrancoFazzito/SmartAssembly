﻿using Domain.Employees;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface IEmployeeReadOnlyRepository
    {
        IEnumerable<Employee> All { get; }

        Employee GetMostInactiveEmployee();

        Employee GetEmployeeWithoutOrder();

        Employee GetByName(string email);
    }
}
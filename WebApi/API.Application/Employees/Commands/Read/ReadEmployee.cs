using Application.Repositories.Interfaces;
using Domain.Employees;
using System.Collections.Generic;

namespace Application.Employees.Commands.Read
{
    public class ReadEmployee
    {
        private readonly IEmployeeReadOnlyRepository read;

        public ReadEmployee(IEmployeeReadOnlyRepository read)
        {
            this.read = read;
        }

        public IEnumerable<Employee> All => read.All;

    }
}

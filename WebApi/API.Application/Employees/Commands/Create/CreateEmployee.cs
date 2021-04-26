using Application.Common.Exceptions;
using Application.Repositories.Interfaces;
using Domain.Employees;

namespace Application.Employees.Commands.Create
{
    public class CreateEmployee
    {
        private readonly ICreate<Employee> create;
        private readonly IEmployeeReadOnlyRepository read;

        public CreateEmployee(ICreate<Employee> create, IEmployeeReadOnlyRepository read)
        {
            this.create = create;
            this.read = read;
        }

        public void Create(Employee employee)
        {
            if (read.GetByName(employee.Email) != null)
            {
                throw new EmployeeAlreadyExistsException();
            }
            create.Create(employee);
        }
    }
}
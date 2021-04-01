using Application.Repositories.Interfaces;
using Domain.Employees;

namespace Application.Employees.Commands.Create
{
    public class CreateEmployee
    {
        private readonly ICreate<Employee> create;

        public CreateEmployee(ICreate<Employee> create)
        {
            this.create = create;
        }

        public void Create(Employee employee)
        {
            create.Create(employee);
        }
    }
}
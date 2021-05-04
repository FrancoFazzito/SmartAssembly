using Application.Repositories.Interfaces;
using Domain.Employees;
using Infra.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System.Data;
using System.Linq;

namespace Infra.Repositories.Implementations.Employees
{
    public class EmployeeReadOnlyRepository : AbstractReadOnlyRepository<Employee>, IEmployeeReadOnlyRepository
    {
        private const string QUERY_MOST_INACTIVE = "select top(1) e.Email from Employee e inner join [Order] o on o.Email_Employee = e.Email inner join Computer c on c.ID_Order = o.ID group by e.Email order by COUNT(e.Email)";
        private const string QUERY_INACTIVE = "select top(1) Email from Employee e where e.Email not in (select o.Email_Employee from [order] o)";

        public EmployeeReadOnlyRepository(IConnection connection) : base(connection)
        {
        }

        protected override string QuerySelectAll => "SELECT * FROM Employee";

        public Employee GetMostInactiveEmployee()
        {
            return GetRecord(QUERY_MOST_INACTIVE);
        }

        public Employee GetEmployeeWithoutOrder()
        {
            return GetRecord(QUERY_INACTIVE);
        }

        protected override Employee NewRecord(IDataReader reader)
        {
            return new Employee(ConvertReader<string>.WithName(reader, "Email"));
        }

        public Employee GetByName(string email)
        {
            return GetAll().FirstOrDefault(c => c.Email == email);
        }
    }
}
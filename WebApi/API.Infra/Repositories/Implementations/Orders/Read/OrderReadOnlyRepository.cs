using Application.Repositories.Interfaces;
using Domain.Orders;
using Domain.Orders.States;
using Infra.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infra.Repositories.Implementations.Orders
{
    public class OrderReadOnlyRepository : AbstractReadOnlyRepository<Order>, IOrderReadOnlyRepository
    {
        public OrderReadOnlyRepository(IConnection connection, IComputerReadOnlyRepository computerRepository, IEmployeeReadOnlyRepository employeeRepository, IClientReadOnlyRepository clientRepository) : base(connection)
        {
            ComputerRepository = computerRepository;
            EmployeeRepository = employeeRepository;
            ClientRepository = clientRepository;
        }

        public IComputerReadOnlyRepository ComputerRepository { get; }
        public IEmployeeReadOnlyRepository EmployeeRepository { get; }
        public IClientReadOnlyRepository ClientRepository { get; }

        protected override string QuerySelectAll => "SELECT * FROM [Order]";

        public IEnumerable<Order> GetByEmployee(string email)
        {
            return GetRecords("SELECT * FROM [Order] where Email_Employee = @email", new Dictionary<string, object>() { { "@email", email } });
        }

        public IEnumerable<Order> GetByClient(string email)
        {
            return GetRecords("SELECT * FROM [Order] where Email_client = @email", new Dictionary<string, object>() { { "@email", email } });
        }

        protected override Order NewRecord(IDataReader reader)
        {
            var order = new Order
            {
                Id = ConvertReader<int>.WithName(reader, "id"),
                DateRequested = ConvertReader<DateTime>.WithName(reader, "DateRequested"),
                DateDelivered = ConvertReader<DateTime>.WithName(reader, "DateDelivered"),
                Employee = EmployeeRepository.GetByName(ConvertReader<string>.WithName(reader, "Email_Employee")),
                Client = ClientRepository.GetByEmail(ConvertReader<string>.WithName(reader, "Email_client")),
                Commentary = ConvertReader<string>.WithName(reader, "Commentary"),
                State = ConvertReader<OrderState>.WithName(reader, "OrderState")
            };
            foreach (var computer in ComputerRepository.GetByOrder(ConvertReader<int>.WithName(reader, "id")).ToList())
            {
                order.Add(computer);
            }
            return order;
        }
    }
}
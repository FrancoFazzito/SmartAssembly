using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Orders.Interfaces;
using Domain.Orders;
using Domain.Orders.States;
using Infra.Interfaces.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System;
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

        protected override Order NewRecord(IDataReader reader)
        {
            return new Order
            {
                Id = ConvertReader<int>.WithName(reader, "id"),
                DateRequested = ConvertReader<DateTime>.WithName(reader, "DateRequested"),
                Computers = ComputerRepository.GetByOrderId(ConvertReader<int>.WithName(reader, "id")).ToList(),
                DateDelivered = ConvertReader<DateTime>.WithName(reader,"DateDelivered"),
                Employee = EmployeeRepository.GetByName(ConvertReader<string>.WithName(reader, "Email_Employee")),
                Client = ClientRepository.GetByEmail(ConvertReader<string>.WithName(reader, "Email_client")),
                Commentary = ConvertReader<string>.WithName(reader, "Commentary"),
                State = ConvertReader<OrderState>.WithName(reader, "OrderState")
            };
        }
    }
}
